using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Data;
using bScoredDatabase.Models;

namespace bScoredDisplay
{
	class DataService
    {
        public static Settings LoadSettings()
        {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["bscored"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Settings>($"SELECT * FROM Settings").FirstOrDefault();
            }
        }
    }
}
