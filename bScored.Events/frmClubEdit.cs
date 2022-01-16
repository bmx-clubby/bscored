using bScoredDatabase.Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
	public partial class frmClubEdit : Form
	{

		private BindingSource bindingSource = new BindingSource();

		public Clubs Club { get; private set; }

		public frmClubEdit(Clubs club)
		{
			InitializeComponent();
			Club = club;
		}

		private void frm_Load(object sender, EventArgs e)
		{
			this.txtName.Text = Club.Club;
			this.txtGroup.Text = Club.Group;
			this.txtCode.Enabled = !String.IsNullOrWhiteSpace(Club.Club_Code);
			this.txtCode.ReadOnly = !String.IsNullOrWhiteSpace(Club.Club_Code);
			this.txtCode.Text = Club.Club_Code;
			
		}


		private void btnSave_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtName.Text))
			{
				MessageBox.Show("Club Name is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			this.Club.Club = this.txtName.Text.Trim();
			this.Club.Group = this.txtGroup.Text.Trim();

			this.Club = DataService.UpdateClub(this.Club);

			this.DialogResult = DialogResult.OK;
		}
	}
}
