using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000006)]
	public class _20211211000006_OSM_Transponders : Migration
	{
		public override void Up()
		{
			if (this.TableExists("OSM_Transponders")) return;

			Create.Table("OSM_Transponders")
					.Text("Membership_No")
					.Text("Type", 10)
					.Text("Chip_Code", 10)
					;
		}

		public override void Down()
		{
			Delete.Table("OSM_Transponders");
		}
	}
}
