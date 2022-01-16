namespace WindowsFormsApp7
{
	partial class frmClubEdit
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.lblClubCode = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtGroup = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(143, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 20);
			this.label1.TabIndex = 45;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(249, 21);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(343, 26);
			this.txtName.TabIndex = 44;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(249, 195);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(101, 33);
			this.btnSave.TabIndex = 46;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(143, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 20);
			this.label2.TabIndex = 48;
			this.label2.Text = "Code:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtCode
			// 
			this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCode.Location = new System.Drawing.Point(249, 138);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(343, 26);
			this.txtCode.TabIndex = 47;
			// 
			// lblClubCode
			// 
			this.lblClubCode.AutoSize = true;
			this.lblClubCode.Location = new System.Drawing.Point(249, 166);
			this.lblClubCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblClubCode.Name = "lblClubCode";
			this.lblClubCode.Size = new System.Drawing.Size(439, 13);
			this.lblClubCode.TabIndex = 49;
			this.lblClubCode.Text = "ONLY needs to be set for your club, it must match the club code in the your Tidy " +
    "HQ Export.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(143, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 20);
			this.label3.TabIndex = 51;
			this.label3.Text = "Abbreviation";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtGroup
			// 
			this.txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGroup.Location = new System.Drawing.Point(249, 62);
			this.txtGroup.MaxLength = 10;
			this.txtGroup.Name = "txtGroup";
			this.txtGroup.Size = new System.Drawing.Size(101, 26);
			this.txtGroup.TabIndex = 50;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(249, 91);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(388, 13);
			this.label4.TabIndex = 52;
			this.label4.Text = "Short abbreviation of the club name (e.g. MANW for Manly Warringah BMX Club)";
			// 
			// frmClubEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 258);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtGroup);
			this.Controls.Add(this.lblClubCode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtName);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmClubEdit";
			this.Text = "Club Details";
			this.Load += new System.EventHandler(this.frm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label lblClubCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtGroup;
		private System.Windows.Forms.Label label4;
	}
}