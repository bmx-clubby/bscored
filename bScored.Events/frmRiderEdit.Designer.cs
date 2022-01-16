namespace WindowsFormsApp7
{
    partial class frmRiderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRiderEdit));
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblMembership_No = new System.Windows.Forms.Label();
            this.lblFinancial_date = new System.Windows.Forms.Label();
            this.lblClub = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.cboRiderClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTranspoders = new System.Windows.Forms.ComboBox();
            this.txtMembership_No = new System.Windows.Forms.TextBox();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClub = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExpiryStatus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberFindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddMember = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pboxStatus = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMember_Type = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmergency_Number = new System.Windows.Forms.TextBox();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmergency_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberFindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStatus)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Location = new System.Drawing.Point(166, 37);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(6);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(254, 29);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFullName.Location = new System.Drawing.Point(95, 40);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(66, 24);
            this.lblFullName.TabIndex = 29;
            this.lblFullName.Text = "Name:";
            // 
            // lblMembership_No
            // 
            this.lblMembership_No.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMembership_No.Location = new System.Drawing.Point(23, 57);
            this.lblMembership_No.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMembership_No.Name = "lblMembership_No";
            this.lblMembership_No.Size = new System.Drawing.Size(122, 48);
            this.lblMembership_No.TabIndex = 30;
            this.lblMembership_No.Text = "Membership No:";
            this.lblMembership_No.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFinancial_date
            // 
            this.lblFinancial_date.AutoSize = true;
            this.lblFinancial_date.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFinancial_date.Location = new System.Drawing.Point(77, 178);
            this.lblFinancial_date.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFinancial_date.Name = "lblFinancial_date";
            this.lblFinancial_date.Size = new System.Drawing.Size(68, 24);
            this.lblFinancial_date.TabIndex = 31;
            this.lblFinancial_date.Text = "Expiry:";
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblClub.Location = new System.Drawing.Point(92, 142);
            this.lblClub.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblClub.Name = "lblClub";
            this.lblClub.Size = new System.Drawing.Size(54, 24);
            this.lblClub.TabIndex = 32;
            this.lblClub.Text = "Club:";
            // 
            // txtPlate
            // 
            this.txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlate.Location = new System.Drawing.Point(144, 19);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(6);
            this.txtPlate.MaxLength = 10;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(79, 29);
            this.txtPlate.TabIndex = 5;
            // 
            // cboRiderClass
            // 
            this.cboRiderClass.FormattingEnabled = true;
            this.cboRiderClass.Location = new System.Drawing.Point(144, 55);
            this.cboRiderClass.Margin = new System.Windows.Forms.Padding(6);
            this.cboRiderClass.Name = "cboRiderClass";
            this.cboRiderClass.Size = new System.Drawing.Size(194, 32);
            this.cboRiderClass.TabIndex = 6;
            this.cboRiderClass.SelectedIndexChanged += new System.EventHandler(this.cboRiderClass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Plate:";
            // 
            // cboTranspoders
            // 
            this.cboTranspoders.FormattingEnabled = true;
            this.cboTranspoders.Location = new System.Drawing.Point(144, 94);
            this.cboTranspoders.Margin = new System.Windows.Forms.Padding(6);
            this.cboTranspoders.MaxLength = 10;
            this.cboTranspoders.Name = "cboTranspoders";
            this.cboTranspoders.Size = new System.Drawing.Size(157, 32);
            this.cboTranspoders.TabIndex = 7;
            // 
            // txtMembership_No
            // 
            this.txtMembership_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMembership_No.Location = new System.Drawing.Point(166, 91);
            this.txtMembership_No.Margin = new System.Windows.Forms.Padding(6);
            this.txtMembership_No.Name = "txtMembership_No";
            this.txtMembership_No.ReadOnly = true;
            this.txtMembership_No.Size = new System.Drawing.Size(134, 29);
            this.txtMembership_No.TabIndex = 1;
            // 
            // txtExpiry
            // 
            this.txtExpiry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpiry.Location = new System.Drawing.Point(149, 176);
            this.txtExpiry.Margin = new System.Windows.Forms.Padding(6);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.ReadOnly = true;
            this.txtExpiry.Size = new System.Drawing.Size(125, 29);
            this.txtExpiry.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "Transponder:";
            // 
            // txtClub
            // 
            this.txtClub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClub.Location = new System.Drawing.Point(149, 140);
            this.txtClub.Margin = new System.Windows.Forms.Padding(6);
            this.txtClub.Name = "txtClub";
            this.txtClub.ReadOnly = true;
            this.txtClub.Size = new System.Drawing.Size(346, 29);
            this.txtClub.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 39;
            this.label3.Text = "Class:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(136, 663);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 37);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 664);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 37);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblExpiryStatus
            // 
            this.lblExpiryStatus.AutoSize = true;
            this.lblExpiryStatus.Location = new System.Drawing.Point(286, 181);
            this.lblExpiryStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblExpiryStatus.Name = "lblExpiryStatus";
            this.lblExpiryStatus.Size = new System.Drawing.Size(118, 24);
            this.lblExpiryStatus.TabIndex = 52;
            this.lblExpiryStatus.Text = "Expiry Status";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullNameDataGridViewTextBoxColumn,
            this.clubDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.membershipNoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.memberFindBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(543, 34);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(484, 420);
            this.dataGridView1.TabIndex = 56;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // clubDataGridViewTextBoxColumn
            // 
            this.clubDataGridViewTextBoxColumn.DataPropertyName = "Club";
            this.clubDataGridViewTextBoxColumn.HeaderText = "Club";
            this.clubDataGridViewTextBoxColumn.Name = "clubDataGridViewTextBoxColumn";
            this.clubDataGridViewTextBoxColumn.ReadOnly = true;
            this.clubDataGridViewTextBoxColumn.Width = 75;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            this.ageDataGridViewTextBoxColumn.Width = 50;
            // 
            // membershipNoDataGridViewTextBoxColumn
            // 
            this.membershipNoDataGridViewTextBoxColumn.DataPropertyName = "Membership_No";
            this.membershipNoDataGridViewTextBoxColumn.HeaderText = "License";
            this.membershipNoDataGridViewTextBoxColumn.Name = "membershipNoDataGridViewTextBoxColumn";
            this.membershipNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // memberFindBindingSource
            // 
            this.memberFindBindingSource.DataSource = typeof(WindowsFormsApp7.MemberFind);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.Location = new System.Drawing.Point(543, 498);
            this.btnAddMember.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(115, 37);
            this.btnAddMember.TabIndex = 57;
            this.btnAddMember.Text = "New Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pboxStatus
            // 
            this.pboxStatus.Location = new System.Drawing.Point(107, 445);
            this.pboxStatus.Margin = new System.Windows.Forms.Padding(6);
            this.pboxStatus.Name = "pboxStatus";
            this.pboxStatus.Size = new System.Drawing.Size(48, 42);
            this.pboxStatus.TabIndex = 58;
            this.pboxStatus.TabStop = false;
            this.pboxStatus.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(168, 450);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(97, 33);
            this.lblStatus.TabIndex = 59;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtMember_Type);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Controls.Add(this.lblExpiryStatus);
            this.panel1.Controls.Add(this.lblFinancial_date);
            this.panel1.Controls.Add(this.txtExpiry);
            this.panel1.Controls.Add(this.txtClub);
            this.panel1.Controls.Add(this.lblClub);
            this.panel1.Controls.Add(this.lblMembership_No);
            this.panel1.Location = new System.Drawing.Point(15, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 222);
            this.panel1.TabIndex = 60;
            // 
            // txtMember_Type
            // 
            this.txtMember_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMember_Type.Location = new System.Drawing.Point(150, 104);
            this.txtMember_Type.Margin = new System.Windows.Forms.Padding(6);
            this.txtMember_Type.Name = "txtMember_Type";
            this.txtMember_Type.ReadOnly = true;
            this.txtMember_Type.Size = new System.Drawing.Size(345, 29);
            this.txtMember_Type.TabIndex = 78;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblSearch.Location = new System.Drawing.Point(148, 46);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(259, 13);
            this.lblSearch.TabIndex = 77;
            this.lblSearch.Text = "Enter Name, QR Code, Membership No, Transponder";
            this.lblSearch.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(87, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 24);
            this.label8.TabIndex = 76;
            this.label8.Text = "Type:";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(380, 65);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(115, 37);
            this.btnModify.TabIndex = 64;
            this.btnModify.Text = "Modify...";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 37);
            this.button1.TabIndex = 63;
            this.button1.Text = "History...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtEmergency_Number);
            this.panel2.Controls.Add(this.txtBirthDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtAge);
            this.panel2.Controls.Add(this.txtGender);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtEmergency_Name);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(16, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 180);
            this.panel2.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 142);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 24);
            this.label10.TabIndex = 83;
            this.label10.Text = "Number:";
            // 
            // txtEmergency_Number
            // 
            this.txtEmergency_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmergency_Number.Location = new System.Drawing.Point(148, 141);
            this.txtEmergency_Number.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmergency_Number.Name = "txtEmergency_Number";
            this.txtEmergency_Number.ReadOnly = true;
            this.txtEmergency_Number.Size = new System.Drawing.Size(200, 29);
            this.txtEmergency_Number.TabIndex = 82;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBirthDate.Location = new System.Drawing.Point(148, 14);
            this.txtBirthDate.Margin = new System.Windows.Forms.Padding(6);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.ReadOnly = true;
            this.txtBirthDate.Size = new System.Drawing.Size(125, 29);
            this.txtBirthDate.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 59);
            this.label5.TabIndex = 76;
            this.label5.Text = "Emergency Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "Age:";
            // 
            // txtAge
            // 
            this.txtAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAge.Location = new System.Drawing.Point(343, 14);
            this.txtAge.Margin = new System.Windows.Forms.Padding(6);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(50, 29);
            this.txtAge.TabIndex = 74;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(148, 49);
            this.txtGender.Margin = new System.Windows.Forms.Padding(6);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(125, 29);
            this.txtGender.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 24);
            this.label6.TabIndex = 77;
            this.label6.Text = "Gender:";
            // 
            // txtEmergency_Name
            // 
            this.txtEmergency_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmergency_Name.Location = new System.Drawing.Point(148, 106);
            this.txtEmergency_Name.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmergency_Name.Name = "txtEmergency_Name";
            this.txtEmergency_Name.ReadOnly = true;
            this.txtEmergency_Name.Size = new System.Drawing.Size(200, 29);
            this.txtEmergency_Name.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 24);
            this.label7.TabIndex = 81;
            this.label7.Text = "Birth Date:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cboTranspoders);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cboRiderClass);
            this.panel3.Controls.Add(this.txtPlate);
            this.panel3.Location = new System.Drawing.Point(16, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 143);
            this.panel3.TabIndex = 75;
            // 
            // frmRiderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 709);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pboxStatus);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtMembership_No);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRiderEdit";
            this.Text = "Rider Details";
            this.Load += new System.EventHandler(this.frmRiderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberFindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblMembership_No;
        private System.Windows.Forms.Label lblFinancial_date;
        private System.Windows.Forms.Label lblClub;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.ComboBox cboRiderClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTranspoders;
        private System.Windows.Forms.TextBox txtMembership_No;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExpiryStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource memberFindBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pboxStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmergency_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmergency_Number;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMember_Type;
    }
}