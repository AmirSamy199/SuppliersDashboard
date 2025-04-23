using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class HrAttendance
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
        public Nullable<int> Level_ID { get; set; }
        public string time { get; set; }
        public string time_leave { get; set; }
        public string Duration { get; set; }
        public string OverTime { get; set; }
        public string Delay { get; set; }
        public string Missing { get; set; }
        public Nullable<int> AbsentStatues { get; set; }
        public string Deduction { get; set; }
        public Nullable<int> DeductionID { get; set; }
        public Nullable<decimal> DeductionAmount { get; set; }
        public string Execuses { get; set; }
        public Nullable<int> ExecusesID { get; set; }
        public Nullable<decimal> Excuses_Amount { get; set; }
        public string Missions { get; set; }
        public Nullable<int> MissionsID { get; set; }
        public Nullable<decimal> Deduction_Amount { get; set; }
        public string Vacation { get; set; }
        public Nullable<int> VacationsID { get; set; }
        public Nullable<int> VacationAmount { get; set; }
        public string Violation { get; set; }
        public Nullable<int> ViolationID { get; set; }
        public Nullable<decimal> ViolationAmount { get; set; }
        public string Absences { get; set; }
    }
}