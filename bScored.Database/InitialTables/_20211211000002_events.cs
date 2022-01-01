using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000002)]
	public class _20211211000002_events : Migration
	{
		public override void Up()
		{
			if (this.TableExists("events")) return;

			Create.Table("events")
					.Identity("EventID", primaryKeyName: "PK_BMX_Events")
					.Text("Name", 50).Nullable()
					.Date("Date").Nullable()
					.Int32("Entry_No").Nullable()
					.Int32("Moto_No").Nullable()
					.Int32("Race_No").Nullable()
					.Text("Result_File", 50).Nullable()
					.Int32("Race_Completed").Nullable()
					.Int32("Event_Status").Nullable()
					;
		}

		public override void Down()
		{
			Delete.Table("events");
		}
	}
}
