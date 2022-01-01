using bScoredDatabase;
using bScoredDatabase.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Globalization;
using System.Threading.Tasks;
using Dapper;
using System.Diagnostics;
using System.Data;
using bScored;

namespace TidyHQMemberImporter
{
	public class TidyHQImporter
	{
		ImportLog log = new ImportLog();


		public async Task<ImportLog> ImportAsync(TidyMember[] members)
		{
			using (var db = DatabaseConnection.GetConnection())
			{
				using (var transaction = db.BeginTransaction())
				{
					var club = db.GetDefaultClub(transaction);

					if (club == null)
					{
						log.Fail("No default club has been setup in BScored!, cannot continue!");
						return log;
					}

					//Process all inactive / cancelled memberships
					await ProcessMembers(db, transaction, club, members, m => !IsMemberShipActive(m));

					//Process active memberships, which can override cancelled memberships (some people have multiple memberships)
					await ProcessMembers(db, transaction, club, members, m => IsMemberShipActive(m));

					//Update Transponders, assume 1. 20inch 2. Cruiser

					transaction.Commit();
					return log;
				}
			}
		}

		private async Task ProcessMembers(DbConnection db, DbTransaction transaction, Clubs club, IEnumerable<TidyMember> members, Func<TidyMember, bool> filter)
		{

			int line = 0;

			//Insert Only Default Club members as in TidyHQ you only have access to the members in your club.
			foreach (var m in members)
			{
				log.Line = line++;
				log.Current = m;

				//must pass filter before processing.
				if (!filter(m)) continue;

				if (!m.Groups.Contains(club.Club))
				{
					//Don't log as its just noise, no one reads
					//  log.Fail($"Member does not belong to our club ({club.Club})");
					continue;
				}

				DateTime? dob = ParseDate(m.DateOfBirth);

				if (!dob.HasValue)
				{
					log.Fail($"Member: {m.IDNumber}  dob count not be parsed: \"{m.DateOfBirth}\"");
					continue;
				}

				if (dob.Value < new DateTime(1900, 1, 1) || dob.Value > DateTime.Now)
				{
					log.Fail($"Member: {m.IDNumber}  dob now valid: \"{m.DateOfBirth}\"");
					continue;
				}

				var member = new Member
				{

					Class_No = -1, //not updating this
					Plate = null, //not updating this..
					Transponder = m.TransponderID1, // add this on insert

					Membership_No = m.IDNumber,
					BirthDate = dob.Value,
					Club = club.Club,
					Club_Code = club.Club_Code,
					First_Name = m.FirstName,  // May not have Proper Case
					Last_Name = m.LastName,    // May not have Proper Case
					Gender = m.Gender,
					Emergency_Contact_Person = m.EmergencyContact,
					Emergency_Contact_Number = m.EmergencyContactNumber,
					Member_Type = m.MembershipLevel,

					Financial_date = IsMemberShipActive(m) ? ParseDate(m.MembershipEndDate) ?? DateTime.Now.AddYears(1)
															: DateTime.Now.AddYears(-1),

					Disciplinary_Suspension = IsSuspended(m) ? "Yes" : "No",
					Medical_Suspension = "No", //hopefully  this is covered by suspension fields!
					Other_Suspension = "No", //hopefully  this is covered by suspension fields!
					POA_Suspension = "No",
					Status = m.MembershipStatus == "Active" ? "Active" : "Inactive",
					Race_Status = GetRaceStatus(m),

					Transponder_ID1 = FormatTransponder(m.TransponderID1),
					Transponder_ID2 = FormatTransponder(m.TransponderID2),
					Transponder_ID3 = FormatTransponder(m.TransponderID3),

				};

				try
				{
					var (inserted, updated, merged) = await UpsertMember(db, transaction, member);

					if (inserted) log.Inserted();
					if (updated) log.Updated();
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex.ToString());
					Debugger.Break();
					throw;
				}

			}
		}

		private async Task<(bool inserted, bool updated, bool merged)> UpsertMember(DbConnection db, DbTransaction transaction, Member member)
		{

			//Try updating using auscycling membershipNo
			var rowsAffected = await UpdateMemberFromTidyHQData(db, transaction, member, member.Membership_No);

			if (rowsAffected == 1) return (inserted: false, updated: true, merged: false);

			//Try finding a existing member by name & dob.
			var matches = db.FindMemberByFirstNameLastNameDob(member.First_Name, member.Last_Name, member.BirthDate, transaction);

			// Do not Merge to exisiting Member if TidyHQ Member is Non Riding or LifeStyle Membership
			if (matches.Count == 1 && member.Race_Status == true)
			{

				rowsAffected = await UpdateMemberFromTidyHQData(db, transaction, member, matches[0].Membership_No);

				if (rowsAffected == 1)
				{
					//Change membership no
					log.Info($"Membership number updated ({matches[0].Membership_No} => {member.Membership_No} )");
					db.ChangeMembershipNumber(matches[0].Membership_No, member.Membership_No, transaction);
					return (inserted: false, updated: true, merged: true);
				}
			}

			//Otherwise we Add a New Member
			var sql = @"
    INSERT INTO OSM_Membership (
                    Membership_No ,
                    BirthDate ,
                    Club ,
                    Club_Code ,
                    First_Name,
                    Last_Name,
                    Gender ,
                    Emergency_Contact_Person ,
                    Emergency_Contact_Number,
                    Member_Type,
                    Financial_date ,
                    Disciplinary_Suspension ,
                    Medical_Suspension ,
                    Other_Suspension ,
                    POA_Suspension ,
                    Status,
                    Transponder, 
                    Race_Status,
                    Transponder_ID1, 
                    Transponder_ID2,
                    Transponder_ID3
) 
        VALUES (
                    @Membership_No ,
                    @BirthDate ,
                    @Club ,
                    @Club_Code ,
                    @First_Name,
                    @Last_Name,
                    @Gender ,
                    @Emergency_Contact_Person ,
                    @Emergency_Contact_Number,
                    @Member_Type,
                    @Financial_date ,
                    @Disciplinary_Suspension ,
                    @Medical_Suspension ,
                    @Other_Suspension ,
                    @POA_Suspension ,
                    @Status,
                    @Transponder,
                    @Race_Status,
                    @Transponder_ID1,
                    @Transponder_ID2,
                    @Transponder_ID3
)
";

			var result = await db.ExecuteScalarAsync<string>(sql, member, transaction);
			return (inserted: true, updated: false, merged: false);

		}

		private Task<int> UpdateMemberFromTidyHQData(DbConnection db, DbTransaction transaction, Member member, string membershipNo)
		{
			var sql = @"
UPDATE OSM_Membership
        SET 
                    BirthDate  = @BirthDate,
                    First_Name = @First_Name,
                    Last_Name = @Last_Name,
                    Gender  = @Gender ,
                    Club = @Club ,
                    Club_Code = @Club_Code ,
                    Emergency_Contact_Person  = @Emergency_Contact_Person ,
                    Emergency_Contact_Number = @Emergency_Contact_Number,
                    Member_Type = @Member_Type,
                    Financial_date  = @Financial_date ,
                    Disciplinary_Suspension  = @Disciplinary_Suspension ,
                    Medical_Suspension  = @Medical_Suspension ,
                    Other_Suspension  = @Other_Suspension ,
                    POA_Suspension  = @POA_Suspension ,
                    Status = @Status ,
                    Race_Status = @Race_Status ,
                    Transponder_ID1 = @Transponder_ID1 ,
                    Transponder_ID2 = @Transponder_ID2 ,
                    Transponder_ID3 = @Transponder_ID3 
WHERE 
   Membership_No = @membershipNo";


			var p = new DynamicParameters(member);
			p.Add("membershipNo", membershipNo);

			return db.ExecuteAsync(sql, p, transaction);
		}




		private static bool IsMemberShipActive(TidyMember m)
		{
			return IsActiveDateRange(m.MembershipStartDate, m.MembershipEndDate) &&
					m.MembershipStatus == "Active";
		}
		private static bool IsSuspended(TidyMember m)
		{
			return IsActiveDateRange(m.SuspensionStartDate, m.SuspensionEndDate);
		}

		private static bool IsActiveDateRange(string startDate, string endDate)
		{
			DateTime? start = ParseDate(startDate);
			DateTime? end = ParseDate(endDate);
			return start.HasValue && start < DateTime.Now && (
					!end.HasValue ||
					end > DateTime.Now);
		}

		private static DateTime? ParseDate(string value)
		{
			//Some dates seem to come through as "0012" assuming this is 2012..
			//Now formatted as d/MM/yyy
			value = value.StartsWith("00") ? "2" + value.Substring(1) : value;
			if (!DateTime.TryParseExact(value, new string[] { "d/MM/yyyy", "dd MMM yyyy", "dd-MMM-yyyy", "yyyy-MM-dd", "00yy-MM-dd" },
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
			{
				return null;
			}
			return date;
		}

		/* NOT USED */
		private static string GetTransponderString(TidyMember m)
		{
			var transponders = new List<string>();
			if (!String.IsNullOrWhiteSpace(m.TransponderID1))
			{
				transponders.Add($"20Inch:{m.TransponderID1}");
			}
			if (!String.IsNullOrWhiteSpace(m.TransponderID2))
			{
				transponders.Add($"Cruiser:{m.TransponderID2}");
			}
			if (!String.IsNullOrWhiteSpace(m.TransponderID3))
			{
				transponders.Add($"Other:{m.TransponderID3}");
			}
			return String.Join(";", transponders);
		}

		private static bool GetRaceStatus(TidyMember m)
		{
			if (m.MembershipLevel.Contains("All Discipline"))
			{
				return true;
			}
			else if (m.MembershipLevel.Contains("Kids"))
			{
				return true;
			}
			else if (m.MembershipLevel.Contains("Race"))
			{
				return true;
			}
			else if (m.MembershipLevel.Contains("One Day"))
			{
				return true;
			}
			else if (m.MembershipLevel.Contains("7 Day"))
			{
				return true;
			}

			return false;
		}

		/* Format should be XX-99999 */
		private string FormatTransponder(string raw)
		{
			if (raw == null) return null; //Probably never be null when coming from a CSV..
			raw = raw.Replace(" ", "");
			raw = raw.ToUpper();
			if (raw.Length <= 2 || raw.IndexOf("-") >= 0) return raw;
			return raw.Insert(2, "-");
		}
	}


	public class ImportLog
	{
		private List<(TidyMember, string)> messages = new List<(TidyMember, string)>();

		public void Fail(string msg)
		{
			if (messages.Count < 100)
				messages.Add((Current, $"Line: {Line}: {msg}"));
			Failed++;
		}

		public void Info(string msg)
		{
			if (messages.Count < 100)
				messages.Add((Current, $"Line: {Line}: {msg}"));
			Failed++;
		}

		public void Updated()
		{
			Updates++;
		}

		public void Inserted()
		{
			Inserts++;
		}

		public int Line { get; set; }

		public TidyMember Current { get; set; }


		public int SuccessCount { get { return Inserts + Updates; } }
		public int Failed { get; private set; }
		public int Inserts { get; private set; }
		public int Updates { get; private set; }

		public List<(TidyMember, string)> GetMessages() => messages;
	}


}
