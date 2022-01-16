using bScoredDatabase.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class frmPrintResults : Form
    {
        int EventSelected;
        List<RiderResults> riderResults;
        List<RaceResult> eventResults;

        public frmPrintResults(int eventSelected)
        {
            InitializeComponent();

            EventSelected = eventSelected;
        }

        private void frmPrintResults_Load(object sender, EventArgs e)
        {
            Event thisEvent = DataService.GetEvent(EventSelected);

            /* Get the Last results for each rider and save back into the rider */
            List<LastResults> lastResults = DataService.GetLastResults(EventSelected);
            DataService.UpdateLastResults(lastResults);

            riderResults = DataService.GetRiderResults(EventSelected);
            PopulateResults();

            Settings currentSettings = DataService.LoadSettings();

            RiderResultsBindingSource.DataSource = riderResults;

            //ReportDataSource rds = new ReportDataSource("DataSet1", riderResults);
            //this.reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter p1 = new ReportParameter("EventName", thisEvent.Name);
            ReportParameter p2 = new ReportParameter("RiderCount", riderResults.Count.ToString());

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

        /* This is also in Form1 - the main form... */
        private void PopulateResults()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            /* Create a Crosstab, go through each race result and put in Moto column for the rider */
            eventResults = DataService.GetRaceResults(EventSelected);
            foreach (RaceResult r in eventResults)
            {
                var riderResult = riderResults.Find(c => c.Membership_No == r.Membership_No && c.Race_Class == r.Class_No);
                if(riderResult !=null)
                {
                    if (r.Moto_No == 1)
                    {
                        riderResult.Moto_1 = r.Place;
                        riderResult.Moto_1_HillTime   = r.HillTime;
                        riderResult.Moto_1_FinishTime = r.FinishTime;
                        //riderResult.FinishTime  = r.FinishTime;
                    }
                    else if (r.Moto_No == 2)
                    {
                        riderResult.Moto_2 = r.Place;
                        riderResult.Moto_2_HillTime = r.HillTime;
                        riderResult.Moto_2_FinishTime = r.FinishTime;
                        //riderResult.FinishTime = r.FinishTime;
                    }
                    else if (r.Moto_No == 3)
                    {
                        riderResult.Moto_3 = r.Place;
                        riderResult.Moto_3_HillTime = r.HillTime;
                        riderResult.Moto_3_FinishTime = r.FinishTime;
                        //riderResult.FinishTime = r.FinishTime;
                    }
                    else if (r.Moto_No == 4)
                    {
                        riderResult.Moto_4 = r.Place;
                        riderResult.Moto_4_HillTime = r.HillTime;
                        riderResult.Moto_4_FinishTime = r.FinishTime;
                        //riderResult.FinishTime = r.FinishTime;
                    }
                    else if (r.Moto_No == 5)
                    {
                        riderResult.Moto_5 = r.Place;
                        riderResult.Moto_5_HillTime = r.HillTime;
                        riderResult.Moto_5_FinishTime = r.FinishTime;
                        //riderResult.FinishTime = r.FinishTime;
                    }
                    else if (r.Moto_No == 6)
                    {
                        riderResult.Moto_6 = r.Place;
                        riderResult.Moto_6_HillTime = r.HillTime;
                        riderResult.Moto_6_FinishTime = r.FinishTime;
                        //riderResult.FinishTime = r.FinishTime;
                    }
                }
            }
            stopwatch.Stop();
            //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString()); 
        }
    }
}
