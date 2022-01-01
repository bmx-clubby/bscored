using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bScoredDatabase.Models;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp7
{
    public partial class frmPrintRiders : Form
    {
        int EventSelected;

        public frmPrintRiders(int eventSelected)
        {
            InitializeComponent();
            EventSelected = eventSelected;
        }

        private void frmPrintRiders_Load(object sender, EventArgs e)
        {
            Settings currentSettings = DataService.LoadSettings();

            Event thisEvent = DataService.GetEvent(EventSelected);
            List<Rider> ridersList = DataService.GetRiders(EventSelected);

            ReportDataSource rds = new ReportDataSource("dsRiders", ridersList);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            
            ReportParameter p1 = new ReportParameter("EventName", thisEvent.Name);
            ReportParameter p2 = new ReportParameter("RiderCount", ridersList.Count.ToString());

            /* If LogoFile contains a path use the logfile specified otherwise assume it is in the program executing directory */
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            string pathName = string.Empty;
            if (!currentSettings.LogoFile.Contains(@"\"))
            {
                pathName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
                //MessageBox.Show(pathName);
            }
            ReportParameter p3 = new ReportParameter("LogoFile", @"file:///" + pathName + currentSettings.LogoFile);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
            this.reportViewer1.RefreshReport();
        }
    }
}
