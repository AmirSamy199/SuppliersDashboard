using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Attendence
    {
        public int Employee_ID { get; set; }
        public int Duration { get; set; }
        public string EnglishName { get; set; }
        public string Department { get; set; }
        public string Lm_E_Name { get; set; }
        public Nullable<System.DateTime> AttendDate { get; set; }
        public string _Date { get; set; }
        public string Time { get; set; }

    }
}