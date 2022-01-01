namespace bScoredSeries
{
    partial class frmSeries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeries));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSeriesNew = new System.Windows.Forms.Button();
            this.btnEventOpen = new System.Windows.Forms.Button();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numer_of_Rounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minNonMandatoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblWebReport = new System.Windows.Forms.Label();
            this.btnAddRound = new System.Windows.Forms.Button();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesEventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabControl1.Location = new System.Drawing.Point(1, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 642);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.OldLace;
            this.tabPage1.Controls.Add(this.btnSeriesNew);
            this.tabPage1.Controls.Add(this.btnEventOpen);
            this.tabPage1.Controls.Add(this.dgvSeries);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 609);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Series";
            // 
            // btnSeriesNew
            // 
            this.btnSeriesNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeriesNew.Location = new System.Drawing.Point(128, 463);
            this.btnSeriesNew.Name = "btnSeriesNew";
            this.btnSeriesNew.Size = new System.Drawing.Size(115, 37);
            this.btnSeriesNew.TabIndex = 7;
            this.btnSeriesNew.Text = "New...";
            this.btnSeriesNew.UseVisualStyleBackColor = true;
            this.btnSeriesNew.Click += new System.EventHandler(this.btnSeriesNew_Click);
            // 
            // btnEventOpen
            // 
            this.btnEventOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEventOpen.Location = new System.Drawing.Point(7, 463);
            this.btnEventOpen.Name = "btnEventOpen";
            this.btnEventOpen.Size = new System.Drawing.Size(115, 37);
            this.btnEventOpen.TabIndex = 6;
            this.btnEventOpen.Text = "Open...";
            this.btnEventOpen.UseVisualStyleBackColor = true;
            this.btnEventOpen.Click += new System.EventHandler(this.btnEventOpen_Click);
            // 
            // dgvSeries
            // 
            this.dgvSeries.AllowUserToAddRows = false;
            this.dgvSeries.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSeries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeries.AutoGenerateColumns = false;
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.Numer_of_Rounds,
            this.minNonMandatoryDataGridViewTextBoxColumn});
            this.dgvSeries.DataSource = this.seriesBindingSource;
            this.dgvSeries.Location = new System.Drawing.Point(6, 6);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.ReadOnly = true;
            this.dgvSeries.RowTemplate.Height = 32;
            this.dgvSeries.Size = new System.Drawing.Size(693, 451);
            this.dgvSeries.TabIndex = 0;
            this.dgvSeries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeries_CellContentClick);
            this.dgvSeries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeries_CellDoubleClick);
            this.dgvSeries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSeries_KeyDown);
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 110;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 325;
            // 
            // Numer_of_Rounds
            // 
            this.Numer_of_Rounds.DataPropertyName = "Numer_of_Rounds";
            this.Numer_of_Rounds.HeaderText = "Rounds";
            this.Numer_of_Rounds.Name = "Numer_of_Rounds";
            this.Numer_of_Rounds.ReadOnly = true;
            // 
            // minNonMandatoryDataGridViewTextBoxColumn
            // 
            this.minNonMandatoryDataGridViewTextBoxColumn.DataPropertyName = "Min_Non_Mandatory";
            this.minNonMandatoryDataGridViewTextBoxColumn.HeaderText = "Mandatory";
            this.minNonMandatoryDataGridViewTextBoxColumn.Name = "minNonMandatoryDataGridViewTextBoxColumn";
            this.minNonMandatoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seriesBindingSource
            // 
            this.seriesBindingSource.DataSource = typeof(bScoredSeries.Series);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.OldLace;
            this.tabPage2.Controls.Add(this.lblWebReport);
            this.tabPage2.Controls.Add(this.btnAddRound);
            this.tabPage2.Controls.Add(this.btnWebsite);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 609);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Events";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // lblWebReport
            // 
            this.lblWebReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWebReport.BackColor = System.Drawing.Color.Transparent;
            this.lblWebReport.Location = new System.Drawing.Point(344, 550);
            this.lblWebReport.Name = "lblWebReport";
            this.lblWebReport.Size = new System.Drawing.Size(285, 24);
            this.lblWebReport.TabIndex = 18;
            this.lblWebReport.Text = ".......................................................";
            this.lblWebReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWebReport.Visible = false;
            // 
            // btnAddRound
            // 
            this.btnAddRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRound.Location = new System.Drawing.Point(8, 537);
            this.btnAddRound.Name = "btnAddRound";
            this.btnAddRound.Size = new System.Drawing.Size(115, 37);
            this.btnAddRound.TabIndex = 9;
            this.btnAddRound.Text = "Add..";
            this.btnAddRound.UseVisualStyleBackColor = true;
            this.btnAddRound.Click += new System.EventHandler(this.btnAddRound_Click);
            // 
            // btnWebsite
            // 
            this.btnWebsite.Location = new System.Drawing.Point(635, 537);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(115, 37);
            this.btnWebsite.TabIndex = 8;
            this.btnWebsite.Text = "Website...";
            this.btnWebsite.UseVisualStyleBackColor = true;
            this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.entryNoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.seriesEventBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(742, 524);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // dateDataGridViewTextBoxColumn1
            // 
            this.dateDataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn1.Name = "dateDataGridViewTextBoxColumn1";
            this.dateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn1.Width = 110;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.Width = 450;
            // 
            // entryNoDataGridViewTextBoxColumn
            // 
            this.entryNoDataGridViewTextBoxColumn.DataPropertyName = "Entry_No";
            this.entryNoDataGridViewTextBoxColumn.HeaderText = "Entry_No";
            this.entryNoDataGridViewTextBoxColumn.Name = "entryNoDataGridViewTextBoxColumn";
            this.entryNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seriesEventBindingSource
            // 
            this.seriesEventBindingSource.DataSource = typeof(bScoredSeries.SeriesEvent);
            // 
            // frmSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 667);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeries";
            this.Text = "Event Series";
            this.Load += new System.EventHandler(this.frmSeries_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesEventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.BindingSource seriesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numer_of_Rounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn minNonMandatoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnEventOpen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource seriesEventBindingSource;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.Button btnSeriesNew;
        private System.Windows.Forms.Button btnAddRound;
        private System.Windows.Forms.Label lblWebReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryNoDataGridViewTextBoxColumn;
    }
}

