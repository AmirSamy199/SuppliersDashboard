using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class PayRoleAttend
    {
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public decimal daily_salary { get; set; }
        public decimal hourly_salary { get; set; }
        public decimal OverTimeHours { get; set; }
        public decimal OverTimeMin { get; set; }
        public string[] TotalMorning_ { get; set; }
        public decimal OverTimeNHours { get; set; }
        public decimal OverTimeNMin { get; set; }
        public string[] TotalNight_ { get; set; }
        public string OverTimeShift { get; set; }
        public DateTime DateFrom { get; set; }
        public string DateFrom_ { get; set; }
        public DateTime DateTo { get; set; }
        public string DateTo_ { get; set; }
        public string TotalMorningOverTime { get; set; }
        public decimal TotalMorning { get; set; }
        public string TotalNightOverTime { get; set; }
        public decimal TotalNight { get; set; }
        public string TotalMissing { get; set; }
        public string TotalDelay { get; set; }
        public decimal MissingHours { get; set; }
        public decimal MissingMin { get; set; }
        public decimal MissingDeduction { get; set; }
        public string[] TotalMissing_ { get; set; }
        public string totalDuration { get; set; }
        public decimal DurationHours { get; set; }
        public decimal DurationMin { get; set; }
        public decimal Duration { get; set; }
        public string[] TotalDuration_ { get; set; }

        public Nullable<System.TimeSpan> ComHoursTo { get; set; }
        public Nullable<int> DeductionType { get; set; }
        public Nullable<decimal> DeductionDelay { get; set; }
        public Nullable<int> DelayDayes { get; set; }
        public decimal DeductionDelayAmount { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal Durationtotal_ { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal VacationDeduction { get; set; }
        public decimal MissionsDeduction { get; set; }
        public decimal ExcusesDeduction { get; set; }
        public decimal Violation_Amount { get; set; }
        public decimal YearlySalary { get; set; }
        public decimal ActualyearlyVat { get; set; }
        public decimal ActualMonthlyVat { get; set; }
        public decimal YearlyTotalSalary { get; set; }
        public decimal FinalyTotalSalary { get; set; }
        public decimal FinalyTotalSalary2 { get; set; }
        public decimal YearlyTotalVat { get; set; }
        public decimal MonthlyTotalVat { get; set; }
        public decimal VAT { get; set; }
        public decimal Worker_share { get; set; }
        public decimal Bouns_Amount { get; set; }
        public decimal ExchangeAmount { get; set; }
        public decimal TakafulContribution { get; set; }



    }
}