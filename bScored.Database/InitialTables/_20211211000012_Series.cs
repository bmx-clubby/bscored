using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000012)]
	public class _20211211000012_Series : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Series")) return;

			Create.Table("Series")
					.Identity("SeriesID")
					.Text("Name", 50)
					.Text("Sponser", 50)
					.Text("Administrator", 10)
					.Int32("Numer_of_Rounds")
					.Int32("Min_Non_Mandatory")
					.Date("Date").Nullable()
					.Text("Result_File", 50).Nullable()
					;

		}

		public override void Down()
		{
			Delete.Table("Series");
		}
	}
}
