using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
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
        public int Entry_No { get; set; }
        public int Draw_No { get; set; }
    }

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

         public string Full_Name
         {
             get { return this.First_Name + " " + this.Last_Name; }
         }
     }


    public class DisplayResults
    {
        public Race race { get; set; }
        public List<RaceResult> results { get; set; }
    }

}
