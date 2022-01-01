using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000000)]
	public class _20211211000000_tMembers : Migration
	{
		public override void Up()
		{
			if (this.TableExists("_tMembers")) return;

			Create.Table("_tMembers")
					.Text("Membership_No").PrimaryKey()
					.Text("First_Name",50)
					.Text("Last_Name",50)
					.Date("BirthDate")
					.Text("Gender", 20).Nullable()
					.Text("Emergency_Contact_Person", 50).Nullable()
					.Text("Emergency_Contact_Number", 50).Nullable()
					.Date("Financial_Date")
					.Text("Status", 20)
					.Text("Member_Type", 50)
					.Text("Club", 50)
					.Text("Club_Code", 20)
					.Text("Member_Transponders", 100).Nullable()
					.Text("International_Licence_Code", 50).Nullable()
					.Text("UCI_Code", 50)
					.Text("UCI_ID", 50)
					.Text("Medical_Suspension", 10)
					.Text("Disciplinary_Suspension", 10)
					.Text("Other_Suspension", 10)
					.Text("POA_Suspension", 10)
					;
		}

		public override void Down()
		{
			Delete.Table("_tMembers");
		}
	}
}
