using bScored;
using bScoredDatabase;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		private static Mutex mutex = null;

		[STAThread]
		static int Main()
		{
			AppDomain.CurrentDomain.SetData("DataDirectory",
					Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bScored"));

			string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
			bool createdNew;

			mutex = new Mutex(true, assemblyName, out createdNew);
			if (!createdNew)
			{
				MessageBox.Show("bScored is already running...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}

			var connectionStringName = "bscored";
			var connection = ConfigurationManager.ConnectionStrings[connectionStringName];

			if (connection == null)
			{
				MessageBox.Show($"Unable to find a \"{connectionStringName}\" connection string in the application settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}

			//Database Migrations
			try
			{
				using (var db = DatabaseConnection.GetConnection())
				{
					long? migrateDownToVersion = null;

					/* Uncomment this line to test the down migrations, update the migration version with the last know good migration (normally the one right before your new migration) */

					//migrateDownToVersion = 20180430121800;

					if (!migrateDownToVersion.HasValue)
					{
						DatabaseMigrations.Up(db);
					}
					else
					{
						DatabaseMigrations.Down(db, migrateDownToVersion.Value);
					}

				}
			}
			catch (SqlException ex)
			{
				MessageBox.Show($"Database operation failed! \n\nConnection: \"{connection.ConnectionString}\". \n\nMessage: \"{ex.Message}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An application error has occurred. \n\nDetails: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}
			/* Retreive User settings for Initial Catalog and update connect string if required 
             Config file is ready only at runtime so this doesnt work always ...*/
			/*  if (File.Exists(@"C:\BMX\InitialCatalog.txt"))
                {
                    string settingInitialCatalog = File.ReadAllText(@"C:\BMX\InitialCatalog.txt");
                    string connString = ConfigurationManager.ConnectionStrings["bscored"].ConnectionString;
                    if (!connString.Contains(settingInitialCatalog))
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        var connectionStringSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                        connectionStringSection.ConnectionStrings["bscored"].ConnectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = " + settingInitialCatalog + "; Integrated Security = True";
                        config.Save();
                        ConfigurationManager.RefreshSection("connectionStrings");

                        MessageBox.Show(ConfigurationManager.ConnectionStrings["bscored"].ConnectionString, "Initial Catalog Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            */

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			return 0;
		}



	}
}
