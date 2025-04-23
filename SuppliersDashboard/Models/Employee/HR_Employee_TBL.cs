namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Employee_TBL
    {
        [Key]
        [Column(Order = 0)]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }

        [StringLength(50)]
        public string ArabicName { get; set; }

        [StringLength(20)]
        public string NationalID { get; set; }

        [StringLength(50)]
        public string EmployeeInsrance { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? DateOfHiring { get; set; }

        public DateTime? EndOfHiring { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Title { get; set; }

        public int? Gender { get; set; }

        public int? PositionType { get; set; }

        [StringLength(10)]
        public string EmployeeCode { get; set; }

        public int? EmployeeCompany { get; set; }

        [StringLength(50)]
        public string EmployeeBranch { get; set; }

        public decimal? EmployeeSalary { get; set; }

        [StringLength(50)]
        public string EmployeeMacId { get; set; }

        public string EmployeePicture { get; set; }

        [StringLength(10)]
        public string EmployeeCostCenter { get; set; }

        [StringLength(50)]
        public string NationalityCode { get; set; }

        public int? Employee_ID { get; set; }

        public int? Employee_degree { get; set; }

        public int? YearsOfExperiance { get; set; }

        [StringLength(150)]
        public string Employee_comment { get; set; }

        public DateTime? SocialSecurityStartDate { get; set; }

        [StringLength(150)]
        public string EmployeeJob { get; set; }

        public int? Religion { get; set; }

        [StringLength(150)]
        public string EmployeeDepartment { get; set; }

        public int? Emp_Job { get; set; }

        public int? Emp_Manager { get; set; }

        [StringLength(50)]
        public string jobCategories { get; set; }

        [StringLength(50)]
        public string jobLevel { get; set; }

        public DateTime? ID_StartDate { get; set; }

        public DateTime? ID_ExpDate { get; set; }

        public DateTime? Graduation_Date { get; set; }

        public int? Edu_Grade { get; set; }

        public int? Military_Status { get; set; }

        [StringLength(50)]
        public string Place_Of_Birth { get; set; }

        [StringLength(50)]
        public string MotherName { get; set; }

        public int? University { get; set; }

        public int? Martial_Status { get; set; }

        public DateTime? ProbationDate { get; set; }

        public int? ShiftID { get; set; }

        public int? InsuranceStatus { get; set; }

        public DateTime? MilitaryDate { get; set; }

        public int? BranchID { get; set; }
    }
}
