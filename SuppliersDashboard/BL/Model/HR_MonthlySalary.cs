using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class HR_MonthlySalary

    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public Nullable<decimal> EmployeeSalary { get; set; }
        public Nullable<decimal> ExchangeAmount { get; set; }
        public Nullable<int> Bouns_ID { get; set; }
        public Nullable<decimal> Bouns_Amount { get; set; }
        public Nullable<decimal> Total_Salary { get; set; }
        public string EmployeeName { get; set; }
        public string BounsName { get; set; }
        public string ExchangeName { get; set; }
        public Nullable<int> Exchange_ID { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }

    }
}