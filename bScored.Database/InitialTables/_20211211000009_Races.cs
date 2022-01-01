using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000009)]
	public class _20211211000009_Races : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Races")) return;

			Create.Table("Races")
					.Identity("RaceId")
					.Int32("EventId").Nullable()
					.Int32("Race_No").Nullable()
					.Int32("Moto_No").Nullable()
					.Int32("Class_No").Nullable()
					.Int32("Gate_No").Nullable()
					.DateTime2("Starttime").Nullable()
					.Int32("Race_Status").Nullable()	
					;
		}

		public override void Down()
		{
			Delete.Table("Races");
		}
	}
}
