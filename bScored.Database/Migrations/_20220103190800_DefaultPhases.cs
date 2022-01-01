using FluentMigrator;

namespace bScoredDatabase.DbMigrations
{
	[Migration(20220103190800)]
	public class _20220103190800_DefaultPhases : Migration
	{
		public override void Up()
		{
			string insertSql = $@"
INSERT INTO Phases
( [Phase_No], [Phase_Name])
Values 
{phases}
";
			this.Execute.Sql($@" 

begin tran

if not exists (select * from Phases with (updlock, rowlock, holdlock))
begin
   {insertSql}
end

commit
");
		}

		public override void Down()
		{

		}

		const string phases = @"
('1', 'Moto 1' ), 
('2', 'Moto 2' ), 
('3', 'Moto 3' ), 
('4', 'Moto 4' ), 
('5', 'Moto 5' ), 
('6', 'Moto 6' )
";
	}
}
