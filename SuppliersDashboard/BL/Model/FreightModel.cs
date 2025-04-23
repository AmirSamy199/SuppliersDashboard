using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class FreightModel
    {

        public int RecordID { get; set; }

        public string shipMethod { get; set; }
        public string shipType { get; set; }
        public string shipmentFrom { get; set; }
        public string shipmentTo { get; set; }
        public string FileNO { get; set; }
        public string cargoVolume { get; set; }
        public string grossWeight { get; set; }
        public string BL_AWB_No { get; set; }
        public string incoterms { get; set; }
        public DateTime deliveryDate { get; set; }
        public string comment { get; set; }

    }
}