using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000004)]
	public class _20211211000004_OSM_Clubs : Migration
	{
		public override void Up()
		{

			if (this.TableExists("OSM_Clubs")) return;

			Create.Table("OSM_Clubs")
					.Text("Club_Code", 20).Nullable()
					.Text("Club", 100).Nullable()
					.Text("Group", 10).Nullable()
					.Text("State", 10).Nullable()
					.Text("Country", 10).Nullable()

					;
		}

		public override void Down()
		{
			Delete.Table("OSM_Clubs");
		}
	}
}
