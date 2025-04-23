using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class RequestModel
    {
        public string ReqNo { get; set; }
        public string RecordID { get; set; }
        public string Comment { get; set; }
        public string Fees { get; set; }
        public string Expenses { get; set; }
        public string Custom { get; set; }
        public string Cargo { get; set; }
        public string FileNo { get; set; }
        public string GrossWeight { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public string ShipType { get; set; }
        public string ShipMeth { get; set; }
        public List<string> Services { get; set; }
        public List<string> Amount { get; set; }
        public string Customer { get; set; }
        public string date { get; set; }
        public string ReqName { get; set; }
        public string DeliveryDate { get; set; }
        public string InsurancePolicy { get; set; }
        public string ShippingCost_des { get; set; }
        public string ShippingOffer_des { get; set; }
        public HttpPostedFileBase Invoice { get; set; }
        public HttpPostedFileBase Offer { get; set; }
        public HttpPostedFileBase Additional { get; set; }
    }
}