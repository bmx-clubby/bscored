using bScoredDatabase.Models;
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
    public partial class frmClubs : Form
    {
		public frmClubs()
        {
            InitializeComponent();
        }

		private void LoadClubs()
		{
			this.bindingSource.DataSource = DataService.GetClubList();
		}

		private void frm_Load(object sender, EventArgs e)
		{
			LoadClubs();
		}

		private void btnNewClub_Click(object sender, EventArgs e)
		{
			new frmClubEdit(new Clubs()).ShowDialog();
			LoadClubs();
		}

		private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var club = this.bindingSource.Current as Clubs;
			new frmClubEdit(club).ShowDialog();
			LoadClubs();
			//this.dgList.ClearSelection();
		}
	}
}
