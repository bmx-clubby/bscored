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
    public partial class frmRiderHistory : Form
    {
        string Membership_Selected;
        string Name_Selected;

        public frmRiderHistory(string Membership_No, string Full_Name)
        {
            InitializeComponent();
            Membership_Selected = Membership_No;
            Name_Selected = Full_Name;
        }

        private void frmRiderHistory_Load(object sender, EventArgs e)
        {
            lblRiderHistory.Text += Name_Selected;

            riderHistoryBindingSource.DataSource = DataService.GetRiderHistory(Membership_Selected);

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }
            
        }
    }
}
