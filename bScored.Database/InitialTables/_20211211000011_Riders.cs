using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000011)]
	public class _20211211000011_Riders : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Riders")) return;

			Create.Table("Riders")
					.Identity("RiderID")
					.Int32("EventId")
					.Text("Membership_No")
					.Text("Plate",10)
					.Text("Transponder",10)
					.Int32("Class_No")
					.Int32("Chip_Status").Nullable()
					.Time("FinishTime").Nullable()
					;

	}

		public override void Down()
		{
			Delete.Table("Riders");
		}
	}
}
