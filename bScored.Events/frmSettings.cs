using bScoredDatabase.Models;
using System;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var currentSettings = DataService.LoadSettings() ?? new Settings();

			currentSettings.DefaultClub = (clubsBindingSource.Current as Clubs).Club_Code;
			currentSettings.Host = txtHost.Text.Trim();
			currentSettings.UserName = txtUserName.Text.Trim();
			currentSettings.Password = txtPassword.Text.Trim();
			currentSettings.DestinationPath = txtDestinationPath.Text.Trim();
			currentSettings.PassingFile = txtPassingFile.Text.Trim();
			currentSettings.LogoFile = txtLogoFile.Text.Trim();
			currentSettings.TCPAddress = txtTCPAddress.Text.Trim();
			currentSettings.TCPPort = Int32.TryParse(txtTCPPort.Text.Trim(), out int port) ? port : currentSettings.TCPPort;


			if (String.IsNullOrWhiteSpace(currentSettings.PassingFile))
			{
				MessageBox.Show("Passing File is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (String.IsNullOrWhiteSpace(currentSettings.TCPAddress))
			{
				MessageBox.Show("TCP Address is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (!IPAddress.TryParse(currentSettings.TCPAddress, out IPAddress _))
			{
				MessageBox.Show("TCP Address is INVALID.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (String.IsNullOrWhiteSpace(txtTCPPort.Text))
			{
				MessageBox.Show("TCP Port is Required.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (!Int32.TryParse(txtTCPPort.Text.Trim(), out int temp) || temp <= 0)
			{
				MessageBox.Show("TCP Port must be a number greater than 0.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}


			DataService.SaveSettings(currentSettings);
			this.DialogResult = DialogResult.OK;


		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			var currentSettings = DataService.LoadSettings() ?? new Settings
			{
				//	DefaultClub PassingFile LogoFile    ReportLink  TCPAddress  TCPPort
				//C:\BMX\Passings\Track\Track.txt C:\BMX\manly_logo2.jpg manlywarringahbmx.com.au / 127.0.0.1   8910

				PassingFile = "C:\\BMX\\Passings\\Track\\Track.txt",
				TCPAddress = "127.0.0.1",
				TCPPort = 8910

			};

			clubsBindingSource.DataSource = DataService.GetClubList();

			if (!String.IsNullOrWhiteSpace(currentSettings.DefaultClub))
				ddlClubs.SelectedValue = currentSettings.DefaultClub;

			txtHost.Text = currentSettings.Host;
			txtUserName.Text = currentSettings.UserName;
			txtPassword.Text = currentSettings.Password;
			txtDestinationPath.Text = currentSettings.DestinationPath;

			txtPassingFile.Text = currentSettings.PassingFile;
			txtLogoFile.Text = currentSettings.LogoFile;
			txtTCPAddress.Text = currentSettings.TCPAddress;
			txtTCPPort.Text = currentSettings.TCPPort.ToString();

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.openFileDialog1.FileName = this.txtLogoFile.Text.Trim();
			this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
			var result = this.openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
				this.txtLogoFile.Text = this.openFileDialog1.FileName;
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void txtPassingFile_TextChanged(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void txtLogoFile_TextChanged(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.openFileDialog1.FileName = this.txtPassingFile.Text.Trim();
			this.openFileDialog1.Filter = "Text Files|*.txt;";
			var result = this.openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
				this.txtPassingFile.Text = this.openFileDialog1.FileName;
		}

		private void btnClubs_Click(object sender, EventArgs e)
		{
			new frmClubs().ShowDialog();
		}
	}
}
