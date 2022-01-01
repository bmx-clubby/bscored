using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TidyHQMemberImporter
{
	public partial class ResultDisplay : Form
	{
		private BindingSource bindingSource = new BindingSource();

		public ResultDisplay()
		{
			InitializeComponent();
		}

		public ImportLog ImportLog { get; set; }


		public class RowData
		{
			public string Message { get; set; }
			public string IDNumber { get; set; }
			public string Contact { get; set; }
			public string Membership { get; set; }

		}

		private void ResultDisplay_Load(object sender, EventArgs e)
		{
			gvResults.DataSource = null;

			if (ImportLog == null) return;

			lblSuccessCountResult.Text = ImportLog.SuccessCount.ToString();
			lblFailedCountResult.Text = ImportLog.Failed.ToString();
			lblNewMembers.Text = ImportLog.Inserts.ToString();
			lblExistingMembers.Text = ImportLog.Updates.ToString();

			var results = ImportLog.GetMessages();

			for (var i = 0; i < results.Count; i++)
			{
				var (member, msg) = results[i];
				var row = new RowData();
				row.Message = msg;
				row.IDNumber = member?.IDNumber;
				row.Contact = member?.FirstName + " " + member?.LastName;
				row.Membership = member?.MembershipLevel;
				bindingSource.Add(row);
			}

			// Initialize the DataGridView.
			gvResults.AutoGenerateColumns = false;
			gvResults.AutoSize = true;
			gvResults.DataSource = bindingSource;

			CreateColumns();
			gvResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			gvResults.Invalidate();
		}

		private void CreateColumns()
		{
			foreach (var prop in typeof(RowData).GetProperties())
			{
				var col = new DataGridViewTextBoxColumn();
				col.DataPropertyName = prop.Name;
				col.Name = prop.Name;
				col.HeaderText = prop.Name;
				gvResults.Columns.Add(col);
			}
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}
	}

	
}
