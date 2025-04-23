using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class AssignShifts
    {
        public int RecordID { get; set; }
        public Nullable<int> shift_id { get; set; }
        public string CompanyName { get; set; }
        public string ShiftName { get; set; }
        public Nullable<int> Com_ID { get; set; }
        public Nullable<System.TimeSpan> durationFrom { get; set; }
        public String DurationFromString { get; set; }
        public String DurationToString { get; set; }
        public TimeSpan durationTo { get; set; }
        public string Hours { get; set; }
        public string Editor { get; set; }
        public string DelayAllowedString { get; set; }
        public Nullable<System.TimeSpan> DelayAllowed { get; set; }
        public Nullable<int> DeductionType { get; set; }
        public Nullable<decimal> DeductionAmount { get; set; }
        public string DeductionTypeName { get; set; }

    }
}