using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using bScoredDatabase;
using bScoredDatabase.Models;
using Dapper;

namespace bScoredSeries
{
    class DataService
    {
        public static DbConnection OpenConnection() => DatabaseConnection.GetConnection();

        public static Settings LoadSettings() => OpenConnection().GetSettings();


        /* Get All Riders for Event*/
        public static List<Rider> GetRiders(int EventId)
        {
            using (IDbConnection db = OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                /* Note use of SQL View */
                return db.Query<Rider>("SELECT * FROM Riders_List WHERE EventId = @Id ORDER BY Class_No desc, Last_Name", new { Id = EventId }).ToList();
            }
        }

        public static List<RaceResult> GetRaceResults(int EventId)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<RaceResult>($"SELECT * FROM Race_Results WHERE EventId = @Id ORDER BY Race_No ASC", new { Id = EventId }).ToList();
            }
        }

        
        public static List<Series> GetSeriesList()
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Series>($"SELECT * FROM Series ORDER BY Date").ToList();
            }
        }

        public static int UpdateSeries(Series Series)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Execute("UPDATE Series SET Name = @Name, Numer_of_Rounds = @Numer_of_Rounds, Min_Non_Mandatory = @Min_Non_Mandatory, Date = @Date, Result_File = @Result_File WHERE SeriesID = @SeriesID", Series);
            }
        }

        public static int CreateSeries(Series Series)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@SeriesID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { Name = Series.Name, Sponser = Series.Sponser, Administrator =Series.Administrator });
                p.AddDynamicParams(new { Numer_of_Rounds = Series.Numer_of_Rounds, Min_Non_Mandatory = Series.Min_Non_Mandatory, Date = Series.Date, Result_File = Series.Result_File });

                var result = db.Execute("sp_Series_Insert", p, commandType: CommandType.StoredProcedure);
                Series.SeriesID = p.Get<int>("@SeriesID");

                return result;
            }
        }

        public static int[] DeleteSeries(int seriesID)
        {
            int[] result = new int[3];

            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                result[1] = db.Execute("DELETE FROM Series_Events WHERE SeriesID = @SeriesID", new { SeriesId = seriesID });
                result[2] = db.Execute("DELETE FROM Series_Riders WHERE SeriesID = @SeriesID", new { SeriesId = seriesID });

                result[0] = db.Execute("DELETE FROM Series WHERE SeriesID = @SeriesID", new { SeriesId = seriesID });

                return result;
            }

        }

        /* NOT USED */
        public static List<Event> GetEventList()
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Event>($"SELECT * FROM Events ORDER BY Date").ToList();
            }
        }

        public static List<SeriesEvent> GetSeriesEvents(int SeriesId)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<SeriesEvent>($"select * from Series_Names WHERE SeriesID = @Id ORDER BY Date", new { Id = SeriesId }).ToList();
            }
        }

        public static int DeleteSeriesEvent(int ID)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Execute("Delete from Series_Events WHERE ID = @ID", new { ID = ID }, commandType: CommandType.Text);
            }
        }

        public static int AddSeriesEvent(int SeriesID, int EventID)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Execute("INSERT INTO Series_Events (SeriesID, EventID) VALUES ("+SeriesID.ToString()+", "+ EventID.ToString()+")");
            }
        }


        public static int CreateSeriesRiders(int seriesID, List<SeriesRider> riderList)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                /* Need to Delete all Riders for this Series first */
                db.Execute("DELETE FROM Series_Riders WHERE SeriesID = @SeriesId", new { SeriesId = seriesID });

                /* This Loops through riderList inserting each rider in the Series list */
                return db.Execute("INSERT INTO Series_Riders (SeriesID, Membership_No, Class_No, Class_Name) VALUES (@SeriesID, @Membership_No, @Class_No, @Class_Name)", riderList);
            }
        }

        public static int UpdateSeriesRider(int SeriesId, string Membership_No, int Class_No, int Round_No, int Total, TimeSpan hilltime, TimeSpan finishtime)
        {
            string sSQL;
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                sSQL = "UPDATE Series_Riders SET " +
                    "R" + Round_No.ToString() + "_Total = " + Total.ToString() + ", HillTime = '" + hilltime.ToString(@"hh\:mm\:ss\.fff") + "', Finishtime = '" + finishtime.ToString(@"hh\:mm\:ss\.fff") + "' " +
                    "WHERE SeriesID = " + SeriesId.ToString() + " AND Membership_No = '" + Membership_No.ToString() + "' AND Class_No = " + Class_No.ToString();

                return db.Execute(sSQL);
            }
        }

        public static int UpdateSeriesTotals(int SeriesId)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.AddDynamicParams(new { SeriesID = SeriesId });

                return db.Execute("sp_Series_Totals", p, commandType: CommandType.StoredProcedure);
            }
        }

        /* select * from Series_Results where SeriesId=11 order by Class_No DESC, Series_Total DESC */
        public static List<SeriesResults> GetSeriesResults(int SeriesId)
        {
            using (IDbConnection db =  OpenConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<SeriesResults>($"SELECT * FROM Series_Results WHERE SeriesId=@Id ORDER BY Class_No DESC, Qualified DESC, Series_Total DESC", new { Id = SeriesId }).ToList();
            }
        }

    }
}
