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
      
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            Init();

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
    }
}
