using bScored;
using bScoredDatabase;
using Sentry;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
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
			using (SentrySdk.Init(o =>
			{
				o.Dsn = "https://bad7cc7aa2b948e7848fcbed7cca19fb@o1017083.ingest.sentry.io/6133229";
				// When configuring for the first time, to see what the SDK is doing:
				o.Debug = true;
				// Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
				// We recommend adjusting this value in production.
				o.TracesSampleRate = 1.0;

			}))
			{
				SentrySdk.ConfigureScope(scope =>
				{
					scope.User = new User
					{
						Username = Environment.UserName,
					};
				});
				return SentryWrappedMain();
			}
		}

		static int SentryWrappedMain()
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
				CreateDefaultDabase();

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
				SentrySdk.CaptureException(ex);
				return -1;
			}

			Application.ThreadException += new ThreadExceptionEventHandler(FormsThreadExceptionHandler);



			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				Application.Run(new Form1());
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				return -1;
			}
			return 0;
		}

		private static void FormsThreadExceptionHandler(object sender, ThreadExceptionEventArgs t)
		{
			SentrySdk.CaptureException(t.Exception);
			MessageBox.Show($"An application error has occurred. \n\nDetails: {t.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private static string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		private static string bScoredDataDir = Path.Combine(appDataDir, "bScored");
		private static DirectoryInfo dataDirectory = new DirectoryInfo(bScoredDataDir);
		private static FileInfo DataDirFile(string name) => new FileInfo(Path.Combine(dataDirectory.FullName, name));

		public static void CreateDefaultDabase()
		{
			var bScoredDBFile = DataDirFile("bscored.mdf");

			if (!bScoredDBFile.Exists)
				CreateSqlDatabase(bScoredDBFile);
		}

		private static void CreateSqlDatabase(FileInfo dbFile)
		{
			string databaseName = Path.GetFileNameWithoutExtension(dbFile.Name);

			using (var connection = new System.Data.SqlClient.SqlConnection(
				"Data Source=(LocalDb)\\MSSQLLocalDB;Integrated Security=true;"))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						String.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, dbFile);
					command.ExecuteNonQuery();
				}
			}
		}

	}
}
