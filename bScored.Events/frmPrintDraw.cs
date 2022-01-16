using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Reflection;
using bScoredDatabase.Models;

namespace WindowsFormsApp7
{
    public partial class frmPrintDraw : Form
    {
        int EventSelected;
        int RacesPerMoto;
        List<Race> raceList = new List<Race>();
        List<MotoDraw> motoDraw = new List<MotoDraw>();

        public frmPrintDraw(int eventSelected)
        {
            InitializeComponent();

            EventSelected = eventSelected;
        }

        private void frmDrawPrint_Load(object sender, EventArgs e)
        {
            Event thisEvent = DataService.GetEvent(EventSelected);
            RacesPerMoto = thisEvent.Race_No / thisEvent.Moto_No;

            Settings currentSettings = DataService.LoadSettings();

            /* This Populates motoDraw */
            PopulateDraw();

            ReportDataSource rds = new ReportDataSource("DataSet1", motoDraw);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
 
            ReportParameter p1 = new ReportParameter("EventName", thisEvent.Name);
            ReportParameter p2 = new ReportParameter("RacesPerMoto", RacesPerMoto.ToString());
            ReportParameter p3 = new ReportParameter("RiderCount", thisEvent.Entry_No.ToString());

            /* If LogoFile contains a path use the logfile specified otherwise assume it is in the program executing directory */
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            string pathName = string.Empty;
            if (!currentSettings.LogoFile.Contains(@"\"))
            {
                pathName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\";
                //MessageBox.Show(pathName);
            }
			var logoUrl = @"file:///" + pathName + (!String.IsNullOrWhiteSpace(currentSettings.LogoFile) ? currentSettings.LogoFile : "Resources\\DefaultDrawLogo.PNG");
			ReportParameter p4 = new ReportParameter("LogoFile", logoUrl);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            this.reportViewer1.RefreshReport();
        }


        private void PopulateDraw()
        {
            int Offset, index, iColumn, iMoto, iRaceNo;
            bool bRightHand;
            Stopwatch stopwatch = Stopwatch.StartNew();

            /* Each Race has a Gate of 8 Lanes */
            raceList = DataService.GetRaceList(EventSelected);  /* this is race numbr order */
            if (raceList.Count==0)
            {
                return;
            }

            iColumn = 0;
            iMoto = raceList[0].Moto_No;

            foreach (Race r in raceList)
            {
                /* Set Column Number for Report Control */
                iColumn++;
                if (iColumn > 2)
                {
                    iColumn = 1;
                }
                if (r.Moto_No != iMoto)
                {
                    iColumn = 1;
                    iMoto = r.Moto_No;
                }
                /* 2 races side by side in motoDraw */
                if (iColumn == 1)
                {
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 1 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 2 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 3 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 4 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 5 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 6 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 7 });
                    motoDraw.Add(new MotoDraw() { Race_No = r.Race_No, Moto_No = r.Moto_No, Class_No = r.Class_No, Class_Name = r.Class_Name, Lane_No = 8 });
                }
                if (iColumn == 2)
                {
                    Offset = motoDraw.Count;

                    /* go back to motoDraw to fill in second race */
                    motoDraw[Offset - 8].Race_No2 = r.Race_No;
                    motoDraw[Offset - 8].Class_No2 = r.Class_No;
                    motoDraw[Offset - 8].Class_Name2 = r.Class_Name;
                    motoDraw[Offset - 7].Race_No2 = r.Race_No;
                    motoDraw[Offset - 6].Race_No2 = r.Race_No;
                    motoDraw[Offset - 5].Race_No2 = r.Race_No;
                    motoDraw[Offset - 4].Race_No2 = r.Race_No;
                    motoDraw[Offset - 3].Race_No2 = r.Race_No;
                    motoDraw[Offset - 2].Race_No2 = r.Race_No;
                    motoDraw[Offset - 1].Race_No2 = r.Race_No;
                 }
            }


            /* Get race draw and match to the motoDraw */
            List<Draw> drawList = new List<Draw>();
            drawList = DataService.GetRaceDraw(EventSelected);

            Offset = 0;
            iRaceNo = motoDraw[0].Race_No;
            bRightHand = false;

            foreach (Draw d in drawList)
            {
                if (d.Lane_No == 0)
                    continue;

                /* Find first entry for this race_no will be lane 1 */
                if (iRaceNo != d.Race_No)
                {
                    /* Seach left hand column in motoDraw
                     * Note end up earching 2x for all races on right hand side 
                     * If RacesPerMoto is even, all even race numbers are on right hand side, all odd on left had side
                     * If RacesPerMoto is odd, then odd, even, odd on left hand side and even, odd, even on right hand side 
                     * just search for it and be done.....*/

                    Offset = motoDraw.FindIndex(p => p.Race_No == d.Race_No);
                    if (Offset >= 0)
                    {
                        iRaceNo = d.Race_No;
                        bRightHand = false;
                    }
                    else
                    {
                        /* Seach right hand column in motoDraw */
                        Offset = motoDraw.FindIndex(p => p.Race_No2 == d.Race_No);
                        if (Offset >= 0)
                        {
                            iRaceNo = d.Race_No;
                            bRightHand = true;
                        }
                    }
                }
                if (Offset >= 0)
                {
                    index = Offset + (d.Lane_No - 1);
                    if (bRightHand==false)
                    {
                        motoDraw[index].Plate = d.Plate;
                        motoDraw[index].Full_Name = d.Full_Name;
                        motoDraw[index].Group = d.Group;
                    }
                    else
                    {
                        motoDraw[index].Plate2 = d.Plate;
                        motoDraw[index].Full_Name2 = d.Full_Name;
                        motoDraw[index].Group2 = d.Group;
                    }
                }
            }

            stopwatch.Stop();
            //MessageBox.Show("PopulateDraw(): "+stopwatch.ElapsedMilliseconds.ToString()); 
        }

     }
}
