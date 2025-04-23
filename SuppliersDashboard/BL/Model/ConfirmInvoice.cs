using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ConfirmInvoice
    {
        public string Name { get; set; }
        public string RecordID { get; set; }
        public string Date { get; set; }
        public string InvoiceNum { get; set; }
        public string TotalAmount { get; set; }
        public string TotalAfterVat { get; set; }
        public string DocType { get; set; }
        public string TransferDate { get; set; }
        public string Code { get; set; }
        public string Editor { get; set; }
        public string Valid { get; set; }
    }
}