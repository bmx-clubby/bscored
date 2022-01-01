using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000007)]
	public class _20211211000007_Passing_Type : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Passing_Type")) return;

			Create.Table("Passing_Type")
					.Int32("Type").Nullable()
					.Text("Name", 20).Nullable()
					;
		
	}

		public override void Down()
		{
			Delete.Table("Passing_Type");
		}
	}
}
