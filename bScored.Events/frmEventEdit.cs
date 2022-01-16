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
    public partial class frmEventEdit : Form
    {
        public Event EventInfo { get; set; }
        public bool EventAddMode { get; set; }


        public frmEventEdit(Event obj, bool pAddMode)
        {
            InitializeComponent();

            EventInfo = obj;
            EventAddMode = pAddMode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void frmEventEdit_Load(object sender, EventArgs e)
        {
			if (EventInfo != null)
			{
				txtEvent_Name.Text = EventInfo.Name;
				dtpEventDate.Value = EventInfo.Date;
				cboMotos.Text = EventInfo.Moto_No.ToString();

				txtResult_File.Text = EventInfo.Result_File;
			}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventInfo.Name = txtEvent_Name.Text.Trim();
            EventInfo.Date = dtpEventDate.Value;
            EventInfo.Moto_No = Convert.ToInt32(cboMotos.Text);

            EventInfo.Result_File = txtResult_File.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }

    }
}
