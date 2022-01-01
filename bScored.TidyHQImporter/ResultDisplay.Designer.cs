
namespace TidyHQMemberImporter
{
	partial class ResultDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultDisplay));
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFailedCount = new System.Windows.Forms.Label();
            this.lblFailedCountResult = new System.Windows.Forms.Label();
            this.lblSuccessCountResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNewMembersLabel = new System.Windows.Forms.Label();
            this.lblExistingMembers = new System.Windows.Forms.Label();
            this.lblExistingMembersLabel = new System.Windows.Forms.Label();
            this.lblNewMembers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // gvResults
            // 
            this.gvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Location = new System.Drawing.Point(3, 286);
            this.gvResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvResults.Name = "gvResults";
            this.gvResults.Size = new System.Drawing.Size(1580, 662);
            this.gvResults.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Member Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblFailedCount
            // 
            this.lblFailedCount.AutoSize = true;
            this.lblFailedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedCount.Location = new System.Drawing.Point(136, 138);
            this.lblFailedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFailedCount.Name = "lblFailedCount";
            this.lblFailedCount.Size = new System.Drawing.Size(208, 37);
            this.lblFailedCount.TabIndex = 2;
            this.lblFailedCount.Text = "Failed Count:";
            this.lblFailedCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFailedCountResult
            // 
            this.lblFailedCountResult.AutoSize = true;
            this.lblFailedCountResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedCountResult.Location = new System.Drawing.Point(356, 138);
            this.lblFailedCountResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFailedCountResult.Name = "lblFailedCountResult";
            this.lblFailedCountResult.Size = new System.Drawing.Size(35, 37);
            this.lblFailedCountResult.TabIndex = 3;
            this.lblFailedCountResult.Text = "0";
            // 
            // lblSuccessCountResult
            // 
            this.lblSuccessCountResult.AutoSize = true;
            this.lblSuccessCountResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessCountResult.Location = new System.Drawing.Point(356, 66);
            this.lblSuccessCountResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuccessCountResult.Name = "lblSuccessCountResult";
            this.lblSuccessCountResult.Size = new System.Drawing.Size(35, 37);
            this.lblSuccessCountResult.TabIndex = 4;
            this.lblSuccessCountResult.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(968, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "0";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblNewMembersLabel
            // 
            this.lblNewMembersLabel.AutoSize = true;
            this.lblNewMembersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewMembersLabel.Location = new System.Drawing.Point(504, 66);
            this.lblNewMembersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewMembersLabel.Name = "lblNewMembersLabel";
            this.lblNewMembersLabel.Size = new System.Drawing.Size(231, 37);
            this.lblNewMembersLabel.TabIndex = 5;
            this.lblNewMembersLabel.Text = "New Members:";
            this.lblNewMembersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNewMembersLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblExistingMembers
            // 
            this.lblExistingMembers.AutoSize = true;
            this.lblExistingMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistingMembers.Location = new System.Drawing.Point(1125, 66);
            this.lblExistingMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExistingMembers.Name = "lblExistingMembers";
            this.lblExistingMembers.Size = new System.Drawing.Size(35, 37);
            this.lblExistingMembers.TabIndex = 8;
            this.lblExistingMembers.Text = "0";
            this.lblExistingMembers.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblExistingMembersLabel
            // 
            this.lblExistingMembersLabel.AutoSize = true;
            this.lblExistingMembersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistingMembersLabel.Location = new System.Drawing.Point(842, 66);
            this.lblExistingMembersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExistingMembersLabel.Name = "lblExistingMembersLabel";
            this.lblExistingMembersLabel.Size = new System.Drawing.Size(278, 37);
            this.lblExistingMembersLabel.TabIndex = 7;
            this.lblExistingMembersLabel.Text = "Existing Members:";
            this.lblExistingMembersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewMembers
            // 
            this.lblNewMembers.AutoSize = true;
            this.lblNewMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewMembers.Location = new System.Drawing.Point(746, 66);
            this.lblNewMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewMembers.Name = "lblNewMembers";
            this.lblNewMembers.Size = new System.Drawing.Size(35, 37);
            this.lblNewMembers.TabIndex = 9;
            this.lblNewMembers.Text = "0";
            // 
            // ResultDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 946);
            this.Controls.Add(this.lblNewMembers);
            this.Controls.Add(this.lblExistingMembers);
            this.Controls.Add(this.lblExistingMembersLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNewMembersLabel);
            this.Controls.Add(this.lblSuccessCountResult);
            this.Controls.Add(this.lblFailedCountResult);
            this.Controls.Add(this.lblFailedCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ResultDisplay";
            this.Text = "ResultDisplay";
            this.Load += new System.EventHandler(this.ResultDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView gvResults;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblFailedCount;
		private System.Windows.Forms.Label lblFailedCountResult;
		private System.Windows.Forms.Label lblSuccessCountResult;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblNewMembersLabel;
		private System.Windows.Forms.Label lblExistingMembers;
		private System.Windows.Forms.Label lblExistingMembersLabel;
		private System.Windows.Forms.Label lblNewMembers;
	}
}