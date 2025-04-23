using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class warehouse_main_V
    {
        public string ItemName { get; set; }


        public decimal bal { get; set; }


        public int ItemId { get; set; }
        public int? Supplier_Id { get; set; }
        public decimal iTEM_C { get; set; }
        public decimal iTEM_d { get; set; }
        public string CompanyName { get; set; }
    }
}