using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class DeductionAction
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public string DeductionName { get; set; }
        public Nullable<int> Deduction_ID { get; set; }
        public Nullable<decimal> Deduction_Amount { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
    }
}