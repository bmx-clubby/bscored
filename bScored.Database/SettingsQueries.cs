using bScoredDatabase.Models;
using Dapper;
using System.Data.Common;
using System.Linq;

namespace bScoredDatabase
{
	public static class SettingsQueries
	{
		public static Settings GetSettings(this DbConnection db, DbTransaction transaction = null)
		{
			var results = db.Query<Settings>($"SELECT * FROM Settings", transaction: transaction);
			return results.FirstOrDefault();
		}

		public static void SaveSettings(this DbConnection db, Settings settings, DbTransaction transaction = null)
		{
			string updateSQL = @"UPDATE Settings SET

	Host = @Host,	
	UserName = @UserName,	
	Password = @Password,	
	DestinationPath = @DestinationPath,	
	DefaultClub = @DefaultClub,	
	PassingFile = @PassingFile,	
	LogoFile = @LogoFile,	
	ReportLink = @ReportLink,	
	TCPAddress = @TCPAddress,	
	TCPPort = @TCPPort
";

			int affectedCount = db.Execute(updateSQL, settings, transaction: transaction);


			if (affectedCount > 0) return;


			string insertSQL = @"INSERT INTO Settings 
(
	Host,	UserName,	Password,	DestinationPath,	DefaultClub,	PassingFile,	LogoFile,	ReportLink,	TCPAddress,	TCPPort
) 
VALUES  (
	@Host,	@UserName,	@Password,	@DestinationPath,	@DefaultClub,	@PassingFile,	@LogoFile,	@ReportLink,	@TCPAddress,	@TCPPort
)";
			db.Execute(insertSQL, settings, transaction: transaction);
		}
	}

}