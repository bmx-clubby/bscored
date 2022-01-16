using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20211211000015)]
	public class _20211211000015_Settings : Migration
	{
		public override void Up()
		{
			if (this.TableExists("Settings")) return;

			Create.Table("Settings")
					.Text("Host", 60).Nullable()
					.Text("UserName", 30).Nullable()
					.Text("Password", 30).Nullable()
					.Text("DestinationPath", 1200).Nullable()
					.Text("DefaultClub", 10).Nullable()
					.Text("PassingFile", 60).Nullable()
					.Text("LogoFile", 60).Nullable()
					.Text("ReportLink", 60).Nullable()
					.Text("TCPAddress",30).Nullable()
					.Int32("TCPPort").Nullable()
					;

	}

	public override void Down()
	{
		Delete.Table("Settings");
	}
}
}
