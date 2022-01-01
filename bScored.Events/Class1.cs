using System;
using System.Collections.Generic;

namespace WindowsFormsApp7
{

    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Entry_No { get; set; }
        public int Moto_No { get; set; }
        public int Race_No { get; set; }
        public string Result_File { get; set; }
        public int Race_Completed { get; set; }
        public int Event_Status { get; set; }
    }

   

    public class MemberFind
    {
        public string Membership_No { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Member_Type { get; set; }
        public string Club { get; set; }

    }

    /* Also used in bScoredSeries */
    public class Rider
    {
        public int RiderID { get; set; }
        public int EventID { get; set; }
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Plate { get; set; }
        public string Transponder { get; set; }
        public string Club { get; set; }
        public int Class_No { get; set; }
        public string Class_Name { get; set; }
        public string Merged_To { get; set; }
        public int Race_Class { get; set; }
        public int Chip_Status { get; set; }
        public string Membership_Status { get; set; }
        public int RaceOrder { get; set; }

        public string Full_Name
        {
            get { return this.First_Name + " " + (this.Last_Name != null ? this.Last_Name.ToUpper() : this.Last_Name); }
        }
    }


    public class RiderHistory
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Plate { get; set; }
        public string Transponder { get; set; }
        public string Class_Name { get; set; }

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name.ToUpper(); }
        }
    }


    /* Should be called EventClass */
    public class RiderClass
    {
        public int ClassID { get; set; }
        public int EventID { get; set; }
        public int Class_No { get; set; }
        public string Name { get; set; }
        public int RaceOrder { get; set; }
        public int FinalOrder { get; set; }
        public int MinEntry { get; set; }
        public string Type { get; set; }
        public int Entry_No { get; set; }
        public int Gate_No { get; set; }
        public int Race_Class { get; set; }
        public int Race_No { get; set; }
        public string Merged_To { get; set; }

    }

    public class Race
    {
        public int RaceID { get; set; }
        public int EventID { get; set; }
        public int Race_No { get; set; }
        public int Moto_No { get; set; }
        public string Moto_Name { get; set; }
        public int Class_No { get; set; }
        public string Class_Name { get; set; }
        public string Class_Type { get; set; }
        public int Gate_No { get; set; }
        public bool Draw_Status { get; set; }
        public DateTime Starttime { get; set; }
        public int Race_Status { get; set; }
        public int Entry_No { get; set; }
        public int Draw_No { get; set; }
    }

    public class Draw
    {
        public int ResultID { get; set; }
        public int EventID { get; set; }
        public int Race_No { get; set; }
        public int Lane_No { get; set; }
        public int RiderID { get; set; }
        public string Plate { get; set; }
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Group { get; set; }
        public int Moto_No { get; set; }
        public int Class_No { get; set; }

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name.ToUpper(); }
        }
    }

    public class MotoDraw
    {
        public int Race_No { get; set; }
        public int Moto_No { get; set; }
        public int Class_No { get; set; }
        public string Class_Name { get; set; }
        public int Lane_No { get; set; }
        public string Plate { get; set; }
        public string Full_Name { get; set; }
        public string Group { get; set; }
        public int Race_No2 { get; set; }
        public int Moto_No2 { get; set; }
        public int Class_No2 { get; set; }
        public string Class_Name2 { get; set; }
        public string Plate2 { get; set; }
        public string Full_Name2 { get; set; }
        public string Group2 { get; set; }
    }

    public class PreviousLane
    {
        public string Membership_No { get; set; }
        public int[] Lanes { get; set; }
    }

    public class MotoPoints
    {
        public string Place { get; set; }
        public int Points { get; set; }
    }

    /* Also used in bScoredSeries */
    public class RaceResult
    {
        public int ResultID { get; set; }
        public int EventID { get; set; }
        public int Race_No { get; set; }
        public int Lane_No { get; set; }
        public string Plate { get; set; }
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Transponder { get; set; }
        public TimeSpan HillTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public string Place { get; set; }
        public int Points { get; set; }
        public int Moto_No { get; set; }
        public int Class_No { get; set; }   /* This may not be needed */

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name; }
        }
    }

    public class RaceTiming
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Transponder { get; set; }
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Gatetime { get; set; }
        public int Type { get; set; }
        public string Type_Name { get; set; }
        public string Race_Name { get; set; }
        public int RaceId { get; set; }
        public int Ignore { get; set; }

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name; }
        }

    }

    public class GateRiders
    {
        public DateTime GateTime { get; set; }
        public string Transponder { get; set; }
        public string Membership_No { get; set; }
        public string Full_Name { get; set; }
        public DateTime HillTime { get; set; }
        public DateTime FinishTime { get; set; }

        public TimeSpan Hill
        {
            get { return HillTime - GateTime; }
        }
        public TimeSpan Finish
        {
            get { if (FinishTime > GateTime) { return FinishTime - GateTime; } else { return TimeSpan.Zero; } }
        }
        public TimeSpan Expiry;
    }


    public class RiderResults
    {
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Plate { get; set; }
        public string Class_Name { get; set; }
        public int Class_No { get; set; }
        public int RaceOrder { get; set; }
        public int Race_Class { get; set; }
        public string Merged_To { get; set; }
        public string Type { get; set; }
        public string Club { get; set; }
        public int Points { get; set; }
        public TimeSpan FinishTime { get; set; }
        public string Moto_1 { get; set; }
        public TimeSpan Moto_1_HillTime { get; set; }
        public TimeSpan Moto_1_FinishTime { get; set; }
        public string Moto_2 { get; set; }
        public TimeSpan Moto_2_HillTime { get; set; }
        public TimeSpan Moto_2_FinishTime { get; set; }
        public string Moto_3 { get; set; }
        public TimeSpan Moto_3_HillTime { get; set; }
        public TimeSpan Moto_3_FinishTime { get; set; }
        public string Moto_4 { get; set; }
        public TimeSpan Moto_4_HillTime { get; set; }
        public TimeSpan Moto_4_FinishTime { get; set; }
        public string Moto_5 { get; set; }
        public TimeSpan Moto_5_HillTime { get; set; }
        public TimeSpan Moto_5_FinishTime { get; set; }
        public string Moto_6 { get; set; }
        public TimeSpan Moto_6_HillTime { get; set; }
        public TimeSpan Moto_6_FinishTime { get; set; }

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name.ToUpper(); }
        }
    }

    public class LastResults
    {
        public int EventId { get; set; }
        public int Race_No { get; set; }
        public string Membership_No { get; set; }
        public string Place { get; set; }
        public int Points { get; set; }
        public TimeSpan HillTime { get; set; }
        public TimeSpan FinishTime { get; set; }
    }



    public class DisplayResults
    {
        public Race race { get; set; }
        public List<RaceResult> results { get; set; }
    }

    public class ChipStatus
    {
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Transponder { get; set; }
    }


}
