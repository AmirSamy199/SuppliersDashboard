using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class PRDetailscs
    {
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> EmployeeSalary { get; set; }
        public decimal daily_salary { get; set; }
        public decimal hourly_salary { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string DateFrom_ { get; set; }
        public string DateTo_ { get; set; }
        public string Date_ { get; set; }
        public string OverTimeShift { get; set; }
        public string DeductionType { get; set; }
        public Nullable<decimal> DeductionDelay { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string OverTimeM { get; set; }
        public string OverTimeN { get; set; }
        public string[] OverTimeM_ { get; set; }
        public decimal OverTimeMHours { get; set; }
        public decimal OverTimeMMin { get; set; }
        public decimal TotalovertimeM { get; set; }
        public string[] OverTimeN_ { get; set; }
        public decimal OverTimeNHours { get; set; }
        public decimal OverTimeNMin { get; set; }
        public decimal TotalovertimeN { get; set; }
        public string[] Missing_ { get; set; }
        public decimal MissingHours { get; set; }
        public decimal MissingMin { get; set; }
        public decimal MissingDeduction { get; set; }
        public string[] Duration_ { get; set; }
        public decimal DurationHours { get; set; }
        public decimal DurationMin { get; set; }
        public decimal Durationtotal { get; set; }
        public decimal Durationtotal_ { get; set; }
        public decimal DeductionDelayAmount { get; set; }
        public string Missing { get; set; }
        public string Delay { get; set; }
        public int DelayDayes { get; set; }
        public string Duration { get; set; }
    }
}