using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000003)]
	public class _20211211000003_Mylaps_Pasing : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Mylaps_Pasing")) return;


			Create.Table("Mylaps_Pasing")
					.Identity("ID")
					.Int32("EventId").Nullable()
					.DateTime2("Timestamp").Nullable()
					.Text("Transponder", 10).Nullable()
					.Text("Membership_No").Nullable()
					.DateTime2("GateTime").Nullable()
					.Int32("Type").Nullable()
					.Int32("RaceId").Nullable()
					.Int32("Ignore").Nullable()
					;
		}

		public override void Down()
		{
			Delete.Table("Mylaps_Pasing");
		}
	}
}
