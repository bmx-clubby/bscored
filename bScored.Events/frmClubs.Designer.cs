namespace WindowsFormsApp7
{
	partial class frmClubs
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgList = new System.Windows.Forms.DataGridView();
			this.btnNewClub = new System.Windows.Forms.Button();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clubCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clubDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dgList
			// 
			this.dgList.AllowUserToAddRows = false;
			this.dgList.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgList.AutoGenerateColumns = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clubCodeDataGridViewTextBoxColumn,
            this.clubDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn});
			this.dgList.DataSource = this.bindingSource;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgList.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgList.Location = new System.Drawing.Point(0, 114);
			this.dgList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dgList.Name = "dgList";
			this.dgList.ReadOnly = true;
			this.dgList.RowTemplate.Height = 26;
			this.dgList.Size = new System.Drawing.Size(707, 695);
			this.dgList.TabIndex = 0;
			this.dgList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellDoubleClick);
			// 
			// btnNewClub
			// 
			this.btnNewClub.Location = new System.Drawing.Point(12, 37);
			this.btnNewClub.Name = "btnNewClub";
			this.btnNewClub.Size = new System.Drawing.Size(95, 38);
			this.btnNewClub.TabIndex = 1;
			this.btnNewClub.Text = "New Club";
			this.btnNewClub.UseVisualStyleBackColor = true;
			this.btnNewClub.Click += new System.EventHandler(this.btnNewClub_Click);
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(bScoredDatabase.Models.Clubs);
			// 
			// clubCodeDataGridViewTextBoxColumn
			// 
			this.clubCodeDataGridViewTextBoxColumn.DataPropertyName = "Club_Code";
			this.clubCodeDataGridViewTextBoxColumn.HeaderText = "Code";
			this.clubCodeDataGridViewTextBoxColumn.Name = "clubCodeDataGridViewTextBoxColumn";
			this.clubCodeDataGridViewTextBoxColumn.ReadOnly = true;
			this.clubCodeDataGridViewTextBoxColumn.Width = 150;
			// 
			// clubDataGridViewTextBoxColumn
			// 
			this.clubDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clubDataGridViewTextBoxColumn.DataPropertyName = "Club";
			this.clubDataGridViewTextBoxColumn.HeaderText = "Name";
			this.clubDataGridViewTextBoxColumn.Name = "clubDataGridViewTextBoxColumn";
			this.clubDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// groupDataGridViewTextBoxColumn
			// 
			this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
			this.groupDataGridViewTextBoxColumn.HeaderText = "Group";
			this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
			this.groupDataGridViewTextBoxColumn.ReadOnly = true;
			this.groupDataGridViewTextBoxColumn.Visible = false;
			// 
			// stateDataGridViewTextBoxColumn
			// 
			this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
			this.stateDataGridViewTextBoxColumn.HeaderText = "State";
			this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
			this.stateDataGridViewTextBoxColumn.ReadOnly = true;
			this.stateDataGridViewTextBoxColumn.Visible = false;
			// 
			// countryDataGridViewTextBoxColumn
			// 
			this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
			this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
			this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
			this.countryDataGridViewTextBoxColumn.ReadOnly = true;
			this.countryDataGridViewTextBoxColumn.Visible = false;
			// 
			// frmClubs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(705, 828);
			this.Controls.Add(this.btnNewClub);
			this.Controls.Add(this.dgList);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmClubs";
			this.Text = "Clubs List";
			this.Load += new System.EventHandler(this.frm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgList;
		private System.Windows.Forms.Button btnNewClub;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn clubCodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clubDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
	}
}