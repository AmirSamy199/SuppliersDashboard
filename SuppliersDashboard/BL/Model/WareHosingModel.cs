using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class WareHosingModel
    {
        public int RecordID { get; set; }

        public string WhPoint { get; set; }
        public DateTime WhStartDate { get; set; }
        public DateTime WhEndDate { get; set; }
        public string kindOfCargo { get; set; }
        public string cargoVolume { get; set; }
        public string grossWeight { get; set; }
        public DateTime deliveryDate { get; set; }
        public string comment { get; set; }


    }
}