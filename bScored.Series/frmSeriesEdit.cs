using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bScoredSeries
{
    public partial class frmSeriesEdit : Form
    {
        public Series SeriesInfo { get; set; }
        public bool EventAddMode { get; set; }


        public frmSeriesEdit(Series obj, bool pAddMode)
        {
            InitializeComponent();

            SeriesInfo = obj;
            EventAddMode = pAddMode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void frmSeriesEdit_Load(object sender, EventArgs e)
        {
            txtEvent_Name.Text = SeriesInfo.Name;
            if (SeriesInfo.Date == DateTime.MinValue)
            {
                SeriesInfo.Date = DateTime.Now;
            }
            dtpEventDate.Value = SeriesInfo.Date;
            cboNoOfRounds.Text = SeriesInfo.Numer_of_Rounds.ToString();
            cboMinMandatory.Text = SeriesInfo.Min_Non_Mandatory.ToString();

            txtResult_File.Text = SeriesInfo.Result_File;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SeriesInfo.Name = txtEvent_Name.Text.Trim();
            SeriesInfo.Date = dtpEventDate.Value;
            SeriesInfo.Numer_of_Rounds = Convert.ToInt32(cboNoOfRounds.Text);
            SeriesInfo.Min_Non_Mandatory = Convert.ToInt32(cboMinMandatory.Text);

            SeriesInfo.Result_File = txtResult_File.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }
    }
}
