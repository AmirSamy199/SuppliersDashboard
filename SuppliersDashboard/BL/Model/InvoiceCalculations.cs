using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class InvoiceCalculations
    {
        public decimal ItemTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTax { get; set; }
        public decimal WithDiscount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmnt { get; set; }
        public decimal WHC { get; set; }
        public decimal WHS { get; set; }
        public decimal TotalAfterVAT { get; set; }
    }
}