
namespace TidyHQMemberImporter
{
    partial class CSVImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVImport));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFieldList1 = new System.Windows.Forms.Label();
            this.lblFieldList2 = new System.Windows.Forms.Label();
            this.btnSelectClubs = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV Import|*.csv";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(124, 59);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(124, 39);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select Tidy HQ File";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(89, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click the button below and select the file exported from Tidy HQ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TidyHQ Export Fields Required";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblFieldList1
            // 
            this.lblFieldList1.AutoSize = true;
            this.lblFieldList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldList1.Location = new System.Drawing.Point(12, 180);
            this.lblFieldList1.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblFieldList1.Name = "lblFieldList1";
            this.lblFieldList1.Size = new System.Drawing.Size(54, 13);
            this.lblFieldList1.TabIndex = 3;
            this.lblFieldList1.Text = "[Field List]";
            this.lblFieldList1.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblFieldList2
            // 
            this.lblFieldList2.AutoSize = true;
            this.lblFieldList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldList2.Location = new System.Drawing.Point(212, 180);
            this.lblFieldList2.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblFieldList2.Name = "lblFieldList2";
            this.lblFieldList2.Size = new System.Drawing.Size(54, 13);
            this.lblFieldList2.TabIndex = 4;
            this.lblFieldList2.Text = "[Field List]";
            // 
            // btnSelectClubs
            // 
            this.btnSelectClubs.Location = new System.Drawing.Point(402, 59);
            this.btnSelectClubs.Name = "btnSelectClubs";
            this.btnSelectClubs.Size = new System.Drawing.Size(123, 39);
            this.btnSelectClubs.TabIndex = 5;
            this.btnSelectClubs.Text = "Select Club File";
            this.btnSelectClubs.UseVisualStyleBackColor = true;
            this.btnSelectClubs.Click += new System.EventHandler(this.btnSelectClubs_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "Text Import|*.txt";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(373, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Click the button below and select the file exported from SQORZ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(373, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Choose the ...Club_Names file";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CSVImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 321);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectClubs);
            this.Controls.Add(this.lblFieldList2);
            this.Controls.Add(this.lblFieldList1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CSVImport";
            this.Text = "Tidy HQ Importer";
            this.Load += new System.EventHandler(this.CSVImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFieldList1;
        private System.Windows.Forms.Label lblFieldList2;
        private System.Windows.Forms.Button btnSelectClubs;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}