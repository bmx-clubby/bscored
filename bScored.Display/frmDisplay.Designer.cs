namespace WindowsFormsApp1
{
    partial class frmDisplay
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplay));
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.dgvDisplay = new System.Windows.Forms.DataGridView();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblRaceSelected = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.placeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.plateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hillTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.finishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.raceResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.raceResultBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// txtStatus
			// 
			this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStatus.Location = new System.Drawing.Point(18, 897);
			this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtStatus.Multiline = true;
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.Size = new System.Drawing.Size(2539, 44);
			this.txtStatus.TabIndex = 16;
			// 
			// dgvDisplay
			// 
			this.dgvDisplay.AllowUserToAddRows = false;
			this.dgvDisplay.AllowUserToDeleteRows = false;
			this.dgvDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDisplay.AutoGenerateColumns = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.placeDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.plateDataGridViewTextBoxColumn,
            this.hillTimeDataGridViewTextBoxColumn,
            this.finishTimeDataGridViewTextBoxColumn});
			this.dgvDisplay.DataSource = this.raceResultBindingSource;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDisplay.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvDisplay.Location = new System.Drawing.Point(18, 225);
			this.dgvDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dgvDisplay.Name = "dgvDisplay";
			this.dgvDisplay.ReadOnly = true;
			this.dgvDisplay.RowTemplate.Height = 90;
			this.dgvDisplay.RowTemplate.ReadOnly = true;
			this.dgvDisplay.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDisplay.Size = new System.Drawing.Size(2523, 643);
			this.dgvDisplay.TabIndex = 17;
			this.dgvDisplay.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDisplay_CellFormatting);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(18, 5);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(432, 180);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 18;
			this.pictureBox1.TabStop = false;
			// 
			// lblRaceSelected
			// 
			this.lblRaceSelected.AutoSize = true;
			this.lblRaceSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
			this.lblRaceSelected.Location = new System.Drawing.Point(1178, 140);
			this.lblRaceSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblRaceSelected.Name = "lblRaceSelected";
			this.lblRaceSelected.Size = new System.Drawing.Size(455, 64);
			this.lblRaceSelected.TabIndex = 19;
			this.lblRaceSelected.Text = "Race Selected....";
			this.lblRaceSelected.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(750, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 82);
			this.label1.TabIndex = 20;
			this.label1.Text = "...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// placeDataGridViewTextBoxColumn
			// 
			this.placeDataGridViewTextBoxColumn.DataPropertyName = "Place";
			this.placeDataGridViewTextBoxColumn.HeaderText = "Place";
			this.placeDataGridViewTextBoxColumn.Name = "placeDataGridViewTextBoxColumn";
			this.placeDataGridViewTextBoxColumn.ReadOnly = true;
			this.placeDataGridViewTextBoxColumn.Width = 140;
			// 
			// fullNameDataGridViewTextBoxColumn
			// 
			this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "Full_Name";
			this.fullNameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
			this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.fullNameDataGridViewTextBoxColumn.Width = 800;
			// 
			// plateDataGridViewTextBoxColumn
			// 
			this.plateDataGridViewTextBoxColumn.DataPropertyName = "Plate";
			this.plateDataGridViewTextBoxColumn.HeaderText = "Plate";
			this.plateDataGridViewTextBoxColumn.Name = "plateDataGridViewTextBoxColumn";
			this.plateDataGridViewTextBoxColumn.ReadOnly = true;
			this.plateDataGridViewTextBoxColumn.Width = 275;
			// 
			// hillTimeDataGridViewTextBoxColumn
			// 
			this.hillTimeDataGridViewTextBoxColumn.DataPropertyName = "HillTime";
			dataGridViewCellStyle2.Format = "mm\\:ss\\.fff";
			this.hillTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.hillTimeDataGridViewTextBoxColumn.HeaderText = "Hill Time";
			this.hillTimeDataGridViewTextBoxColumn.Name = "hillTimeDataGridViewTextBoxColumn";
			this.hillTimeDataGridViewTextBoxColumn.ReadOnly = true;
			this.hillTimeDataGridViewTextBoxColumn.Width = 250;
			// 
			// finishTimeDataGridViewTextBoxColumn
			// 
			this.finishTimeDataGridViewTextBoxColumn.DataPropertyName = "FinishTime";
			dataGridViewCellStyle3.Format = "mm\\:ss\\.fff";
			this.finishTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.finishTimeDataGridViewTextBoxColumn.HeaderText = "Finish Time";
			this.finishTimeDataGridViewTextBoxColumn.Name = "finishTimeDataGridViewTextBoxColumn";
			this.finishTimeDataGridViewTextBoxColumn.ReadOnly = true;
			this.finishTimeDataGridViewTextBoxColumn.Width = 250;
			// 
			// raceResultBindingSource
			// 
			this.raceResultBindingSource.DataSource = typeof(WindowsFormsApp1.RaceResult);
			// 
			// frmDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2559, 962);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblRaceSelected);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.dgvDisplay);
			this.Controls.Add(this.txtStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmDisplay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmTcpClient_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.raceResultBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.DataGridView dgvDisplay;
        private System.Windows.Forms.BindingSource raceResultBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRaceSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hillTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishTimeDataGridViewTextBoxColumn;
    }
}

