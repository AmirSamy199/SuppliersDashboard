using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace SuppliersDashboard.Models
{
    public class StoreMaterialsView
    {
        public int ItemId { set; get; } 
        public string ItemName { set; get; }
        public decimal InCome { set; get; }
        public decimal OutCome { set; get; }
        public decimal Available { set; get; }
    }
}