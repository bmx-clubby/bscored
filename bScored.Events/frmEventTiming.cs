using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class frmEventTiming : Form
    {
        public DateTime GateDropSelected { get; set; }
        int EventSelected;
        int RaceID;
        int IgnoreMode = 1;
         
        public frmEventTiming(int eventSelected, int raceID)
        {
            InitializeComponent();
            EventSelected = eventSelected;
            RaceID = raceID;
        }

        private void frmEventTiming_Load(object sender, EventArgs e)
        {
            bool RaceFound = true;
            //if (RaceID != 0)
            //{
            //    MessageBox.Show(RaceID.ToString());
            //}
            List<RaceTiming> t = DataService.GetRaceTiming(EventSelected);

            /* Find this Race or unacclocted Race for Rider on Gate */
            int index = t.FindIndex(c => c.RaceId == RaceID);
            if (index==-1)
            {
                RaceFound = false;
                index = t.FindIndex(c => c.RaceId == 0 && c.Type == 1 && c.Ignore==0);
            }
            dataGridView1.SuspendLayout();
 
            timingDataBindingSource.DataSource = t; // DataService.GetRaceTiming(EventSelected);

            /* Automatically select the gate drop, Move back 1, should be the Gate Drop */
            if (index>0)
            {
                timingDataBindingSource.Position = index - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[timingDataBindingSource.Position].Cells[0];
                RaceTiming obj = timingDataBindingSource.Current as RaceTiming;
                if (obj != null && obj.Transponder == "00-09992")
                {
                    GateDropSelected = obj.Timestamp;
                    //MessageBox.Show(obj.Transponder+" "+ GateDropSelected.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value.ToString() == "00-09992")
                {
                    row.DefaultCellStyle.BackColor = Color.Plum;
                    //row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (row.Cells[7].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            dataGridView1.ResumeLayout();
            if (RaceFound == false)
            {
//                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                
            }
            if (index>0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = index - 1;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(GateDropSelected.ToLongTimeString());
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RaceTiming obj = timingDataBindingSource.Current as RaceTiming;

            if (obj != null && obj.Ignore == 1)
            {
                IgnoreMode = 0;  /* Restore Selected Timing Data */
                btnIgnore.Text = "Restore...";
            }
            else
            {
                IgnoreMode = 1;  /* Ignore Seleted Timing Data */
                btnIgnore.Text = "Ignore...";
            }

            if (obj != null && obj.Transponder == "00-09992")
            {
                GateDropSelected = obj.Timestamp;

                dataGridView1.SuspendLayout();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[4].Value.ToString() == GateDropSelected.ToString() || row.Cells[1].Value.ToString() == "00-09992")
                    {
                        row.Cells[4].Style.BackColor = Color.Plum;
                        //row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (row.Cells[7].Value.ToString() == "1")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        row.Cells[4].Style.BackColor = Color.White;
                    }
                }
                dataGridView1.ResumeLayout();
            }
        }


        /* IgnoreMode is set when grid row is selected, 1=Ignore, 0=Restore */
        private void btnIgnore_Click(object sender, EventArgs e)
        {
            List<RaceTiming> timingSelected = new List<RaceTiming>();
            string lcMesssage;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                 MessageBox.Show("No Rows Selected !");
                 return;
            }

            if(IgnoreMode == 1)
                lcMesssage = "Ignore Selected Records ?";
            else
                lcMesssage = "Restore Selected Records ?";

            if (MessageBox.Show(lcMesssage, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                /* Update timingDataBindingSource ?? */
                if(IgnoreMode==1)
                     row.DefaultCellStyle.BackColor = Color.LightGray;
                else
                    row.DefaultCellStyle.BackColor = Color.White;

                timingSelected.Add(new RaceTiming() { ID = (int)row.Cells[6].Value });
            }
            
            DataService.UpdateRaceTimingIgnore(timingSelected, IgnoreMode);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<RaceTiming> timingSelected = new List<RaceTiming>(); ;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                 MessageBox.Show("No Rows Selected !");
                 return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                 timingSelected.Add(new RaceTiming() { ID = (int)row.Cells[6].Value });
            }

            if (MessageBox.Show("Delete Selected Records ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataService.DeleteRaceTimingSelected(timingSelected);

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                     dataGridView1.Rows.Remove(row);
                }
            }
         }


    }
    
}
