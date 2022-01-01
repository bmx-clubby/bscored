using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000010)]
	public class _20211211000010_Results : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Results")) return;

			Create.Table("Results")
					.Identity("ResultId")
					.Int32("EventId").Nullable()
					.Int32("Race_No").Nullable()
					.Text("Membership_No").Nullable()
					.Int32("Lane_No").Nullable()
					.Text("Place", 10).Nullable()
					.Int32("Points").Nullable()
					.Time("Hilltime").Nullable()
					.Time("Finishtime").Nullable()
					.Int32("RiderID").Nullable()

					;
		}

		public override void Down()
		{
			Delete.Table("Results");
		}
	}
}
