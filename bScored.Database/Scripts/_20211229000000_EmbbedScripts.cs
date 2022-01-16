using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211229000000)]
	public class _20211229000000_EmbbedScripts : Migration
	{
		public override void Up()
		{
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Member_Search.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Race_Draw.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Race_List.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Race_List2.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Race_Results.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Race_Timing.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Rider_Classes.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Riders_History.sql");
			Execute.EmbeddedScript("bScored.Database.Scripts.view_Riders_List.sql");
		}

		public override void Down()
		{
		}
	}
}
