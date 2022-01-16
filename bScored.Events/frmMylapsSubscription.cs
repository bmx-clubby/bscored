using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp7
{
    public partial class frmMylapsSubscription : Form
    {
        static HttpClient httpClient = new HttpClient();
        int EventSelected;

        public frmMylapsSubscription(int eventSelected)
        {
            InitializeComponent();
            EventSelected = eventSelected;
        }



        private void frmMylapsSubscription_Load(object sender, EventArgs e)
        {
            //progressBar1.Maximum = 100;
            //progressBar1.Step = 1;


        }

        private void DisplayResults(string url, string contents)
        {
            /* Could search for Transponder in ridersList then add to riderBindingSource if content contains 'false' */
            var displayUrl = url.Replace("https://api-gateway.mylaps.com/transponder/", "");
            txtResults.AppendText($"\r\n{displayUrl} {contents} \n");
        }

        public  async Task<string> MakeRequestAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-MYLAPS-Auth-Token", "Jnbkli(983");

            
            using (var response = await httpClient.SendAsync(request))
            {
                string content = await response.Content.ReadAsStringAsync();
                DisplayResults(url, content);
                return content;
            }
         }


        static bool CheckMylapsSubscription(string sTransponder)
        {
            string content = null;
            string url = "https://api-gateway.mylaps.com/transponder/" + sTransponder + "/subscription/valid";

            Task task = Task.Run(async () =>
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("X-MYLAPS-Auth-Token", "Jnbkli(983");

                HttpResponseMessage response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
            });

            Task.WaitAll(task);
            /* content = {'valid':true} OR {'valid':false}  */
            //MessageBox.Show(sTransponder + " " + content);

            if (content.Contains("true"))
            {
                return true;
            }
            return false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send("api-gateway.mylaps.com");
                if (reply.Status != IPStatus.Success)
                {
                    MessageBox.Show("Mylaps does does respond...", "bScored Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (PingException ex)
            {
                MessageBox.Show(ex.InnerException.Message, "bScored Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
 
            List<Rider> ridersList = DataService.GetRidersWithTransponders(EventSelected); 
            var tasks = new List<Task<string>>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            lblMessage.Visible = true;
            progressBar1.Visible = true;

            foreach (Rider r in ridersList)
            {
                //if (r.Transponder.Trim().Length > 0)
                //{
                    /* Multiple Requests */
                    string url = "https://api-gateway.mylaps.com/transponder/" + r.Transponder.Trim() + "/subscription/valid";
                    tasks.Add(MakeRequestAsync(url));

                    /*progressBar1.Value += 1;
                    txtTransponder.Text = r.Transponder;

                    SubscriptionStatus = CheckMylapsSubscription(r.Transponder.Trim());
                    if (SubscriptionStatus == false)
                    {
                        MessageBox.Show(r.Full_Name + " " + r.Transponder + " " + SubscriptionStatus);
                    }*/
                //}
            }
            await Task.WhenAll(tasks);      /*  Wait for all of them to complete */

            stopwatch.Stop();
            progressBar1.Visible = false;
            //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
            lblMessage.Text = ridersList.Count.ToString() + " Transponder Subscriptions Checked in " + stopwatch.Elapsed.ToString("mm\\:ss\\.ff");

            if (tasks.Count != ridersList.Count)
            {
                MessageBox.Show("There seems to be a problem...");
                return;
            }

            int rider_index = 0;
            foreach (var task in tasks)
            {
                var str = await task;       /* or task.Result, won't block, already completed; */
                if (str.Contains("true"))
                {

                }
                else
                {
                    riderBindingSource.Add(ridersList[rider_index]);
                    //MessageBox.Show(ridersList[rider_index].Full_Name + " " + ridersList[rider_index].Transponder + str);
                }
                rider_index++;
            }

        }

        /* https://stackoverflow.com/questions/55231008/multiple-web-requests-start-another-request-while-waiting-for-response-on-last */
        /* https://www.youtube.com/watch?v=yZYAaScEsc0 - Please Wait */




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
