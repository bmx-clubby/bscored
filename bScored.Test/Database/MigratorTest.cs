using bScoredDatabase;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Data.Common;

namespace bScored.Test
{
	public class MigratorTest
	{
		[Test]
		public void can_migrate_the_database()
		{
			var connectionStringName = "bscored_migration_test";
			var connection = ConfigurationManager.ConnectionStrings[connectionStringName];

			if (connection == null)
			{
				throw new Exception($"Unable to find a \"{connectionStringName}\" connection string in the application settings");
			}

			//Ensure database exists 
		
			using (var db = DatabaseConnection.GetConnection(connectionStringName, "master"))
			{
				var cmd = db.CreateCommand();
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.CommandText = @"
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'bscored_migration_testing')
BEGIN
    CREATE DATABASE bscored_migration_testing


END
";
				cmd.ExecuteNonQuery();
			}

			//Database Migrations
				using (var db = DatabaseConnection.GetConnection(connectionStringName))
			{
				DatabaseMigrations.Down(db, 0);

				DatabaseMigrations.Up(db);

				DatabaseMigrations.Down(db, 0);

				DatabaseMigrations.Up(db);
			}

		}

	}
}