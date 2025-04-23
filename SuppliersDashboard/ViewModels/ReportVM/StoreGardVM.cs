using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels.ReportVM
{
    public class StoreGardVM
    {
        public string Item_Name { get; set; }
        public decimal bal { get; set; }
        public decimal Item_Credit { get; set; }
        public decimal Item_Debit { get; set; }
        public string Company_Name { get; set; }
    }
}