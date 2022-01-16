using bScored.Installer.CustomActions;
using bScoredDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Install;
using System.Data.Common;

namespace bScored.Test
{
	public class bScoredInstallerTest
	{
		[Test, Explicit]
		public void Install()
		{
			var installer = new bScoredInstaller();

			installer.Context = new InstallContext();
			installer.Context.Parameters["targetdir"] = @"C:\Program Files (x86)\bScored\bScored";



			installer.Install(new Dictionary<string,object>());
		}

	}
}