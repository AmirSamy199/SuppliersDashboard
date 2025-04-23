using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class InsuranseModel
    {

        public int RecordID { get; set; }

        public string shipMethod { get; set; }
        public string shipType { get; set; }
        public string shipmentFrom { get; set; }
        public string shipmentTo { get; set; }
        public string insurancePolicyNo { get; set; }
        public string cargoValue { get; set; }
        public string cargoVolume { get; set; }
        public string comment { get; set; }

    }
}