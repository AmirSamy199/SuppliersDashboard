using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class TerminationOfStaff
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string EnJob { get; set; }
        public string ArJob { get; set; }
        public string Job_Name { get; set; }
        public string LeavingTypeName { get; set; }
        public Nullable<int> Leaving_Type { get; set; }
        public string _DateOfRejoin { get; set; }
        public string _EndDate { get; set; }
        public string JobID { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> DateOfRejoin { get; set; }
        public Nullable<decimal> Indemnity { get; set; }

    }
}