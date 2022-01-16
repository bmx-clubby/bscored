using bScored;
using bScoredDatabase;
using bScoredDatabase.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
	public partial class frmMemberNew : Form
	{
		List<Clubs> Clubs;
		public string Membership_No { get; set; }
		bool addmode = true;

		public frmMemberNew(string membership_no = "", Member member = null)
		{
			InitializeComponent();

			Settings currentSettings = DataService.LoadSettings();

			Clubs = DataService.GetClubList();

			cboClubs.DataSource = Clubs;
			cboClubs.DisplayMember = "Club";
			cboClubs.ValueMember = "Club_Code";
			//cboRiderClass.Text = "";

			/* This could be a setting from config file */
			cboClubs.SelectedValue = currentSettings.DefaultClub;         //"1-2-3";
			cboMembershipType.SelectedIndex = 3;                          //Open

			if (!string.IsNullOrEmpty(membership_no))
			{
				txtMembership_No.Text = membership_no;
			}

			/* We are Editing an Existing Member */
			if (member != null)
			{
				txtFirst_Name.Text = member.First_Name;
				txtLast_Name.Text = member.Last_Name;
				cboGender.Text = member.Gender;
				dtpBirthDate.Value = member.BirthDate;
				cboClubs.Text = member.Club;
				cboMembershipType.Text = member.Member_Type;
				dtpExpiresOn.Value = member.Financial_date;
				txtEmergency_Name.Text = member.Emergency_Contact_Person;
				txtEmergency_Number.Text = member.Emergency_Contact_Number;

				/* Need to Track if this is changed i.e. ChangeMembershipNo() required */
				txtMembership_No.Text = member.Membership_No;
				Membership_No = member.Membership_No;

				/* Make Controls Ready Only */
				txtFirst_Name.ReadOnly = true;
				txtLast_Name.ReadOnly = true;
				dtpBirthDate.Enabled = false;
				dtpStartDate.Enabled = false;

				addmode = false;
			}

			this.Text += (addmode == true) ? " - Add Mode" : " - Update Mode";
		}

		private void frmNewMember_Load(object sender, EventArgs e)
		{

		}


		private void btnSave_Click(object sender, EventArgs e)
		{
			/* Validation */
			if (string.IsNullOrEmpty(txtFirst_Name.Text))
			{
				MessageBox.Show("First Name is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				txtFirst_Name.Focus();
				return;
			}
			if (string.IsNullOrEmpty(txtLast_Name.Text))
			{
				MessageBox.Show("Last Name is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				txtLast_Name.Focus();
				return;
			}
			if (string.IsNullOrEmpty(txtMembership_No.Text))
			{
				MessageBox.Show("Membership No is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				txtMembership_No.Focus();
				return;
			}
			if (addmode || Membership_No != txtMembership_No.Text.Trim())
			{
				List<Member> m = DataService.FindMemberByNumber(txtMembership_No.Text.Trim());
				if (m.Count > 0)
				{
					MessageBox.Show("Membership No is Already Allocated.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					txtMembership_No.Focus();
					return;
				}
			}

			/* Need to do Race_Status as a shared Function, for AusCycling otherwise set true
             * Manually entering Membership Details so assume its active etc
            */
			Member member = new Member
			{
				Membership_No = txtMembership_No.Text.Trim(),
				First_Name = txtFirst_Name.Text,
				Last_Name = txtLast_Name.Text,
				BirthDate = dtpBirthDate.Value,
				Emergency_Contact_Person = txtEmergency_Name.Text,
				Emergency_Contact_Number = txtEmergency_Number.Text,
				Gender = cboGender.Text,
				Financial_date = dtpExpiresOn.Value,
				Status = "Active",
				Member_Type = cboMembershipType.Text,
				Club_Code = (string)cboClubs.SelectedValue,
				Club = cboClubs.Text,
				Race_Status = true
			};

			string msg = (addmode == true) ? "Add new Member " : "Update Member ";

			if (MessageBox.Show(msg + member.First_Name + " " + member.Last_Name, "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				this.DialogResult = DialogResult.Cancel;
				return;
			}

			if (addmode)
			{
				if (DataService.AddMember(member) > 0)
				{
					MessageBox.Show(Membership_No + ", " + member.First_Name + " " + member.Last_Name + " has been added.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

					Membership_No = member.Membership_No;
					this.DialogResult = DialogResult.OK;
					return;
				}

			}

			/* Existing Member -> Update the Member */
			using (var db = DatabaseConnection.GetConnection())
			{
				using (var transaction = db.BeginTransaction())
				{

					//Update using the existing membership number
					if (db.UpdateMemberFromUserForm(member, Membership_No, transaction) == 1)
					{

						//Process change to membership no
						if (Membership_No != member.Membership_No)
						{
							db.ChangeMembershipNumber(Membership_No, member.Membership_No, transaction);

						}
						transaction.Commit();

						MessageBox.Show(Membership_No + ", " + member.First_Name + " " + member.Last_Name + " has been updated.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

						Membership_No = member.Membership_No;
						this.DialogResult = DialogResult.OK;
						return;
					}
				}
			}

			this.DialogResult = DialogResult.Cancel;
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;

		}

		private void txtFirst_Name_Leave(object sender, EventArgs e)
		{
			CultureInfo culture_info = Thread.CurrentThread.CurrentCulture;
			TextInfo text_info = culture_info.TextInfo;
			txtFirst_Name.Text = text_info.ToTitleCase(txtFirst_Name.Text);

		}

		private void txtLast_Name_Leave(object sender, EventArgs e)
		{
			CultureInfo culture_info = Thread.CurrentThread.CurrentCulture;
			TextInfo text_info = culture_info.TextInfo;
			txtLast_Name.Text = text_info.ToTitleCase(txtLast_Name.Text);

		}

		private void button1_Click(object sender, EventArgs e)
		{
			var club = new Clubs();
			new frmClubEdit(club).ShowDialog();
			Clubs = DataService.GetClubList();
			cboClubs.DataSource = Clubs;
			cboClubs.SelectedValue = club.Club_Code;
		}
	}
}
