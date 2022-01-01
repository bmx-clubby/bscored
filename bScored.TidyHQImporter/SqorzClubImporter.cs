using bScoredDatabase;
using bScoredDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using bScored;

namespace TidyHQMemberImporter
{

    class SqorzClubImporter
    {
        ClubImportLog log = new ClubImportLog();

        public async Task<ClubImportLog> ImportAsync(string[] clubnames, string[] clubcodes)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                using (var transaction = db.BeginTransaction())
                {
                    await ProcessClubs(db, transaction, clubnames, clubcodes);

                    transaction.Commit();
                    return log;
                }
            }
        }

        private async Task ProcessClubs(DbConnection db, DbTransaction transaction, string[] clubnames, string[] clubcodes)
        {
            string[] parts;
            int clublengthmax = 0;

            /* clubnames and clubcodes must be same length, checked in calling program
            */
            for (var i = 0; i < clubnames.Length; i++)
            {
                var club = new Clubs();

                /* Most club names have the state included seperated by comma but
                 * some have just the club name
                 * e.g. " Adelaide Mountain Bike Club, SA"; Freestyle ACT BMX Club;
                */

                if (clubnames[i].IndexOf(",") != -1)        // Club Name and State
                {
                    parts = clubnames[i].Split(',');
                    if (parts.Length == 2)
                    {
                        club.Club = parts[0].Substring(1).TrimStart();
                        club.State = parts[1].Substring(0, parts[1].Length - 1).TrimStart();
                    }
                }
                else                                       // Club Name only
                {
                    club.Club = clubnames[i].TrimStart();
                    club.State = "";
                }

                /* This contains Index and Club_Code, we want the Club_Code
                 * 0: MB39;1: MB131;2: MB160;3: MB78;...
                 * */
                club.Club_Code = clubcodes[i].Substring(clubcodes[i].IndexOf(":") + 1).TrimStart();

                //Debug.WriteLine(i.ToString() + ": " + club.Club + "\\" + club.Club_Code + "\\" + club.State);
                if (club.Club.Length > clublengthmax)
                    clublengthmax = club.Club.Length;

                /* The Group or short code is not included so will have to be update manually
                 * */
                try
                {
                    var (inserted, updated) = await UpsertClub(db, transaction, club);

                    if (inserted) log.Inserted();
                    if (updated) log.Updated();
                }
                catch (Exception)
                {
                    Debugger.Break();
                    throw;
                }
            }
            //Debug.WriteLine("Club Max Length = " + clublengthmax.ToString());

        }

        private async Task<(bool inserted, bool updated)> UpsertClub(DbConnection db, DbTransaction transaction, Clubs club)
        {

            //Try updating using Club_Code
            var rowsAffected = await UpdateClubFromSqorzData(db, transaction, club, club.Club_Code);

            if (rowsAffected == 1) return (inserted: false, updated: true);

            //Otherwise we Add a New Club
            var sql = @"
    INSERT INTO OSM_Clubs (
                    Club_Code ,
                    Club ,
                    State 
) 
        VALUES (
                    @Club_Code ,
                    @Club ,
                    @State 
)
";

            var result = await db.ExecuteScalarAsync<string>(sql, club, transaction);
            return (inserted: true, updated: false);
        }

        private Task<int> UpdateClubFromSqorzData(DbConnection db, DbTransaction transaction, Clubs club, string club_code)
        {
            var sql = @"
UPDATE OSM_Clubs
        SET 
                    Club  = @Club,
                    State = @State
 WHERE 
   Club_Code = @club_Code";

            var p = new DynamicParameters(club);
            p.Add("club_Code", club_code);

            return db.ExecuteAsync(sql, p, transaction);
        }


    }
    public class ClubImportLog
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
