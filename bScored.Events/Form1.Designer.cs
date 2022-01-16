namespace WindowsFormsApp7
{
    partial class Form1
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dgvRiders = new System.Windows.Forms.DataGridView();
			this.Chip_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Membership_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAddRider = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnEventOpen = new System.Windows.Forms.Button();
			this.btnDuplicateEvent = new System.Windows.Forms.Button();
			this.dgvEvents = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnMylapsSubscription = new System.Windows.Forms.Button();
			this.btnChipStatus = new System.Windows.Forms.Button();
			this.btnPrintRiders = new System.Windows.Forms.Button();
			this.lblNumberOfRiders = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnClassMoveDown = new System.Windows.Forms.Button();
			this.btnClassMoveUp = new System.Windows.Forms.Button();
			this.lblMergeMode = new System.Windows.Forms.Label();
			this.btnUnMerge = new System.Windows.Forms.Button();
			this.btnMerge = new System.Windows.Forms.Button();
			this.dgvClasses = new System.Windows.Forms.DataGridView();
			this.Race_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Merged_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MinEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnDeleteRaces = new System.Windows.Forms.Button();
			this.btnClearDraw = new System.Windows.Forms.Button();
			this.btnPrintDraw = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.Entry_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Draw_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.lblRaceStarttime = new System.Windows.Forms.Label();
			this.lblRace_No = new System.Windows.Forms.Label();
			this.dvgGateRiders = new System.Windows.Forms.DataGridView();
			this.btnScore = new System.Windows.Forms.Button();
			this.lblRaceCompleted = new System.Windows.Forms.Label();
			this.lblWebReport = new System.Windows.Forms.Label();
			this.btnWebsite = new System.Windows.Forms.Button();
			this.btnScoringOff = new System.Windows.Forms.Button();
			this.btnScoringOn = new System.Windows.Forms.Button();
			this.btnDisplay = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.btnPrintResults = new System.Windows.Forms.Button();
			this.btnGetTimes = new System.Windows.Forms.Button();
			this.lblRaceSelected = new System.Windows.Forms.Label();
			this.btnRaceClear = new System.Windows.Forms.Button();
			this.btnRacePrevious = new System.Windows.Forms.Button();
			this.btnRaceNext = new System.Windows.Forms.Button();
			this.dgvRaceResult = new System.Windows.Forms.DataGridView();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTimer = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entryNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.classNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clubDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.plateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.transponderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mergedFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ridersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entryNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.riderClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.raceNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.motoNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.classNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.raceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fullNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.transponderDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.finishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gateRidersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fullNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.plateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.transponderDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hillTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.finishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.placeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.motoPointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.raceResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvRiders)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvgGateRiders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRaceResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ridersBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riderClassBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.raceBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gateRidersBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.motoPointsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.raceResultBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvRiders
			// 
			this.dgvRiders.AllowUserToAddRows = false;
			this.dgvRiders.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvRiders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvRiders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvRiders.AutoGenerateColumns = false;
			this.dgvRiders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRiders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.clubDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.plateDataGridViewTextBoxColumn,
            this.transponderDataGridViewTextBoxColumn,
            this.mergedFromDataGridViewTextBoxColumn,
            this.Chip_Status,
            this.Membership_Status});
			this.dgvRiders.DataSource = this.ridersBindingSource;
			this.dgvRiders.Location = new System.Drawing.Point(7, 6);
			this.dgvRiders.Name = "dgvRiders";
			this.dgvRiders.ReadOnly = true;
			this.dgvRiders.RowTemplate.Height = 32;
			this.dgvRiders.Size = new System.Drawing.Size(925, 520);
			this.dgvRiders.TabIndex = 0;
			this.dgvRiders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRiders_CellDoubleClick);
			this.dgvRiders.VisibleChanged += new System.EventHandler(this.dgvRiders_VisibleChanged);
			this.dgvRiders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRiders_KeyDown);
			// 
			// Chip_Status
			// 
			this.Chip_Status.DataPropertyName = "Chip_Status";
			this.Chip_Status.HeaderText = "Chip_Status";
			this.Chip_Status.Name = "Chip_Status";
			this.Chip_Status.ReadOnly = true;
			this.Chip_Status.Visible = false;
			// 
			// Membership_Status
			// 
			this.Membership_Status.DataPropertyName = "Membership_Status";
			this.Membership_Status.HeaderText = "Membership_Status";
			this.Membership_Status.Name = "Membership_Status";
			this.Membership_Status.ReadOnly = true;
			this.Membership_Status.Visible = false;
			// 
			// btnAddRider
			// 
			this.btnAddRider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddRider.Location = new System.Drawing.Point(7, 532);
			this.btnAddRider.Name = "btnAddRider";
			this.btnAddRider.Size = new System.Drawing.Size(115, 37);
			this.btnAddRider.TabIndex = 1;
			this.btnAddRider.Text = "Add..";
			this.btnAddRider.UseVisualStyleBackColor = true;
			this.btnAddRider.Click += new System.EventHandler(this.btnAddRider_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(1, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1109, 625);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tabPage4.Controls.Add(this.btnSettings);
			this.tabPage4.Controls.Add(this.btnEventOpen);
			this.tabPage4.Controls.Add(this.btnDuplicateEvent);
			this.tabPage4.Controls.Add(this.dgvEvents);
			this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.tabPage4.Location = new System.Drawing.Point(4, 29);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage4.Size = new System.Drawing.Size(1101, 592);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Event";
			this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSettings.Location = new System.Drawing.Point(629, 445);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(132, 37);
			this.btnSettings.TabIndex = 6;
			this.btnSettings.TabStop = false;
			this.btnSettings.Text = "Settings...";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.button4_Click);
			// 
			// btnEventOpen
			// 
			this.btnEventOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEventOpen.Location = new System.Drawing.Point(14, 445);
			this.btnEventOpen.Name = "btnEventOpen";
			this.btnEventOpen.Size = new System.Drawing.Size(115, 37);
			this.btnEventOpen.TabIndex = 5;
			this.btnEventOpen.Text = "Open...";
			this.btnEventOpen.UseVisualStyleBackColor = true;
			this.btnEventOpen.Click += new System.EventHandler(this.btnEventOpen_Click);
			// 
			// btnDuplicateEvent
			// 
			this.btnDuplicateEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDuplicateEvent.Location = new System.Drawing.Point(135, 445);
			this.btnDuplicateEvent.Name = "btnDuplicateEvent";
			this.btnDuplicateEvent.Size = new System.Drawing.Size(115, 37);
			this.btnDuplicateEvent.TabIndex = 3;
			this.btnDuplicateEvent.Text = "New...";
			this.btnDuplicateEvent.UseVisualStyleBackColor = true;
			this.btnDuplicateEvent.Click += new System.EventHandler(this.btnDuplicateEvent_Click);
			// 
			// dgvEvents
			// 
			this.dgvEvents.AllowUserToAddRows = false;
			this.dgvEvents.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvEvents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEvents.AutoGenerateColumns = false;
			this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.dateDataGridViewTextBoxColumn,
            this.entryNoDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1});
			this.dgvEvents.DataSource = this.eventBindingSource;
			this.dgvEvents.Location = new System.Drawing.Point(7, 6);
			this.dgvEvents.Name = "dgvEvents";
			this.dgvEvents.ReadOnly = true;
			this.dgvEvents.RowTemplate.Height = 32;
			this.dgvEvents.Size = new System.Drawing.Size(911, 433);
			this.dgvEvents.TabIndex = 0;
			this.dgvEvents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellDoubleClick);
			this.dgvEvents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEvents_KeyDown);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Race_No";
			this.dataGridViewTextBoxColumn1.HeaderText = "Race No";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 95;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tabPage1.Controls.Add(this.btnMylapsSubscription);
			this.tabPage1.Controls.Add(this.btnChipStatus);
			this.tabPage1.Controls.Add(this.btnPrintRiders);
			this.tabPage1.Controls.Add(this.lblNumberOfRiders);
			this.tabPage1.Controls.Add(this.dgvRiders);
			this.tabPage1.Controls.Add(this.btnAddRider);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage1.Size = new System.Drawing.Size(1101, 592);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Riders";
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
			this.tabPage1.Leave += new System.EventHandler(this.tabPage1_Leave);
			// 
			// btnMylapsSubscription
			// 
			this.btnMylapsSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMylapsSubscription.Location = new System.Drawing.Point(858, 532);
			this.btnMylapsSubscription.Name = "btnMylapsSubscription";
			this.btnMylapsSubscription.Size = new System.Drawing.Size(115, 37);
			this.btnMylapsSubscription.TabIndex = 7;
			this.btnMylapsSubscription.Text = "Expired..";
			this.btnMylapsSubscription.UseVisualStyleBackColor = true;
			this.btnMylapsSubscription.Click += new System.EventHandler(this.btnMylaps_Click);
			// 
			// btnChipStatus
			// 
			this.btnChipStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChipStatus.Location = new System.Drawing.Point(979, 531);
			this.btnChipStatus.Name = "btnChipStatus";
			this.btnChipStatus.Size = new System.Drawing.Size(115, 37);
			this.btnChipStatus.TabIndex = 6;
			this.btnChipStatus.Text = "Chip Status";
			this.btnChipStatus.UseVisualStyleBackColor = true;
			this.btnChipStatus.Click += new System.EventHandler(this.btnChipStatus_Click);
			// 
			// btnPrintRiders
			// 
			this.btnPrintRiders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrintRiders.Location = new System.Drawing.Point(128, 532);
			this.btnPrintRiders.Name = "btnPrintRiders";
			this.btnPrintRiders.Size = new System.Drawing.Size(115, 37);
			this.btnPrintRiders.TabIndex = 5;
			this.btnPrintRiders.Text = "Print...";
			this.btnPrintRiders.UseVisualStyleBackColor = true;
			this.btnPrintRiders.Click += new System.EventHandler(this.btnPrintRiders_Click);
			// 
			// lblNumberOfRiders
			// 
			this.lblNumberOfRiders.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lblNumberOfRiders.AutoSize = true;
			this.lblNumberOfRiders.Location = new System.Drawing.Point(481, 537);
			this.lblNumberOfRiders.Name = "lblNumberOfRiders";
			this.lblNumberOfRiders.Size = new System.Drawing.Size(152, 24);
			this.lblNumberOfRiders.TabIndex = 2;
			this.lblNumberOfRiders.Text = "NumberOfRiders";
			this.lblNumberOfRiders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tabPage2.Controls.Add(this.btnClassMoveDown);
			this.tabPage2.Controls.Add(this.btnClassMoveUp);
			this.tabPage2.Controls.Add(this.lblMergeMode);
			this.tabPage2.Controls.Add(this.btnUnMerge);
			this.tabPage2.Controls.Add(this.btnMerge);
			this.tabPage2.Controls.Add(this.dgvClasses);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage2.Size = new System.Drawing.Size(1101, 592);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Classes";
			this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
			this.tabPage2.Leave += new System.EventHandler(this.tabPage2_Leave);
			// 
			// btnClassMoveDown
			// 
			this.btnClassMoveDown.Location = new System.Drawing.Point(829, 205);
			this.btnClassMoveDown.Name = "btnClassMoveDown";
			this.btnClassMoveDown.Size = new System.Drawing.Size(103, 37);
			this.btnClassMoveDown.TabIndex = 6;
			this.btnClassMoveDown.Text = "Move Dn";
			this.btnClassMoveDown.UseVisualStyleBackColor = true;
			this.btnClassMoveDown.Click += new System.EventHandler(this.btnClassMoveDown_Click);
			// 
			// btnClassMoveUp
			// 
			this.btnClassMoveUp.Location = new System.Drawing.Point(829, 94);
			this.btnClassMoveUp.Name = "btnClassMoveUp";
			this.btnClassMoveUp.Size = new System.Drawing.Size(103, 37);
			this.btnClassMoveUp.TabIndex = 5;
			this.btnClassMoveUp.Text = "Move Up";
			this.btnClassMoveUp.UseVisualStyleBackColor = true;
			this.btnClassMoveUp.Click += new System.EventHandler(this.btnClassMoveUp_Click);
			// 
			// lblMergeMode
			// 
			this.lblMergeMode.AutoSize = true;
			this.lblMergeMode.Location = new System.Drawing.Point(248, 326);
			this.lblMergeMode.Name = "lblMergeMode";
			this.lblMergeMode.Size = new System.Drawing.Size(198, 24);
			this.lblMergeMode.TabIndex = 4;
			this.lblMergeMode.Text = "Merge Mode Selected";
			// 
			// btnUnMerge
			// 
			this.btnUnMerge.Location = new System.Drawing.Point(127, 320);
			this.btnUnMerge.Name = "btnUnMerge";
			this.btnUnMerge.Size = new System.Drawing.Size(115, 37);
			this.btnUnMerge.TabIndex = 3;
			this.btnUnMerge.Text = "Unmerge";
			this.btnUnMerge.UseVisualStyleBackColor = true;
			this.btnUnMerge.Click += new System.EventHandler(this.btnUnMerge_Click);
			// 
			// btnMerge
			// 
			this.btnMerge.Location = new System.Drawing.Point(7, 321);
			this.btnMerge.Name = "btnMerge";
			this.btnMerge.Size = new System.Drawing.Size(115, 37);
			this.btnMerge.TabIndex = 2;
			this.btnMerge.Text = "Merge";
			this.btnMerge.UseVisualStyleBackColor = true;
			this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
			// 
			// dgvClasses
			// 
			this.dgvClasses.AllowUserToAddRows = false;
			this.dgvClasses.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvClasses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvClasses.AutoGenerateColumns = false;
			this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.entryNoDataGridViewTextBoxColumn,
            this.Race_No,
            this.Merged_To,
            this.MinEntry});
			this.dgvClasses.DataSource = this.riderClassBindingSource;
			this.dgvClasses.Location = new System.Drawing.Point(7, 6);
			this.dgvClasses.Name = "dgvClasses";
			this.dgvClasses.ReadOnly = true;
			this.dgvClasses.RowTemplate.Height = 32;
			this.dgvClasses.Size = new System.Drawing.Size(812, 309);
			this.dgvClasses.TabIndex = 0;
			this.dgvClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasses_CellClick);
			this.dgvClasses.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvClasses_CellFormatting);
			// 
			// Race_No
			// 
			this.Race_No.DataPropertyName = "Race_No";
			this.Race_No.HeaderText = "Racing";
			this.Race_No.Name = "Race_No";
			this.Race_No.ReadOnly = true;
			// 
			// Merged_To
			// 
			this.Merged_To.DataPropertyName = "Merged_To";
			this.Merged_To.HeaderText = "Merged To";
			this.Merged_To.Name = "Merged_To";
			this.Merged_To.ReadOnly = true;
			this.Merged_To.Width = 150;
			// 
			// MinEntry
			// 
			this.MinEntry.DataPropertyName = "MinEntry";
			this.MinEntry.HeaderText = "Min Entry";
			this.MinEntry.Name = "MinEntry";
			this.MinEntry.ReadOnly = true;
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tabPage3.Controls.Add(this.btnDeleteRaces);
			this.tabPage3.Controls.Add(this.btnClearDraw);
			this.tabPage3.Controls.Add(this.btnPrintDraw);
			this.tabPage3.Controls.Add(this.button3);
			this.tabPage3.Controls.Add(this.button2);
			this.tabPage3.Controls.Add(this.button1);
			this.tabPage3.Controls.Add(this.dataGridView3);
			this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.tabPage3.Location = new System.Drawing.Point(4, 29);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage3.Size = new System.Drawing.Size(1101, 592);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Draw";
			this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
			// 
			// btnDeleteRaces
			// 
			this.btnDeleteRaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeleteRaces.Location = new System.Drawing.Point(590, 466);
			this.btnDeleteRaces.Name = "btnDeleteRaces";
			this.btnDeleteRaces.Size = new System.Drawing.Size(115, 37);
			this.btnDeleteRaces.TabIndex = 6;
			this.btnDeleteRaces.Text = "Delete...";
			this.btnDeleteRaces.UseVisualStyleBackColor = true;
			this.btnDeleteRaces.Click += new System.EventHandler(this.btnDeleteRaces_Click);
			// 
			// btnClearDraw
			// 
			this.btnClearDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClearDraw.Location = new System.Drawing.Point(367, 466);
			this.btnClearDraw.Name = "btnClearDraw";
			this.btnClearDraw.Size = new System.Drawing.Size(115, 37);
			this.btnClearDraw.TabIndex = 5;
			this.btnClearDraw.Text = "Clear...";
			this.btnClearDraw.UseVisualStyleBackColor = true;
			this.btnClearDraw.Visible = false;
			this.btnClearDraw.Click += new System.EventHandler(this.btnClearDraw_Click);
			// 
			// btnPrintDraw
			// 
			this.btnPrintDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrintDraw.Location = new System.Drawing.Point(228, 466);
			this.btnPrintDraw.Name = "btnPrintDraw";
			this.btnPrintDraw.Size = new System.Drawing.Size(115, 37);
			this.btnPrintDraw.TabIndex = 4;
			this.btnPrintDraw.Text = "Print...";
			this.btnPrintDraw.UseVisualStyleBackColor = true;
			this.btnPrintDraw.Click += new System.EventHandler(this.btnPrintDraw_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(477, 466);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(115, 37);
			this.button3.TabIndex = 3;
			this.button3.Text = "Gates...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Visible = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(118, 466);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(115, 37);
			this.button2.TabIndex = 2;
			this.button2.Text = "Draw...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(8, 466);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(115, 37);
			this.button1.TabIndex = 1;
			this.button1.Text = "Create...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView3
			// 
			this.dataGridView3.AllowUserToAddRows = false;
			this.dataGridView3.AllowUserToDeleteRows = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView3.AutoGenerateColumns = false;
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.raceNoDataGridViewTextBoxColumn,
            this.motoNameDataGridViewTextBoxColumn,
            this.classNameDataGridViewTextBoxColumn1,
            this.Entry_No,
            this.Draw_No});
			this.dataGridView3.DataSource = this.raceBindingSource;
			this.dataGridView3.Location = new System.Drawing.Point(8, 7);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.ReadOnly = true;
			this.dataGridView3.RowTemplate.Height = 32;
			this.dataGridView3.Size = new System.Drawing.Size(696, 453);
			this.dataGridView3.TabIndex = 0;
			this.dataGridView3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellDoubleClick);
			this.dataGridView3.VisibleChanged += new System.EventHandler(this.dataGridView3_VisibleChanged);
			// 
			// Entry_No
			// 
			this.Entry_No.DataPropertyName = "Entry_No";
			this.Entry_No.HeaderText = "Entry No";
			this.Entry_No.Name = "Entry_No";
			this.Entry_No.ReadOnly = true;
			this.Entry_No.Width = 75;
			// 
			// Draw_No
			// 
			this.Draw_No.DataPropertyName = "Draw_No";
			this.Draw_No.HeaderText = "Draw No";
			this.Draw_No.Name = "Draw_No";
			this.Draw_No.ReadOnly = true;
			this.Draw_No.Width = 75;
			// 
			// tabPage5
			// 
			this.tabPage5.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tabPage5.Controls.Add(this.lblRaceStarttime);
			this.tabPage5.Controls.Add(this.lblRace_No);
			this.tabPage5.Controls.Add(this.dvgGateRiders);
			this.tabPage5.Controls.Add(this.btnScore);
			this.tabPage5.Controls.Add(this.lblRaceCompleted);
			this.tabPage5.Controls.Add(this.lblWebReport);
			this.tabPage5.Controls.Add(this.btnWebsite);
			this.tabPage5.Controls.Add(this.btnScoringOff);
			this.tabPage5.Controls.Add(this.btnScoringOn);
			this.tabPage5.Controls.Add(this.btnDisplay);
			this.tabPage5.Controls.Add(this.button6);
			this.tabPage5.Controls.Add(this.btnPrintResults);
			this.tabPage5.Controls.Add(this.btnGetTimes);
			this.tabPage5.Controls.Add(this.lblRaceSelected);
			this.tabPage5.Controls.Add(this.btnRaceClear);
			this.tabPage5.Controls.Add(this.btnRacePrevious);
			this.tabPage5.Controls.Add(this.btnRaceNext);
			this.tabPage5.Controls.Add(this.dgvRaceResult);
			this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.tabPage5.Location = new System.Drawing.Point(4, 29);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage5.Size = new System.Drawing.Size(1101, 592);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Score";
			this.tabPage5.Enter += new System.EventHandler(this.tabPage5_Enter);
			this.tabPage5.Leave += new System.EventHandler(this.tabPage5_Leave);
			// 
			// lblRaceStarttime
			// 
			this.lblRaceStarttime.AutoSize = true;
			this.lblRaceStarttime.BackColor = System.Drawing.Color.PeachPuff;
			this.lblRaceStarttime.Location = new System.Drawing.Point(508, 29);
			this.lblRaceStarttime.Name = "lblRaceStarttime";
			this.lblRaceStarttime.Size = new System.Drawing.Size(115, 24);
			this.lblRaceStarttime.TabIndex = 22;
			this.lblRaceStarttime.Text = "Race Start....";
			// 
			// lblRace_No
			// 
			this.lblRace_No.BackColor = System.Drawing.Color.Transparent;
			this.lblRace_No.Location = new System.Drawing.Point(647, 29);
			this.lblRace_No.Name = "lblRace_No";
			this.lblRace_No.Size = new System.Drawing.Size(151, 24);
			this.lblRace_No.TabIndex = 21;
			this.lblRace_No.Text = "NoOfRaces";
			this.lblRace_No.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dvgGateRiders
			// 
			this.dvgGateRiders.AllowUserToAddRows = false;
			this.dvgGateRiders.AllowUserToDeleteRows = false;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dvgGateRiders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dvgGateRiders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dvgGateRiders.AutoGenerateColumns = false;
			this.dvgGateRiders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dvgGateRiders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullNameDataGridViewTextBoxColumn2,
            this.transponderDataGridViewTextBoxColumn2,
            this.hillDataGridViewTextBoxColumn,
            this.finishDataGridViewTextBoxColumn,
            this.gateTimeDataGridViewTextBoxColumn});
			this.dvgGateRiders.DataSource = this.gateRidersBindingSource;
			this.dvgGateRiders.Location = new System.Drawing.Point(32, 417);
			this.dvgGateRiders.Name = "dvgGateRiders";
			this.dvgGateRiders.ReadOnly = true;
			this.dvgGateRiders.RowTemplate.Height = 32;
			this.dvgGateRiders.Size = new System.Drawing.Size(887, 112);
			this.dvgGateRiders.TabIndex = 20;
			this.dvgGateRiders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dvgGateRiders_CellFormatting);
			this.dvgGateRiders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dvgGateRiders_KeyDown);
			// 
			// btnScore
			// 
			this.btnScore.Location = new System.Drawing.Point(440, 356);
			this.btnScore.Name = "btnScore";
			this.btnScore.Size = new System.Drawing.Size(115, 37);
			this.btnScore.TabIndex = 19;
			this.btnScore.Text = "Score..";
			this.btnScore.UseVisualStyleBackColor = true;
			this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
			// 
			// lblRaceCompleted
			// 
			this.lblRaceCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRaceCompleted.AutoSize = true;
			this.lblRaceCompleted.BackColor = System.Drawing.Color.Transparent;
			this.lblRaceCompleted.Location = new System.Drawing.Point(771, 555);
			this.lblRaceCompleted.Name = "lblRaceCompleted";
			this.lblRaceCompleted.Size = new System.Drawing.Size(15, 24);
			this.lblRaceCompleted.TabIndex = 18;
			this.lblRaceCompleted.Text = ".";
			this.lblRaceCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblWebReport
			// 
			this.lblWebReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblWebReport.BackColor = System.Drawing.Color.Transparent;
			this.lblWebReport.Location = new System.Drawing.Point(492, 555);
			this.lblWebReport.Name = "lblWebReport";
			this.lblWebReport.Size = new System.Drawing.Size(285, 24);
			this.lblWebReport.TabIndex = 17;
			this.lblWebReport.Text = ".......................................................";
			this.lblWebReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnWebsite
			// 
			this.btnWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnWebsite.Location = new System.Drawing.Point(804, 549);
			this.btnWebsite.Name = "btnWebsite";
			this.btnWebsite.Size = new System.Drawing.Size(115, 37);
			this.btnWebsite.TabIndex = 16;
			this.btnWebsite.Text = "Website..";
			this.btnWebsite.UseVisualStyleBackColor = true;
			this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click);
			// 
			// btnScoringOff
			// 
			this.btnScoringOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnScoringOff.Location = new System.Drawing.Point(314, 549);
			this.btnScoringOff.Name = "btnScoringOff";
			this.btnScoringOff.Size = new System.Drawing.Size(119, 37);
			this.btnScoringOff.TabIndex = 15;
			this.btnScoringOff.Text = "Timer Off";
			this.btnScoringOff.UseVisualStyleBackColor = false;
			this.btnScoringOff.Click += new System.EventHandler(this.btnScoringOff_Click_1);
			// 
			// btnScoringOn
			// 
			this.btnScoringOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnScoringOn.Location = new System.Drawing.Point(192, 549);
			this.btnScoringOn.Name = "btnScoringOn";
			this.btnScoringOn.Size = new System.Drawing.Size(116, 37);
			this.btnScoringOn.TabIndex = 14;
			this.btnScoringOn.Text = "Timer On";
			this.btnScoringOn.UseVisualStyleBackColor = true;
			this.btnScoringOn.Click += new System.EventHandler(this.btnScoringOn_Click_1);
			// 
			// btnDisplay
			// 
			this.btnDisplay.Location = new System.Drawing.Point(804, 15);
			this.btnDisplay.Name = "btnDisplay";
			this.btnDisplay.Size = new System.Drawing.Size(115, 37);
			this.btnDisplay.TabIndex = 13;
			this.btnDisplay.Text = "Display...";
			this.btnDisplay.UseVisualStyleBackColor = true;
			this.btnDisplay.Click += new System.EventHandler(this.button7_Click_1);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button6.Location = new System.Drawing.Point(32, 549);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(151, 37);
			this.button6.TabIndex = 12;
			this.button6.Text = "Clear All Times";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// btnPrintResults
			// 
			this.btnPrintResults.Location = new System.Drawing.Point(153, 355);
			this.btnPrintResults.Name = "btnPrintResults";
			this.btnPrintResults.Size = new System.Drawing.Size(115, 37);
			this.btnPrintResults.TabIndex = 9;
			this.btnPrintResults.Text = "Print...";
			this.btnPrintResults.UseVisualStyleBackColor = true;
			this.btnPrintResults.Click += new System.EventHandler(this.btnPrintResults_Click);
			// 
			// btnGetTimes
			// 
			this.btnGetTimes.Location = new System.Drawing.Point(562, 355);
			this.btnGetTimes.Name = "btnGetTimes";
			this.btnGetTimes.Size = new System.Drawing.Size(115, 37);
			this.btnGetTimes.TabIndex = 7;
			this.btnGetTimes.Text = "Get Times..";
			this.btnGetTimes.UseVisualStyleBackColor = true;
			this.btnGetTimes.Click += new System.EventHandler(this.btnGetTimes_Click);
			// 
			// lblRaceSelected
			// 
			this.lblRaceSelected.AutoSize = true;
			this.lblRaceSelected.BackColor = System.Drawing.Color.PeachPuff;
			this.lblRaceSelected.Location = new System.Drawing.Point(28, 28);
			this.lblRaceSelected.Name = "lblRaceSelected";
			this.lblRaceSelected.Size = new System.Drawing.Size(153, 24);
			this.lblRaceSelected.TabIndex = 6;
			this.lblRaceSelected.Text = "Race Selected....";
			// 
			// btnRaceClear
			// 
			this.btnRaceClear.Location = new System.Drawing.Point(32, 355);
			this.btnRaceClear.Name = "btnRaceClear";
			this.btnRaceClear.Size = new System.Drawing.Size(115, 37);
			this.btnRaceClear.TabIndex = 5;
			this.btnRaceClear.Text = "Clear..";
			this.btnRaceClear.UseVisualStyleBackColor = true;
			this.btnRaceClear.Click += new System.EventHandler(this.btnRaceClear_Click);
			// 
			// btnRacePrevious
			// 
			this.btnRacePrevious.Location = new System.Drawing.Point(683, 355);
			this.btnRacePrevious.Name = "btnRacePrevious";
			this.btnRacePrevious.Size = new System.Drawing.Size(115, 37);
			this.btnRacePrevious.TabIndex = 4;
			this.btnRacePrevious.Text = "Previous..";
			this.btnRacePrevious.UseVisualStyleBackColor = true;
			this.btnRacePrevious.Click += new System.EventHandler(this.btnRacePrevious_Click);
			// 
			// btnRaceNext
			// 
			this.btnRaceNext.Location = new System.Drawing.Point(804, 355);
			this.btnRaceNext.Name = "btnRaceNext";
			this.btnRaceNext.Size = new System.Drawing.Size(115, 37);
			this.btnRaceNext.TabIndex = 3;
			this.btnRaceNext.Text = "Next..";
			this.btnRaceNext.UseVisualStyleBackColor = true;
			this.btnRaceNext.Click += new System.EventHandler(this.btnRace_Next_Click);
			// 
			// dgvRaceResult
			// 
			this.dgvRaceResult.AllowUserToAddRows = false;
			this.dgvRaceResult.AllowUserToDeleteRows = false;
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvRaceResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
			this.dgvRaceResult.AutoGenerateColumns = false;
			this.dgvRaceResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRaceResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullNameDataGridViewTextBoxColumn1,
            this.plateDataGridViewTextBoxColumn1,
            this.transponderDataGridViewTextBoxColumn1,
            this.hillTimeDataGridViewTextBoxColumn,
            this.finishTimeDataGridViewTextBoxColumn,
            this.placeDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
			this.dgvRaceResult.DataSource = this.raceResultBindingSource;
			this.dgvRaceResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvRaceResult.Location = new System.Drawing.Point(32, 56);
			this.dgvRaceResult.Name = "dgvRaceResult";
			this.dgvRaceResult.RowTemplate.Height = 32;
			this.dgvRaceResult.Size = new System.Drawing.Size(887, 294);
			this.dgvRaceResult.TabIndex = 0;
			this.dgvRaceResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRaceResult_CellClick);
			this.dgvRaceResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRaceResult_CellFormatting);
			this.dgvRaceResult.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRaceResult_CellValueChanged);
			this.dgvRaceResult.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRaceResult_CurrentCellDirtyStateChanged);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Chartreuse;
			this.panel1.Location = new System.Drawing.Point(930, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(16, 16);
			this.panel1.TabIndex = 5;
			// 
			// lblTimer
			// 
			this.lblTimer.AutoSize = true;
			this.lblTimer.Location = new System.Drawing.Point(891, 3);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new System.Drawing.Size(13, 13);
			this.lblTimer.TabIndex = 6;
			this.lblTimer.Text = "0";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// timer2
			// 
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 100;
			this.toolTip1.ShowAlways = true;
			// 
			// nameDataGridViewTextBoxColumn1
			// 
			this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
			this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
			this.nameDataGridViewTextBoxColumn1.Width = 350;
			// 
			// dateDataGridViewTextBoxColumn
			// 
			this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
			dataGridViewCellStyle3.Format = "d";
			dataGridViewCellStyle3.NullValue = null;
			this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
			this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
			this.dateDataGridViewTextBoxColumn.ReadOnly = true;
			this.dateDataGridViewTextBoxColumn.Width = 150;
			// 
			// entryNoDataGridViewTextBoxColumn1
			// 
			this.entryNoDataGridViewTextBoxColumn1.DataPropertyName = "Entry_No";
			this.entryNoDataGridViewTextBoxColumn1.HeaderText = "Entry No";
			this.entryNoDataGridViewTextBoxColumn1.Name = "entryNoDataGridViewTextBoxColumn1";
			this.entryNoDataGridViewTextBoxColumn1.ReadOnly = true;
			this.entryNoDataGridViewTextBoxColumn1.Width = 95;
			// 
			// eventBindingSource
			// 
			this.eventBindingSource.DataSource = typeof(WindowsFormsApp7.Event);
			// 
			// classNameDataGridViewTextBoxColumn
			// 
			this.classNameDataGridViewTextBoxColumn.DataPropertyName = "Class_Name";
			this.classNameDataGridViewTextBoxColumn.HeaderText = "Class";
			this.classNameDataGridViewTextBoxColumn.Name = "classNameDataGridViewTextBoxColumn";
			this.classNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.classNameDataGridViewTextBoxColumn.Width = 165;
			// 
			// fullNameDataGridViewTextBoxColumn
			// 
			this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "Full_Name";
			this.fullNameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
			this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.fullNameDataGridViewTextBoxColumn.Width = 225;
			// 
			// clubDataGridViewTextBoxColumn
			// 
			this.clubDataGridViewTextBoxColumn.DataPropertyName = "Club";
			this.clubDataGridViewTextBoxColumn.HeaderText = "Club";
			this.clubDataGridViewTextBoxColumn.Name = "clubDataGridViewTextBoxColumn";
			this.clubDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// ageDataGridViewTextBoxColumn
			// 
			this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
			this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
			this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
			this.ageDataGridViewTextBoxColumn.ReadOnly = true;
			this.ageDataGridViewTextBoxColumn.Width = 60;
			// 
			// plateDataGridViewTextBoxColumn
			// 
			this.plateDataGridViewTextBoxColumn.DataPropertyName = "Plate";
			this.plateDataGridViewTextBoxColumn.HeaderText = "Plate";
			this.plateDataGridViewTextBoxColumn.Name = "plateDataGridViewTextBoxColumn";
			this.plateDataGridViewTextBoxColumn.ReadOnly = true;
			this.plateDataGridViewTextBoxColumn.Width = 80;
			// 
			// transponderDataGridViewTextBoxColumn
			// 
			this.transponderDataGridViewTextBoxColumn.DataPropertyName = "Transponder";
			this.transponderDataGridViewTextBoxColumn.HeaderText = "Transponder";
			this.transponderDataGridViewTextBoxColumn.Name = "transponderDataGridViewTextBoxColumn";
			this.transponderDataGridViewTextBoxColumn.ReadOnly = true;
			this.transponderDataGridViewTextBoxColumn.Width = 125;
			// 
			// mergedFromDataGridViewTextBoxColumn
			// 
			this.mergedFromDataGridViewTextBoxColumn.DataPropertyName = "Merged_To";
			this.mergedFromDataGridViewTextBoxColumn.HeaderText = "Merged To";
			this.mergedFromDataGridViewTextBoxColumn.Name = "mergedFromDataGridViewTextBoxColumn";
			this.mergedFromDataGridViewTextBoxColumn.ReadOnly = true;
			this.mergedFromDataGridViewTextBoxColumn.Width = 125;
			// 
			// ridersBindingSource
			// 
			this.ridersBindingSource.DataSource = typeof(WindowsFormsApp7.Rider);
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Class";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.ReadOnly = true;
			this.nameDataGridViewTextBoxColumn.Width = 175;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
			this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
			this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			this.typeDataGridViewTextBoxColumn.ReadOnly = true;
			this.typeDataGridViewTextBoxColumn.Width = 125;
			// 
			// entryNoDataGridViewTextBoxColumn
			// 
			this.entryNoDataGridViewTextBoxColumn.DataPropertyName = "Entry_No";
			this.entryNoDataGridViewTextBoxColumn.HeaderText = "Entered";
			this.entryNoDataGridViewTextBoxColumn.Name = "entryNoDataGridViewTextBoxColumn";
			this.entryNoDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// riderClassBindingSource
			// 
			this.riderClassBindingSource.DataSource = typeof(WindowsFormsApp7.RiderClass);
			// 
			// raceNoDataGridViewTextBoxColumn
			// 
			this.raceNoDataGridViewTextBoxColumn.DataPropertyName = "Race_No";
			this.raceNoDataGridViewTextBoxColumn.HeaderText = "Race";
			this.raceNoDataGridViewTextBoxColumn.Name = "raceNoDataGridViewTextBoxColumn";
			this.raceNoDataGridViewTextBoxColumn.ReadOnly = true;
			this.raceNoDataGridViewTextBoxColumn.Width = 75;
			// 
			// motoNameDataGridViewTextBoxColumn
			// 
			this.motoNameDataGridViewTextBoxColumn.DataPropertyName = "Moto_Name";
			this.motoNameDataGridViewTextBoxColumn.HeaderText = "Moto";
			this.motoNameDataGridViewTextBoxColumn.Name = "motoNameDataGridViewTextBoxColumn";
			this.motoNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.motoNameDataGridViewTextBoxColumn.Width = 150;
			// 
			// classNameDataGridViewTextBoxColumn1
			// 
			this.classNameDataGridViewTextBoxColumn1.DataPropertyName = "Class_Name";
			this.classNameDataGridViewTextBoxColumn1.HeaderText = "Class";
			this.classNameDataGridViewTextBoxColumn1.Name = "classNameDataGridViewTextBoxColumn1";
			this.classNameDataGridViewTextBoxColumn1.ReadOnly = true;
			this.classNameDataGridViewTextBoxColumn1.Width = 215;
			// 
			// raceBindingSource
			// 
			this.raceBindingSource.DataSource = typeof(WindowsFormsApp7.Race);
			// 
			// fullNameDataGridViewTextBoxColumn2
			// 
			this.fullNameDataGridViewTextBoxColumn2.DataPropertyName = "Full_Name";
			this.fullNameDataGridViewTextBoxColumn2.HeaderText = "Name";
			this.fullNameDataGridViewTextBoxColumn2.Name = "fullNameDataGridViewTextBoxColumn2";
			this.fullNameDataGridViewTextBoxColumn2.ReadOnly = true;
			this.fullNameDataGridViewTextBoxColumn2.Width = 325;
			// 
			// transponderDataGridViewTextBoxColumn2
			// 
			this.transponderDataGridViewTextBoxColumn2.DataPropertyName = "Transponder";
			this.transponderDataGridViewTextBoxColumn2.HeaderText = "Transponder";
			this.transponderDataGridViewTextBoxColumn2.Name = "transponderDataGridViewTextBoxColumn2";
			this.transponderDataGridViewTextBoxColumn2.ReadOnly = true;
			this.transponderDataGridViewTextBoxColumn2.Width = 125;
			// 
			// hillDataGridViewTextBoxColumn
			// 
			this.hillDataGridViewTextBoxColumn.DataPropertyName = "Hill";
			dataGridViewCellStyle7.Format = "mm\\:ss\\.fff";
			this.hillDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
			this.hillDataGridViewTextBoxColumn.HeaderText = "HillTime";
			this.hillDataGridViewTextBoxColumn.Name = "hillDataGridViewTextBoxColumn";
			this.hillDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// finishDataGridViewTextBoxColumn
			// 
			this.finishDataGridViewTextBoxColumn.DataPropertyName = "Finish";
			dataGridViewCellStyle8.Format = "mm\\:ss\\.fff";
			this.finishDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
			this.finishDataGridViewTextBoxColumn.HeaderText = "FinishTime";
			this.finishDataGridViewTextBoxColumn.Name = "finishDataGridViewTextBoxColumn";
			this.finishDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// gateTimeDataGridViewTextBoxColumn
			// 
			this.gateTimeDataGridViewTextBoxColumn.DataPropertyName = "GateTime";
			dataGridViewCellStyle9.Format = "HH\\:mm\\:ss\\.fff";
			this.gateTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
			this.gateTimeDataGridViewTextBoxColumn.HeaderText = "GateTime";
			this.gateTimeDataGridViewTextBoxColumn.Name = "gateTimeDataGridViewTextBoxColumn";
			this.gateTimeDataGridViewTextBoxColumn.ReadOnly = true;
			this.gateTimeDataGridViewTextBoxColumn.Width = 175;
			// 
			// gateRidersBindingSource
			// 
			this.gateRidersBindingSource.DataSource = typeof(WindowsFormsApp7.GateRiders);
			// 
			// fullNameDataGridViewTextBoxColumn1
			// 
			this.fullNameDataGridViewTextBoxColumn1.DataPropertyName = "Full_Name";
			this.fullNameDataGridViewTextBoxColumn1.HeaderText = "Name";
			this.fullNameDataGridViewTextBoxColumn1.Name = "fullNameDataGridViewTextBoxColumn1";
			this.fullNameDataGridViewTextBoxColumn1.ReadOnly = true;
			this.fullNameDataGridViewTextBoxColumn1.Width = 225;
			// 
			// plateDataGridViewTextBoxColumn1
			// 
			this.plateDataGridViewTextBoxColumn1.DataPropertyName = "Plate";
			this.plateDataGridViewTextBoxColumn1.HeaderText = "Plate";
			this.plateDataGridViewTextBoxColumn1.Name = "plateDataGridViewTextBoxColumn1";
			this.plateDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// transponderDataGridViewTextBoxColumn1
			// 
			this.transponderDataGridViewTextBoxColumn1.DataPropertyName = "Transponder";
			this.transponderDataGridViewTextBoxColumn1.HeaderText = "Transponder";
			this.transponderDataGridViewTextBoxColumn1.Name = "transponderDataGridViewTextBoxColumn1";
			this.transponderDataGridViewTextBoxColumn1.ReadOnly = true;
			this.transponderDataGridViewTextBoxColumn1.Width = 125;
			// 
			// hillTimeDataGridViewTextBoxColumn
			// 
			this.hillTimeDataGridViewTextBoxColumn.DataPropertyName = "HillTime";
			dataGridViewCellStyle11.Format = "mm\\:ss\\.fff";
			this.hillTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
			this.hillTimeDataGridViewTextBoxColumn.HeaderText = "HillTime";
			this.hillTimeDataGridViewTextBoxColumn.Name = "hillTimeDataGridViewTextBoxColumn";
			this.hillTimeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// finishTimeDataGridViewTextBoxColumn
			// 
			this.finishTimeDataGridViewTextBoxColumn.DataPropertyName = "FinishTime";
			dataGridViewCellStyle12.Format = "mm\\:ss\\.fff";
			this.finishTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
			this.finishTimeDataGridViewTextBoxColumn.HeaderText = "FinishTime";
			this.finishTimeDataGridViewTextBoxColumn.Name = "finishTimeDataGridViewTextBoxColumn";
			this.finishTimeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// placeDataGridViewTextBoxColumn
			// 
			this.placeDataGridViewTextBoxColumn.DataPropertyName = "Place";
			this.placeDataGridViewTextBoxColumn.DataSource = this.motoPointsBindingSource;
			this.placeDataGridViewTextBoxColumn.DisplayMember = "Place";
			this.placeDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.placeDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.placeDataGridViewTextBoxColumn.HeaderText = "Place";
			this.placeDataGridViewTextBoxColumn.Name = "placeDataGridViewTextBoxColumn";
			this.placeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.placeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.placeDataGridViewTextBoxColumn.ValueMember = "Place";
			// 
			// motoPointsBindingSource
			// 
			this.motoPointsBindingSource.DataSource = typeof(WindowsFormsApp7.MotoPoints);
			// 
			// pointsDataGridViewTextBoxColumn
			// 
			this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
			this.pointsDataGridViewTextBoxColumn.HeaderText = "Points";
			this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
			this.pointsDataGridViewTextBoxColumn.Width = 75;
			// 
			// raceResultBindingSource
			// 
			this.raceResultBindingSource.DataSource = typeof(WindowsFormsApp7.RaceResult);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1111, 638);
			this.Controls.Add(this.lblTimer);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Event Riders";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvRiders)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvgGateRiders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvRaceResult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ridersBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riderClassBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.raceBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gateRidersBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.motoPointsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.raceResultBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRiders;
        private System.Windows.Forms.BindingSource ridersBindingSource;
        private System.Windows.Forms.Button btnAddRider;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.BindingSource riderClassBindingSource;
        private System.Windows.Forms.Label lblNumberOfRiders;
        private System.Windows.Forms.Button btnUnMerge;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label lblMergeMode;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.BindingSource raceBindingSource;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnClearDraw;
        private System.Windows.Forms.Button btnPrintDraw;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.Button btnDuplicateEvent;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnPrintRiders;
        private System.Windows.Forms.DataGridView dgvRaceResult;
        private System.Windows.Forms.BindingSource raceResultBindingSource;
        private System.Windows.Forms.Button btnRaceNext;
        private System.Windows.Forms.Button btnRacePrevious;
        private System.Windows.Forms.BindingSource motoPointsBindingSource;
        private System.Windows.Forms.Button btnRaceClear;
        private System.Windows.Forms.Label lblRaceSelected;
        private System.Windows.Forms.Button btnGetTimes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnPrintResults;
        private System.Windows.Forms.Button button6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnScoringOff;
        private System.Windows.Forms.Button btnScoringOn;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnChipStatus;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.Button btnMylapsSubscription;
        private System.Windows.Forms.Label lblWebReport;
        private System.Windows.Forms.Label lblRaceCompleted;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnEventOpen;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.DataGridView dvgGateRiders;
        private System.Windows.Forms.BindingSource gateRidersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transponderDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hillTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn placeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn transponderDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRace_No;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnDeleteRaces;
        private System.Windows.Forms.Label lblRaceStarttime;
        private System.Windows.Forms.Button btnClassMoveDown;
        private System.Windows.Forms.Button btnClassMoveUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn classNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transponderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mergedFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chip_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Membership_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Race_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merged_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motoNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Draw_No;
	}
}

