using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class service
    {
        public int sId { get; set; } = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
        public decimal VAT { get; set; }
        public decimal Amount { get; set; }
        public string point { get; set; }
        public string origin { get; set; }
        public string desitnation { get; set; }
        public string ACIDNumber { get; set; }
        public string shipMethod { get; set; }
        public string shipType { get; set; }
        public string typeOfTruck { get; set; }
        public string noOfTruck { get; set; }
        public string shipmentFrom { get; set; }
        public string shipmentTo { get; set; }
        public string FileNO { get; set; }
        public string cargoVolume { get; set; }
        public string grossWeight { get; set; }
        public string deliveryDate { get; set; }
        public string customCertificate { get; set; }
        public string nameOfBroker { get; set; }
        public string cargoValue { get; set; }
        public string insurancePolicyNo { get; set; }
        public string kindOfCargo { get; set; }
        public string WhStartDate { get; set; }
        public string WhEndDate { get; set; }
        public string WhPoint { get; set; }
        public string BL_AWB_No { get; set; }
        public string incoterms { get; set; }
        public string ClearancePoint { get; set; }
        public string comment { get; set; }


    }
}