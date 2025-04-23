using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class NewEmloyee
    {
        public string RecordID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeARName { get; set; }
        public string NationalID { get; set; }
        public string InsuranceNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string DateOfHiring { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PositionType { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Degree { get; set; }
        public string Job { get; set; }
        public string Manager { get; set; }
        public string EmployeeSalary { get; set; }
        public string jobLevel { get; set; }
        public string jobCategories { get; set; }
        public string ID_StartDate { get; set; }
        public string ID_ExpDate { get; set; }
        public string Graduation_Date { get; set; }
        public string Edu_Grade { get; set; }
        public string Military_Status { get; set; }
        public string Place_Of_Birth { get; set; }
        public string MotherName { get; set; }
        public string University { get; set; }
        public string Martial_Status { get; set; }
        public string Religion { get; set; }
        public string SocialSecurityStartDate { get; set; }
        public string CompanyinsuranceDate { get; set; }
        public List<HttpPostedFileBase> Files { get; set; }

        public string InsuranceStatus { get; set; }
        public string MilitaryDate { get; set; }
        public string Shift { get; set; }

    }
}