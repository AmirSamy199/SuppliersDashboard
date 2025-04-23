using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Insurance
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> EmployeeSalary { get; set; }
        public Nullable<decimal> Insurance_Fee { get; set; }
        public Nullable<decimal> Worker_share { get; set; }
        public Nullable<decimal> Employers_share { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}