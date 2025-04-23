using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class SimpleClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Page { get; set; }
    } 
    public class Select
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class AgentSelect : Select
    {
        public int IsLastChild { get; set; }
        public int Level { get; set; }
    }
    public class AllCusWithDeffered
    {
        public string item { get; set; }
        public decimal Unpaid_deferred { get; set; }
        public int Customer_ID { get; set; }
        public int Branch_ID { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
    public class DetailsVM
    {
        public int State { get; set; }
        public List<DetailsData> data { get; set; }

    }

    public class DetailsData
    {
        public string CompanyName { get; set; }
        public string Date { get; set; }
        public double TotalAmountBeforDiscount { get; set; }
        public double TotalAmountAfterDiscount { get; set; }
        public double VAT { get; set; }
        public double TotalAmountAfterVAT { get; set; }
        public double Cash { get; set; }
        public double Deferred { get; set; }
        public double ReturnAmount { get; set; }
        public double CollectionAmount { get; set; }
        public string Distributor { get; set; }
    }

    public class BillsDetailsVM
    {
        public int BillNo { get; set; }
        public int BillID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDateString { get; set; }
        public string distributerName { get; set; }
        public decimal TotalAmountBeforDiscount { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }
        public List<ItemDetails> Items { get; set; }

    }

    public class ItemDetails
    {
        public string ItemName { get; set; }
        public decimal ItemCount { get; set; }
        public string Supplier { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal ItemSize { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SupplyPrice { get; set; }

    }
}
