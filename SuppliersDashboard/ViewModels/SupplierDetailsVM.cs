using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class SupplierDetailsVM
    {
         public int State { get; set; }
        public string Message { get; set; }

        [Display(Name = "Supplier Name")]
         public string SupplierName { get; set; }
        [Display(Name = "Total Pills")]
        public Nullable<decimal> TotalPil { get; set; }
        [Display(Name = "Total Bills Before Discount")]
        public Nullable<decimal> TotalPillBeforDiscount { get; set; }
        [Display(Name = "Total Bill Discount")]
        public Nullable<decimal> TotalPilDiscount { get; set; }
        [Display(Name = "total Bill after Discount ")]
        public Nullable<decimal> TotalPilAfterDiscount { get; set; }
        [Display(Name = "Total Item Count ")]
        public Nullable<decimal> TotalItemsQount { get; set; } 
        [Display(Name = "Total Item Discount ")]
        public Nullable<decimal> TotalItemsDiscount { get; set; } 
        [Display(Name = "Total Bill Cash")]
        public Nullable<decimal> TotalPilCach { get; set; }  
        [Display(Name = "Total Bill Agil ")]
        public Nullable<decimal> TotalPilAgel { get; set; } 
        [Display(Name = "masrofat ")]
        public Nullable<decimal> Msrofat { get; set; } 
        [Display(Name = "Total Bill Net ")]
        public Nullable<decimal> TotalPilNet { get; set; } 
        [Display(Name = "Return Amount ")]
        public Nullable<decimal> ReturnAmount { get; set; } 
        [Display(Name = "Collection")]
        public Nullable<decimal> Collection { get; set; }  
    }
    public class SelectCustomer_Statement_Pro
    {
        public int BillNo { get; set; }
        public string Typett { get; set; }
        public string Add_date { get; set; }
        public Nullable<decimal> Old_RemainingAmount { get; set; }
        public Nullable<decimal> SalesAmount { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public Nullable<decimal> Amount_Required { get; set; }
        public Nullable<decimal> TotalePayment { get; set; }
        public Nullable<decimal> CollectionAmount { get; set; }
        public Nullable<decimal> cash { get; set; }
        public Nullable<decimal> Deferred { get; set; }
        public Nullable<decimal> RemainingAmount { get; set; }
     

    }
    public class DistributerGroupDetails
    {
        public int Record_ID { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Distributor { get; set; }
        public Nullable<byte> Status { get; set; }

    }
    public class Select_SalesSummry_For_CusAndBranches_Pro // this class for Specific Customer and his Branches // new Requirment for 3omda //10/8/2022
    {
        public int TotalPil { get; set; }
        public Nullable<decimal> TotalPillBeforDiscount { get; set; }
        public Nullable<decimal> TotalPilDiscount { get; set; }
        public Nullable<decimal> TotalPilAfterDiscount { get; set; }
        public Nullable<decimal> TotalItemsQount { get; set; }
        public Nullable<decimal> TotalItemsDiscount { get; set; }
        public Nullable<decimal> TotalPilCach { get; set; }
        public Nullable<decimal> TotalPilAgel { get; set; }
        public int NumOfBranches { get; set; }
        public Nullable<decimal> TotalPilNet { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public Nullable<decimal> Collection { get; set; }
    }
    public class SelectSales_Today_English_Pro
    {
        public string SalesName { get; set; }
        public int SalesId { get; set; }
        public int TotalPil { get; set; }
        public Nullable<decimal> TotalPillBeforDiscount { get; set; }
        public Nullable<decimal> TotalPilDiscount { get; set; }
        public Nullable<decimal> TotalPilAfterDiscount { get; set; }
        public Nullable<decimal> TotalItemsQount { get; set; }
        public Nullable<decimal> TotalItemsDiscount { get; set; }
        public Nullable<decimal> TotalPilCach { get; set; }
        public Nullable<decimal> TotalPilAgel { get; set; }
        public Nullable<decimal> Msrofat { get; set; }
        public Nullable<decimal> TotalPilNet { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public Nullable<decimal> Collection { get; set; }



        public Nullable<decimal> MoneyReceiptPapers_count { get; set; }
        public Nullable<decimal> MoneyReceiptPapers_Amount { get; set; }
        public Nullable<decimal> DeferredMoneyPaper_count { get; set; }
        public Nullable<decimal> DeferredMoneyPaper_Amount { get; set; }
    }

}