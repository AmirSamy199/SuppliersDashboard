using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ExcuseAction
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> Excuse_ID { get; set; }
        public string ExcuseName { get; set; }
        public Nullable<int> Excuses_Amount { get; set; }
        public Nullable<int> Excuses_Remaning { get; set; }
        public Nullable<decimal> Deduction { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
    }
}