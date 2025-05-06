using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public partial class Bill_Report_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillNo { get; set; }

        public int? Branch_id { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public decimal? Discount { get; set; }

        public string Comment { get; set; }

        public DateTime? BillDate { get; set; }

        [StringLength(30)]
        public string BillDateString { get; set; }

        public int? Sales_ID { get; set; }

        [StringLength(150)]
        public string SalesMan { get; set; }

        public decimal? TotalAmountBeforDiscount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TotalAmountAfterVAT { get; set; }

        public decimal? Cash { get; set; }

        public decimal? Deferred { get; set; }

        public decimal? CollectionAmount { get; set; }

        [StringLength(1000)]
        public string discount_reason { get; set; }

        public decimal? DistanceInMeters { get; set; }

        public int? NoDocument { get; set; }

        public decimal? BillCash { get; set; }

        public decimal? realpaidfrombranch { get; set; }

        public DateTime? BillWillBeLateDate { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ComId { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public decimal? Old_RemainingAmount { get; set; }

        public decimal? Amount_Required { get; set; }

        public decimal? DefferefinThisBill { get; set; }

        public int? ComAgentId { get; set; }

        [StringLength(50)]
        public string ComAgentName { get; set; }

        public int? SalesManAgentId { get; set; }

        [StringLength(50)]
        public string SalesMAnAgentName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string DetailsItemName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string DetailsNumberOfUnit { get; set; }

        [Key]
        [Column(Order = 4)]
        public string DetailsUnitPrice { get; set; }

        [Key]
        [Column(Order = 5)]
        public string DetailsTotalPric { get; set; }

        [Key]
        [Column(Order = 6)]
        public string DetailsSize { get; set; }

        [Key]
        [Column(Order = 7)]
        public string DetailsDiscount { get; set; }
    }
    public class Collection_v
    {
        //									
        [Key]
        public int Record_Id { get; set; }
        public int? SalemanId { get; set; }
        public int? BranchId { get; set; }
        public string SalesmanName { get; set; }
        public string Bill { get; set; }
        public string BranchName { get; set; }
        public DateTime? Add_date { get; set; }
        public decimal? Old_RemainingAmount { get; set; }
        public decimal? CollectionAmount { get; set; }
        public decimal? MoneyTakeFromBranch { get; set; }
        public decimal? RemainingAmount { get; set; }
        public decimal? SalesAmount { get; set; }
        public decimal? ReturnAmount { get; set; }
        public DateTime? dailyClosing { get; set; }
        public int? PaymentId { get; set; }
        public string PaymentName { get; set; }
        public decimal? BillCash { get; set; }
        public decimal? BillCashDefferd { get; set; }
        public string Add_dateString { get; set; }

    }

    public class Expenses_v
    {
        // 								
        [Key]
        public int Record_ID { get; set; }
        public int? ExpenseID { get; set; }
        public string ExpenseType { get; set; }
        public string comment { get; set; }
        public string ResponseMan { get; set; }
        public decimal? Amount { get; set; }
        public int? User_ID { get; set; }
        public DateTime? Add_date { get; set; }
        public string SalesName { get; set; }
        public string Add_dateString { get; set; }
        public DateTime? dailyClosing { get; set; }
        public string AccountName { set; get; }
        public int AccountId { set; get; }
    }
}