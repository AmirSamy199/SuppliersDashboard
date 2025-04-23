using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class VacationBooking_V
    {
        public int RecordID { get; set; }
        public Nullable<int> Vacation_ID { get; set; }
        public string AR_TypeName { get; set; }
        public string EN_TypeName { get; set; }
        public Nullable<int> Remaining_Balance { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EN_EmployeeName { get; set; }
        public string AR_EmployeeName { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Status { get; set; }
        public Nullable<int> Actual_Balance { get; set; }
        public Nullable<int> Vacation_Balance { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Date_ { get; set; }
        public string Editor { get; set; }
        public Nullable<decimal> Deduction { get; set; }
    }
}