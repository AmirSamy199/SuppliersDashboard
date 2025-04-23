using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class InvoiceDetailsItem
    {
        public string ItemName { get; set; }
        public string ItemQnty { get; set; }
        public string ItemPrice { get; set; }
        public string ItemTotal { get; set; }
        public string ItemUnit { get; set; }
    }
}