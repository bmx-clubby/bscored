using bScoredDatabase.Models;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TidyHQMemberImporter
{
    public partial class CSVImport : Form
    {
        public CSVImport()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = "%userprofile%\\Downloads";
            openFileDialog1.FileName = String.Empty;
            var fields = typeof(TidyMember).GetProperties()
                                .Select(x => x.GetCustomAttributes(false)
                                                .Where(a => a.GetType() == typeof(NameAttribute))
                                                .Cast<NameAttribute>()
                                                .FirstOrDefault()?.Names.First() ?? x.Name
                                        )
                                .ToArray();
            var half = fields.Length / 2;
            lblFieldList1.Text = String.Join("\n", fields.Take(half));
            lblFieldList2.Text = String.Join("\n", fields.Skip(half));

            openFileDialog2.InitialDirectory = "%userprofile%\\Downloads";
            openFileDialog2.FileName = String.Empty;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private async void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var csvFile = new FileInfo(openFileDialog1.FileName);
                var csvOutputFile = Path.Combine(csvFile.Directory.FullName, Path.GetFileNameWithoutExtension(csvFile.Name) + "_output.csv");

                using (var reader = new StreamReader(csvFile.FullName ))
                {
                    using (var csv = new CsvReader(reader, false))
                    {

                        //csv.Configuration.MissingFieldFound ;
                        var records = csv.GetRecords<TidyMember>().ToArray(); //Enumerate all records as this picks up any header errors. (but uses more memory..)

                        //Writing back to a file so I can comparse the data across a round trip.
                        //if (false)
                        //{
                        //    WriteCSV(csvOutputFile, records);
                        //}

                        var result = await new TidyHQImporter().ImportAsync(records);

                        var resultsForm = new ResultDisplay();
                        resultsForm.ImportLog = result;
                        resultsForm.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private static void WriteCSV(string csvOutputFile, TidyMember[] records)
        {
            using (var writer = new StreamWriter(csvOutputFile))
            {

                using (var csvOut = new CsvWriter(writer, false))
                {
                    csvOut.WriteHeader<TidyMember>();
                    csvOut.NextRecord();
                    foreach (var record in records)
                    {
                        csvOut.WriteRecord(record);
                        csvOut.NextRecord();
                    }
                }
            }
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void CSVImport_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectClubs_Click(object sender, EventArgs e)
        {
            this.openFileDialog2.ShowDialog();
        }

        private async void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var txtFile = new FileInfo(openFileDialog2.FileName);
                var txtOutputFile = Path.Combine(txtFile.Directory.FullName, Path.GetFileNameWithoutExtension(txtFile.Name) + "_output.txt");
                string readContents;
                string[] ClubNames, ClubCodes;
                List<Clubs> clubs = new List<Clubs>();

                /* There 2 Files, one with Names and one with Codes
                 * Select the Names file first and we will try to open the associated Codes file
                 * */
                using (StreamReader reader = new StreamReader(txtFile.FullName)) 
                {
                    readContents = reader.ReadToEnd();
                    ClubNames = readContents.Split(';');
                }

                /* Change FileName for Codes*/
                openFileDialog2.FileName = openFileDialog2.FileName.Replace("Names", "Codes");

                txtFile = new FileInfo(openFileDialog2.FileName);
                if(txtFile.Exists == false)
                {
                    MessageBox.Show(openFileDialog2.FileName+" not found","Application Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader reader = new StreamReader(txtFile.FullName))
                {
                    readContents = reader.ReadToEnd();
                    ClubCodes = readContents.Split(';');
                }

                if (ClubNames.Length != ClubCodes.Length)
                {
                    MessageBox.Show("Club Names & Club Codes have different Item Count", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = await new SqorzClubImporter().ImportAsync(ClubNames, ClubCodes);
                MessageBox.Show($"Clubs Updatd: {result.Updates}\nClubs Inserted: {result.Inserts}", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}

