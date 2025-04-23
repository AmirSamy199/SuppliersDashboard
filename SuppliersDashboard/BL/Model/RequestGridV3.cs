using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class RequestGridV3
    {
        public int RecordID { get; set; }
        public string Editor { get; set; }
        public string ShippingOffer { get; set; }
        public string ShippingCost { get; set;}
        public string additionalFile { get; set;}
        public DateTime? Date { get; set; }
        public string _Date { get; set; }
        public decimal AdditionalExpenses { get; set; }
        public decimal AdditionalCharges { get; set; }
        public string comment { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerID { get; set; }
    }
}