using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Common;
using System.IO;

namespace bScoredDatabase
{
    public static class DatabaseMigrations
    {
        
        public static void Up(DbConnection connection)
        {
            GetRunner(connection.ConnectionString).MigrateUp();
        }

        public static void Down(DbConnection connection, long version)
        {
            GetRunner(connection.ConnectionString).MigrateDown(version);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static IMigrationRunner GetRunner(string connectionString)
        {
            var serviceProvider = CreateServices(connectionString);
            return serviceProvider.GetRequiredService<IMigrationRunner>();
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .Configure<AssemblySourceOptions>(x =>
                x.AssemblyNames = new[] { typeof(DatabaseMigrations).Assembly.GetName().Name })
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(connectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(DatabaseMigrations).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }
    }
}
