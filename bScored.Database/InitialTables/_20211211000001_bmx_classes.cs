using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000001)]
	public class _20211211000001_bmx_classes : Migration
	{
		public override void Up()
		{

			if (this.TableExists("bmx_classes")) return;

			Create.Table("bmx_classes")
					.Identity("ClassID")
					.Int32("EventID").Nullable()
					.Int32("Class_No").Nullable()
					.Text("Name", 50).Nullable()
					.Text("Short", 50).Nullable()
					.Int32("RaceOrder").Nullable()
					.Int32("FinalOrder").Nullable()
					.Int32("MinEntry").Nullable()
					.Text("Type", 50).Nullable()
					.Int32("Entry_No").Nullable()
					.Int32("Race_Class").Nullable()
					.Int32("Race_No").Nullable()
					;
		}

		public override void Down()
		{
			Delete.Table("bmx_classes");
		}
	}
}
