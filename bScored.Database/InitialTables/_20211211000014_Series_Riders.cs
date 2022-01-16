using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000014)]
	public class _20211211000014_Series_Riders : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Series_Riders")) return;

			Create.Table("Series_Riders")
					.Identity("RiderID")
					.Int32("SeriesID")
					.Text("Membership_No")
					.Int32("Class_No")
					.Int32("R1_Total").Nullable()
					.Int32("R2_Total").Nullable()
					.Int32("R3_Total").Nullable()
					.Int32("R4_Total").Nullable()
					.Int32("R5_Total").Nullable()
					.Int32("R6_Total").Nullable()
					.Int32("R7_Total").Nullable()
					.Int32("R8_Total").Nullable()
					.Int32("R9_Total").Nullable()
					.Int32("R10_Total").Nullable()
					.Int32("R11_Total").Nullable()
					.Int32("R12_Total").Nullable()
					.Int32("Series_Total").Nullable()
					.Int32("Entered").Nullable()
					.Text("Class_Name", 30).Nullable()
					.Time("Hilltime").Nullable()
					.Time("Finishtime").Nullable()
					;
		}

		public override void Down()
		{
			Delete.Table("Series_Riders");
		}
	}
}
