namespace WindowsFormsApp7
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.btnSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDestinationPath = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPassingFile = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtLogoFile = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnBrowseLogo = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTCPAddress = new System.Windows.Forms.TextBox();
			this.txtTCPPort = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ddlClubs = new System.Windows.Forms.ComboBox();
			this.clubsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnClubs = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.clubsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(337, 730);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(268, 45);
			this.btnSave.TabIndex = 48;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(159, 57);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 29);
			this.label2.TabIndex = 53;
			this.label2.Text = "Host Name:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtHost
			// 
			this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHost.Location = new System.Drawing.Point(307, 54);
			this.txtHost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(269, 35);
			this.txtHost.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(159, 106);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(141, 29);
			this.label3.TabIndex = 55;
			this.label3.Text = "User Name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtUserName
			// 
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserName.Location = new System.Drawing.Point(307, 103);
			this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(268, 35);
			this.txtUserName.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(170, 154);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 29);
			this.label4.TabIndex = 57;
			this.label4.Text = "Password:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(307, 152);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(268, 35);
			this.txtPassword.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(103, 203);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(193, 29);
			this.label5.TabIndex = 59;
			this.label5.Text = "Destination Path:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtDestinationPath
			// 
			this.txtDestinationPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDestinationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDestinationPath.Location = new System.Drawing.Point(307, 201);
			this.txtDestinationPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDestinationPath.Name = "txtDestinationPath";
			this.txtDestinationPath.Size = new System.Drawing.Size(515, 35);
			this.txtDestinationPath.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(173, 170);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(152, 29);
			this.label6.TabIndex = 61;
			this.label6.Text = "Passing File:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// txtPassingFile
			// 
			this.txtPassingFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassingFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassingFile.Location = new System.Drawing.Point(337, 168);
			this.txtPassingFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtPassingFile.Name = "txtPassingFile";
			this.txtPassingFile.Size = new System.Drawing.Size(514, 35);
			this.txtPassingFile.TabIndex = 6;
			this.txtPassingFile.TextChanged += new System.EventHandler(this.txtPassingFile_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(195, 109);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 29);
			this.label7.TabIndex = 63;
			this.label7.Text = "Club Logo:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// txtLogoFile
			// 
			this.txtLogoFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLogoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLogoFile.Location = new System.Drawing.Point(336, 109);
			this.txtLogoFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtLogoFile.Name = "txtLogoFile";
			this.txtLogoFile.Size = new System.Drawing.Size(514, 35);
			this.txtLogoFile.TabIndex = 7;
			this.txtLogoFile.TextChanged += new System.EventHandler(this.txtLogoFile_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(175, 57);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 29);
			this.label8.TabIndex = 65;
			this.label8.Text = "Default Club:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtHost);
			this.groupBox1.Controls.Add(this.txtUserName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDestinationPath);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(29, 448);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(979, 244);
			this.groupBox1.TabIndex = 66;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Website FTP Settings";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(337, 208);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(488, 25);
			this.label1.TabIndex = 67;
			this.label1.Text = "The location of the passings file created by the decoder";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// btnBrowseLogo
			// 
			this.btnBrowseLogo.Location = new System.Drawing.Point(747, 109);
			this.btnBrowseLogo.Name = "btnBrowseLogo";
			this.btnBrowseLogo.Size = new System.Drawing.Size(104, 35);
			this.btnBrowseLogo.TabIndex = 68;
			this.btnBrowseLogo.Text = "Browse";
			this.btnBrowseLogo.UseVisualStyleBackColor = true;
			this.btnBrowseLogo.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtTCPAddress);
			this.groupBox2.Controls.Add(this.txtTCPPort);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(35, 255);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(979, 164);
			this.groupBox2.TabIndex = 67;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Results Server Settings";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(154, 63);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 29);
			this.label9.TabIndex = 53;
			this.label9.Text = "IP Address:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.label9.Click += new System.EventHandler(this.label9_Click);
			// 
			// txtTCPAddress
			// 
			this.txtTCPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTCPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTCPAddress.Location = new System.Drawing.Point(307, 57);
			this.txtTCPAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTCPAddress.Name = "txtTCPAddress";
			this.txtTCPAddress.Size = new System.Drawing.Size(262, 35);
			this.txtTCPAddress.TabIndex = 2;
			// 
			// txtTCPPort
			// 
			this.txtTCPPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTCPPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTCPPort.Location = new System.Drawing.Point(307, 106);
			this.txtTCPPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTCPPort.Name = "txtTCPPort";
			this.txtTCPPort.Size = new System.Drawing.Size(262, 35);
			this.txtTCPPort.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(227, 108);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 29);
			this.label10.TabIndex = 55;
			this.label10.Text = "Port:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(176, 173);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(0, 29);
			this.label11.TabIndex = 57;
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(746, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 35);
			this.button1.TabIndex = 69;
			this.button1.Text = "Browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// ddlClubs
			// 
			this.ddlClubs.DataSource = this.clubsBindingSource;
			this.ddlClubs.DisplayMember = "Club";
			this.ddlClubs.FormattingEnabled = true;
			this.ddlClubs.Location = new System.Drawing.Point(342, 57);
			this.ddlClubs.Name = "ddlClubs";
			this.ddlClubs.Size = new System.Drawing.Size(274, 28);
			this.ddlClubs.TabIndex = 70;
			this.ddlClubs.ValueMember = "Club_Code";
			// 
			// clubsBindingSource
			// 
			this.clubsBindingSource.DataSource = typeof(bScoredDatabase.Models.Clubs);
			// 
			// btnClubs
			// 
			this.btnClubs.Location = new System.Drawing.Point(810, 14);
			this.btnClubs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnClubs.Name = "btnClubs";
			this.btnClubs.Size = new System.Drawing.Size(181, 29);
			this.btnClubs.TabIndex = 71;
			this.btnClubs.TabStop = false;
			this.btnClubs.Text = "Club List";
			this.btnClubs.UseVisualStyleBackColor = true;
			this.btnClubs.Click += new System.EventHandler(this.btnClubs_Click);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1029, 789);
			this.Controls.Add(this.btnClubs);
			this.Controls.Add(this.ddlClubs);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnBrowseLogo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtLogoFile);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtPassingFile);
			this.Controls.Add(this.btnSave);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettings";
			this.Text = "          ";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.clubsBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassingFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLogoFile;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnBrowseLogo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTCPAddress;
		private System.Windows.Forms.TextBox txtTCPPort;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox ddlClubs;
		private System.Windows.Forms.BindingSource clubsBindingSource;
		private System.Windows.Forms.Button btnClubs;
	}
}