using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20220103123700)]
	public class _20220103123700_IncreaseDefaultClubLenght : Migration
	{
		public override void Up()
		{
			Alter.Table("Settings")
					.AlterColumn("DefaultClub")
					.AsString(20);
		}

		public override void Down()
		{
			Alter.Table("Settings")
					.AlterColumn("DefaultClub")
					.AsString(10);
		}
	}
}
