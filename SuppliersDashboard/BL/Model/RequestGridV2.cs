using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class RequestGridV2
    {
        public int status { get; set; }
        public int RecordID { get; set; }
        public DateTime? RequestDate { get; set; }
        public string _RequestDate { get; set; }
        public string Editor { get; set; }
        public DateTime? Date { get; set; }
        public string _Date { get; set; }
        public string Customer { get; set; }
        public int CustComId { get; set; }
        public int ComID { get; set; }
        public string comment { get; set; }
        public string additionalFile { get; set; }
        public string AdditionalCharges { get; set; }
        public string AdditionalExpenses { get; set; }
        public string ShippingCost { get; set; }
        public string ShippingCost_des { get; set; }
        public string ShippingOffer { get; set; }
        public string ShippingOffer_des { get; set; }
        public string _Request_Time { get; set; }
    }
}