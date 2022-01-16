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
    public partial class frmDrawEdit : Form
    {
        Race thisRace;
        List<Draw> drawList;

        public frmDrawEdit(Race obj)
        {
            InitializeComponent();

            thisRace = obj;
        }

        private void frmDrawEdit_Load(object sender, EventArgs e)
        {
            //this.Text = thisRace.Moto_Name + " " + thisRace.Class_Name;
            lblRaceSelected.Text = thisRace.Moto_Name + " " + thisRace.Class_Name;
 
            //drawBindingSource.DataSource = DataService.GetRaceDrawByRace(EventId, Race_No);
            drawList = DataService.GetRaceDrawByMotoClass(thisRace);
            drawBindingSource.DataSource = drawList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataService.UpdateRaceDraw(drawList);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
