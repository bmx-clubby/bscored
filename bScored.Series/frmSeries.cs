using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using bScoredDatabase.Models;
using Renci.SshNet;


namespace bScoredSeries
{
    public partial class frmSeries : Form
    {
        Series thisSeries;
        Settings currentSettings;

        int SeriesSelected = 9;                                   


        public frmSeries()
        {
            InitializeComponent();
        }

        private void frmSeries_Load(object sender, EventArgs e)
        {
            currentSettings = DataService.LoadSettings();

            seriesBindingSource.DataSource = DataService.GetSeriesList();
            if (dgvSeries.RowCount > 0)
            {
                dgvSeries.FirstDisplayedScrollingRowIndex = dgvSeries.RowCount - 1;
                dgvSeries.CurrentCell = dgvSeries.Rows[dgvSeries.RowCount - 1].Cells[0];
            }

            var obj = seriesBindingSource.Current as Series;
            SelectSeries(obj);

        }


        private bool SelectSeries(Series obj, int mode = 0)
        {
            if (obj == null)
                return false;

            thisSeries = obj;
            SeriesSelected = thisSeries.SeriesID;

            this.Text = thisSeries.Name;

            //MessageBox.Show("Series Selected: "+SeriesSelected.ToString(), "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (currentSettings.Host != null && currentSettings.Host.Length > 0 && thisSeries.Result_File != null && thisSeries.Result_File.Trim().Length > 0)
                btnWebsite.Enabled = true;
            else
                btnWebsite.Enabled = false;

            //lblWebReport.Text = thisSeries.Result_File;

            return true;
        }


 
        private string CreateSeriesResultCSV(int SeriesSelected)
        {
            /* This is sorted by Class, Series_Points - NEED TO INCLUDE QUALIFIED...*/
            List<SeriesResults> sResults = DataService.GetSeriesResults(SeriesSelected);

            StringBuilder sb = new StringBuilder();

            /* Create the CSV File Header */
            sb.Append("Rank,Name,Club,Entered,Points");
            
            for(int i=1; i <= thisSeries.Numer_of_Rounds; i++)
            {
                sb.Append(", R"+i.ToString());
            }

            sb.Append(",Class");
            sb.AppendLine();

            int class_no = 0;
            int rank = 0;

            foreach (SeriesResults r in sResults)
            {
                if (r.Class_No != class_no)
                {
                    class_no = r.Class_No;
                    rank = 0;
                }

                //if (r.Type == "ALLMOTO")
                rank++;
                //else
                //rank = 1;                           // Sprockets and Mini Wheelers

                if (rank != 0)
                    sb.Append(rank.ToString() + ",");
                else
                    sb.Append(",");

                sb.Append(r.Full_Name + ",");
                sb.Append(r.Club + ",");
                sb.Append(r.Entered + ",");
                sb.Append(r.Series_Total.ToString() + ",");

                /* Note these are Nullable and if it is Null "" is returned */
                if (thisSeries.Numer_of_Rounds > 0)
                    sb.Append(r.R1_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 1)
                    sb.Append(r.R2_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 2)
                    sb.Append(r.R3_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 3)
                    sb.Append(r.R4_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 4)
                    sb.Append(r.R5_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 5)
                    sb.Append(r.R6_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 6)
                    sb.Append(r.R7_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 7)
                    sb.Append(r.R8_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 8)
                    sb.Append(r.R9_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 9)
                    sb.Append(r.R10_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 10)
                    sb.Append(r.R11_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 11)
                    sb.Append(r.R12_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 12)
                    sb.Append(r.R13_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 13)
                    sb.Append(r.R14_Total.ToString() + ",");
                if (thisSeries.Numer_of_Rounds > 14)
                    sb.Append(r.R15_Total.ToString() + ",");

                sb.Append(r.Class_Name);
                sb.AppendLine();
            }

            return sb.ToString();
        }


        private void SeriesResultsToWebsite()
        {
            /* SeriesSelected is set above */
            List<SeriesEvent> eventList = DataService.GetSeriesEvents(SeriesSelected);
            List<SeriesRider> riderList = new List<SeriesRider>();
            List<RaceResult> s;
            int RoundNumber = 0;

            Stopwatch stopwatch = Stopwatch.StartNew();

            /* Create Series Rider List from Riders in each Event then save to Table*/
            foreach (SeriesEvent v in eventList)
            {
                List<Rider> eventRiders = DataService.GetRiders(v.EventID);

                foreach (Rider r in eventRiders)
                {
                    if (riderList.FindIndex(c => c.Membership_No == r.Membership_No && c.Class_No == r.Class_No) == -1)
                    {
                        riderList.Add(new SeriesRider() { SeriesID = SeriesSelected, Membership_No = r.Membership_No, Class_No = r.Class_No, Class_Name = r.Class_Name });
                    }
                }
            }

            DataService.CreateSeriesRiders(SeriesSelected, riderList);
            //stopwatch.Stop();
            //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());

            /* Compute Resullts for each rider in each event */
            foreach (SeriesEvent v in eventList)
            {
                RoundNumber++;

                List<Rider> eventRiders = DataService.GetRiders(v.EventID);
                List<RaceResult> eventResults = DataService.GetRaceResults(v.EventID);

                foreach (Rider r in eventRiders)
                {
                    int round_total = 0;
                    TimeSpan hilltime, finishtime;

                    hilltime = TimeSpan.Zero;
                    finishtime = TimeSpan.Zero;

                    /* Get Results for this Rider for this Event and calcultae Series Total from their place in each race */
                    s = eventResults.FindAll(c => c.Membership_No == r.Membership_No);
                    foreach (RaceResult u in s)
                    {
                        /* No Series Points for DNS and DNF */
                        if (u.Place == "1st")
                        {
                            round_total += 10;
                        }
                        else if (u.Place == "2nd")
                        {
                            round_total += 8;
                        }
                        else if (u.Place == "3rd")
                        {
                            round_total += 6;
                        }
                        else if (u.Place == "4th")
                        {
                            round_total += 5;
                        }
                        else if (u.Place == "5th")
                        {
                            round_total += 4;
                        }
                        else if (u.Place == "6th")
                        {
                            round_total += 3;
                        }
                        else if (u.Place == "7th")
                        {
                            round_total += 2;
                        }
                        else if (u.Place == "8th")
                        {
                            round_total += 1;
                        }
                        else if (u.Place == "DNF")
                        {
                            round_total += 1;
                        }

                        hilltime = u.HillTime;
                        finishtime = u.FinishTime;
                    }

                    /* Write Round Total for this Rider to Database */
                    DataService.UpdateSeriesRider(SeriesSelected, r.Membership_No, r.Class_No, RoundNumber, round_total, hilltime, finishtime);
                }
            }

            DataService.UpdateSeriesTotals(SeriesSelected);

            stopwatch.Stop();
            MessageBox.Show("Update Series Totals: " + stopwatch.ElapsedMilliseconds.ToString(), "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string csvString = CreateSeriesResultCSV(SeriesSelected);

            if (thisSeries.Result_File == null || thisSeries.Result_File.Trim().Length == 0)
            {
                MessageBox.Show("This Series has no Report File configured...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pathLocalFile = Path.GetTempPath() + thisSeries.Result_File.Trim();
            MessageBox.Show("Report File: " + pathLocalFile, "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            File.WriteAllText(pathLocalFile, csvString);

 
            if (currentSettings.Host == null || currentSettings.Host.Length == 0)
            {
                MessageBox.Show("The Web Host is not configured...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string host = currentSettings.Host;
            string username = currentSettings.UserName;
            string password = currentSettings.Password;

            // Path to file on SFTP server 
            string destinationPath = currentSettings.DestinationPath;

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                sftp.ChangeDirectory(destinationPath);

                using (FileStream fs = new FileStream(pathLocalFile, FileMode.Open))
                {
                    sftp.BufferSize = 4 * 1024;
                    sftp.UploadFile(fs, Path.GetFileName(pathLocalFile));
                }
                sftp.Disconnect();
            }
 //           MessageBox.Show("Report Transferred to Web Host: ", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

 
        private void btnEventOpen_Click(object sender, EventArgs e)
        {
            var obj = seriesBindingSource.Current as Series;
            if (SelectSeries(obj) == true)
            {
                //MessageBox.Show(thisEvent.Name + " Selected..." + thisEvent.Date.Year.ToString() + "/" + thisEvent.Date.Month.ToString("D2"), "System Message");
                tabControl1.SelectedIndex = 1;
            }

        }

         public void EventsRefresh()
        {
            //dgvRiders.SuspendLayout();
            seriesEventBindingSource.DataSource = DataService.GetSeriesEvents(SeriesSelected);
            //dgvRiders.ResumeLayout();
            //ShowTotalRiders();
        }

        /* Page Events */
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            EventsRefresh();
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            //SeriesResultsToWebsite();

            //    return;

            //Open wait form dialog
            using (frmWaitForm frm = new frmWaitForm(SeriesResultsToWebsite))
            {
                frm.ShowDialog(this);
            }

        }

        private void dgvSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var obj = seriesBindingSource.Current as Series;
            if (obj == null)
            {
                return;
            }

            using (frmSeriesEdit frm = new frmSeriesEdit(obj, false))
            {
                DialogResult dr = frm.ShowDialog();
                /* pntr to Event Object is passed and is updated if "Save" is selected. */
                if (dr == DialogResult.OK)
                {
                    /* Save to Events Table */
                    seriesBindingSource.ResetBindings(false);

                    /* Update Event Table for this Event */
                    if (DataService.UpdateSeries(obj) == 1)
                    {
                        /* If this is the selectecd event need to reload event */
                        //if (obj.EventID == thisEvent.EventID)
                        //{
                        //    SelectEvent(obj, 1);        // Surpress Timer=Off
                        //    MessageBox.Show(obj.Name + " Updated.\nEvent Motos: " + EventMotos.ToString() + "\nResult File: " + thisEvent.Result_File, "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //{
                        MessageBox.Show(obj.Name + " Updated.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                }
            }

        }

        private void dgvSeries_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Delete))
            {
                return;
            }

            var obj = seriesBindingSource.Current as Series;
            if (obj == null)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete Series\n" + obj.Name, "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /* Delete from all associated Tables for this SeriesID
                  result[0] Delete from Series Table
                  result[1] Delete from Series_Events Table
                  result[2] Delete from Series_Ridres Table
               */
                int[] result = DataService.DeleteSeries(obj.SeriesID);

                seriesBindingSource.RemoveCurrent();
            }

        }

        private void btnSeriesNew_Click(object sender, EventArgs e)
        {
            Series newSeries = new Series();

            var obj = seriesBindingSource.Current as Series;
            if (obj != null)
            {
                newSeries.Name = obj.Name;
                newSeries.Date = obj.Date;
                newSeries.Numer_of_Rounds = obj.Numer_of_Rounds;
                newSeries.Min_Non_Mandatory = obj.Min_Non_Mandatory;
                newSeries.Result_File = obj.Result_File;
            }

            newSeries.Sponser = "";
            newSeries.Administrator = "";

            using (frmSeriesEdit frm = new frmSeriesEdit(newSeries, true))
            {
                DialogResult dr = frm.ShowDialog();

                /* pntr to Event Object is passed and is updated if "Save" is selected. */
                if (dr == DialogResult.OK)
                {
                    /* Create Event, note EventId is updated by CreateEvent() */
                    if (DataService.CreateSeries(newSeries) != 0)
                    {
                        seriesBindingSource.DataSource = DataService.GetSeriesList();
                        dgvSeries.FirstDisplayedScrollingRowIndex = dgvSeries.RowCount - 1;
                    }
                }
            }

        }


        private void btnAddRound_Click(object sender, EventArgs e)
        {
            //SeriesEvent obj = new SeriesEvent();
            //obj.SeriesID = SeriesSelected;

            /* If races are created need to add rider to race also */
            using (frmEventAdd frm = new frmEventAdd(SeriesSelected, this))
            {
                /* Can write to the form here... */
                DialogResult dr = frm.ShowDialog();

                /* pointr to Rider Object is passed and is updated if "Save" is selected. */
                if (dr == DialogResult.OK)
                {
                    //RidersRefresh();
                    //ridersBindingSource.DataSource = DataService.GetRiders(EventSelected);
                    //ShowTotalRiders();
                }
            }

        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                SeriesEvent obj = seriesEventBindingSource.Current as SeriesEvent;
                if (obj != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete " + obj.Name, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Delete from DB and if sucessful Delete from BindingSource
                        if (DataService.DeleteSeriesEvent(obj.ID) != 0)
                        {
                            seriesEventBindingSource.RemoveCurrent();
                        }
                    }
                }
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgvSeries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
