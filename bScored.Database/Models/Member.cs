using System;

namespace bScoredDatabase.Models
{
    public class Member
    {
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Emergency_Contact_Person { get; set; }
        public string Emergency_Contact_Number { get; set; }
        public DateTime Financial_date { get; set; }
        public string Status { get; set; }
        public string Member_Type { get; set; }
        public string Club { get; set; }
        public string Club_Code { get; set; }
        public string Member_Transponders { get; set; }       /* Move to Transponder_ID1, Transponder_ID2, Transponder_ID3 */
        public string Medical_Suspension { get; set; }
        public string Disciplinary_Suspension { get; set; }
        public string Other_Suspension { get; set; }
        public string POA_Suspension { get; set; }            /* Proof of Age Suspension */
        public bool Race_Status { get; set; }                 /* Indicate if AC Membership has BMX Racing status */
        
        /* Rider Preferences */
        public int Class_No { get; set; }
        public string Plate { get; set; }
        public string Transponder { get; set; }
        public string BMXA_No { get; set; }

        public string Transponder_ID1 { get; set; }
        public string Transponder_ID2 { get; set; }
        public string Transponder_ID3 { get; set; }

    }


}
