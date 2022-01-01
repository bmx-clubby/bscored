using System.Configuration;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace bScored
{
	// Copying this class between projects as the bScoredDatabase is targing "netstandard2.0" which does not have the  DbProviderFactories.GetFactory(settings.ProviderName) method.
	// The bScoredDatabase could target netstandard2.1 however that would require updated all the projects to .NET 5  which would then require each computer running bscore to install .net 5.
	// Therefore I have just left this code as copied between projects for now..
	public static class DatabaseConnection
	{
		public static DbConnection GetConnection(string connectionStringName = "bscored", string databaseNameOverride = null)
		{
			var settings = ConfigurationManager.ConnectionStrings[connectionStringName];
			var factory = DbProviderFactories.GetFactory(settings.ProviderName);
			var connection = factory.CreateConnection();
			connection.ConnectionString = settings.ConnectionString;

			if (databaseNameOverride != null)
			{
				connection.ConnectionString = Regex.Replace(connection.ConnectionString, "Catalog=([^;]+)", $"Catalog={databaseNameOverride}");
			}

			if (connection.State != System.Data.ConnectionState.Open) connection.Open();
			return connection;
		}
	}
}
