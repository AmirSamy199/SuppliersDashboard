using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Integration
    {
        public string Invoice_No { get; set; }
        public string Invoice_Date { get; set; }
        public string Receiver_Name { get; set; }
        public string TAX_No { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public string Document_Type { get; set; }
        public string _transfer_date { get; set; }
        public Nullable<System.DateTime> transfer_date { get; set; }
        public string validation { get; set; }
        public string uuid { get; set; }
        public int Bill_RecordID { get; set; }
        public byte sendToEta { get; set; }
    }
}