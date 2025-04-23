using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class violationsAction
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> violations_ID { get; set; }
        public string violationsName { get; set; }
        public string violations_Desc { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Action_type { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
    }
}