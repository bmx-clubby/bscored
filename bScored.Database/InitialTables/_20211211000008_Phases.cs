using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000008)]
	public class _20211211000008_Phases : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Phases")) return;

			Create.Table("Phases")
					.Int32("Phase_No").PrimaryKey()
					.Text("Phase_Name", 10).Nullable()
					;

		}


		public override void Down()
		{
			Delete.Table("Phases");
		}
	}
}
