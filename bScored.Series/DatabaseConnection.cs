using System.Configuration;
using System.Data.Common;

namespace bScoredDatabase
{
    // Copying this class between projects as the bScoredDatabase is targing "netstandard2.0" which does not have the  DbProviderFactories.GetFactory(settings.ProviderName) method.
    // The bScoredDatabase could target netstandard2.1 however that would require updated all the projects to .NET 5  which would then require each computer running bscore to install .net 5.
    // Therefore I have just left this code as copied between projects for now..
    public static class DatabaseConnection
	{
        public static DbConnection GetConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["bscored"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["bscored"].ConnectionString;
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            return connection;
        }
    }
}
