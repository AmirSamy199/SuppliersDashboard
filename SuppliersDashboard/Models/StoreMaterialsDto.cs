using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class StoreMaterialsDto
    {
        public int ItemId { set; get; }
        public string ItemName { set; get; }

        public double InCome { set; get; }
        public decimal OutCome { set; get; }
        public double Available { set; get; }
    }
}