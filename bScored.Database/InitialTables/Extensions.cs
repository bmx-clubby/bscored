using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Infrastructure;
using System;

namespace bScoredDatabase.DbMigrations
{
	public static class Extensionss
	{
		public static ICreateTableColumnOptionOrWithColumnSyntax Identity(this ICreateTableWithColumnOrSchemaOrDescriptionSyntax table, string name="id", string primaryKeyName =null)
		{
			return table.WithColumn(name).AsInt32().NotNullable().PrimaryKey(primaryKeyName).Identity();
		}

		public static ICreateTableColumnOptionOrWithColumnSyntax Text(this ICreateTableWithColumnSyntax context, string name, int size = 255)
		{
			//ICreateTableColumnAsTypeSyntax
			return context.WithColumn(name).AsString(size)	;
		}

		public static ICreateTableColumnOptionOrWithColumnSyntax Date(this ICreateTableWithColumnSyntax context, string name)
		{
			return context.WithColumn(name).AsDate();
		}
		public static ICreateTableColumnOptionOrWithColumnSyntax DateTime2(this ICreateTableWithColumnSyntax context, string name)
		{
			return context.WithColumn(name).AsCustom("datetime2(3)");
		}
		public static ICreateTableColumnOptionOrWithColumnSyntax Bool(this ICreateTableWithColumnSyntax context, string name)
		{
			return context.WithColumn(name).AsBoolean();
		}

		public static ICreateTableColumnOptionOrWithColumnSyntax Int32(this ICreateTableWithColumnSyntax context, string name)
		{
			return context.WithColumn(name).AsInt32();
		}

		public static ICreateTableColumnOptionOrWithColumnSyntax Time(this ICreateTableWithColumnSyntax context, string name)
		{
			return context.WithColumn(name).AsCustom("time(3)");
		}

		public static bool TableExists(this MigrationBase self, string tableName)
		{
			return self.Schema.Table(tableName).Exists();
		}
	}
}
