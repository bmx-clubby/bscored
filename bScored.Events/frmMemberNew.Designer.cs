namespace WindowsFormsApp7
{
    partial class frmMemberNew
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMemberNew));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtLast_Name = new System.Windows.Forms.TextBox();
			this.lblFullName = new System.Windows.Forms.Label();
			this.txtFirst_Name = new System.Windows.Forms.TextBox();
			this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
			this.cboMembershipType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblLicense_No = new System.Windows.Forms.Label();
			this.txtMembership_No = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboGender = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dtpExpiresOn = new System.Windows.Forms.DateTimePicker();
			this.cboClubs = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtEmergency_Name = new System.Windows.Forms.TextBox();
			this.txtEmergency_Number = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(313, 500);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 29);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(192, 500);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(104, 29);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtLast_Name
			// 
			this.txtLast_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLast_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLast_Name.Location = new System.Drawing.Point(182, 127);
			this.txtLast_Name.MaxLength = 50;
			this.txtLast_Name.Name = "txtLast_Name";
			this.txtLast_Name.Size = new System.Drawing.Size(222, 26);
			this.txtLast_Name.TabIndex = 2;
			this.txtLast_Name.Leave += new System.EventHandler(this.txtLast_Name_Leave);
			// 
			// lblFullName
			// 
			this.lblFullName.AutoSize = true;
			this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFullName.Location = new System.Drawing.Point(86, 129);
			this.lblFullName.Name = "lblFullName";
			this.lblFullName.Size = new System.Drawing.Size(90, 20);
			this.lblFullName.TabIndex = 31;
			this.lblFullName.Text = "Last Name:";
			this.lblFullName.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtFirst_Name
			// 
			this.txtFirst_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFirst_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFirst_Name.Location = new System.Drawing.Point(182, 95);
			this.txtFirst_Name.MaxLength = 50;
			this.txtFirst_Name.Name = "txtFirst_Name";
			this.txtFirst_Name.Size = new System.Drawing.Size(222, 26);
			this.txtFirst_Name.TabIndex = 1;
			this.txtFirst_Name.Leave += new System.EventHandler(this.txtFirst_Name_Leave);
			// 
			// dtpBirthDate
			// 
			this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpBirthDate.Location = new System.Drawing.Point(182, 193);
			this.dtpBirthDate.Name = "dtpBirthDate";
			this.dtpBirthDate.Size = new System.Drawing.Size(121, 26);
			this.dtpBirthDate.TabIndex = 4;
			// 
			// cboMembershipType
			// 
			this.cboMembershipType.DisplayMember = "Open";
			this.cboMembershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMembershipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.cboMembershipType.FormattingEnabled = true;
			this.cboMembershipType.Items.AddRange(new object[] {
            "4 Month - Open",
            "4 Month - Sprocket Rocket",
            "BMX Mini Wheeler",
            "Open",
            "Sprocket Rocket",
            "Kids - All Discipline - 7yrs and under - Annual",
            "Race - All Discipline - U13 - Annual",
            "Race - All Discipline - Concession - Annual",
            "Race - All Discipline - Concession - Payment Plan",
            "Race - Off Road - Adult - Annual",
            "Race - Off Road - Adult - Payment Plan",
            "Race - All Discipline - Adult - Annual",
            "Race - All Discipline - Adult - Payment Plan",
            "Non-Riding - Annual",
            "All Discipline - 4 Week Free Trail"});
			this.cboMembershipType.Location = new System.Drawing.Point(182, 357);
			this.cboMembershipType.Name = "cboMembershipType";
			this.cboMembershipType.Size = new System.Drawing.Size(222, 28);
			this.cboMembershipType.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(87, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 20);
			this.label1.TabIndex = 36;
			this.label1.Text = "First Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblLicense_No
			// 
			this.lblLicense_No.AutoSize = true;
			this.lblLicense_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLicense_No.Location = new System.Drawing.Point(52, 327);
			this.lblLicense_No.Name = "lblLicense_No";
			this.lblLicense_No.Size = new System.Drawing.Size(124, 20);
			this.lblLicense_No.TabIndex = 38;
			this.lblLicense_No.Text = "Membership No:";
			// 
			// txtMembership_No
			// 
			this.txtMembership_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMembership_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMembership_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMembership_No.Location = new System.Drawing.Point(182, 325);
			this.txtMembership_No.MaxLength = 8;
			this.txtMembership_No.Name = "txtMembership_No";
			this.txtMembership_No.Size = new System.Drawing.Size(121, 26);
			this.txtMembership_No.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(130, 360);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 20);
			this.label2.TabIndex = 39;
			this.label2.Text = "Type:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(74, 197);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 20);
			this.label3.TabIndex = 40;
			this.label3.Text = "Birth of Date:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cboGender
			// 
			this.cboGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.cboGender.FormattingEnabled = true;
			this.cboGender.Items.AddRange(new object[] {
            "Female",
            "Male",
            "Undisclosed"});
			this.cboGender.Location = new System.Drawing.Point(182, 159);
			this.cboGender.Name = "cboGender";
			this.cboGender.Size = new System.Drawing.Size(121, 28);
			this.cboGender.TabIndex = 3;
			this.cboGender.Text = "Male";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(110, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 20);
			this.label4.TabIndex = 42;
			this.label4.Text = "Gender:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpStartDate.Location = new System.Drawing.Point(182, 391);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(121, 26);
			this.dtpStartDate.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(90, 397);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 20);
			this.label5.TabIndex = 44;
			this.label5.Text = "Start Date:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(87, 433);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 20);
			this.label6.TabIndex = 45;
			this.label6.Text = "Expires On:";
			// 
			// dtpExpiresOn
			// 
			this.dtpExpiresOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpExpiresOn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpExpiresOn.Location = new System.Drawing.Point(182, 423);
			this.dtpExpiresOn.Name = "dtpExpiresOn";
			this.dtpExpiresOn.Size = new System.Drawing.Size(121, 26);
			this.dtpExpiresOn.TabIndex = 10;
			// 
			// cboClubs
			// 
			this.cboClubs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboClubs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboClubs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboClubs.FormattingEnabled = true;
			this.cboClubs.Location = new System.Drawing.Point(182, 40);
			this.cboClubs.Margin = new System.Windows.Forms.Padding(6);
			this.cboClubs.Name = "cboClubs";
			this.cboClubs.Size = new System.Drawing.Size(276, 28);
			this.cboClubs.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(131, 43);
			this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 20);
			this.label7.TabIndex = 47;
			this.label7.Text = "Club:";
			// 
			// txtEmergency_Name
			// 
			this.txtEmergency_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmergency_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmergency_Name.Location = new System.Drawing.Point(182, 242);
			this.txtEmergency_Name.MaxLength = 50;
			this.txtEmergency_Name.Name = "txtEmergency_Name";
			this.txtEmergency_Name.Size = new System.Drawing.Size(222, 26);
			this.txtEmergency_Name.TabIndex = 5;
			// 
			// txtEmergency_Number
			// 
			this.txtEmergency_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmergency_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmergency_Number.Location = new System.Drawing.Point(182, 274);
			this.txtEmergency_Number.MaxLength = 50;
			this.txtEmergency_Number.Name = "txtEmergency_Number";
			this.txtEmergency_Number.Size = new System.Drawing.Size(222, 26);
			this.txtEmergency_Number.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(38, 244);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(139, 20);
			this.label8.TabIndex = 50;
			this.label8.Text = "Emergency Name:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(24, 276);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(153, 20);
			this.label9.TabIndex = 51;
			this.label9.Text = "Emergency Number:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(506, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 29);
			this.button1.TabIndex = 52;
			this.button1.Text = "New Club";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmMemberNew
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 556);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtEmergency_Number);
			this.Controls.Add(this.txtEmergency_Name);
			this.Controls.Add(this.cboClubs);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtpExpiresOn);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtpStartDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cboGender);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblLicense_No);
			this.Controls.Add(this.txtMembership_No);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboMembershipType);
			this.Controls.Add(this.dtpBirthDate);
			this.Controls.Add(this.txtFirst_Name);
			this.Controls.Add(this.txtLast_Name);
			this.Controls.Add(this.lblFullName);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMemberNew";
			this.Text = "Member Details";
			this.Load += new System.EventHandler(this.frmNewMember_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLast_Name;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFirst_Name;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cboMembershipType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLicense_No;
        private System.Windows.Forms.TextBox txtMembership_No;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpExpiresOn;
        private System.Windows.Forms.ComboBox cboClubs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmergency_Number;
        private System.Windows.Forms.TextBox txtEmergency_Name;
		private System.Windows.Forms.Button button1;
	}
}