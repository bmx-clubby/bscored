using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bScored"));

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            bool createdNew;

            mutex = new Mutex(true, assemblyName, out createdNew);
            if(!createdNew)
            {
                MessageBox.Show(assemblyName + " is already running...");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDisplay());
        }
    }
}
