using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class RequestInfo
    {
        public int ID { get; set; }
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
        
    }
}