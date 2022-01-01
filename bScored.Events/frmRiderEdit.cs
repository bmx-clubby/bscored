using bScored;
using bScoredDatabase;
using bScoredDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class frmRiderEdit : Form
    {
        public Rider RiderInfo { get; set; }
        public bool RiderAddMode { get; set; }
        private Form1 frmParent;

        List<Member> MemberInfo;
        List<MemberFind> Memberfind;
        List<RiderClass> Classes;
        TimeSpan span;
        int EventSelected;
        bool RiderHasBeenAdded = false;
        int numberofRaces = 0;

        public frmRiderEdit(Rider obj, bool pAddMode, int NumberOfRaces, Form1 frm1)
        {
            InitializeComponent();

            /* Get Class for this event, Maybe Cache this */
            Classes = DataService.GetRiderClasses(obj.EventID);

            cboRiderClass.DataSource = Classes;
            cboRiderClass.DisplayMember = "Name";
            cboRiderClass.ValueMember = "Class_No";
            cboRiderClass.Text = "";

            /* Remember for when adding more riders */
            EventSelected = obj.EventID;

            /* obj is Rider object passed in */
            /* A blank Rider object is passed in if Add Mode is selected but EventId is filled in */
            RiderInfo = obj;
            RiderAddMode = pAddMode;
            numberofRaces = NumberOfRaces;
            frmParent = frm1;

            /* In Edit Mode Cannot change Class if Races are already Created ? or could fix it up automatically....*/
            if (RiderAddMode == true)
            {
                this.Text += " - Add Mode";
                lblSearch.Visible = true;
            }
            else
            {
                this.Text += " - Edit Mode";
                lblSearch.Visible = false;
            }

            if (RiderAddMode == false && numberofRaces > 0)
            {
                cboRiderClass.Enabled = false;
            }

            //MessageBox.Show("Number of Races: " + numberofRaces.ToString());
        }


        private void frmRiderDetails_Load(object sender, EventArgs e)
        {
            if (RiderAddMode == false)
            {
                txtFullName.Text = RiderInfo.Full_Name;
                txtMembership_No.Text = RiderInfo.Membership_No;
                txtAge.Text = RiderInfo.Age.ToString();
                txtPlate.Text = RiderInfo.Plate.Trim();
                //cboRiderClass.Text = RiderInfo.Class_Name;
                cboRiderClass.SelectedValue = RiderInfo.Class_No;

                /* Need to reteive details from OSM_Memebrship Table */
                MemberInfo = DataService.FindMemberByNumber(RiderInfo.Membership_No);

                if (MemberInfo.Count == 1)
                {
                    txtMember_Type.Text = MemberInfo[0].Member_Type;
                    txtExpiry.Text = MemberInfo[0].Financial_date.ToString("dd MMM yyyy");
                    txtBirthDate.Text = MemberInfo[0].BirthDate.ToString("dd MMM yyyy");
                    txtClub.Text = MemberInfo[0].Club;
                    txtEmergency_Name.Text = MemberInfo[0].Emergency_Contact_Person;
                    txtEmergency_Number.Text = MemberInfo[0].Emergency_Contact_Number;
                    txtGender.Text = MemberInfo[0].Gender;

                    SetExpiryStatus(MemberInfo[0]);

                    SetTransponder(MemberInfo[0]);
                }

                cboTranspoders.Text = RiderInfo.Transponder.Trim();

                if (string.IsNullOrWhiteSpace(cboTranspoders.Text) && cboTranspoders.Items.Count>0)
                {
                   cboTranspoders.Text = cboTranspoders.Items[0].ToString();
                }
            }
            else
            {
                //txtLicense.ReadOnly = false;
                txtFullName.ReadOnly = false;
                /* This will be Zero for a blank record */
                cboRiderClass.SelectedValue = RiderInfo.Class_No;
            }

            pboxStatus.Image = SystemIcons.Error.ToBitmap();
        }

        private void SetTransponder(Member m)
        {
            if (m == null)
                return;

            cboTranspoders.Items.Clear();

            if (!String.IsNullOrWhiteSpace(m.Transponder_ID1))
            {
                cboTranspoders.Items.Add(m.Transponder_ID1);
            }
            if (!String.IsNullOrWhiteSpace(m.Transponder_ID2))
            {
                cboTranspoders.Items.Add(m.Transponder_ID2);
            }
            if (!String.IsNullOrWhiteSpace(m.Transponder_ID3))
            {
                cboTranspoders.Items.Add(m.Transponder_ID3);
            }

            /* Hide Transponders for Participation Classes unless they have a transponder */
            //MessageBox.Show("SetTransponde Transponders: " + cboTranspoders.Items.Count.ToString());

            if (cboRiderClass.SelectedIndex >= 0 && cboRiderClass.SelectedIndex <= Classes.Count)
                if (Classes[cboRiderClass.SelectedIndex].Type == "PART" && cboTranspoders.Items.Count == 0)
                    cboTranspoders.Visible = false;
                else
                    cboTranspoders.Visible = true;
        }


        private void SetExpiryStatus(Member m)
        {
            DateTime DateNow = DateTime.Now;
            span = m.Financial_date.Date - DateNow.Date;
            int days = span.Days;

            //pictureBox1.Image = SystemIcons.Error.ToBitmap();

            lblStatus.Text = "";
            if (days < 0)
            {
                //lblExpiryStatus.Text = "Expired..";
                //lblExpiryStatus.ForeColor = Color.Red;
                lblStatus.Text = "License Expired";

            }
            else if (days < 14)
            {
                lblExpiryStatus.Text = "Expires Soon..";
                lblExpiryStatus.ForeColor = Color.Red;
            }
            else
            {
                //lblExpiryStatus.Text = "Good..";
                //lblExpiryStatus.ForeColor = Color.ForestGreen;
            }

            if (m.Medical_Suspension == "Yes")
            {
                lblStatus.Text = "Medical Suspension";
            }
            else if (m.Disciplinary_Suspension == "Yes")
            {
                lblStatus.Text = "Disciplinary Suspension";
            }
            else if (m.Other_Suspension == "Yes")
            {
                lblStatus.Text = "Other Suspension";
            }
            else if (m.POA_Suspension == "Yes")
            {
                lblStatus.Text = "Proof of Age Suspension";
            }
            else if (m.Status == "Inactive")
            {
                lblStatus.Text = "License Expired";
            }

            /* Some AusCycling Licenses are not for BMX Racing */
            if (m.Race_Status==false)
            {
                lblStatus.Text = "Non BMX Racing License";
                btnSave.Enabled = false;
            }
            else
                btnSave.Enabled = true;


            if (lblStatus.Text.Length > 0)
            {
                lblStatus.Visible = true;
                pboxStatus.Visible = true;
            }
            else
            {
                lblStatus.Visible = false;
                pboxStatus.Visible = false;
            }
        }

        private void SetAge(DateTime BirthDate)
        {
            /* SQL version YEAR(GETDATE()) - YEAR(dbo.OSM_Membership.BirthDate) AS Age */
            DateTime DateNow = DateTime.Now;
            int years = (DateNow.Year - BirthDate.Year);
            txtAge.Text = years.ToString();
        }

        private void DisplayNewRider()
        {
            /* Values for new Rider */
            RiderInfo.Membership_No = MemberInfo[0].Membership_No;
            RiderInfo.First_Name = MemberInfo[0].First_Name;
            RiderInfo.Last_Name = MemberInfo[0].Last_Name;
            /* Rider Preferrences */
            //                           RiderInfo.Transponder = MemberInfo[0].Transponder;
            //                           RiderInfo.Plate = MemberInfo[0].Plate;

            txtMembership_No.Text = RiderInfo.Membership_No;
            txtFullName.Text = RiderInfo.Full_Name;
            txtFullName.ReadOnly = true;
            //txtLicense.ReadOnly = true;

            /* Need to Add Suspension Details; Medical_Suspension, Disciplinary_Suspension, Other_Suspension */
            txtExpiry.Text = MemberInfo[0].Financial_date.ToString("dd MMM yyyy");
            txtBirthDate.Text = MemberInfo[0].BirthDate.ToString("dd MMM yyyy");
            txtMember_Type.Text = MemberInfo[0].Member_Type;
            txtClub.Text = MemberInfo[0].Club;
            txtEmergency_Name.Text = MemberInfo[0].Emergency_Contact_Person;
            txtEmergency_Number.Text = MemberInfo[0].Emergency_Contact_Number;
            txtGender.Text = MemberInfo[0].Gender;
            txtPlate.Text = MemberInfo[0].Plate;
 
            SetAge(MemberInfo[0].BirthDate);

            SetExpiryStatus(MemberInfo[0]);                         
            SetTransponder(MemberInfo[0]);

            cboTranspoders.Text = MemberInfo[0].Transponder;

            if (string.IsNullOrWhiteSpace(cboTranspoders.Text) && cboTranspoders.Items.Count > 0)
            {
                cboTranspoders.Text = cboTranspoders.Items[0].ToString();
            }

            cboRiderClass.SelectedValue = MemberInfo[0].Class_No;

            lblSearch.Visible = false;
            //btnSave.Enabled = true;  /*
        }

        private void ClearForm()
        {
            /*  Use Databinding ?? */
            txtMembership_No.Text = "";
            txtFullName.Text = "";
            txtExpiry.Text = "";
            txtClub.Text = "";
            txtEmergency_Name.Text = "";
            txtEmergency_Number.Text = "";
            txtGender.Text = "";
            txtPlate.Text = "";
            txtAge.Text = "";
            txtBirthDate.Text = "";
            txtMember_Type.Text = "";

            lblExpiryStatus.Text = "Expiry Status";
            lblExpiryStatus.ForeColor = Color.Black;

            lblStatus.Text = "";
            pboxStatus.Visible = false;

            cboTranspoders.Text = "";
            cboRiderClass.Text = "";
            cboRiderClass.SelectedValue = 0;

            txtFullName.ReadOnly = false;
            //txtLicense.ReadOnly = false;
            btnSave.Enabled = false;
            lblSearch.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (RiderHasBeenAdded)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;

        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (cboRiderClass.SelectedValue == null)
            {
                MessageBox.Show("Please Select Rider Class.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            /* Update Rider object from UI */
            RiderInfo.Plate = txtPlate.Text;
            RiderInfo.Class_No = (int)cboRiderClass.SelectedValue;
            RiderInfo.Class_Name = cboRiderClass.Text;
            RiderInfo.Transponder = cboTranspoders.Text;

            /* Save new Rider and Loop for next one */
            if (RiderAddMode == true)
            {
                if (DataService.FindRiderByClass(RiderInfo) > 0)
                {
                    MessageBox.Show(RiderInfo.Full_Name + " Already Exists.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                /* Save Class and Transponder to member preferences in OSM_Members table */
                DataService.UpdateMemberPreference(RiderInfo);

                if (DataService.AddRider(RiderInfo) != 0)
                {
                    /* Races and Race Draw/Resuilts are already created so need to add this rider */
                    if (numberofRaces > 0)
                    {
                        List<Draw> drawList = new List<Draw>();

                        /* This gets Gate 1 for each moto for this class
                          * Need to check if the riders class is merged */
                        List<RiderClass> classList = DataService.GetRiderClasses(EventSelected);  /* This already exists as Classes ...*/
                        RiderClass c = classList.Find((x => x.Class_No == RiderInfo.Class_No));
                        if (c == null)
                        {

                        }
                        List<Race> raceList = DataService.GetRaceListByRaceClass(EventSelected, c.Race_Class);
                        foreach (Race r in raceList)
                        {
                            drawList.Add(new Draw() { EventID = EventSelected, Race_No = r.Race_No, Membership_No = RiderInfo.Membership_No, RiderID = RiderInfo.RiderID });
                        }
                        DataService.CreatedDraw(drawList);
                        //return;
                    }

                    RiderHasBeenAdded = true;
                    frmParent.RidersRefresh();

                    MessageBox.Show(RiderInfo.Full_Name + " Added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Rider obj = new Rider();
                    obj.EventID = EventSelected;

                    RiderInfo = obj;

                    ClearForm();
                    txtFullName.Focus();

                    //if (this.Width == 930)
                    //    this.Width = 430;

                    //ridersBindingSource.Add(EventRider);
                    //ridersBindingSource.MoveLast();

                    // Need to Update Rider Totals
                    //DataService.UpdateClassCount(EventId, EventRider.Class_No);
                    //DataService.UpdateRiderCount(EventId);
                }

            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /* For Aus Cycling */
        private static bool GetRaceStatus(string member_type)
        {
            if (member_type.Contains("All Discipline"))
            {
                return true;
            }
            else if (member_type.Contains("Kids"))
            {
                return true;
            }
            else if (member_type.Contains("Race"))
            {
                return true;
            }
            else if (member_type.Contains("One Day"))
            {
                return true;
            }
            else if (member_type.Contains("7 Day"))
            {
                return true;
            }

            return false;
        }

        private int ProcessQRCode(string[] qrcode)
        {
            /*  QR Code can be from any club */
            /*  QR Code contains the following seperated by \n:
            *  1 = Membership_No
            *  2 = First_Name
            *  3 = Last_Name
            *  4 = BirthDate
            *  5 = Emmergency_Contact_Person
            *  6 = Emmergency_Contact_Number
            *  7 = Club
            *  8 = Member_Type
            *  9 = Status
            * 10 = Financial_Date
            */

            using (var db = DatabaseConnection.GetConnection())
            {
                using (var transaction = db.BeginTransaction())
                {
                    /* This May Fail if Club not in table, so insert it */
                    var club = db.GetClubFromClub(qrcode[6], transaction);
                    if (club == null)
                    {
                        var newclub = new Clubs
                        {
                            Club = qrcode[6],
                            Club_Code = Guid.NewGuid().ToString("N").Substring(0, 10),
                            State = ""
                        };

                        var result = db.InsertClub(newclub, transaction);

                        if (result == 1) club = newclub;
                        else return -1;
                    }

                    var member = new Member
                    {
                        Membership_No = qrcode[0],
                        First_Name = qrcode[1],
                        Last_Name = qrcode[2],
                        BirthDate = Convert.ToDateTime(DateTime.Parse(qrcode[3]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)),
                        Emergency_Contact_Person = qrcode[4],
                        Emergency_Contact_Number = qrcode[5],
                        Club = qrcode[6],
                        Club_Code = club.Club_Code,
                        Gender = "Undisclosed",
                        Member_Type = qrcode[7],
                        Status = qrcode[8] == "Active" ? "Active" : "Inactive",
                        Financial_date = Convert.ToDateTime(DateTime.Parse(qrcode[9]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)),
                        Race_Status = GetRaceStatus(qrcode[7]),
                    };

                    //Try updating using auscycling membershipNo
                    var rowsAffected = db.UpdateMemberFromQRCode(member, member.Membership_No, transaction);

                    if (rowsAffected == 1)
                    {
                        transaction.Commit();
                        return 1;
                    }

                    //If Not Found search on First_Name, Last_Name, DOB 
                    var matches = db.FindMemberByFirstNameLastNameDob(member.First_Name, member.Last_Name, member.BirthDate, transaction);

                    // Do not Merge to exisiting Member if TidyHQ Member is Non Riding or LifeStyle Membership
                    if (matches.Count == 1 && member.Race_Status == true)
                    {
                        rowsAffected = db.UpdateMemberFromQRCode(member, matches[0].Membership_No, transaction);
                        if (rowsAffected == 1)
                        {
                            //Change membership no
                            //log.Info($"Membership number updated ({matches[0].Membership_No} => {member.Membership_No} )");
                            db.ChangeMembershipNumber(matches[0].Membership_No, member.Membership_No, transaction);
                            transaction.Commit();
                            return 2;
                        }
                    }

                    // Otherwise Insert this Member
                    rowsAffected = db.InsertMemberFromQRCode(member, transaction);
                    if (rowsAffected == 1)
                    {
                        transaction.Commit();
                        return 3;
                    }

                    return -1;
                }
            }
        }


        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            string[] QRCode = null;

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtFullName.Text))
                    return;

                /* Check for QRCode Scanned */
                if (txtFullName.Text.Length > 1 && txtFullName.Text.Substring(0, 2) == "AC")
                {
                    QRCode = txtFullName.Text.Split(new string[] { "\\n" }, StringSplitOptions.None);
                    if (QRCode.Length == 10)
                    {
//                        MessageBox.Show("QR Code Match");

                        txtFullName.Text = QRCode[0];

                        var result = ProcessQRCode(QRCode);

                        string msg = "Member " + QRCode[0] + "; " + QRCode[1] + " " + QRCode[2];

                        if (result > 0)
                        {
                            if (result == 1) MessageBox.Show(msg + " updated.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == 2) MessageBox.Show(msg + " merged.","Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == 3) MessageBox.Show(msg + " inserted.","Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MemberInfo = DataService.FindMemberByNumber(txtFullName.Text);
                            DisplayNewRider();
                            return;
                        }
                        else MessageBox.Show(msg + " update FAILED !", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if(QRCode.Length > 10)
                    {
                        MessageBox.Show("Incorrect QR Code Length, Please Try Again.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFullName.Text = "";
                        return;
                    }
                }

                /* Check for Transponder Entered */
                if (Regex.Match(txtFullName.Text, "^[A-Za-z]{2}[-][0-9]{5}").Success )
                {
//                    MessageBox.Show("Trasnponder Match: "+txtFullName.Text);

                    Memberfind = DataService.FindMemberByTransponder(txtFullName.Text);
                    if (Memberfind.Count == 1)
                    {
                        MemberInfo = DataService.FindMemberByNumber(Memberfind[0].Membership_No);
                        DisplayNewRider();
                    }
                    else
                    {
                        memberFindBindingSource.DataSource = Memberfind;
                        /* Make the Grid Visible */
                        this.Width = 1065;
                    }
                    
                    return;
                }

                /* Check for Membership Numebr BMXA= 999999, AC999999 or MB999999  */
                if (Regex.Match(txtFullName.Text, "[0-9]{6}").Success)
                {
//                    MessageBox.Show("Membership Number Match: "+ txtFullName.Text);

                    MemberInfo = DataService.FindMemberByNumber(txtFullName.Text);
                    if (MemberInfo.Count == 1)
                    {
                        DisplayNewRider();
                        return;
                    }

                    /* Seacrch BMXA_No Column if Rider has upgraded to Auscycle but scans old BMXA card */
                    MemberInfo = DataService.FindMemberByBMXANo(txtFullName.Text);
                    if (MemberInfo.Count == 1)
                    {
                        DisplayNewRider();
                        return;
                    }
                }

                // Must be Name entered so try and find it.
                string s;

                /* Replace apostrophe with double apostrophe for SQL Server Query e.g. A'BECKETT => A''BECKETT */
                if (txtFullName.Text.Contains("'"))
                    s = txtFullName.Text.Replace("'", "''");
                else
                    s = txtFullName.Text;

                //         MessageBox.Show(s);
                string[] Names = s.Split(' ');

                Memberfind = DataService.FindMemberByName(Names);
                //dataGridView1.DataSource = MemberResult;
                if (Memberfind.Count == 0)
                {
                    memberFindBindingSource.DataSource = Memberfind;
                    /* Make the Grid Visible */
                    this.Width = 1065;
                }
                else if (Memberfind.Count == 1)
                {
                    MemberInfo = DataService.FindMemberByNumber(Memberfind[0].Membership_No);
                    DisplayNewRider();
                }
                else
                {
                    memberFindBindingSource.DataSource = Memberfind;
                    /* Make the Grid Visible */
                    this.Width = 1065;
                }

            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberFind obj = memberFindBindingSource.Current as MemberFind;
            if (obj != null)
            {
                MemberInfo = DataService.FindMemberByNumber(obj.Membership_No);
                DisplayNewRider();
            }
        }

        private void cboRiderClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Hide Transponders for Participation Classes unless they have a transponder */
            //MessageBox.Show("cboRiderClass Transponders: " + cboTranspoders.Items.Count.ToString());

            if (cboRiderClass.SelectedIndex >= 0 && cboRiderClass.SelectedIndex <= Classes.Count)
                if (Classes[cboRiderClass.SelectedIndex].Type == "PART" && cboTranspoders.Items.Count == 0)
                    cboTranspoders.Visible = false;
                else
                    cboTranspoders.Visible = true;

        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            using (frmMemberNew frm2 = new frmMemberNew())
            {
                DialogResult dr = frm2.ShowDialog();

                if (dr == DialogResult.OK)
                {
//                  MessageBox.Show(frm2.Membership_No);
                    MemberInfo = DataService.FindMemberByNumber(frm2.Membership_No);
                    DisplayNewRider();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (RiderInfo.Membership_No == null)
            {
                MessageBox.Show("Rider has not been Selected.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (frmRiderHistory frm = new frmRiderHistory(RiderInfo.Membership_No, RiderInfo.Full_Name))
            {
                frm.ShowDialog();
            }

        }


        private void btnModify_Click(object sender, EventArgs e)
        {
            if (RiderInfo.Membership_No == null)
            {
                MessageBox.Show("Rider has not been Selected.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("This form is to Update some Membership Details for an exisiitng Rider. Only do this if QR Code or TidyHQ import is not avaliable.  Proceed... ", "Application Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (frmMemberNew frm2 = new frmMemberNew("", MemberInfo[0]))
            {
                /* Can write to the form here... */
                DialogResult dr = frm2.ShowDialog();

                /* pointr to Rider Object is passed and is updated if "Save" is selected. */
                if (dr == DialogResult.OK)
                {
//                  MessageBox.Show(frm2.Membership_No);
                    MemberInfo = DataService.FindMemberByNumber(frm2.Membership_No);
                    DisplayNewRider();
                }

            }

        }
    }

}
