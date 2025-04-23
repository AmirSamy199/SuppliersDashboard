using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class VacationSettings
    {
        public string date { get; set; }
        public int DimDateID { get; set; }
        public string _DateValue { get; set; }
        public System.DateTime DateValue { get; set; }
        public Nullable<int> Day { get; set; }
        public Nullable<int> Week { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Quarter { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> DayOfWeek { get; set; }
        public bool IsCalenderHoliday { get; set; }
        public bool IsPublicHoliday { get; set; }
        public string description { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Editor_date { get; set; }
        public string Editordate { get; set; }
    }
}