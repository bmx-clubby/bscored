using bScoredDatabase.Models;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using Renci.SshNet;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
	public partial class Form1 : Form
	{
		/* Do this when draw created ... */
		private static Random rnd = new Random();

		int[,] Moto2TypeR = new int[9, 9] {
			{0,0,0,0,0,0,0,0,0},
			{0, 1, 6, 4, 8, 3, 5, 7, 2},
			{0, 2, 5, 7, 4, 1, 6, 3, 8},
			{0, 3, 8, 6, 1, 4, 7, 2, 5},
			{0, 4, 7, 1, 6, 2, 8, 5, 3},
			{0, 5, 2, 8, 3, 6, 1, 4, 7},
			{0, 6, 1, 3, 7, 5, 2, 8, 4},
			{0, 7, 4, 2, 5, 8, 3, 6, 1},
			{0, 8, 3, 5, 2, 7, 4, 1, 6}
		};

		int[,] Last2Lanes = new int[9, 9] {
			{0,0,0,0,0,0,0,0,0},
			{0, 6, 6,27,33,38,11,73,55},
			{0, 5, 5,28,76,16,44,50,56},
			{0,75,22,22, 8,39,45,51,13},
			{0,18,23,29, 7,40,70,10,57},
			{0,19,15,77,35, 2, 2,52,58},
			{0,12,24,31,36,41, 1,53,72},
			{0,20,25,32, 9,71,47, 4,60},
			{0,21,74,14,37,43,48,54, 3}
		};

		int[,] Lane_Priority = new int[81, 9] {
			{0,0,0,0,0,0,0,0,0 },
			{ 1, 1, 2, 3, 4, 8, 7, 5, 6 },
			{ 2, 2, 1, 3, 8, 7, 4, 6, 5 },
			{ 3, 3, 4, 2, 5, 1, 6, 7, 8 },
			{ 4, 4, 3, 2, 5, 1, 6, 8, 7 },
			{ 5, 5, 6, 4, 7, 8, 3, 1, 2 },
			{ 6, 6, 5, 7, 8, 4, 3, 2, 1 },
			{ 7, 7, 8, 6, 1, 2, 5, 3, 4 },
			{ 8, 8, 7, 6, 5, 1, 2, 4, 3 },
			{ 9, 1, 2, 5, 3, 6, 8, 4, 7 },
			{10, 2, 1, 6, 8, 5, 3, 7, 4 },
			{11, 3, 4, 8, 7, 5, 2, 6, 1 },
			{12, 4, 3, 8, 2, 7, 5, 1, 6 },
			{13, 5, 6, 1, 7, 2, 4, 8, 3 },
			{14, 6, 5, 1, 2, 4, 7, 3, 8 },
			{15, 7, 8, 3, 4, 1, 6, 2, 5 },
			{16, 8, 7, 4, 6, 3, 1, 5, 2 },
			{17, 8, 7, 6, 5, 2, 4, 1, 3 },
			{18, 7, 8, 6, 5, 2, 3, 1, 4 },
			{19, 7, 8, 3, 2, 4, 6, 1, 5 },
			{20, 4, 3, 5, 6, 2, 8, 1, 7 },
			{21, 4, 5, 3, 6, 2, 7, 1, 8 },
			{22, 8, 7, 6, 5, 4, 1, 2, 3 },
			{23, 7, 8, 6, 5, 1, 3, 2, 4 },
			{24, 4, 8, 3, 1, 5, 7, 2, 6 },
			{25, 4, 5, 3, 1, 6, 8, 2, 7 },
			{26, 4, 5, 3, 6, 1, 7, 2, 8 },
			{27, 8, 7, 6, 5, 4, 2, 3, 1 },
			{28, 8, 7, 6, 5, 4, 1, 3, 2 },
			{29, 7, 8, 6, 1, 5, 2, 3, 4 },
			{30, 8, 7, 1, 6, 2, 4, 3, 5 },
			{31, 8, 1, 2, 4, 5, 7, 3, 6 },
			{32, 1, 5, 2, 4, 6, 8, 3, 7 },
			{33, 7, 8, 6, 5, 3, 2, 4, 1 },
			{34, 8, 7, 6, 5, 3, 1, 4, 2 },
			{35, 1, 8, 2, 7, 3, 6, 4, 5 },
			{36, 1, 2, 8, 3, 7, 5, 4, 6 },
			{37, 2, 1, 5, 6, 3, 7, 4, 8 },
			{38, 7, 8, 3, 6, 4, 2, 5, 1 },
			{39, 8, 7, 1, 6, 2, 4, 5, 3 },
			{40, 8, 1, 7, 2, 6, 3, 5, 4 },
			{41, 1, 2, 3, 8, 4, 7, 5, 6 },
			{42, 1, 2, 3, 4, 6, 8, 5, 7 },
			{43, 1, 2, 3, 4, 6, 7, 5, 8 },
			{44, 4, 8, 7, 5, 3, 1, 6, 2 },
			{45, 1, 8, 7, 5, 4, 2, 6, 3 },
			{46, 1, 8, 2, 7, 3, 5, 6, 4 },
			{47, 1, 2, 3, 4, 5, 8, 6, 7 },
			{48, 2, 1, 3, 4, 5, 7, 6, 8 },
			{49, 5, 4, 3, 6, 8, 2, 7, 1 },
			{50, 5, 4, 3, 6, 8, 1, 7, 2 },
			{51, 1, 5, 6, 8, 2, 4, 7, 3 },
			{52, 1, 2, 3, 8, 4, 6, 7, 5 },
			{53, 1, 2, 3, 4, 8, 5, 7, 6 },
			{54, 1, 2, 3, 4, 5, 6, 7, 8 },
			{55, 5, 4, 6, 3, 7, 2, 8, 1 },
			{56, 5, 4, 6, 3, 7, 1, 8, 2 },
			{57, 1, 2, 6, 7, 5, 3, 8, 4 },
			{58, 2, 1, 3, 7, 4, 6, 8, 5 },
			{59, 1, 2, 3, 4, 5, 7, 8, 6 },
			{60, 1, 2, 3, 4, 5, 6, 8, 7 },
			{61, 0, 0, 0, 0, 0, 0, 0, 0 },
			{62, 0, 0, 0, 0, 0, 0, 0, 0 },
			{63, 0, 0, 0, 0, 0, 0, 0, 0 },
			{64, 0, 0, 0, 0, 0, 0, 0, 0 },
			{65, 0, 0, 0, 0, 0, 0, 0, 0 },
			{66, 0, 0, 0, 0, 0, 0, 0, 0 },
			{67, 0, 0, 0, 0, 0, 0, 0, 0 },
			{68, 0, 0, 0, 0, 0, 0, 0, 0 },
			{69, 0, 0, 0, 0, 0, 0, 0, 0 },
			{70, 7, 2, 8, 3, 5, 1, 6, 4 },
			{71, 3, 1, 4, 6, 8, 2, 5, 7 },
			{72, 1, 2, 4, 5, 7, 3, 8, 6 },
			{73, 5, 3, 6, 8, 2, 4, 7, 1 },
			{74, 4, 3, 6, 1, 7, 5, 2, 8 },
			{75, 7, 8, 5, 2, 4, 6, 1, 3 },
			{76, 8, 6, 5, 3, 1, 7, 4, 2 },
			{77, 7, 1, 6, 2, 4, 8, 3, 5 },
			{78, 0, 0, 0, 0, 0, 0, 0, 0 },
			{79, 0, 0, 0, 0, 0, 0, 0, 0 },
			{80, 0, 0, 0, 0, 0, 0, 0, 0 }
		};


		Event thisEvent;
		List<Rider> filtered = new List<Rider>();
		List<RiderClass> thisClasses = new List<RiderClass>();

		List<Race> raceList = new List<Race>();
		List<RaceResult> eventResults = new List<RaceResult>();   /*           */
		List<RaceResult> raceResults = new List<RaceResult>();
		List<MotoPoints> motoPoints = new List<MotoPoints>();
		List<MotoPoints> partPoints = new List<MotoPoints>();
		Race thisRace;

		List<GateRiders> gateRiders = new List<GateRiders>();
		List<GateRiders> gateDisplay = new List<GateRiders>();

		Settings currentSettings;

		int i;
		int EventSelected = 1004;                                   /* Updated when event is selected from list */
		int EventMotos = 6;                                         /* Updated when event is selected from list */
		int ClassNoToMerge;
		bool MergeMode = false;
		int RaceSelected = 1;
		int MotoSelected = 0;
		bool ScoringEntryDirty;
		bool ClassMoveUpDown;

		string sPassingFileName;
		DateTime dtGateDrop;
		DateTime Finish_GateTime;
		DateTime Rider_GateTime;
		bool ScoringOn = false;

		public DateTime DateNow = DateTime.Now;
		Stopwatch stopwatch = Stopwatch.StartNew();

		SimpleTcpServer TcpServer;



		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			currentSettings = DataService.LoadSettings();

			if (currentSettings?.AreValid() != true)
			{
				ShowSettings();

				currentSettings = DataService.LoadSettings();

				if (!currentSettings.AreValid())
				{
					this.Close();
					return;
				}
			}

			gateRidersBindingSource.DataSource = gateDisplay;

			eventBindingSource.DataSource = DataService.GetEventList();
			if (dgvEvents.RowCount > 0)
			{
				dgvEvents.FirstDisplayedScrollingRowIndex = dgvEvents.RowCount - 1;
				dgvEvents.CurrentCell = dgvEvents.Rows[dgvEvents.RowCount - 1].Cells[0];
			}
			var obj = eventBindingSource.Current as Event;
			SelectEvent(obj);

			motoPoints.Add(new MotoPoints() { Place = "", Points = 0 });
			motoPoints.Add(new MotoPoints() { Place = "1st", Points = 1 });
			motoPoints.Add(new MotoPoints() { Place = "2nd", Points = 2 });
			motoPoints.Add(new MotoPoints() { Place = "3rd", Points = 3 });
			motoPoints.Add(new MotoPoints() { Place = "4th", Points = 4 });
			motoPoints.Add(new MotoPoints() { Place = "5th", Points = 5 });
			motoPoints.Add(new MotoPoints() { Place = "6th", Points = 6 });
			motoPoints.Add(new MotoPoints() { Place = "7th", Points = 7 });
			motoPoints.Add(new MotoPoints() { Place = "8th", Points = 8 });
			motoPoints.Add(new MotoPoints() { Place = "DNF", Points = 999 });
			motoPoints.Add(new MotoPoints() { Place = "DNS", Points = 99 });

			partPoints.Add(new MotoPoints() { Place = "", Points = 0 });
			partPoints.Add(new MotoPoints() { Place = "Finish", Points = 0 });
			partPoints.Add(new MotoPoints() { Place = "DNF", Points = 999 });
			partPoints.Add(new MotoPoints() { Place = "DNS", Points = 99 });

			btnScoringOff.BackColor = Color.LightCoral;
			sPassingFileName = currentSettings.PassingFile;             //@"C:\BEM\Passings\Track\Track.txt";
			ScoringOn = false;

			//backgroundWorker1.RunWorkerAsync();

			TcpServer = new SimpleTcpServer();
			TcpServer.Delimiter = 0x13;
			TcpServer.StringEncoder = Encoding.UTF8;
			TcpServer.DataReceived += TcpServer_DataReceived;

			System.Net.IPAddress ip = System.Net.IPAddress.Parse(currentSettings.TCPAddress);
			TcpServer.Start(ip, currentSettings.TCPPort);

			toolTip1.SetToolTip(btnMerge, "1. Always Merge from Lower Class to Higher Class\n2. In the List Select the Class to Merge from\n3. Select the Merge Button\n4. In the List select the Class To Merge to\n5. Accept the Merge ");
			toolTip1.SetToolTip(btnUnMerge, "1. In the List Select the Merged from Class\n2. Select the UnMerge button\n3. Accept the UnMerge ");
			toolTip1.SetToolTip(btnMylapsSubscription, "Online Subscription check with MyLaps.");
			toolTip1.SetToolTip(btnChipStatus, "Check if Transponders seen on Track.");
			toolTip1.SetToolTip(btnClassMoveUp, "Move selected Class up the List.");
			toolTip1.SetToolTip(btnClassMoveDown, "Move selected Class down the List.");

			//LogMessageToFile("Application Started.");
			//tabControl1.TabPages[1].Enabled = false;
		}


		private void TcpServer_DataReceived(object sender, SimpleTCP.Message e)
		{
			//txtStatus.Invoke((MethodInvoker)delegate ()
			//{
			string myMessage = e.MessageString.Substring(0, e.MessageString.Length - 1);
			//txtStatus.Text += myMessage + Environment.NewLine;
			e.ReplyLine(string.Format("You said" + myMessage));
			//});
		}


		private bool SelectEvent(Event obj, int mode = 0)
		{
			if (obj == null)
				return false;

			thisEvent = obj;

			EventSelected = thisEvent.EventID;
			EventMotos = thisEvent.Moto_No;
			//MessageBox.Show(EventSelected.ToString());

			ShowEventName();

			thisClasses = DataService.GetRiderClasses(EventSelected);
			riderClassBindingSource.DataSource = thisClasses;

			/* Need a Blank Object */
			thisRace = new Race();
			RaceSelected = 1;

			/* Must Start it Manually if a different Event is Selected */
			if (mode == 0)
			{
				timer1.Stop();
				btnScoringOff.BackColor = Color.LightCoral;
				btnScoringOn.BackColor = Control.DefaultBackColor;
			}

			btnDuplicateEvent.Text = "Duplicate...";

			if (currentSettings.Host != null && currentSettings.Host.Length > 0 && thisEvent.Result_File != null && thisEvent.Result_File.Trim().Length > 0)
				btnWebsite.Enabled = true;
			else
				btnWebsite.Enabled = false;

			return true;
		}


		private void ShowEventName()
		{
			this.Text = thisEvent.Name + " - " + thisEvent.Date.ToString("dd MMM yyyy");
			//lblEventDate.Text = thisEvent.Date.ToString("dd MMM yyyy");
		}

		private void ShowTotalRiders()
		{
			lblNumberOfRiders.Text = "Total Riders: " + ridersBindingSource.Count.ToString();
		}


		private void dgvRiders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Rider obj = ridersBindingSource.Current as Rider;
			if (obj != null)
			{
				using (frmRiderEdit frm = new frmRiderEdit(obj, false, thisEvent.Race_No, this))
				{
					/* Can write to the form here... */
					DialogResult dr = frm.ShowDialog();

					//frm.RiderInfo.Class_Name;
					//frm.Close();

					/* pointr to Rider Object is passed and is updated if "Save" is selected. */
					if (dr == DialogResult.OK)
					{
						/* Save to Riders Table */
						ridersBindingSource.ResetBindings(false);

						/*Update Rider Table for this Event*/
						if (DataService.UpdateRider(obj) == 1)
						{
							/* Update Rider Preferences in OSM_Memebership */
							DataService.UpdateMemberPreference(obj);

							MessageBox.Show(obj.Full_Name + " Updated.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}

				}
				i = 2;
			}

		}

		/* This is called by frmRiderEdit */
		public void RidersRefresh()
		{
			//dgvRiders.SuspendLayout();
			ridersBindingSource.DataSource = DataService.GetRiders(EventSelected);
			//dgvRiders.ResumeLayout();

			ShowTotalRiders();
		}


		private void btnAddRider_Click(object sender, EventArgs e)
		{
			Rider obj = new Rider();

			obj.EventID = EventSelected;

			/* If races are created need to add rider to race also */
			using (frmRiderEdit frm = new frmRiderEdit(obj, true, thisEvent.Race_No, this))
			{
				/* Can write to the form here... */
				DialogResult dr = frm.ShowDialog();

				//frm.RiderInfo.Class_Name;
				//frm.Close();

				/* pointr to Rider Object is passed and is updated if "Save" is selected. */
				if (dr == DialogResult.OK)
				{
					RidersRefresh();
					//ridersBindingSource.DataSource = DataService.GetRiders(EventSelected);
					//ShowTotalRiders();
				}
			}
		}


		private void dgvRiders_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				Rider obj = ridersBindingSource.Current as Rider;
				if (obj != null)
				{
					if (MessageBox.Show("Are you sure you want to delete " + obj.Full_Name, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						// Delete from DB and if sucessful Delete from Binding Source
						if (DataService.DeleteRider(obj.RiderID) != 0)
						{
							/* If Draw/Results are created Delete this Rider from it. */
							if (thisEvent.Race_No > 0)
							{
								DataService.DeleteRiderFromDraw(obj);
							}
							ridersBindingSource.RemoveCurrent();
							ShowTotalRiders();
						}
					}
				}
			}

		}

		/* Page Riders */
		private void tabPage1_Enter(object sender, EventArgs e)
		{
			RidersRefresh();
			//ridersBindingSource.DataSource = DataService.GetRiders(EventSelected);
			//ShowTotalRiders();
		}

		/* Page Classes */
		private void tabPage2_Enter(object sender, EventArgs e)
		{
			/* This is setup when Event is Selected but needs refresh here*/
			thisClasses = DataService.GetRiderClasses(EventSelected);
			riderClassBindingSource.DataSource = thisClasses;

			MergeMode = false;
			lblMergeMode.Text = "";
			ClassMoveUpDown = false;

			if (thisEvent.Race_No > 0)
			{
				btnMerge.Enabled = false;
				btnUnMerge.Enabled = false;
				btnClassMoveUp.Enabled = false;
				btnClassMoveDown.Enabled = false;
			}
			else
			{
				btnMerge.Enabled = true;
				btnUnMerge.Enabled = true;
				btnClassMoveUp.Enabled = true;
				btnClassMoveDown.Enabled = true;
			}

		}


		private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			RiderClass obj = riderClassBindingSource.Current as RiderClass;
			if (obj != null && MergeMode == true && obj.Merged_To.Length == 0)
			{
				if (MessageBox.Show(lblMergeMode.Text + obj.Name, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataService.CreateClassMerge(EventSelected, ClassNoToMerge, obj.Class_No);

					thisClasses = DataService.GetRiderClasses(EventSelected);
					riderClassBindingSource.DataSource = thisClasses;

					MergeMode = false;
					lblMergeMode.Text = "";
				}

			}

		}


		private void btnMerge_Click(object sender, EventArgs e)
		{
			RiderClass obj = riderClassBindingSource.Current as RiderClass;
			if (obj != null && obj.Merged_To.Length == 0)
			{
				if (MergeMode == false)
				{
					MergeMode = true;
					lblMergeMode.Text = "Merge " + obj.Name + " to ...";
					ClassNoToMerge = obj.Class_No;
				}
				else
				{
					MergeMode = false;
					lblMergeMode.Text = "";
				}
			}
		}

		private void btnUnMerge_Click(object sender, EventArgs e)
		{
			RiderClass obj = riderClassBindingSource.Current as RiderClass;
			if (obj != null && obj.Merged_To.Length != 0)
			{
				if (MessageBox.Show("Remove Merge\n" + obj.Name + " into " + obj.Merged_To, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataService.RemoveClassMerge(EventSelected, obj.Class_No);

					thisClasses = DataService.GetRiderClasses(EventSelected);
					riderClassBindingSource.DataSource = thisClasses;
				}
			}

		}

		private void dgvClasses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			foreach (DataGridViewRow row in dgvClasses.Rows)
			{
				if ((Convert.ToInt32(row.Cells["Race_No"].Value) < Convert.ToInt32(row.Cells["MinEntry"].Value)) && Convert.ToInt32(row.Cells["Race_No"].Value) != 0)
				{
					row.DefaultCellStyle.BackColor = Color.Red;
					row.DefaultCellStyle.ForeColor = Color.White;
				}
			}
		}



		/* Fisher-Yates shuffle */
		public static void Shuffle<T>(IList<T> list)
		{
			//Random rnd = new Random();
			string sMessage;
			sMessage = "";
			//           int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
			int n = list.Count;

			while (n > 1)
			{
				// Use Next on random instance with an argument.
				// ... The argument is an exclusive bound.
				//     So we will not go past the end of the array.
				n--;
				int k = rnd.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}

			//foreach (int value in array)
			//     sMessage = sMessage + " " + value.ToString();
			//
			//MessageBox.Show(sMessage);
		}


		/* From BEM ... */
		public static void RandomGateDraw()
		{
			//           Random rnd = new Random();
			int Num_2_Allocate, match_count, Rnd_Select, Free_Count;
			string sMessage = "";

			match_count = 9;

			int[] rider = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			for (Num_2_Allocate = match_count; Num_2_Allocate >= 0; --Num_2_Allocate)
			{
				Rnd_Select = 1 + rnd.Next(Num_2_Allocate);
				Free_Count = 0;

				for (int i = 1; i <= match_count; i++)
				{
					if (rider[i] > 0)
					{
					}
					else
					{
						Free_Count = Free_Count + 1;
						if (Free_Count == Rnd_Select)
						{
							rider[i] = 1;
							sMessage = sMessage + " " + i.ToString();
							break;
						}
					}

				}

			}
			MessageBox.Show(sMessage);
		}

		/* From BEM ... */
		public static void RandomLaneDraw()
		{
			//           Random rnd = new Random();
			int Lane_Number, Num_Lanes, Rnd_Number, Free_Count;
			int k = 0;
			string sMessage = "";

			int[] Random_Lanes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			Num_Lanes = 8;

			for (Lane_Number = Num_Lanes; Lane_Number > 0; --Lane_Number)
			{
				Rnd_Number = 1 + rnd.Next(Lane_Number);
				//                sMessage = sMessage + " " + Rnd_Number.ToString();

				Free_Count = 0;
				for (int i = 1; i <= Num_Lanes; i++)
				{
					k = k + 1;
					if (Random_Lanes[i] == 0)
					{
						Free_Count = Free_Count + 1;
						if (Free_Count == Rnd_Number)
						{
							Random_Lanes[i] = Lane_Number;
							break;
						}
					}
				}
			}

			foreach (int value in Random_Lanes)
			{
				sMessage = sMessage + " " + value.ToString();
			}
			MessageBox.Show(sMessage + "    " + k.ToString());

		}




		private void CreateDraw()   //  Allocate lanes
		{
			List<RiderClass> raceClasses = new List<RiderClass>();
			List<Race> raceList = new List<Race>();
			List<Draw> drawList = new List<Draw>();
			List<PreviousLane> laneList = new List<PreviousLane>();
			int GatesPerClass;
			int Link;

			Stopwatch stopwatch = Stopwatch.StartNew();

			raceClasses = DataService.GetClassesRaceOrder(EventSelected);
			raceList = DataService.GetRaceList(EventSelected);
			drawList = DataService.GetRaceDraw(EventSelected);

			//raceList.Sort((v, w) => v.Class_No.CompareTo(w.Class_No));

			/* MUST PROTECT THIS !! */
			if (EventMotos == 0)
			{
				MessageBox.Show("Event Motos is not set.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			if (raceList.Count == 0)
			{
				MessageBox.Show("There Are No Races.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			int RacesPerMoto = raceList.Count / EventMotos;

			/* Get Races for First Moto, one by one */
			foreach (Race r in raceList)
			{
				RiderClass c = raceClasses.Find(x => x.Class_No == r.Class_No);
				GatesPerClass = (int)Math.Ceiling((float)c.Race_No / 8);

				List<Draw> filtered = drawList.FindAll(x => x.Race_No == r.Race_No);

				if (r.Moto_No == 1)
				{
					int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
					Shuffle(array);                                 // Fisher–Yates

					int i = 0;
					foreach (Draw d in filtered)
					{
						d.Lane_No = array[i];
						/* Save Lane selected in Moto1 */
						laneList.Add(new PreviousLane() { Membership_No = d.Membership_No, Lanes = new int[8] });
						laneList[laneList.Count - 1].Lanes[0] = d.Lane_No;
						i++;
					}
					i = 9;
				}
				else if (r.Moto_No == 2)
				{
					string lanesUsed = "";
					foreach (Draw d in filtered)
					{
						PreviousLane l = laneList.Find(x => x.Membership_No == d.Membership_No);
						if (GatesPerClass == 1)
						{
							d.Lane_No = Moto2TypeR[l.Lanes[0], r.Moto_No];
						}
						else
						{
							Link = Moto2TypeR[l.Lanes[0], r.Moto_No];
							for (i = 1; i <= 8; i++)
							{
								if (lanesUsed.Contains(Lane_Priority[Link, i].ToString()) == false)   // && l.Lanes.Contains(Lane_Priority[Link, i]) == false
								{
									d.Lane_No = Lane_Priority[Link, i];
									l.Lanes[r.Moto_No - 1] = d.Lane_No;
									break;
								}
							}
						}
						lanesUsed += d.Lane_No.ToString() + ";";
					}

				}
				else if (r.Moto_No >= 3)
				{
					string lanesUsed = "";
					foreach (Draw d in filtered)
					{
						PreviousLane l = laneList.Find(x => x.Membership_No == d.Membership_No);
						if (GatesPerClass == 1)
						{
							d.Lane_No = Moto2TypeR[l.Lanes[0], r.Moto_No];
						}
						else
						{
							Link = Last2Lanes[l.Lanes[r.Moto_No - 2], l.Lanes[r.Moto_No - 3]];          // l.Lanes array index is from 0
							for (i = 1; i <= 8; i++)
							{
								if (lanesUsed.Contains(Lane_Priority[Link, i].ToString()) == false)  //  && l.Lanes.Contains(Lane_Priority[Link, i]) == false
								{
									d.Lane_No = Lane_Priority[Link, i];
									l.Lanes[r.Moto_No - 1] = d.Lane_No;
									break;
								}
							}
						}
						lanesUsed += d.Lane_No.ToString() + ";";
					}
				}
			}
			DataService.UpdateRaceDraw(drawList);

			stopwatch.Stop();
			MessageBox.Show("Create Draw... " + stopwatch.ElapsedMilliseconds.ToString() + " milliseconds");
			raceBindingSource.DataSource = DataService.GetRaceList(EventSelected);
			i = 8;
		}



		private void AllocateGates()        // Allocate Gates where there is more than 1 gate for a class.
		{
			List<RiderClass> raceClasses = new List<RiderClass>();
			List<Draw> drawList;

			int GatesPerClass;
			int MotoCount = 0;
			int raceMin = 0;
			int raceMax = 0;
			int g = 0;

			string gateOrder;

			raceClasses = DataService.GetClassesRaceOrder(EventSelected);

			/* Allocate Riders to Races (Gates); 
             * Leave Lane Allocation to Latter */
			for (int m = 1; m <= EventMotos; m++)
			{
				/* Repeat for Each Moto */
				MotoCount++;
				foreach (RiderClass c in raceClasses)
				{
					GatesPerClass = (int)Math.Ceiling((float)c.Race_No / 8);
					if (GatesPerClass > 1)
					{
						var race = new Race() { EventID = EventSelected, Moto_No = MotoCount, Class_No = c.Class_No };

						drawList = DataService.GetRaceDrawByMotoClass(race);            // Order by Race_No, Lane_No
						raceMin = drawList[0].Race_No;
						raceMax = drawList[drawList.Count - 1].Race_No;

						drawList.Sort((v, w) => v.Last_Name.CompareTo(w.Last_Name));

						// order into name
						// random list for number of riders
						// alocate to gates
						// save
						var numbers = Enumerable.Range(1, c.Race_No).ToArray();
						Shuffle(numbers);

						int RidersPerGate = (int)Math.Ceiling((float)c.Race_No / GatesPerClass);
						gateOrder = "";
						int i = 0;
						foreach (Draw d in drawList)
						{
							g = (int)Math.Ceiling((float)numbers[i] / RidersPerGate);
							d.Race_No = raceMin + (g - 1);

							gateOrder += g.ToString() + ";";
							i++;
						}

						DataService.UpdateRaceDraw(drawList);
					}

				}
			}
		}



		private void CreateRaceList()
		{
			/* Get Class List in Race Order 
             * Only classes with riders including merge 
               Create a Race List to insert into DB */

			List<RiderClass> raceClasses = new List<RiderClass>();
			List<Race> raceList = new List<Race>();
			List<Rider> riderList = new List<Rider>();
			List<Draw> drawList = new List<Draw>();

			int RaceCount = 0;
			int GatesPerClass;
			int MotoCount = 0;

			raceClasses = DataService.GetClassesRaceOrder(EventSelected);

			/* Allocate Riders to Races (Gates); Leave Lane Allocation to Latter */
			for (int m = 1; m <= EventMotos; m++)
			{
				/* Repeat for Each Moto */
				MotoCount++;
				foreach (RiderClass c in raceClasses)
				{
					GatesPerClass = (int)Math.Ceiling((float)c.Race_No / 8);
					for (int g = 1; g <= GatesPerClass; g++)
					{
						RaceCount++;
						raceList.Add(new Race() { EventID = EventSelected, Race_No = RaceCount, Moto_No = MotoCount, Class_No = c.Race_Class, Gate_No = g });
					}

					/* riderList.Count should equal c.Race_No */
					riderList = DataService.GetRidersByRaceClass(EventSelected, c.Race_Class);
					//int j = 1;

					/* If only 1 Gate allocate all riders */
					if (GatesPerClass == 1)
					{
						foreach (Rider r in riderList)
						{
							drawList.Add(new Draw() { EventID = EventSelected, Race_No = RaceCount, Membership_No = r.Membership_No, RiderID = r.RiderID });
						}
					}
					else if (GatesPerClass > 1)
					{
						/* Randomly allocate Riders to Gates (where there is more than 1 Gate for this Class) */
						var numbers = Enumerable.Range(1, c.Race_No).ToArray();
						Shuffle(numbers);

						int RidersPerGate = (int)Math.Ceiling((float)c.Race_No / GatesPerClass);
						int g = 1;
						int i = 0;
						foreach (Rider r in riderList)
						{
							g = (int)Math.Ceiling((float)numbers[i] / RidersPerGate);
							drawList.Add(new Draw() { EventID = EventSelected, Race_No = RaceCount - GatesPerClass + g, Membership_No = r.Membership_No, RiderID = r.RiderID });
							i++;
						}
					}

				}
			}

			i = 99;
			/* Notify User Race list created
             * Only do this once for the event....*/
			if (raceList.Count > 0)
			{
				DataService.CreateRaceList(raceList);
				DataService.CreatedDraw(drawList);
			}
		}


		/* BtnCreateRacesRiders */
		private void button1_Click(object sender, EventArgs e)
		{
			CreateRaceList();
			raceBindingSource.DataSource = DataService.GetRaceList(EventSelected);

			thisEvent.Race_No = raceBindingSource.Count;
			DataService.UpdateEvent(thisEvent);
			if (thisEvent.Race_No > 0)
			{
				button1.Enabled = false;
			}
		}

		private void tabPage3_Enter(object sender, EventArgs e)
		{
			raceBindingSource.DataSource = DataService.GetRaceList(EventSelected);

			/*  thisEvent.Race_No = raceBindingSource.Count;
                DataService.UpdateEvent(thisEvent);
            */

			if (raceBindingSource.Count > 0)
			{
				button1.Enabled = false;
			}
			else
			{
				button1.Enabled = true;
			}
			//MessageBox.Show("Draw Page Enter...");
		}

		/* btnCreateDraw */
		private void button2_Click(object sender, EventArgs e)
		{
			DataService.ClearRaceDraw(EventSelected);
			AllocateGates();
			CreateDraw();

			thisEvent.Event_Status = 1;
			DataService.UpdateEvent(thisEvent);
		}

		/* NOT USED */
		private void button3_Click(object sender, EventArgs e)
		{
			AllocateGates();
		}

		private void btnPrintDraw_Click(object sender, EventArgs e)
		{
			using (frmPrintDraw frm = new frmPrintDraw(EventSelected))
			{
				frm.ShowDialog();
			}
		}

		private void tabPage3_Click(object sender, EventArgs e)
		{

		}

		/* Race List Tab (Draw) */
		private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Race obj = raceBindingSource.Current as Race;
			if (obj != null)
			{
				using (frmDrawEdit frm = new frmDrawEdit(obj))
				{
					/* Can write to the form here... */
					DialogResult dr = frm.ShowDialog();

					/* pointr to Rider Object is passed and is updated if "Save" is selected. */
					if (dr == DialogResult.OK)
					{
					}

				}
			}

		}

		private void btnClearDraw_Click(object sender, EventArgs e)
		{
			DataService.ClearRaceDraw(EventSelected);
		}


		private void btnDuplicateEvent_Click(object sender, EventArgs e)
		{
			Event newEvent = new Event();
			List<RiderClass> newClasses = new List<RiderClass>();

			var obj = eventBindingSource.Current as Event ?? new Event
			{
				Date = DateTime.Now,
				Moto_No = 6
			};

			if (obj == null)
			{
				return;
			}

			/* thisEvent must be populated first */
			newEvent.Name = obj.Name;
			newEvent.Date = obj.Date;
			newEvent.Moto_No = obj.Moto_No;
			newEvent.Result_File = obj.Result_File;

			using (frmEventEdit frm = new frmEventEdit(newEvent, true))
			{
				DialogResult dr = frm.ShowDialog();

				/* pntr to Event Object is passed and is updated if "Save" is selected. */
				if (dr == DialogResult.OK)
				{
					/* Create Event, note EventId is updated by CreateEvent() */
					if (DataService.CreateEvent(newEvent) != 0)
					{
						/* Create New Event Classes */
						newClasses = DataService.GetRiderClasses(obj.EventID);

						if (newClasses.Count == 0)
						{
							newClasses = new List<RiderClass> {
							CreateClass( "Mini Wheelers", 1, true),
							CreateClass("Sprockets B", 2, true),
							CreateClass("Sprockets A", 3, true),
							CreateClass("8 to 10 year", 4),
							CreateClass("11 to 12 year", 5),
							CreateClass("13 to 16 years", 6),
							CreateClass( "17+ Open Wheel", 7),
							CreateClass( "Novice", 8),
							CreateClass( "Open Women", 9),
							CreateClass( "MTB", 10)
							};
						}

						foreach (RiderClass c in newClasses)
						{
							c.EventID = newEvent.EventID;
							c.Race_Class = c.Class_No;      /* Must set this for default */
						}
						/* Only insert the fields to copy */
						DataService.CreateClasses(newClasses);
						i = 9;

						eventBindingSource.DataSource = DataService.GetEventList();
						dgvEvents.FirstDisplayedScrollingRowIndex = dgvEvents.RowCount - 1;
						SelectEvent(eventBindingSource.Current as Event);

					}
				}
			}
		}

		private RiderClass CreateClass(string name, int order, bool participation = false)
		{
			return new RiderClass
			{
				RaceOrder = order,
				Class_No = order,
				Race_Class = order,
				MinEntry = 3,
				Name = name,
				Type = participation ? "PART" : "ALLMOTO"
			};
		}

		private void btnPrintRiders_Click(object sender, EventArgs e)
		{
			using (frmPrintRiders frm = new frmPrintRiders(EventSelected))
			{
				frm.ShowDialog();
			}

		}


		private void SaveRaceResults()
		{
			int result;

			if (ScoringEntryDirty == false)
				return;

			ScoringEntryDirty = false;

			result = DataService.UpdateRaceResults(raceResults);
			if (result != raceResults.Count)
			{
				MessageBox.Show("Rows Saved does not match Results " + result.ToString() + ".", "Application Mssage", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			if (thisRace.Race_No > thisEvent.Race_Completed)
			{
				thisEvent.Race_Completed = thisRace.Race_No;
				lblRaceCompleted.Text = thisRace.Race_No.ToString();
				DataService.UpdateEvent(thisEvent);
			}

			/* If We Are Updating */
			if (timer1.Enabled)
			{
				RiderResultsToWebsite();
			}
		}


		private void ShowRaceStarttime()
		{
			if (thisRace.Starttime > DateTime.MinValue)
			{
				lblRaceStarttime.Text = thisRace.Starttime.ToString("HH:mm:ss.fff");
			}
			else
			{
				lblRaceStarttime.Text = "";
			}

		}

		private void ShowDisplayButton()
		{
			timer2.Stop();
			if (thisRace.Race_Status == 0)
			{
				btnDisplay.BackColor = Control.DefaultBackColor;
			}
			else if (thisRace.Race_Status == 1)
			{
				btnDisplay.BackColor = Color.LightGreen;
				timer2.Start();
			}
			else if (thisRace.Race_Status == 2)
			{
				btnDisplay.BackColor = Color.LightGreen;
			}

		}


		private void ShowRaceResults()
		{
			raceResults = eventResults.FindAll(c => c.Race_No == RaceSelected);
			raceResults.Sort((v, w) => v.Points.CompareTo(w.Points));
			if (raceResults.Count > 0)
			{
				thisRace = raceList[RaceSelected - 1];

				lblRaceSelected.Text = "Race " + thisRace.Race_No.ToString() + " - " + thisRace.Moto_Name + " " + thisRace.Class_Name;
				ShowRaceStarttime();

				if (thisRace.Class_Type == "PART")
				{
					motoPointsBindingSource.DataSource = partPoints;
					btnGetTimes.Visible = false;
					btnScore.Visible = false;
				}
				else
				{
					motoPointsBindingSource.DataSource = motoPoints;
					btnGetTimes.Visible = true;
					btnScore.Visible = true;
				}

			}
			else
			{
				lblRaceSelected.Text = "Race Selected....";
			}

			ShowDisplayButton();
			raceResultBindingSource.DataSource = raceResults;
		}


		private void tabPage5_Enter(object sender, EventArgs e)
		{
			raceList = DataService.GetRaceList(EventSelected);
			eventResults = DataService.GetRaceResults(EventSelected);

			ShowRaceResults();

			lblRace_No.Text = thisEvent.Race_No.ToString();
			lblRaceCompleted.Text = thisEvent.Race_Completed.ToString();

			if (thisEvent.Race_No == 0)
				btnDisplay.Enabled = false;
			else
				btnDisplay.Enabled = true;

			if (thisEvent.Event_Status == 1)
			{
				if (MessageBox.Show("It Looks Like Racing is About to Start\nDelete All Timing Records ?", "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataService.DeleteRaceTiming(EventSelected);

					gateRiders.Clear();
					gateDisplay.Clear();
					gateRidersBindingSource.ResetBindings(false);

					thisEvent.Event_Status = 2;
					DataService.UpdateEvent(thisEvent);
				}
			}
			//timer2.Start();
			i = 9;
		}

		private void btnRace_Next_Click(object sender, EventArgs e)
		{
			SaveRaceResults();
			if (RaceSelected == raceList.Count)
			{
				return;
			}
			RaceSelected += 1;
			//btnRacePrevious.Enabled = true;
			ShowRaceResults();
		}

		private void btnRacePrevious_Click(object sender, EventArgs e)
		{
			SaveRaceResults();
			if (RaceSelected == 1)
			{
				//btnRacePrevious.Enabled = false;
				return;
			}
			RaceSelected -= 1;
			//btnRacePrevious.Enabled = true;
			ShowRaceResults();
		}

		private void dgvRaceResult_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			// Force Commit when Combo is changed otherwise must leave row.
			DataGridViewColumn col = dgvRaceResult.Columns[dgvRaceResult.CurrentCell.ColumnIndex];
			if (col is DataGridViewComboBoxColumn)
			{
				dgvRaceResult.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}

		}

		private void dgvRaceResult_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			bool DNSOrDNFSelected = false;

			// This is bound to Combo in DataGridView
			MotoPoints objPoints = motoPointsBindingSource.Current as MotoPoints;
			if (objPoints != null)
			{
				ScoringEntryDirty = true;
				if (objPoints.Place == "DNS" || objPoints.Place == "DNF")
				{
					DNSOrDNFSelected = true;
				}
				else
				{
					RaceResult objResult = raceResultBindingSource.Current as RaceResult;
					if (objResult != null)
					{
						//MessageBox.Show(objResult.Place);
						objResult.Points = objPoints.Points;
					}
				}
			}
			/* c.Place.Trim() crashes if riders have NO Place assigned yet i.e. null. */
			/* Don't update for PART classes */
			if (DNSOrDNFSelected && thisRace.Class_Type == "ALLMOTO" && raceResults.Count > 1)
			{
				int NumberOfDNS = raceResults.Count(c => c.Place == "DNS");
				//MessageBox.Show(objPoints.Place);

				foreach (RaceResult y in raceResults)
				{
					if (y.Place == "DNS")
					{
						y.Points = raceResults.Count + 2;
					}
					else if (y.Place == "DNF")
					{
						y.Points = raceResults.Count - NumberOfDNS;
					}
				}
				raceResults.Sort((v, w) => v.Points.CompareTo(w.Points));

				ScoringEntryDirty = true;
				raceResultBindingSource.ResetBindings(false);
			}
		}


		private void btnRaceClear_Click(object sender, EventArgs e)
		{
			if (raceResults.Count == 0)
				return;

			// Change in RaceResult -> raceResultBindingSource -> dgvRaceResult     
			foreach (RaceResult r in raceResults)
			{
				r.Place = "";
				r.Points = 0;
				r.HillTime = TimeSpan.Zero;
				r.FinishTime = TimeSpan.Zero;
			}

			if (thisRace.Starttime != null && thisRace.Starttime != DateTime.MinValue)
			{
				DataService.UpdateRaceTimingRaceID(thisRace.Starttime, 0);
				thisRace.Starttime = DateTime.MinValue;
				thisRace.Race_Status = 0;
				DataService.UpdateRaceStatus(thisRace);
				ShowRaceStarttime();
				ShowDisplayButton();
			}

			//RacePointsMax = 0;
			raceResultBindingSource.ResetBindings(false);
			ScoringEntryDirty = true;
			SaveRaceResults();
		}


		private void ScoreRace(DateTime gateDropSelected, int raceID)
		{
			//MessageBox.Show(gateDropSelected.ToString("yyyy-MM-dd HH:mm:ss.fff"));
			RaceResult r = new RaceResult();

			thisRace.Starttime = gateDropSelected;
			thisRace.Race_Status = 1;
			DataService.UpdateRaceStatus(thisRace);
			ShowRaceStarttime();
			ShowDisplayButton();

			List<RaceTiming> gateDrop = DataService.GetRaceTimingByGate(gateDropSelected);

			DataService.UpdateRaceTimingRaceID(gateDropSelected, thisRace.RaceID);

			foreach (RaceTiming t in gateDrop)
			{
				r = raceResults.Find(c => c.Transponder.Trim() == t.Transponder);
				if (r != null)
				{
					if (t.Type_Name == "Start Hill")
					{
						r.HillTime = (t.Timestamp - t.Gatetime);
					}
					else if (t.Type_Name == "Finish Line")
					{
						r.FinishTime = (t.Timestamp - t.Gatetime);
					}
				}
				else  /* If Transponder not found search by Memebrship_No i.e Stuart Wittrien changes transponders at the break */
				{
					r = raceResults.Find(c => c.Membership_No == t.Membership_No);
					if (r != null)
					{
						if (t.Type_Name == "Start Hill")
						{
							r.HillTime = (t.Timestamp - t.Gatetime);
						}
						else if (t.Type_Name == "Finish Line")
						{
							r.FinishTime = (t.Timestamp - t.Gatetime);
						}
					}
				}
			}

			raceResults.Sort((v, w) => v.FinishTime.CompareTo(w.FinishTime));
			int placeCount = 1;
			foreach (RaceResult y in raceResults)
			{
				if (y.FinishTime == TimeSpan.Zero)
				{
					y.Points = raceResults.Count;
					y.Place = "DNF";
				}
				else
				{
					y.Points = placeCount;
					y.Place = motoPoints[y.Points].Place;
					placeCount += 1;
				}
			}
			raceResults.Sort((v, w) => v.Points.CompareTo(w.Points));

			ScoringEntryDirty = true;
			raceResultBindingSource.ResetBindings(false);

			//gateDropSelected = DateTime.Parse("2019-02-09 16:23:23.470");
			//MessageBox.Show(gateDropSelected.ToString("yyyy-MM-dd HH:mm:ss.fff"));

			gateDisplay.RemoveAll(d => (d.GateTime == gateDropSelected));
			gateRidersBindingSource.ResetBindings(false);
		}


		private void btnGetTimes_Click(object sender, EventArgs e)
		{
			/* Display all Timing Records for this event and select this race if it has been assigned. 
             * User selects the gatedrop to be used to score this race */
			using (frmEventTiming frm = new frmEventTiming(EventSelected, thisRace.RaceID))
			{
				DialogResult dr = frm.ShowDialog();

				/* pntr to Event Object is passed and is updated if "Score" is selected. */
				if (dr == DialogResult.OK)
				{
					ScoreRace(frm.GateDropSelected, thisRace.RaceID);
					SaveRaceResults();
				}
			}

		}

		private void dgvRaceResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			//return;
			if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
			var grid = (DataGridView)sender;

			if (grid.Columns[e.ColumnIndex].ValueType == typeof(TimeSpan) &&
					TimeSpan.Zero == (TimeSpan)grid[e.ColumnIndex, e.RowIndex].Value)
			{
				e.Value = " ";
				e.FormattingApplied = true;
			}
		}

		private void LogMessageToFile(string logMessage)
		{
			using (StreamWriter w = File.AppendText("log.txt"))
			{
				//w.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + logMessage);
				w.WriteLine(logMessage);
			}
		}


		private void ProcessPassingFile()
		{
			// Process the whole file...
			string[] lines = File.ReadAllLines(sPassingFileName);

			/* Template from Timing & Scoring

               00-09992,2018-02-24 13:47:18.357
               00-09992,2018-02-24 13:48:09.282
               HS-21773,2018-02-24 13:48:11.836
               GH-74296,2018-02-24 13:48:12.475
            */

			//               int x = lines.Length;             // Number of Passing entries in the File.
			//               int y = lines[0].Length;          // Should be 32 Characters per Passing.
			//               int z = lines[0].IndexOf(",");    // Should be at index 8 in the Passing.
			int passingType;
			int spanSeconds;

			string sTransponder; // = lines[0].Substring(0, 8);
			string sTimestamp; // = lines[0].Substring(9, 23);
			string sSQL = "";
			DateTime dtPassing;
			TimeSpan span;
			string Membership_No;
			int GateDropCount = 0;
			int RidersOnGateCount = 0;
			int RidersFinishedCount = 0;
			int index, index2;
			string First_Name, Last_Name, Class_Type;
			bool Transponder_Found;

			//MessageBox.Show(EventSelected.ToString());
			//return;

			/* Put this outside otherwise its called for each passing file detected */
			var csDestination = ConfigurationManager.ConnectionStrings["bscored"].ConnectionString;

			using (SqlConnection destinationConnection = new SqlConnection(csDestination))
			{
				if (destinationConnection.State == ConnectionState.Closed)
					destinationConnection.Open();

				foreach (string line in lines)
				{
					// Check line length and position of "," in string
					// Length should be 32 Characters, Position of "," should be 8; Otherwise bad string from Mylaps so reject it.
					if (line.Length != 32 || line.IndexOf(",") != 8)
					{
						continue;
					}

					/* This is a fixed format */
					sTransponder = line.Substring(0, 8);
					sTimestamp = line.Substring(9, 23);

					dtPassing = DateTime.ParseExact(sTimestamp, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

					/* The default if we cannot resolve this but its recorded anyway */
					passingType = -1;
					Membership_No = null;
					First_Name = "";
					Last_Name = "";
					Class_Type = "";


					if (sTransponder == "00-09992")
					{
						/* This is a Gate Drop */
						passingType = 0;
						dtGateDrop = dtPassing;

						GateDropCount++;
						RidersOnGateCount = 0;

						/* When Gate drops gateRiders is normally empty i.e. all previous gate riders crossed the finish line and get removed.
                           However if Rider did not complete the race or my be slow finishing need to check and delete any stuck ones...*/
						if (gateRiders.Count > 0)
						{
							foreach (GateRiders g in gateRiders)
							{
								g.Expiry = dtGateDrop - g.GateTime;
							}
							gateRiders.RemoveAll(r => (int)r.Expiry.TotalSeconds > 240);        // 4 minutes to get home after a crash...
							i = 8;
						}
						//LogMessageToFile(dtPassing.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + sTransponder + ", Type=" + passingType.ToString() );
					}
					else
					{
						/* Get Membership details for this transpnder - use the rider list for this event if ScoringOn = true */
						/* Might be better to put all trasnponders into another file */

						//sSQL = "select Membership_No, First_Name, Last_Name from OSM_Membership where (Member_Transponders LIKE '%" + sTransponder + "%' OR Transponder ='" + sTransponder + "') AND Status='Active'";
						/* Only if we are Racing... */
						if (thisEvent.Race_No > 0)
						{
							Transponder_Found = false;

							/* Get from Riderslist for this event - Racing */
							sSQL = "select Membership_No, First_Name, Last_Name, Type from Riders_List where EventId = " + EventSelected.ToString() + " AND Transponder ='" + sTransponder + "'";
							SqlCommand cmd1a = new SqlCommand(sSQL, destinationConnection);
							using (SqlDataReader reader = cmd1a.ExecuteReader())
							{
								/* This takes the first row returned */
								if (reader.Read())
								{
									Membership_No = (string)reader.GetValue(0);
									First_Name = (string)reader.GetValue(1);
									Last_Name = (string)reader.GetValue(2);
									Class_Type = (string)reader.GetValue(3);    // Trim ? 

									Transponder_Found = true;
								}
							}
							/* If Not found Rider may be using their other transponder so search the OSM_Membership Table */
							/* If License has expired and they race must set status=Active to be found */
							if (Transponder_Found == false)
							{
								// Depreciate use of Member_Transponders */
								//sSQL = "select Membership_No, First_Name, Last_Name from Member_Transponders where Chip_Code ='" + sTransponder + "' AND Status='Active'";
								sSQL = @"select Membership_No, First_Name, Last_Name from OSM_Membership 
where (Transponder_ID1 ='" + sTransponder + "' OR Transponder_ID2 ='" + sTransponder + "' OR Transponder_ID3 ='" + sTransponder + "')" +
" AND Status='Active'";
								SqlCommand cmd1b = new SqlCommand(sSQL, destinationConnection);
								using (SqlDataReader reader = cmd1b.ExecuteReader())
								{
									/* This takes the first row returned */
									if (reader.Read())
									{
										Membership_No = (string)reader.GetValue(0);
										First_Name = (string)reader.GetValue(1);
										Last_Name = (string)reader.GetValue(2);

										Transponder_Found = true;
									}
								}
							}
						}
						else
						{
							Transponder_Found = false;

							/* Search OSM_Transponders - Practice */
							/* If License has expired and they race must set status=Active to be found */

							// Depreciate use of Member_Transponders */
							//sSQL = "select Membership_No, First_Name, Last_Name from Member_Transponders where Chip_Code ='" + sTransponder + "' AND Status='Active'";
							sSQL = @"select Membership_No, First_Name, Last_Name from OSM_Membership 
where (Transponder_ID1 ='" + sTransponder + "' OR Transponder_ID2 ='" + sTransponder + "' OR Transponder_ID3 ='" + sTransponder + "')" +
" AND Status='Active'";
							SqlCommand cmd1c = new SqlCommand(sSQL, destinationConnection);
							using (SqlDataReader reader = cmd1c.ExecuteReader())
							{
								/* This takes the first row returned */
								if (reader.Read())
								{
									Membership_No = (string)reader.GetValue(0);
									First_Name = (string)reader.GetValue(1);
									Last_Name = (string)reader.GetValue(2);

									Transponder_Found = true;
								}
							}
							/* If Transponder Not found, Rider may have signed on to this Race with Transponder Code */
							if (Transponder_Found == false)
							{
								sSQL = "select Membership_No, First_Name, Last_Name from Riders_List where EventId = " + EventSelected.ToString() + " AND Transponder = '" + sTransponder + "'";
								SqlCommand cmd1d = new SqlCommand(sSQL, destinationConnection);
								using (SqlDataReader reader = cmd1d.ExecuteReader())
								{
									/* This takes the first row returned */
									if (reader.Read())
									{
										Membership_No = (string)reader.GetValue(0);
										First_Name = (string)reader.GetValue(1);
										Last_Name = (string)reader.GetValue(2);

										Transponder_Found = true;
									}
								}
							}
						}

						/* check to see if this Rider is Already on a gate */
						index = gateRiders.FindIndex(p => p.Transponder == sTransponder);
						if (index == -1)
						{
							/* Time to Last Gate drop */
							span = dtPassing - dtGateDrop;
							spanSeconds = (int)span.TotalSeconds;               // Must use TotalSeconds...

							/* Must be on this Gate ... */
							/* NO Rider might be on previous Gate so need to check */
							if (spanSeconds >= 1 && spanSeconds <= 15)
							{
								gateRiders.Add(new GateRiders() { GateTime = dtGateDrop, Transponder = sTransponder, Membership_No = Membership_No, Full_Name = First_Name + " " + Last_Name.ToUpper(), HillTime = dtPassing });

								/* Only if we are Racing... */
								if (thisEvent.Race_No > 0)
								{
									gateDisplay.Add(new GateRiders() { GateTime = dtGateDrop, Transponder = sTransponder, Membership_No = Membership_No, Full_Name = First_Name + " " + Last_Name.ToUpper(), HillTime = dtPassing });
									gateRidersBindingSource.ResetBindings(false);
								}

								passingType = 1;
								RidersOnGateCount++;
							}
						}

						else
						{
							/* Trasnponder is located in gateRiders
                             * record finish time, add it to the display list, remove it from the gate list */
							/* Check time from gatedrop to finish */

							span = dtPassing - gateRiders[index].GateTime;
							spanSeconds = (int)span.TotalSeconds;               // Must use TotalSeconds...
							if (spanSeconds >= 25 && spanSeconds <= 240)
							{
								gateRiders[index].FinishTime = dtPassing;
								Rider_GateTime = gateRiders[index].GateTime;

								/* Only if we are Racing... */
								if (thisEvent.Race_No > 0)
								{
									index2 = gateDisplay.FindIndex(p => p.Transponder == sTransponder);
									if (index2 != -1)
									{
										gateDisplay[index2].FinishTime = dtPassing;
										gateDisplay.Sort((u, v) => u.FinishTime.CompareTo(v.FinishTime));

										gateRidersBindingSource.ResetBindings(false);
									}
								}
								//gateRiders.Sort((u, v) => u.FinishTime.CompareTo(v.FinishTime));

								//if (gateRiders[index].GateTime != Finish_GateTime)
								//{
								//    gateDisplay.Clear();
								//    Finish_GateTime = gateRiders[index].GateTime;
								//}
								//gateDisplay.Add(gateRiders[index]);  // x2 ??
								//gateDisplay[gateDisplay.Count - 1] = gateRiders[index];

								gateRiders.RemoveAt(index);

								//gateRidersBindingSource.ResetBindings(false);

								//string sJson = JsonConvert.SerializeObject(gateDisplay);
								//TcpServer.BroadcastLine(sJson);

								passingType = 2;
								RidersFinishedCount++;
							}
							//}
						}

						//LogMessageToFile(dtPassing.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + sTransponder + ", Type=" + passingType.ToString() + ", Index=" + index.ToString() + ", Seconds=" + spanSeconds.ToString() + ", Gate=" + dtGateDrop.ToString("yyyy-MM-dd HH:mm:ss.fff"));
					}

					/* Must log every passing to EventSelected, including Membership_No
                     * Only uncertianty is weather it is a Start Hill or Finish Line event and what the gatedrop is...*/
					/* Mark any sprocket Transponders as Ignore during racing */

					if (passingType == -1)      /* Out of sequence passing, will show as Type = null and GateTime = null, need to set ignore flag = 1 */
					{
						sSQL = "INSERT INTO Mylaps_Pasing (EventId, Timestamp, Transponder, Membership_No, Ignore) VALUES (" + EventSelected.ToString() + ", '" + sTimestamp + "', '" + sTransponder + "', '" + Membership_No + "', 1)"; // @Timestamp, @Transponder)";
					}
					else if (passingType == 0)  /* Gate Drop */
					{
						sSQL = "INSERT INTO Mylaps_Pasing (EventId, Timestamp, Transponder, Type) VALUES (" + EventSelected.ToString() + ", '" + sTimestamp + "', '" + sTransponder + "', " + passingType.ToString() + "); SELECT SCOPE_IDENTITY()"; // @Timestamp, @Transponder)";
					}
					else if (passingType == 1)  /* Rider Start Hill Loop */
					{
						if (Class_Type == "PART")
							sSQL = "INSERT INTO Mylaps_Pasing (EventId, Timestamp, Transponder, Membership_No, Type, GateTime, Ignore) VALUES (" + EventSelected.ToString() + ", '" + sTimestamp + "', '" + sTransponder + "', '" + Membership_No + "', " + passingType.ToString() + ", '" + dtGateDrop.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', 1)";
						else
							sSQL = "INSERT INTO Mylaps_Pasing (EventId, Timestamp, Transponder, Membership_No, Type, GateTime) VALUES (" + EventSelected.ToString() + ", '" + sTimestamp + "', '" + sTransponder + "', '" + Membership_No + "', " + passingType.ToString() + ", '" + dtGateDrop.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
					}
					else if (passingType == 2)  /* Rider Finish Line Loop */
					{
						if (Class_Type == "PART")
							sSQL = "INSERT INTO Mylaps_Pasing (EventId, Timestamp, Transponder, Membership_No, Type, GateTime, Ignore) VALUES (" + EventSelected.ToString() + ", '" + sTimestamp + "', '" + sTransponder + "', '" + Membership_No + "', " + passingType.ToString() + ", '" + Rider_GateTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', 1)";
						else
							sSQL = "INSERT INTO Mylaps_Pasing (EventId, Timestamp, Transponder, Membership_No, Type, GateTime) VALUES (" + EventSelected.ToString() + ", '" + sTimestamp + "', '" + sTransponder + "', '" + Membership_No + "', " + passingType.ToString() + ", '" + Rider_GateTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
					}

					SqlCommand cmd2 = new SqlCommand(sSQL, destinationConnection);
					cmd2.ExecuteNonQuery();

				}

				destinationConnection.Close();

				/* Do this if the geteDisplay was updated */
				//gateRidersBindingSource.ResetBindings(false);
			}
		}

		/* This Polls every 1 second  */
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (panel1.BackColor == Color.Chartreuse)
			{
				panel1.BackColor = Color.Gray;
			}
			else
			{
				panel1.BackColor = Color.Chartreuse;
			}

			if (File.Exists(sPassingFileName))
			{
				Stopwatch stopwatch = Stopwatch.StartNew();

				timer1.Stop();
				Thread.Sleep(50);
				ProcessPassingFile();
				timer1.Start();

				File.Delete(sPassingFileName);

				stopwatch.Stop();
				lblTimer.Text = stopwatch.ElapsedMilliseconds.ToString();
			}
		}

		private void btnScoringOn_Click(object sender, EventArgs e)
		{
			//ScoringOn = true;
			timer1.Start();
			btnScoringOn.BackColor = Color.LightGreen;
			btnScoringOff.BackColor = Control.DefaultBackColor;
		}

		private void btnScoringOff_Click(object sender, EventArgs e)
		{
			//ScoringOn = false;
			timer1.Stop();
			btnScoringOff.BackColor = Color.LightCoral;
			btnScoringOn.BackColor = Control.DefaultBackColor;
		}

		private void dataGridView3_VisibleChanged(object sender, EventArgs e)
		{
			dataGridView3.SuspendLayout();
			foreach (DataGridViewRow row in dataGridView3.Rows)
			{
				if (row.Cells["Entry_No"].Value.ToString() != row.Cells["Draw_No"].Value.ToString())
				{
					row.DefaultCellStyle.BackColor = Color.Red;
					row.DefaultCellStyle.ForeColor = Color.White;
				}
			}
			dataGridView3.ResumeLayout();
		}

		private void btnPrintResults_Click(object sender, EventArgs e)
		{
			using (frmPrintResults frm = new frmPrintResults(EventSelected))
			{
				frm.ShowDialog();
			}

		}

		/*       private void button4_Click(object sender, EventArgs e)
			   {
				   ScoringOn = true;
				   button4.BackColor = Color.LightGreen;
				   button5.BackColor = Control.DefaultBackColor;
			   }

			   private void button5_Click(object sender, EventArgs e)
			   {
				   ScoringOn = false;
				   button5.BackColor = Color.LightCoral;
				   button4.BackColor = Control.DefaultBackColor;
			   }
	   */
		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete ALL timing data ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataService.DeleteRaceTiming(EventSelected);
				gateRiders.Clear();

				gateDisplay.Clear();
				gateRidersBindingSource.ResetBindings(false);
			}
		}

		/* Assign Place Automatically bu clicking on the cell */
		private void dgvRaceResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button7_Click(object sender, EventArgs e)
		{
			string sMessage;
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
			//Shuffle(array);
			var shuffled = array.OrderBy(x => Guid.NewGuid()).ToList();
			sMessage = "";
			foreach (int value in shuffled)
				sMessage = sMessage + value.ToString();

			int[] array1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
			//Shuffle(array);
			var shuffled2 = array1.OrderBy(x => Guid.NewGuid()).ToList();
			sMessage = sMessage + "\n";
			foreach (int value in shuffled2)
				sMessage = sMessage + value.ToString();

			int[] array2 = { 1, 2, 3, 4, 5, 6, 7, 8 };
			//Shuffle(array);
			var shuffled3 = array2.OrderBy(x => Guid.NewGuid()).ToList();
			sMessage = sMessage + "\n";
			foreach (int value in shuffled3)
				sMessage = sMessage + value.ToString();

			MessageBox.Show(sMessage);

		}


		/* Assign Place Automatically bu clicking on the cell */
		private void dgvRaceResult_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			//MessageBox.Show(e.ColumnIndex.ToString() );
			if (e.ColumnIndex == 0 && thisRace.Class_Type == "PART")
			{
				RaceResult r = raceResultBindingSource.Current as RaceResult;
				if (r != null)
				{
					//MessageBox.Show(thisRace.Class_Type + "; " + r.Place);
					// Get the Column for the Select Moto
					// Points are 0 for Participation Classes
					r.Place = "Finish";

					//dgvRaceResult.Refresh();
					raceResultBindingSource.ResetBindings(false);
					ScoringEntryDirty = true;
				}

			}
		}

		/* btnDisplay Click()  */
		private void button7_Click_1(object sender, EventArgs e)
		{
			DisplayResults d = new DisplayResults();
			d.race = thisRace;
			d.results = raceResults;

			string sJson = JsonConvert.SerializeObject(d);

			TcpServer.BroadcastLine(sJson);

			if (thisRace.Race_Status == 1)
			{
				thisRace.Race_Status = 2;
				DataService.UpdateRaceStatus(thisRace);
				ShowDisplayButton();
			}
		}


		private void btnScoringOn_Click_1(object sender, EventArgs e)
		{
			timer1.Start();
			btnScoringOn.BackColor = Color.LightGreen;
			btnScoringOff.BackColor = Control.DefaultBackColor;
		}


		private void btnScoringOff_Click_1(object sender, EventArgs e)
		{
			timer1.Stop();
			btnScoringOff.BackColor = Color.LightCoral;
			btnScoringOn.BackColor = Control.DefaultBackColor;
		}


		private void tabPage5_Leave(object sender, EventArgs e)
		{
			timer2.Stop();
			SaveRaceResults();
		}

		private void tabPage1_Leave(object sender, EventArgs e)
		{
			/* Update Rider count forthis EVent */
			thisEvent.Entry_No = ridersBindingSource.Count;
			DataService.UpdateEvent(thisEvent);

			/* Should do this if Rider Count or Classes Changed */
			DataService.UpdateClassCountAll(EventSelected);

		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (btnDisplay.BackColor == Color.LightGreen)
			{
				btnDisplay.BackColor = Control.DefaultBackColor;
			}
			else
			{
				btnDisplay.BackColor = Color.LightGreen;
			}

		}

		private void tabPage5_Click(object sender, EventArgs e)
		{

		}

		private void RidersGridFormat()
		{
			dgvRiders.SuspendLayout();
			foreach (DataGridViewRow row in dgvRiders.Rows)
			{
				//MessageBox.Show(row.Cells[5].Value.ToString());
				//break;
				if (row.Cells[5].Value.ToString() != " " && row.Cells[7].Value.ToString() == "0")
				{
					row.Cells[5].Style.ForeColor = Color.Red;
				}
				else
				{
					row.Cells[5].Style.ForeColor = Color.Black;
				}
				if (row.Cells[8].Value != null && row.Cells[8].Value.ToString() == "Inactive")
				{
					row.Cells[1].Style.ForeColor = Color.Red;
				}
				else
				{
					row.Cells[1].Style.ForeColor = Color.Black;
				}
			}
			dgvRiders.ResumeLayout();
		}


		private void btnChipStatus_Click(object sender, EventArgs e)
		{

			List<ChipStatus> chipList = new List<ChipStatus>();
			List<Rider> riderList = new List<Rider>();
			Rider r = new Rider();

			/* Unique List of Transponders in MyLaps_Pasing for this Event */
			chipList = DataService.GetChipStatus(EventSelected);

			/* Set Chip_Status to 0 for all riders in this event */
			DataService.ClearChipStatus(EventSelected);

			/* Get Rider for this event */
			riderList = DataService.GetRiders(EventSelected);

			/* Update Rider Chip_Status from chipList, note 00-09992 is included */
			foreach (ChipStatus s in chipList)
			{
				r = riderList.Find(c => c.Transponder.Trim() == s.Transponder);
				if (r != null)
					r.Chip_Status = 1;
			}

			/* Save Rider Chip_Status from riderList */
			DataService.UpdateChipStatus(riderList);

			RidersRefresh();
			RidersGridFormat();

			MessageBox.Show("All Transponders checked..");
		}

		/* Grid Formatting will not show on Tab Page Enter */
		private void dgvRiders_VisibleChanged(object sender, EventArgs e)
		{
			RidersGridFormat();
		}


		private void CreateRiderListPDF(string fileName = "")
		{
			// Variables
			Warning[] warnings;
			string[] streamIds;
			string mimeType = string.Empty;
			string encoding = string.Empty;
			string extension = string.Empty;

			// Setup the report viewer object and get the array of bytes
			ReportViewer viewer = new ReportViewer();
			viewer.ProcessingMode = ProcessingMode.Local;

			/* Physical copy of this file is placed in bin\debug folder 
            * Not sure how to get it as an embedded resource . */
			viewer.LocalReport.ReportEmbeddedResource = "bScored.Events.rptRiders.rdlc";
			//viewer.LocalReport.ReportPath = "rptRiders.rdlc";

			Event tEvent = DataService.GetEvent(EventSelected);
			List<Rider> rList = DataService.GetRiders(EventSelected);

			ReportDataSource rds = new ReportDataSource("dsRiders", rList);
			viewer.LocalReport.DataSources.Add(rds);

			ReportParameter p1 = new ReportParameter("EventName", tEvent.Name);
			ReportParameter p2 = new ReportParameter("RiderCount", rList.Count.ToString());

			viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

			byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

			string destFile = @"d:\temp\test.pdf";

			File.WriteAllBytes(destFile, bytes);

		}


		/* This is also in frmPrintResults */
		private void PopulateResults(List<RiderResults> rResults)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			/* Create a Crosstab, go through each race result and put in Moto column for the rider */
			List<RaceResult> eResults = DataService.GetRaceResults(EventSelected);

			foreach (RaceResult r in eResults)
			{
				var riderResult = rResults.Find(c => c.Membership_No == r.Membership_No && c.Race_Class == r.Class_No);
				if (riderResult != null)
				{
					if (r.Moto_No == 1)
					{
						riderResult.Moto_1 = r.Place;
						riderResult.Moto_1_HillTime = r.HillTime;
						riderResult.Moto_1_FinishTime = r.FinishTime;
						//riderResult.Last_FinishTime = r.FinishTime;
					}
					else if (r.Moto_No == 2)
					{
						riderResult.Moto_2 = r.Place;
						riderResult.Moto_2_HillTime = r.HillTime;
						riderResult.Moto_2_FinishTime = r.FinishTime;
						//riderResult.Last_FinishTime = r.FinishTime;
					}
					else if (r.Moto_No == 3)
					{
						riderResult.Moto_3 = r.Place;
						riderResult.Moto_3_HillTime = r.HillTime;
						riderResult.Moto_3_FinishTime = r.FinishTime;
						//riderResult.Last_FinishTime = r.FinishTime;
					}
					else if (r.Moto_No == 4)
					{
						riderResult.Moto_4 = r.Place;
						riderResult.Moto_4_HillTime = r.HillTime;
						riderResult.Moto_4_FinishTime = r.FinishTime;
						//riderResult.Last_FinishTime = r.FinishTime;
					}
					else if (r.Moto_No == 5)
					{
						riderResult.Moto_5 = r.Place;
						riderResult.Moto_5_HillTime = r.HillTime;
						riderResult.Moto_5_FinishTime = r.FinishTime;
						//riderResult.Last_FinishTime = r.FinishTime;
					}
					else if (r.Moto_No == 6)
					{
						riderResult.Moto_6 = r.Place;
						riderResult.Moto_6_HillTime = r.HillTime;
						riderResult.Moto_6_FinishTime = r.FinishTime;
						//riderResult.Last_FinishTime = r.FinishTime;
					}
				}
			}
			stopwatch.Stop();
			//            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString()); 
		}



		private string RaceResultFormat(string place, TimeSpan finish, TimeSpan hill)
		{
			string sResult;

			sResult = place;

			if (finish != TimeSpan.Zero)
			{
				if (finish.Minutes == 0)
					sResult += "\n" + finish.ToString(@"ss\.fff");
				else
					sResult += "\n" + finish.ToString(@"mm\:ss\.fff");
			}
			if (hill != TimeSpan.Zero)
			{
				sResult += "\n{" + hill.ToString(@"ss\.fff") + "}";
			}

			return sResult;
		}


		private string CreateEventResultCSV(Event tEvent)
		{
			//Stopwatch stopwatch = Stopwatch.StartNew();

			/* Get the Last results for each rider and save back into the rider */
			List<LastResults> lastResults = DataService.GetLastResults(tEvent.EventID);
			DataService.UpdateLastResults(lastResults);

			//stopwatch.Stop();
			//MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());

			List<RiderResults> rResults = DataService.GetRiderResults(tEvent.EventID);
			PopulateResults(rResults);

			StringBuilder sb = new StringBuilder();
			sb.Append("Rank,Plate,Name,Club,Points");
			if (tEvent.Moto_No > 0)
				sb.Append(", Moto 1");
			if (tEvent.Moto_No > 1)
				sb.Append(", Moto 2");
			if (tEvent.Moto_No > 2)
				sb.Append(", Moto 3");
			if (tEvent.Moto_No > 3)
				sb.Append(", Moto 4");
			if (tEvent.Moto_No > 4)
				sb.Append(", Moto 5");
			if (tEvent.Moto_No > 5)
				sb.Append(", Moto 6");

			sb.Append(",Class");
			sb.AppendLine();

			/* assume sort order is correct, group by class
               need to adjust if point is same use last finish time
            */
			int race_class = 0;
			int rank = 0;

			foreach (RiderResults r in rResults)
			{
				/*                if (r.Class_No != class_no)
								{
									class_no = r.Class_No;
									rank = 0;
								}
				*/
				if (r.Race_Class != race_class)
				{
					race_class = r.Race_Class;
					rank = 0;
				}
				if (r.Type == "ALLMOTO")
					rank++;
				else
					rank = 1;                           // Sprockets and Mini Wheelers

				if (rank != 0)
					sb.Append(rank.ToString() + ",");
				else
					sb.Append(",");

				sb.Append(r.Plate.Trim() + ",");
				if (r.Race_Class == r.Class_No)
					sb.Append(r.Full_Name + ",");
				else
					sb.Append("\"" + r.Full_Name + "\n(" + r.Class_Name + ")\",");

				sb.Append(r.Club + ",");
				if (r.Points > 0)
					sb.Append(r.Points.ToString() + ",");
				else
					sb.Append(",");

				/* Place "" around this with embedded \n */
				if (tEvent.Moto_No > 0)
					sb.Append("\"" + RaceResultFormat(r.Moto_1, r.Moto_1_FinishTime, r.Moto_1_HillTime) + "\",");
				if (tEvent.Moto_No > 1)
					sb.Append("\"" + RaceResultFormat(r.Moto_2, r.Moto_2_FinishTime, r.Moto_2_HillTime) + "\",");
				if (tEvent.Moto_No > 2)
					sb.Append("\"" + RaceResultFormat(r.Moto_3, r.Moto_3_FinishTime, r.Moto_3_HillTime) + "\",");
				if (tEvent.Moto_No > 3)
					sb.Append("\"" + RaceResultFormat(r.Moto_4, r.Moto_4_FinishTime, r.Moto_4_HillTime) + "\",");
				if (tEvent.Moto_No > 4)
					sb.Append("\"" + RaceResultFormat(r.Moto_5, r.Moto_5_FinishTime, r.Moto_5_HillTime) + "\",");
				if (tEvent.Moto_No > 5)
					sb.Append("\"" + RaceResultFormat(r.Moto_6, r.Moto_6_FinishTime, r.Moto_6_HillTime) + "\",");

				if (r.Race_Class == r.Class_No)
					sb.Append(r.Class_Name);
				else
					sb.Append(r.Merged_To);

				sb.AppendLine();
			}

			return sb.ToString();
		}


		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// The background process is complete. We need to inspect
			// our response to see if an error occurred, a cancel was
			// requested or if we completed successfully.  
			if (e.Cancelled)
			{
				lblWebReport.Text = "Task Cancelled.";
			}
			// Check to see if an error occurred in the background process.
			else if (e.Error != null)
			{
				lblWebReport.Text = e.Error.Message;
				//MessageBox.Show(e.Error.Message);
			}
			else
			{
				// Everything completed normally.
				lblWebReport.Text = "Task Completed...";
			}
		}


		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage == 1)
			{
				lblWebReport.Text = "Report Created......";
			}
			else if (e.ProgressPercentage == 2)
			{
				lblWebReport.Text = "Website Connected......";
			}
			else if (e.ProgressPercentage == 3)
			{
				lblWebReport.Text = "Transferring Report......";
			}
			else if (e.ProgressPercentage == 4)
			{
				lblWebReport.Text = "Transfer Complete......";
			}
		}


		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			if (currentSettings.Host == null || currentSettings.Host.Length == 0)
				return;

			Event tEvent = DataService.GetEvent(EventSelected);

			if (tEvent.Result_File == null || tEvent.Result_File.Trim().Length == 0)
				return;

			string csvString = CreateEventResultCSV(tEvent);
			string pathLocalFile = Path.GetTempPath() + tEvent.Result_File.Trim();
			File.WriteAllText(pathLocalFile, csvString);

			backgroundWorker1.ReportProgress(1);

			string host = currentSettings.Host;
			string username = currentSettings.UserName;
			string password = currentSettings.Password;

			// Path to file on SFTP server 
			string destinationPath = currentSettings.DestinationPath;

			using (SftpClient sftp = new SftpClient(host, username, password))
			{
				sftp.Connect();
				backgroundWorker1.ReportProgress(2);

				sftp.ChangeDirectory(destinationPath);

				using (FileStream fs = new FileStream(pathLocalFile, FileMode.Open))
				{
					backgroundWorker1.ReportProgress(3);

					sftp.BufferSize = 4 * 1024;
					sftp.UploadFile(fs, Path.GetFileName(pathLocalFile));
				}

				sftp.Disconnect();
				backgroundWorker1.ReportProgress(4);
			}

		}



		private void RiderResultsToWebsite()
		{

			if (backgroundWorker1.IsBusy == false)
			{
				backgroundWorker1.RunWorkerAsync();
			}

		}

		private void btnWebsite_Click(object sender, EventArgs e)
		{
			Event tEvent = DataService.GetEvent(EventSelected);

			if (currentSettings.Host == null || currentSettings.Host.Length == 0)
			{
				MessageBox.Show("The WEB Host is not configured...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			if (tEvent.Result_File == null || tEvent.Result_File.Trim().Length == 0)
			{
				MessageBox.Show("This Event has no Report File configured...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			RiderResultsToWebsite();
		}


		private void btnMylaps_Click(object sender, EventArgs e)
		{
			/* Chek online with Mylpas each Transponder Subscription Status */
			using (frmMylapsSubscription frm = new frmMylapsSubscription(EventSelected))
			{
				frm.ShowDialog();
			}
		}


		private void btnEventOpen_Click(object sender, EventArgs e)
		{
			var obj = eventBindingSource.Current as Event;
			if (SelectEvent(obj) == true)
			{
				if (MessageBox.Show("Enable Transponder Passing Updates ?\n", "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					timer1.Start();
					btnScoringOn.BackColor = Color.LightGreen;
					btnScoringOff.BackColor = Control.DefaultBackColor;
				}

				//MessageBox.Show(thisEvent.Name + " Selected..." + thisEvent.Date.Year.ToString() + "/" + thisEvent.Date.Month.ToString("D2"), "System Message");
				tabControl1.SelectedIndex = 1;
			}

		}

		private void btnScore_Click(object sender, EventArgs e)
		{
			int ridersMatched = 0;
			DateTime gateSelected = DateTime.MinValue;

			if (thisRace.Starttime > DateTime.MinValue)
			{
				//MessageBox.Show(" Gate: " + thisRace.Starttime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
				MessageBox.Show("This Race has been Scored...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			/* For Selected Race searh for riders not yet allocated in timing data, must find 2 riders  */
			foreach (RaceResult c in raceResults)
			{
				//MessageBox.Show(c.Full_Name + ", " + c.Membership_No.ToString() + ", " + c.Transponder);
				List<RaceTiming> z = DataService.GetRaceTimingNextGateByMember(EventSelected, c.Membership_No);
				if (z.Count > 0)
				{
					/* Assume Matched Riders vare on same gate */
					ridersMatched++;
					gateSelected = z[0].Gatetime;
				}
				/* Stop Checking when 2 are found */
				if (ridersMatched >= 2)
				{
					break;
				}
			}

			if (ridersMatched == 0)
			{
				MessageBox.Show("No Timing Data Found...", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else if (ridersMatched < 2)
			{
				MessageBox.Show("Could not find enough matches\nPlease use Get Times to Assign..", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			//MessageBox.Show("Riders Matched: " + ridersMatched.ToString() + ", Gate: " + gateSelected.ToString("yyyy-MM-dd HH:mm:ss.fff"));

			ScoreRace(gateSelected, thisRace.RaceID);
			SaveRaceResults();

			btnDisplay.PerformClick();
		}


		private void dvgGateRiders_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				GateRiders obj = gateRidersBindingSource.Current as GateRiders;
				if (obj != null)
				{
					/* This clears out the underlying object */
					gateRidersBindingSource.RemoveCurrent();
				}
			}
		}

		private void ShowSettings()
		{
			using (frmSettings frm = new frmSettings())
			{
				DialogResult dr = frm.ShowDialog();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ShowSettings();
		}

		private void dgvEvents_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode != Keys.Delete))
			{
				return;
			}

			var obj = eventBindingSource.Current as Event;
			if (obj == null)
			{
				return;
			}
			if (MessageBox.Show("Are you sure you want to delete Event\n" + obj.Name, "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				/* Delete from all associated Tables for this EventID
                  result[0] Delete from Event Table
                  result[1] Delete from Classes Table
                  result[2] Delete from Riders Table
                  result[3] Delete from Races Table
                  result[4] Delete from Results Table 
                  result[5] Delete from Mylpas_Pasing Table
                */
				int[] result = DataService.DeleteEvent(obj.EventID);

				eventBindingSource.RemoveCurrent();
			}
		}


		private void dgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var obj = eventBindingSource.Current as Event;
			if (obj == null)
			{
				return;
			}

			using (frmEventEdit frm = new frmEventEdit(obj, false))
			{
				DialogResult dr = frm.ShowDialog();
				/* pntr to Event Object is passed and is updated if "Save" is selected. */
				if (dr == DialogResult.OK)
				{
					/* Save to Events Table */
					eventBindingSource.ResetBindings(false);

					/* Update Event Table for this Event */
					if (DataService.UpdateEvent(obj, 1) == 1)
					{
						/* If this is the selectecd event need to reload event */
						if (obj.EventID == thisEvent?.EventID)
						{
							SelectEvent(obj, 1);        // Surpress Timer=Off
							MessageBox.Show(obj.Name + " Updated.\nEvent Motos: " + EventMotos.ToString() + "\nResult File: " + thisEvent.Result_File, "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show(obj.Name + " Updated.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}

		}

		private void btnDeleteRaces_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete the draw\nAll Races and Results will be deleted.", "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataService.DeleteRaceList(EventSelected);
				DataService.DeleteDraw(EventSelected);

				raceBindingSource.DataSource = DataService.GetRaceList(EventSelected);

				thisEvent.Race_No = raceBindingSource.Count;
				thisEvent.Event_Status = 0;
				DataService.UpdateEvent(thisEvent);

				button1.Enabled = true;
			}
		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}

		private void dvgGateRiders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
			var grid = (DataGridView)sender;

			// if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Balance"))

			if (grid.Columns[e.ColumnIndex].ValueType == typeof(TimeSpan) &&
					TimeSpan.Zero == (TimeSpan)grid[e.ColumnIndex, e.RowIndex].Value)
			{
				e.CellStyle.ForeColor = Color.Red;
			}
		}

		private void btnClassMoveUp_Click(object sender, EventArgs e)
		{
			int rowIndex;
			rowIndex = dgvClasses.SelectedCells[0].OwningRow.Index;

			if (rowIndex > 0)
			{
				RiderClass obj = thisClasses[rowIndex];

				thisClasses.Remove(obj);
				thisClasses.Insert(rowIndex - 1, obj);

				riderClassBindingSource.ResetBindings(false);
				dgvClasses.ClearSelection();
				dgvClasses.Rows[rowIndex - 1].Selected = true;

				ClassMoveUpDown = true;
			}
		}


		private void btnClassMoveDown_Click(object sender, EventArgs e)
		{
			int rowIndex;
			rowIndex = dgvClasses.SelectedCells[0].OwningRow.Index;

			if (rowIndex < thisClasses.Count - 1)
			{
				RiderClass obj = thisClasses[rowIndex];

				thisClasses.Remove(obj);
				thisClasses.Insert(rowIndex + 1, obj);

				riderClassBindingSource.ResetBindings(false);
				dgvClasses.ClearSelection();
				dgvClasses.Rows[rowIndex + 1].Selected = true;

				ClassMoveUpDown = true;
			}

		}

		private void tabPage2_Leave(object sender, EventArgs e)
		{
			//MessageBox.Show("Leaving Class Tab");
			if (ClassMoveUpDown == true)
			{
				ClassMoveUpDown = false;

				int raceOrder = thisClasses.Count;

				foreach (RiderClass c in thisClasses)
				{
					c.RaceOrder = raceOrder;
					raceOrder--;
				}

				DataService.ClassRaceOrdersSave(thisClasses);
			}
		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}
	}
}
