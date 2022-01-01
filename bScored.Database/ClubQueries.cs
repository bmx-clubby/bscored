using bScoredDatabase.Models;
using System.Data.Common;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System;

namespace bScoredDatabase
{
    public static class ClubQueries
    {

        public static List<Clubs> GetClubList(this DbConnection db, DbTransaction transaction = null)
        {
            var results = db.Query<Clubs>($"SELECT * FROM OSM_Clubs ORDER BY Club ASC", transaction: transaction);
            return results.ToList();
        }

        public static Clubs GetDefaultClub(this DbConnection db, DbTransaction transaction = null)
        {
            var results = (db.Query<Clubs>(@"
    SELECT c.*
    FROM OSM_Clubs c
    JOIN Settings s on c.Club_Code = s.DefaultClub
                ", transaction: transaction)
            ).ToList();

            if (results.Count > 1) throw new InvalidOperationException("Only 1 default club should be return from this query.");

            return results.FirstOrDefault();
        }

        public static Clubs GetClubFromClub(this DbConnection db, string club, DbTransaction transaction = null)
        {
            var results = (db.Query<Clubs>(@"SELECT * FROM OSM_Clubs WHERE Club = @club", new { club }, transaction: transaction)
            ).ToList();

            //if (results.Count > 1) throw new InvalidOperationException("Only 1 default club should be return from this query.");

            return results.FirstOrDefault();
        }

        public static int InsertClub(this DbConnection db, Clubs club, DbTransaction transaction = null)
        {
            var sql = @"
    INSERT INTO OSM_Clubs (
                    Club_Code,
                    Club,
                    State
) 
        VALUES (
                    @Club_Code,
                    @Club,
                    @State
)
";

            return db.Execute(sql, club, transaction);
        }
    }

}