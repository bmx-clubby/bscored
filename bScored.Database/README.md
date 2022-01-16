
# bScored Database

This project contains 
* Database migrations, used to apply changes to the database on app startup.
* Common database queries e.g. get settings , Find Member By Number  etc
* Common database models e.g clubs, members, settings

## Migrations

Migrations are applied using the Fluent migration library: https://fluentmigrator.github.io/index.html

**To create new migration:**
1. Create a new csharp file under the Migrations directory. e.g.
```
using FluentMigrator;

namespace namespace bScoredDatabase.DbMigrations
{    
               
    [Migration(YYYYMMDDHHMMSS)]  //Example migration number: 20210103133500
    public class _YYYYMMDDHHMMSS_MyMigrationName : Migration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();

             Alter.Table("Log").AlterColumn("Id").AsString();
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}
```
2. Change `YYYYMMDDHHMMSS` to a long number representing the current date in the format shown
3. Update the file name to match the class name.
4. Run the bScore events project, the migration will be applied

**To revert a migration:**
1. Edit the Program.cs file, uncomment the line which sets the migration version.
```
migrateDownToVersion = 20210103133500;
```
2. run the bscored events project, the database will be migrated down to the version entered.


---

## Common Queries & Models

Common queries and models used in a number of different projects have been included in this project.