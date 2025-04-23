using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class RegisterRequestDTVM
    {
        public int Record_ID { get; set; }
        public string UserName { get; set; }
        public string Serial_No { get; set; }
        public string android_id { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<System.DateTime> Request_date { get; set; }
        public string _Request_date { get; set; }
        public string RejectionNote { get; set; }
        public int Distributor_Group_ID { get; set; }
        public string Distributor_Group_Name { get; set; }
    }
    public class onlineRequest_Detiles_Tbl
    {

        public int request_ID { get; set; }

        public int? request_No { get; set; }


        public string Items { get; set; }

        public string CustomerName { get; set; }

        public string cus_phone { get; set; }

        public string resquest_stauta { get; set; }

        public string Description { get; set; }

        public decimal? NumberOfUnits { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? Suppier_id { get; set; }

        public int? BillNo { get; set; }

        public decimal? size { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Supply_Price { get; set; }

        public int? ItemID { get; set; }


        public string documentType { get; set; }


        public string discount_reason { get; set; }


        public string discountType { get; set; }

        public decimal? discountItemSize { get; set; }
    }
    public class onlineRequest_Tbl
    {
        public int? status { get; set; }
        public int request_ID { get; set; }

        public int? request_No { get; set; }

        [StringLength(100)]
        public string Items { get; set; }

        public string CustomerName { get; set; }

        public string cus_phone { get; set; }

        public string Cancal_reso { get; set; }

        public string Reject_reso { get; set; }

        public string resquest_stautes { get; set; }

        public int? Branch_id { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public decimal? Discount { get; set; }

        public decimal? WTHOLDINGTAX { get; set; }

        public decimal? VAT { get; set; }

        [StringLength(50)]
        public string Payment { get; set; }

        public DateTime? Del_Date { get; set; }

        [StringLength(50)]
        public string Delivery { get; set; }

        [StringLength(50)]
        public string ShipmentMod { get; set; }

        [StringLength(50)]
        public string SalesOrderNo { get; set; }

        public string Comment { get; set; }

        public DateTime? BillDate { get; set; }

        public byte? Payment_Stutes { get; set; }

        public byte? Bill_Stutes { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public int? Store_ID { get; set; }

        public int? Department_ID { get; set; }

        public decimal? TotalAmountBeforDiscount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TotalAmountAfterVAT { get; set; }

        public decimal? VAT_Prs { get; set; }

        public decimal? Cash { get; set; }

        public decimal? Deferred { get; set; }

        public decimal? ReturnAmount { get; set; }

        public decimal? CollectionAmount { get; set; }

        public DateTime? dailyClosing { get; set; }

        public string discount_reason { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? DistanceInMeters { get; set; }

        public int? NoDocument { get; set; }

        public decimal? BillCash { get; set; }

        public string ClientDocumentNo { get; set; }

        public DateTime? BillWillBeLateDate { get; set; }
    }
    public class AddUserVM
    {
        public string phone { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public int GroupId { get; set; }
    }
    public class EditFunctionsVM
    {
        public int GroupId { get; set; }
        public int[] Functions { get; set; }
    }
    public partial class HR_Employee_TBLvm
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
    public class VUsers
    {
        //							
        public int Group_RecordID { get; set; }
        public int Function_RecordID { get; set; }
        public int RecordID { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public string FunctionName { get; set; }
        public string phone { get; set; }
        public string Password { get; set; }
        public List<string> Functions { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int IsActive { get; set; }

    }
    public class CategoriesReportSums
    {


        public string CategoryName { get; set; }
        public string Name { get; set; }
        // public string UserName { get; set; }
        public decimal Discount { get; set; }
        public decimal size { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class CetegoryReportHeadandDetails
    {
        public List<AA_GetItemSalesBranchDistriutorDateByCategories_V> Details { get; set; } = new List<AA_GetItemSalesBranchDistriutorDateByCategories_V>();
        public List<CategoriesReportSums> Heads { get; set; } = new List<CategoriesReportSums>();

    }
    public class AA_GetItemSalesBranchDistriutorDateByCategories_V
    {
        ///	
        public decimal ITEM_Discount { get; set; }
        public decimal NumberOfUnits { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal size { get; set; }
        public int ItemID { get; set; }
        public int Sales_ID { get; set; }
        public int Branch_id { get; set; }
        public int ItemGroup_ID { get; set; }
        public int BillNo { get; set; }
        public string Items { get; set; }
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public string CategoryName { get; set; }
        public DateTime BillDate { get; set; }
        public decimal DefaultKiloPrice { get; set; }
        public int? ComId { get; set; }
        public string CompanyName { get; set; }
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
    }


    public class GroupOrFuncVM
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

}