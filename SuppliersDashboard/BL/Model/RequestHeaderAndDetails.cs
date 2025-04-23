using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class RequestHeaderAndDetails
    {
        public int RequestID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerID { get; set; }
        public int ComID { get; set; }
        public DateTime RequestDate { get; set; }
        public int status { get; set; }
        public string Editor { get; set; }
        public DateTime Date { get; set; }
        public string comment { get; set; }
        public string additionalFile { get; set; }
        public string AdditionalCharges { get; set; }
        public string AdditionalExpenses { get; set; }
        public string ShippingCost { get; set; }
        public string ShippingOffer { get; set; }
        public string CustomerAddress { get; set; }
        public List<ACIDModel> ACIDs { get; set; }
        public List<ClearanceModel> Clearances { get; set; }
        public List<DomesticModel> Domestics { get; set; }
        public List<EGYCAModel> EGYCAs { get; set; }
        public List<FreeHandModel> FreeHands { get; set; }
        public List<FreightModel> Freights { get; set; }
        public List<InsuranseModel> Insuranses { get; set; }
        public List<VendorsRequest> vendors { get; set; }
        public List<Services> services { get; set; }
    }
}