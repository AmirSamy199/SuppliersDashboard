using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class InvoiceDetails
    {
        public string Date { get; set; }
        public string Customer { get; set; }
        public string CustomerCode { get; set; }
        public string TotalItems { get; set; }
        public string Total { get; set; }
        public string DocumentType { get; set; }
        public string BillNo { get; set; }
        public string RecordID { get; set; }
    }
}