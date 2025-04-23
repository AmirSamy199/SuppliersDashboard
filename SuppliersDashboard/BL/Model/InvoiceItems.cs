using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class InvoiceItems
    {
        public int RecordID { get; set; }
        public int SR_No { get; set; }
        public string ItemName { get; set; }
        public string IntCode { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string GPC { get; set; }
        public string itemType { get; set; }
        public decimal? TAX { get; set; }
        public decimal ItemTAX { get; set; }
        public decimal CusTax { get; set; }
        public int Qnty { get; set; }
        public decimal Unitprice { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal DiscountAmnt { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Totalprice { get; set; }
        public decimal VAT { get; set; }
        public string TaxType { get; set; }
        public string SubType { get; set; }
    }
}
