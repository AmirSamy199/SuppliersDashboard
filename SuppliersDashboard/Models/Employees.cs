using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class Employees
    {
        public int RecordID { get; set; }
        public int Emp_Manager { get; set; }
        public int Employee_ID { get; set; }
        public string EmNationalCode { get; set; }
        public string EnglishName { get; set; }
        public string NationalCode { get; set; }
        public string ArabicName { get; set; }
        public string NationalID { get; set; }
        public string TypeName { get; set; }
        public string TitleName { get; set; }
        public string JobName { get; set; }
        public string EmployeeInsrance { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EmployeeDegree { get; set; }
        public Nullable<int> Employee_degree { get; set; }

        public string CompanyName { get; set; }
        public Nullable<int> EmployeeCompany { get; set; }


        public string ManagerName { get; set; }
        public string DegreeName { get; set; }

        public string _Date_of_hiring { get; set; }
        public string _End_of_hiring { get; set; }
        public string _Date_of_Birth { get; set; }
        public Nullable<System.DateTime> DateOfHiring { get; set; }
        public Nullable<System.DateTime> EndOfHiring { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int Title { get; set; }
        public string Nationality { get; set; }
        public Nullable<int> Gender { get; set; }
        public string GenderName { get; set; }
        public Nullable<int> PositionType { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeDepartment { get; set; }
        public Nullable<int> Emp_Job { get; set; }
        public Nullable<decimal> EmployeeSalary { get; set; }

        public string jobLevel { get; set; }
        public string jobCategories { get; set; }
        public Nullable<System.DateTime> ID_StartDate { get; set; }
        public Nullable<System.DateTime> ID_ExpDate { get; set; }
        public Nullable<System.DateTime> Graduation_Date { get; set; }
        public string IDStartDate { get; set; }
        public string IDExpDate { get; set; }
        public string GraduationDate { get; set; }
        public Nullable<int> Edu_Grade { get; set; }
        public Nullable<int> Military_Status { get; set; }
        public string Place_Of_Birth { get; set; }
        public string MotherName { get; set; }
        public Nullable<int> University { get; set; }
        public Nullable<int> Martial_Status { get; set; }
        public string MartialStatusName { get; set; }
        public string GradeENName { get; set; }
        public string UniversityName { get; set; }
        public string MilitaryStatusName { get; set; }
        public string FileName { get; set; }
        public Nullable<System.DateTime> ProbationDate { get; set; }
        public string Probation_Date { get; set; }
        public Nullable<int> Religion { get; set; }
        public string ReligionName { get; set; }
        public string SocialSecurityDate { get; set; }

        public Nullable<System.DateTime> SocialSecurityStartDate { get; set; }
        public string FileUrl { get; set; }
        public Nullable<int> InsuranceStatus { get; set; }
        public string InsuranceStatusName { get; set; }
        public Nullable<System.DateTime> MilitaryDate { get; set; }
        public string Military_Date { get; set; }
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public Nullable<int> Count { get; set; }


    }
}