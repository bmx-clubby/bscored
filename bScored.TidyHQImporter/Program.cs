using bScored;
using bScoredDatabase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TidyHQMemberImporter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main()
        {
			AppDomain.CurrentDomain.SetData("DataDirectory",
					Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bScored"));

			var connectionStringName = "bscored";
			var connection = ConfigurationManager.ConnectionStrings[connectionStringName];

			if (connection == null)
			{
				MessageBox.Show($"Unable to find a \"{connectionStringName}\" connection string in the application settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}

			//Ensure latest Database
			try
			{
				using (var db = DatabaseConnection.GetConnection())
				{
					DatabaseMigrations.Up(db);
				}
			}
			catch (SqlException ex)
			{
				MessageBox.Show($"Database operation failed! \n\nConnection: \"{connection.ConnectionString}\". \n\nMessage: \"{ex.Message}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}
			catch(Exception ex)
			{
				MessageBox.Show($"An application error has occurred. \n\nDetails: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return -1;
			}
			

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CSVImport());

			return 0;
        }
    }
}
