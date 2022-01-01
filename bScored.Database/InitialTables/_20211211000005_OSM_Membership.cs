using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000005)]
	public class _20211211000005_OSM_Membership : Migration
	{
		public override void Up()
		{
			if (this.TableExists("OSM_Membership")) return;

			Create.Table("OSM_Membership")
					.Text("Membership_No").PrimaryKey()
					.Text("First_Name", 50)
					.Text("Last_Name", 50)
					.Date("BirthDate").Nullable()
					.Text("Gender", 20).Nullable()
					.Text("Emergency_Contact_Person", 50).Nullable()
	.Text("Emergency_Contact_Number", 50).Nullable()
	.Date("Financial_Date").Nullable()
	.Text("Status", 20).Nullable()
	.Text("Member_Type", 50).Nullable()
	.Text("Club", 100).Nullable()
	.Text("Club_Code", 20).Nullable()
	.Text("Member_Transponders", 100).Nullable()
	.Text("International_Licence_Code", 50).Nullable()
	.Text("UCI_Code", 50).Nullable()
	.Text("UCI_ID", 50).Nullable()
	.Text("Medical_Suspension", 10).Nullable()
	.Text("Disciplinary_Suspension", 10).Nullable()
	.Text("Other_Suspension", 10).Nullable()
	.Text("POA_Suspension", 10).Nullable()
	.Int32("Class_No").Nullable()
	.Text("Plate", 10).Nullable()
	.Text("Transponder", 50).Nullable()
	.Bool("Race_Status").Nullable()
	.Text("Transponder_ID1", 20).Nullable()
	.Text("Transponder_ID2", 20).Nullable()
	.Text("Transponder_ID3", 20).Nullable()
	.Text("BMXA_No", 20).Nullable()
					;
		}

		public override void Down()
		{
			Delete.Table("OSM_Membership");
		}
	}
}
