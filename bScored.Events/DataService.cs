using bScored;
using bScoredDatabase;
using bScoredDatabase.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace WindowsFormsApp7
{
	public static class DataService
	{
		static readonly DateTime IdGeneratedFrom = new DateTime(2022, 1, 1);

		/// <summary>
		///  Temporary (database could be refactactored in include a GUID or auto-id column) 
		///  method to generate a short unique Id
		///  WARNING: Do not use this method in a loop!
		/// </summary>
		/// <param name="prefix">A prefix to add to the start of the generated id</param>
		/// <returns></returns>
		public static string GenerateId(char prefix) => $"{prefix}{(DateTime.Now.Ticks - IdGeneratedFrom.Ticks).ToString("x")}";

		public static DbProviderFactory GetFactory()
		{
			var settings = ConfigurationManager.ConnectionStrings["bscored"];
			return DbProviderFactories.GetFactory(settings.ProviderName);
		}

		public static DbConnection OpenConnection() => DatabaseConnection.GetConnection();

		public static List<Clubs> GetClubList() => OpenConnection().GetClubList();

		public static Clubs UpdateClub(Clubs club)
		{
			if (String.IsNullOrWhiteSpace(club.Club_Code))
			{
				club.Club_Code = GenerateId('c');
			}

			if (String.IsNullOrWhiteSpace(club.State))
			{
				club.State = String.Empty;
			}

			using (var db = OpenConnection())
			{
				int affected = db.Execute(@"UPDATE OSM_Clubs SET 
Club = @Club, 
[Group] = @Group, 
State = @State, 
Country = @Country 
WHERE Club_Code = @Club_Code", club);

				if (affected == 1) return club;

				db.Execute("INSERT INTO OSM_Clubs (Club_Code, Club, [Group], State, Country) " +
					"VALUES (@Club_Code, @Club, @Group, @State, @Country) ", club);

				return club;
			}
		}

		public static Clubs GetClubFromClub(string club) => OpenConnection().GetClubFromClub(club);

		public static List<Member> FindMemberByBMXANo(string membership_no) => OpenConnection().FindMemberByBMXANo(membership_no);

		public static List<Event> GetEventList()
		{
			using (var db = OpenConnection())
			{
				return db.Query<Event>($"SELECT * FROM Events ORDER BY Date").ToList();
			}
		}

		public static Event GetEvent(int id)
		{
			using (var db = OpenConnection())
			{
				return db.Query<Event>($"SELECT * FROM Events WHERE EventID = @EventID", new { EventID = id }).FirstOrDefault();
			}
		}

		public static Settings LoadSettings() => OpenConnection().GetSettings();

		public static void SaveSettings(Settings settings) => OpenConnection().SaveSettings(settings);


		public static int UpdateEvent(Event Event, int mode = 0)
		{
			using (var db = OpenConnection())
			{
				if (mode == 0)
				{
					return db.Execute("UPDATE Events SET Entry_No = @Entry_No, Race_No = @Race_No, Race_Completed = @Race_Completed, Event_Status = @Event_Status WHERE EventID = @EventID", Event);
				}
				else
				{
					return db.Execute("UPDATE Events SET Name = @Name, Date = @Date, Moto_No = @Moto_No, Result_File = @Result_File WHERE EventID = @EventID", Event);
				}
			}
		}

		public static int CreateEvent(Event Event)
		{
			using (var db = OpenConnection())
			{

				Event.EventID = db.QuerySingle<int>(@"
INSERT INTO Events(Name, Date, Moto_No, Result_File) 
 OUTPUT INSERTED.[EventID]
VALUES (@Name, @Date, @Moto_No, @Result_File)", new
				{
					Name = Event.Name,
					Date = Event.Date,
					Moto_No = Event.Moto_No,
					Result_File = Event.Result_File
				});
			}
			return Event.EventID;
		}

		public static int[] DeleteEvent(int eventID)
		{
			int[] result = new int[6];

			using (var db = OpenConnection())
			{

				result[1] = db.Execute("DELETE FROM BMX_Classes WHERE EventID = @EventID", new { EventId = eventID });
				result[2] = db.Execute("DELETE FROM Riders WHERE EventID = @EventID", new { EventId = eventID });
				result[3] = db.Execute("DELETE FROM Races WHERE EventID = @EventID", new { EventId = eventID });
				result[4] = db.Execute("DELETE FROM Results WHERE EventID = @EventID", new { EventId = eventID });
				result[5] = db.Execute("DELETE FROM Mylaps_Pasing WHERE EventID = @EventID", new { EventId = eventID });

				result[0] = db.Execute("DELETE FROM Events WHERE EventID = @EventID", new { EventId = eventID });

				return result;
			}

		}



		/* Search for Member based on surname, firstname or membership_no */
		public static List<MemberFind> FindMemberByName(string[] Names)
		{
			using (var db = OpenConnection())
			{
				if (Names.Count() == 2)
				{
					return db.Query<MemberFind>($"select * from Member_Search where Last_Name LIKE '%{ Names[1] }%' AND First_Name LIKE '%{ Names[0] }%' ORDER BY Last_Name, First_Name").ToList();
				}
				else
				{
					return db.Query<MemberFind>($"select * from Member_Search where Last_Name LIKE '%{ Names[0] }%' OR First_Name LIKE '%{ Names[0] }%' ORDER BY Last_Name, First_Name").ToList();
				}
			}
		}

		public static List<MemberFind> FindMemberByTransponder(string trasnponder)
		{
			using (var db = OpenConnection())
			{
				return db.Query<MemberFind>($"select * from Member_Search where Transponder = @code OR Transponder_ID1 = @code OR Transponder_ID2 = @code OR Transponder_ID3 = @code", new { code = trasnponder }).ToList();
			}
		}

		public static List<Member> FindMemberByNumber(string membership_no) => OpenConnection().FindMemberByNumber(membership_no);

		public static int AddMember(Member member) => OpenConnection().Insert(member);


		/* Get All Riders for Event*/
		public static List<Rider> GetRiders(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				//return db.Query<Rider>("SELECT * FROM Riders_List WHERE EventId = @Id ORDER BY Class_No desc, Last_Name", new { Id = EventId}).ToList();
				return db.Query<Rider>("SELECT * FROM Riders_List WHERE EventId = @Id ORDER BY RaceOrder desc, Last_Name", new { Id = EventId }).ToList();
			}
		}


		public static List<Rider> GetRidersWithTransponders(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				return db.Query<Rider>("SELECT * FROM Riders_List WHERE EventId = @Id AND TRIM(Transponder) <> '' ORDER BY Class_No desc, Last_Name", new { Id = EventId }).ToList();
			}
		}

		/* Get Riders for Race Class*/
		public static List<Rider> GetRidersByRaceClass(int EventId, int raceClass)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				return db.Query<Rider>("SELECT * FROM Riders_List WHERE EventId = @Id AND Race_Class = @Race_Class", new { Id = EventId, Race_Class = raceClass }).ToList();
			}
		}



		/* select * from Riders_History where Membership_No = 543049 */
		public static List<RiderHistory> GetRiderHistory(string membership_No)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				return db.Query<RiderHistory>("SELECT * FROM Riders_History WHERE Membership_No = @Membership_No", new { Membership_No = membership_No }).ToList();
			}
		}



		public static List<RiderClass> GetRiderClasses(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				//return db.Query<RiderClass>($"SELECT * FROM Rider_Classes WHERE EventId = @Id ORDER BY Class_No DESC", new {Id = EventId}).ToList();
				return db.Query<RiderClass>($"SELECT * FROM Rider_Classes WHERE EventId = @Id ORDER BY RaceOrder DESC", new { Id = EventId }).ToList();
			}
		}

		public static List<RiderClass> GetClassesRaceOrder(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Query<RiderClass>($"SELECT * FROM BMX_Classes WHERE EventId = @Id AND Class_No = Race_Class ORDER BY RaceOrder ASC", new { Id = EventId }).ToList();
			}
		}

		public static int CreateClasses(List<RiderClass> riderClass)
		{
			using (var db = OpenConnection())
			{

				/* This Loops through riderClass inserting each class in the list */
				return db.Execute("INSERT INTO BMX_Classes (EventId, Class_No, Name, RaceOrder, MinEntry, Type, Race_Class) VALUES (@EventId, @Class_No, @Name, @RaceOrder, @MinEntry, @Type, @Race_Class)", riderClass);
			}
		}

		public static int UpdateClassCountAll(int eventId)
		{
			/* UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) 
             From    BMX_Classes S 
             Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=1)
            */

			string sSQL;
			using (var db = OpenConnection())
			{
				sSQL = "UPDATE BMX_Classes SET entry_no = " +
					"(SELECT COUNT(RiderID) FROM Riders WHERE Riders.Class_No = BMX_Classes.Class_No AND Riders.EventID = @EventId) " +
					"WHERE bmx_classes.eventid = @EventId";

				db.Execute(sSQL, new { EventId = eventId });

				sSQL = "UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) " +
					  "From    BMX_Classes S " +
					  "Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=@EventId)";

				return db.Execute(sSQL, new { EventId = eventId });
			}
		}


		public static int UpdateClassCount(int eventId, int class_No)
		{
			/* UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) 
             From    BMX_Classes S 
             Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=1)
            */

			string sSQL;
			using (var db = OpenConnection())
			{
				sSQL = "UPDATE BMX_Classes SET entry_no = " +
					"(SELECT COUNT(RiderID) FROM Riders WHERE Riders.Class_No = @Class_No AND Riders.EventID = @EventId) " +
					"WHERE bmx_classes.eventid = @EventId AND bmx_classes.class_no = @Class_No";

				return db.Execute(sSQL, new { EventId = eventId, Class_No = class_No });
			}
		}

		public static int RemoveClassMerge(int eventId, int class_No)
		{
			/* UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) 
             From    BMX_Classes S 
             Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=1)
            */

			string sSQL;
			using (var db = OpenConnection())
			{

				sSQL = "UPDATE BMX_Classes SET Race_Class = Class_No WHERE bmx_classes.eventid = @EventId AND bmx_classes.class_no = @Class_No";
				db.Execute(sSQL, new { EventId = eventId, Class_No = class_No });

				sSQL = "UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) " +
					   "From    BMX_Classes S " +
					   "Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=@EventId)";

				return db.Execute(sSQL, new { EventId = eventId });
			}
		}

		public static int CreateClassMerge(int eventId, int class_No, int race_class)
		{
			/* UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) 
             From    BMX_Classes S 
             Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=1)
            */

			string sSQL;
			using (var db = OpenConnection())
			{

				sSQL = "UPDATE BMX_Classes SET Race_Class = @Race_Class WHERE bmx_classes.eventid = @EventId AND bmx_classes.class_no = @Class_No";
				db.Execute(sSQL, new { EventId = eventId, Race_Class = race_class, Class_No = class_No });

				sSQL = "UPDATE  BMX_Classes SET Race_No = (Select Sum(Entry_No) " +
					   "From    BMX_Classes S " +
					   "Where S.Race_Class=BMX_Classes.Race_Class AND S.EventId=@EventId)";

				return db.Execute(sSQL, new { EventId = eventId });
			}
		}

		public static int ClassRaceOrdersSave(List<RiderClass> riderClass)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through riderClass inserting each class in the list */
				return db.Execute("UPDATE BMX_Classes SET RaceOrder =  @RaceOrder WHERE ClassID = @ClassID", riderClass);
			}
		}

		public static int CreateRaceList(List<Race> raceList)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through raceList inserting each race in the list */
				return db.Execute("INSERT INTO Races (EventId, Race_No, Moto_No, Class_No, Gate_No) VALUES (@EventId, @Race_No, @Moto_No, @Class_No, @Gate_No)", raceList);
			}
		}

		public static int DeleteRaceList(int eventID)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("Delete from Races WHERE EventId = @EventID", new { EventID = eventID }, commandType: CommandType.Text);
			}
		}

		public static List<Race> GetRaceList(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				return db.Query<Race>($"SELECT * FROM Race_List2 WHERE EventId = @Id ORDER BY Race_No ASC", new { Id = EventId }).ToList();
			}
		}

		public static List<Race> GetRaceListByRaceClass(int EventId, int raceClass)
		{
			using (var db = OpenConnection())
			{
				/* Note use of SQL View */
				return db.Query<Race>($"SELECT * FROM Race_List WHERE EventId = @Id AND Class_no = @Race_Class AND Gate_No=1 ORDER BY Race_No ASC", new { Id = EventId, Race_Class = raceClass }).ToList();
			}
		}

		public static int UpdateMemberPreference(Rider rider)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE OSM_MEMBERSHIP SET Class_No = @Class_No, Plate = @Plate, Transponder = @Transponder WHERE Membership_No = @Membership_No", rider);
			}
		}

		public static int AddRider(Rider Rider)
		{
			using (var db = OpenConnection())
			{
				return db.QuerySingle<int>(@"
INSERT INTO Riders(EventID, Membership_No, Class_No, Plate, Transponder)
   OUTPUT INSERTED.RiderID
VALUES(@EventID, @Membership_No, @Class_No, @Plate, @Transponder)
", new
				{
					EventID = Rider.EventID,
					Membership_No = Rider.Membership_No,
					Class_No = Rider.Class_No,
					Plate = Rider.Plate,
					Transponder = Rider.Transponder
				});
			}
		}

		public static int FindRiderByClass(Rider riderInfo)
		{
			using (var db = OpenConnection())
			{
				return db.Query<Rider>($"select * from Riders where EventId = @EventId AND Membership_No = @Membership_No AND Class_No = @Class_No", riderInfo).ToList().Count;
			}
		}

		public static int UpdateRider(Rider Rider)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE Riders SET Plate = @Plate, Class_No = @Class_No, Transponder = @Transponder WHERE RiderID = @RiderID", Rider);
			}
		}


		public static int DeleteRider(int RiderID)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("Delete from Riders WHERE RiderID = @RiderID", new { RiderID = RiderID }, commandType: CommandType.Text);
			}
		}

		public static int DeleteRiderFromDraw(Rider rider)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("Delete from Results WHERE EventID = @EventId AND Membership_No = @Membership_No", rider);
			}
		}


		public static int CreatedDraw(List<Draw> drawList)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through drawList inserting each race in the list */
				return db.Execute("INSERT INTO Results (EventId, Race_No, Membership_No, RiderID, Lane_No) VALUES (@EventId, @Race_No, @Membership_No, @RiderID, @Lane_No)", drawList);
			}
		}

		public static int DeleteDraw(int eventID)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through drawList inserting each race in the list */
				return db.Execute("Delete from Results WHERE EventId = @EventID", new { EventID = eventID }, commandType: CommandType.Text);
			}
		}

		public static List<Draw> GetRaceDraw(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through drawList inserting each race in the list */
				return db.Query<Draw>($"SELECT * FROM Race_Draw WHERE EventId = @Id ORDER BY Race_No ASC, Last_Name", new { Id = EventId }).ToList();
			}
		}

		public static List<Draw> GetRaceDrawByRace(int EventId, int race_no)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through drawList inserting each race in the list */
				return db.Query<Draw>($"SELECT * FROM Race_Draw WHERE EventId = @Id AND Race_No = @Race_No ORDER BY Lane_No ASC", new { Id = EventId, Race_No = race_no }).ToList();
			}
		}

		public static List<Draw> GetRaceDrawByMotoClass(Race r)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through drawList inserting each race in the list */
				return db.Query<Draw>($"SELECT * FROM Race_Draw WHERE EventId = @EventId AND Moto_No = @Moto_No AND Class_No = @Class_No ORDER BY Race_No ASC, Lane_No ASC", r).ToList();
			}
		}

		public static int ClearRaceDraw(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE Results SET Lane_No = 0  WHERE   EventId = @Id", new { Id = EventId });
			}
		}

		public static int UpdateRaceDraw(List<Draw> drawList)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through drawList updateing each race draw in the list */
				/* Can Change Race_No when editing by Moto and Class */
				return db.Execute("UPDATE Results SET Race_No = @Race_No, Lane_No = @Lane_No WHERE ResultId = @ResultId", drawList);
			}
		}

		public static List<RaceResult> GetRaceResults(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Query<RaceResult>($"SELECT * FROM Race_Results WHERE EventId = @Id ORDER BY Race_No ASC", new { Id = EventId }).ToList();
			}
		}

		/*       select* from results a where eventid = 2028 and race_no = (select max(race_no) from results where a.Membership_No = Membership_No and place<> '' and eventid = 2028)
       */
		public static List<LastResults> GetLastResults(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Query<LastResults>($"SELECT * from Results a WHERE EventId = @Id and Race_No = (SELECT MAX(Race_No) FROM Results WHERE a.Membership_No = Membership_No and Place<> '' and EventId = @Id)", new { Id = EventId }).ToList();
			}
		}

		public static int UpdateLastResults(List<LastResults> lastResults)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE Riders SET FinishTime = @FinishTime WHERE EventId = @EventId AND Membership_No = @Membership_No", lastResults);
			}
		}

		public static int UpdateRaceResults(List<RaceResult> raceResult)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through raceResult updating each race draw in the list */
				return db.Execute("UPDATE Results SET PLace = @Place, Points = @Points, Hilltime = @Hilltime, Finishtime = @FinishTime WHERE ResultId = @ResultId", raceResult);
			}
		}


		public static List<RaceTiming> GetRaceTiming(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Query<RaceTiming>($"SELECT * FROM Race_Timing WHERE EventId = @Id ORDER BY Timestamp ASC", new { Id = EventId }).ToList();
			}
		}

		public static List<RaceTiming> GetRaceTimingNextGateByMember(int EventId, string Membership_No)
		{
			using (var db = OpenConnection())
			{
				/* c.RaceId == 0 && c.Type == 1 && c.Ignore == 0 */
				return db.Query<RaceTiming>($"SELECT * FROM Race_Timing WHERE EventId = @Id AND type=1 AND Membership_No = @membership_no AND (isnull(raceid,0)=0 OR raceid=0) AND (ISNULL(Ignore,0)=0 OR Ignore=0) ORDER BY Timestamp ASC", new { Id = EventId, membership_no = Membership_No }).ToList();
			}
		}

		public static List<RaceTiming> GetRaceTimingNextGate(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* c.RaceId == 0 && c.Type == 1 && c.Ignore == 0 */
				return db.Query<RaceTiming>($"SELECT * FROM Race_Timing WHERE EventId = @Id AND type=1 AND (isnull(raceid,0)=0 OR raceid=0) AND (ISNULL(Ignore,0)=0 OR Ignore=0) ORDER BY Timestamp ASC", new { Id = EventId }).ToList();
			}
		}

		/* Need to Exclude any Ignored Entries */
		public static List<RaceTiming> GetRaceTimingByGate(DateTime gateDrop)
		{
			using (var db = OpenConnection())
			{
				return db.Query<RaceTiming>($"SELECT * FROM Race_Timing WHERE GateTime = '" + gateDrop.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND (ISNULL(Ignore,0)=0 OR Ignore=0)").ToList();
			}
		}

		public static int UpdateRaceTimingRaceID(DateTime gateDrop, int RaceId)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through raceResult updating each race draw in the list */
				return db.Execute("UPDATE Mylaps_Pasing SET RaceId = @raceId WHERE GateTime ='" + gateDrop.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'", new { raceId = RaceId });
			}
		}

		public static int UpdateRaceTimingIgnore(List<RaceTiming> timingList, int Ignore = 1)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through timingList updating the Ignore Value for each ID in the list */
				if (Ignore == 1)
				{
					return db.Execute("UPDATE Mylaps_Pasing SET Ignore = 1 WHERE ID = @ID", timingList);
				}
				else
				{
					return db.Execute("UPDATE Mylaps_Pasing SET Ignore = 0 WHERE ID = @ID", timingList);
				}
			}
		}

		public static int DeleteRaceTimingSelected(List<RaceTiming> timingList)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through timingList deleting each ID in the list */
				return db.Execute("DELETE from Mylaps_Pasing WHERE ID = @ID", timingList);
			}
		}

		public static int UpdateRaceStatus(Race r)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE Races SET Starttime = '" + r.Starttime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', Race_Status = @Race_Status WHERE RaceId = @RaceId", r);
			}
		}

		public static List<RiderResults> GetRiderResults(int EventId)
		{
			using (var db = OpenConnection())
			{
				//return db.Query<RiderResults>($"SELECT * FROM Riders_Results WHERE EventId = @Id ORDER BY Class_No DESC, Points ASC", new { Id = EventId }).ToList();
				//return db.Query<RiderResults>($"SELECT * FROM Riders_Results WHERE EventId = @Id ORDER BY Race_Class DESC, Points ASC, FinishTime", new { Id = EventId }).ToList();
				return db.Query<RiderResults>($"SELECT * FROM Riders_Results WHERE EventId = @Id ORDER BY RaceOrder DESC, Points ASC, FinishTime", new { Id = EventId }).ToList();
			}
		}

		public static int DeleteRaceTiming(int EventId)
		{
			using (var db = OpenConnection())
			{
				/* This Loops through raceResult updating each race draw in the list */
				return db.Execute("DELETE from Mylaps_Pasing  WHERE EventId = @eventId", new { eventId = EventId });
			}
		}

		public static List<ChipStatus> GetChipStatus(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Query<ChipStatus>(@"
SELECT DISTINCT 
	Mylaps_Pasing.Transponder, 
	Mylaps_Pasing.Membership_No, 
	OSM_Membership.First_Name, 
	OSM_Membership.Last_Name, 
	Mylaps_Pasing.EventId
FROM  
	Mylaps_Pasing LEFT OUTER JOIN
    OSM_Membership ON Mylaps_Pasing.Membership_No = OSM_Membership.Membership_No
WHERE EventId = @Id", new { Id = EventId }).ToList();
			}
		}

		public static int ClearChipStatus(int EventId)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE Riders SET Chip_Status = 0 WHERE EventId = @Id", new { Id = EventId });
			}
		}

		public static int UpdateChipStatus(List<Rider> riderList)
		{
			using (var db = OpenConnection())
			{
				return db.Execute("UPDATE Riders SET Chip_Status = @Chip_Status WHERE RiderId = @RiderId", riderList);
			}
		}

	}

}
