using ScoposERB.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class RequestGrid
    {
        public int RecordID { get; set; }
        public int status { get; set; }
        public int RequestNo { get; set; }
        public Nullable<int> ComID { get; set; }
        public string RequestName { get; set; }
        public string Customer { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerID { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public string _RequestDate { get; set; }
        public string ShipmentMethod { get; set; }
        public string ShipmentType { get; set; }
        public string AdditionalCharges { get; set; }
        public string AdditionalExpenses { get; set; }
        public string Orgin { get; set; }
        public string Destination { get; set; }
        public string CustomFile { get; set; }
        public Nullable<int> FileNumber { get; set; }
        public Nullable<int> CargoVolume { get; set; }
        public string InvoiceFile { get; set; }
        public string OfferFile { get; set; }
        public string OtherFile { get; set; }
        public Nullable<decimal> Expenses { get; set; }
        public Nullable<decimal> fees { get; set; }
        public string Comments { get; set; }
        public string Comment { get; set; }
        public string comment { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string _DeliveryDate { get; set; }
        public string ShippingOffer { get; set; }
        public string ShippingOffer_des { get; set; }
        public string ShippingCost { get; set; }
        public string ShippingCost_des { get; set; }
        public string additionalFile { get; set; }
        public int GrossWeight { get; set; }
        public int InsurancePolicy { get; set; }

        public List<service> Services { get; set; }
        public List<VendorsRequest> vendors { get; set; }
        public List<BRO_RequestServices_DTO> RequestServices { get; set; }


    }
}