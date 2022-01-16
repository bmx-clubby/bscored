using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bScoredDisplay;
using Newtonsoft.Json;
using SimpleTCP;


namespace WindowsFormsApp1
{
    public partial class frmDisplay : Form
    {
        SimpleTcpClient TcpClient;
        DisplayResults resultDisplay;
		bScoredDatabase.Models.Settings currentSettings;

        public frmDisplay()
        {
            InitializeComponent();
        }

        private void frmTcpClient_Load(object sender, EventArgs e)
        {
            currentSettings = DataService.LoadSettings();

            string pathName = string.Empty;
            if (!currentSettings.LogoFile.Contains(@"\"))
            {
                pathName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
                //MessageBox.Show(pathName);
            }
            string fullImagePath = pathName + currentSettings.LogoFile;
            
            if (File.Exists(fullImagePath))
                pictureBox1.Image = Image.FromFile(fullImagePath);
            else
                MessageBox.Show(fullImagePath + " does not exist.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
 
            label1.Text = currentSettings.ReportLink;

            resultDisplay = new DisplayResults();
            raceResultBindingSource.DataSource = resultDisplay.results;

            TcpClient = new SimpleTcpClient();
            TcpClient.Delimiter = 0x13;
            try
            {
                TcpClient.Connect(currentSettings.TCPAddress, currentSettings.TCPPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bool bConnected = TcpClient.TcpClient.Connected;

            //TcpClient.TcpClient.Client.Poll(1, System.Net.Sockets.SelectMode.SelectRead);
            //MessageBox.Show("Connected="+bConnected);

            TcpClient.DelimiterDataReceived += TcpClient_DelimiterDataReceived;
            
        }


        private void TcpClient_DelimiterDataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                string myMessage = e.MessageString.Substring(0, e.MessageString.Length);
                txtStatus.Text = myMessage;
                //MessageLength = e.MessageString.Length;

                resultDisplay = JsonConvert.DeserializeObject<DisplayResults>(myMessage);

                raceResultBindingSource.DataSource = resultDisplay.results;

                //gateRidersBindingSource.ResetBindings(false);
                //e.ReplyLine(string.Format("You said" + myMessage));
            });

            lblRaceSelected.Invoke((MethodInvoker)delegate ()
            {
                lblRaceSelected.Text = "Race " + resultDisplay.race.Race_No.ToString() + " - " + resultDisplay.race.Moto_Name + " " + resultDisplay.race.Class_Name;

            });


        }


        private void dgvDisplay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex].ValueType == typeof(TimeSpan) &&
                    TimeSpan.Zero == (TimeSpan)grid[e.ColumnIndex, e.RowIndex].Value)
            {
                e.Value = " ";
                e.FormattingApplied = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
