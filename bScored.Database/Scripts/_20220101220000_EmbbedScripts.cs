using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20220101220000)]
	public class _20220101220000_EmbbedScripts : Migration
	{
		public override void Up()
		{
			Execute.EmbeddedScript("bScored.Database.Scripts.sp_Series_Insert.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.sp_Series_Totals.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Riders_Results.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Series_Names.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Series_Results.sql");
		}

		public override void Down()
		{
		}
	}
}
