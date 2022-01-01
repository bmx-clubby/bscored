using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000013)]
	public class _20211211000013_Series_Events : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Series_Events")) return;

			Create.Table("Series_Events")
					.Identity("ID")
					.Int32("SeriesID").Nullable()
					.Int32("EventID").Nullable()
					;
	}

		public override void Down()
		{
			Delete.Table("Series_Events");
		}
	}
}
