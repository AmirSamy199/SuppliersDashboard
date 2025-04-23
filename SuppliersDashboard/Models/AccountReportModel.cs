using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class MonthAssignItems
    {
        public int SalemenId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemCount { get; set; }
    }



    public class SaleManData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistributorGroupId { get; set; }
        public List<MonthAssignItems> AssignedMonthItems { get; set; }
        // SalesPer	CoveragePer	ItemsPer	ReturnsPer
        public decimal SalesPer { get; set; }
        public decimal CoveragePer { get; set; }
        public decimal ItemsPer { get; set; }
        public decimal ReturnsPer { get; set; }
        //		
        public decimal MonthSalesAmount { get; set; }
        public decimal MonthCoverageAmount { get; set; }
        public decimal MonthReturnAmount { get; set; }
        public int AllowMakeInvoiceFarFromBranch { get; set; }

    }
    public class MoneyPaperModel
    {
        public int TranId { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }
        public string CheckNumber { get; set; }
        public string Bank { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string _Date { get; set; }
        public string _Time { get; set; }
    }
    public class AccountReportModel
        {


            public int AccounterID { get; set; }
            public string Name { get; set; }

            public decimal actual_amount { get; set; }
            public int user_id { get; set; }
            public string UserName { get; set; }
            public decimal Actual_DeferredMoneyPaper_count { get; set; }
            public decimal Actual_DeferredMoneyPaper_Amount { get; set; }
            public decimal Actual_MoneyReceiptPapers_count { get; set; }
            public decimal Actual_MoneyReceiptPapers_Amount { get; set; }
              public decimal Masrofat { get; set; }

        }

        public class MasrofReport
    {
            

            public int MasrofId { get; set; }
            public string MasrofDateString { get; set; }
            public decimal MasrofAmount { get; set; }
            public string Sales { get; set; }
            public string Manager { get; set; }
            public string ExpenseType { get; set; }
        }
    public class SelectAllcustomersOpeningBalance_Pro
    {
        public Nullable<decimal> Debts { get; set; }
        public string region { get; set; }
        public int Branch_ID { get; set; }
        public int cus_id { get; set; }
        public string BranchName { get; set; }
        public string CompanyName { get; set; }
        public string salesStatus { get; set; }

    }
    public class NewCollection
    {
        public string UserID { get; set; }
        public string Amount { get; set; }
        public string Cus_id { get; set; }
        public string RemainingAmount { get; set; }
        public int? Payment_Method_Id { get; set; }
        public string Bank { get; set; }
        public string CheckNumber { get; set; }
    }
}