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
    public partial class frmEventAdd : Form
    {
        private frmSeries frmParent;
        int SeriesSelected;
        int EventSelected;
        int k;

        public frmEventAdd(int SeriesID, frmSeries frm1)
        {
            InitializeComponent();

            frmParent = frm1;
            SeriesSelected = SeriesID;
        }

        private void frmEventAdd_Load(object sender, EventArgs e)
        {
            eventBindingSource.DataSource = DataService.GetEventList();
            if (dgvEvents.RowCount > 0)
            {
                dgvEvents.FirstDisplayedScrollingRowIndex = dgvEvents.RowCount - 1;
                dgvEvents.CurrentCell = dgvEvents.Rows[dgvEvents.RowCount - 1].Cells[0];
            }

        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Event obj = eventBindingSource.Current as Event;
            if (obj != null)
            {
                EventSelected = obj.EventID;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             if (DataService.AddSeriesEvent(SeriesSelected, EventSelected) != 0)
            {

                btnSave.Enabled = false;
                frmParent.EventsRefresh();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
