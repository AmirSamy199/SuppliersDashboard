using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class RequestMaterials
    {
        public int ItemId { set; get; }
        public string ItemName { set; get; }
        public int RequestId { set; get; }
        public decimal ItemCount { set; get; }
        public string DateRequest { set; get; }
        public string UserName { set; get; }
        public double? InCome { set; get; }
        public double? OutCome { set; get; }
        public double? Available { set; get; }
    }
}