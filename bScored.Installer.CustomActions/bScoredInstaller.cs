using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace bScored.Installer.CustomActions
{
	[RunInstaller(true)]
	public partial class bScoredInstaller : System.Configuration.Install.Installer
	{
		DirectoryInfo dataDirectory;
		DirectoryInfo targetDirectory;
		DirectoryInfo userHomeDirectory;

		private void Init()
		{
			var appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var bScoredDataDir = Path.Combine(appDataDir, "bScored");
			dataDirectory = new DirectoryInfo(bScoredDataDir);
			targetDirectory = new DirectoryInfo(this.Context.Parameters["targetdir"]);
			userHomeDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

			if (!dataDirectory.Exists)
				dataDirectory.Create();
		}

		private FileInfo TargetDirFile(string name) => new FileInfo(Path.Combine(targetDirectory.FullName, name));
		private FileInfo DataDirFile(string name) => new FileInfo(Path.Combine(dataDirectory.FullName, name));

		public override void Install(IDictionary stateSaver)
		{
			base.Install(stateSaver);

			Init();

			CreateDefaultDabase();

			CreateDefaultDbConfig();
		}

		public void CreateDefaultDbConfig()
		{

			var expectedDbConfig = TargetDirFile("AppDatabaseConnection.config");
			var defaultbConfig = TargetDirFile("AppDatabaseConnectionDefault.config");

			if (!expectedDbConfig.Exists)
			{
				defaultbConfig.CopyTo(expectedDbConfig.FullName);
			}
		}

		public void CreateDefaultDabase()
		{
			var bScoredDBFile = DataDirFile("bscored.mdf");
			var bScoredDBLogFile = DataDirFile("bscored_log.ldf");
			if (!bScoredDBFile.Exists)
				CreateSqlDatabase(bScoredDBFile, bScoredDBLogFile);
		}

		public void CreateSqlDatabase(FileInfo dbFile, FileInfo logFile)
		{
			string databaseName = Path.GetFileNameWithoutExtension(dbFile.Name);

			using (var connection = new System.Data.SqlClient.SqlConnection(
				"Data Source=.\\sqlexpress;Initial Catalog=master; Integrated Security=true;User Instance=True;"))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						String.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, dbFile);
					command.ExecuteNonQuery();

					command.CommandText =
						String.Format("EXEC sp_detach_db '{0}', 'true'", databaseName);
					command.ExecuteNonQuery();
				}
			}

			Thread.Sleep(1000);

			// Grant MSSQL SQL EXPRESS access to the DB file
			var fSecurity = File.GetAccessControl(dbFile.FullName); // current security settings.
			fSecurity.AddAccessRule(new FileSystemAccessRule(new NTAccount("NT SERVICE\\MSSQL$SQLEXPRESS"), FileSystemRights.FullControl, AccessControlType.Allow));
			fSecurity.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow));
			File.SetAccessControl(dbFile.FullName, fSecurity);

			
			fSecurity = File.GetAccessControl(logFile.FullName); // current security settings.
			fSecurity.AddAccessRule(new FileSystemAccessRule(new NTAccount("NT SERVICE\\MSSQL$SQLEXPRESS"), FileSystemRights.FullControl, AccessControlType.Allow));
			fSecurity.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow));
			File.SetAccessControl(logFile.FullName, fSecurity);
		}
	}
}
