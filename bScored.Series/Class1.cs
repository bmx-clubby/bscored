using System;

namespace bScoredSeries
{

    public class Series
    {
        public int SeriesID { get; set; }
        public string Name { get; set; }
        public string Sponser { get; set; }
        public string Administrator { get; set; }
        public int Numer_of_Rounds { get; set; }
        public int Min_Non_Mandatory { get; set; }
        public DateTime Date { get; set; }
        public string Result_File { get; set; }
     }

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

    public class SeriesEvent
    {
        public int ID { get; set; }
        public int SeriesID { get; set; }
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Entry_No { get; set; }
    }


    public class SeriesRider
    {
        public int SeriesID { get; set; }
        public string Membership_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Club { get; set; }
        public int Class_No { get; set; }
        public string Class_Name { get; set; }
        public int? R1_Total { get; set; }          /* Make These Nullable */
        public int? R2_Total { get; set; }
        public int? R3_Total { get; set; }
        public int? R4_Total { get; set; }
        public int? R5_Total { get; set; }
        public int? R6_Total { get; set; }
        public int? R7_Total { get; set; }
        public int? R8_Total { get; set; }
        public int? R9_Total { get; set; }
        public int? R10_Total { get; set; }
        public int? R11_Total { get; set; }
        public int? R12_Total { get; set; }
        public int? R13_Total { get; set; }
        public int? R14_Total { get; set; }
        public int? R15_Total { get; set; }
    }


    public class SeriesResults
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Club { get; set; }
        public int Class_No { get; set; }
        public string Class_Name { get; set; }

        public TimeSpan HillTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int Entered { get; set; }
        public int Series_Total { get; set; }

        public int? R1_Total { get; set; }       /* Make These Nullable */
        public int? R2_Total { get; set; }
        public int? R3_Total { get; set; }
        public int? R4_Total { get; set; }
        public int? R5_Total { get; set; }
        public int? R6_Total { get; set; }
        public int? R7_Total { get; set; }
        public int? R8_Total { get; set; }
        public int? R9_Total { get; set; }
        public int? R10_Total { get; set; }
        public int? R11_Total { get; set; }
        public int? R12_Total { get; set; }
        public int? R13_Total { get; set; }
        public int? R14_Total { get; set; }
        public int? R15_Total { get; set; }

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name.ToUpper(); }
        }
    }


    /* Also used in bScoredEvents */
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

        public string Full_Name
        {
            get { return this.First_Name + " " + this.Last_Name.ToUpper(); }
        }
    }

    /* Also used in bScoredEvents */
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

}
