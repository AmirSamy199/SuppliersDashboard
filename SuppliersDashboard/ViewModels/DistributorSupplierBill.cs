using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class DistributorSupplierBill
    {
        public int? BillNo { get; set; }
        public int? BillID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDateString { get; set; }
        public string DisName { get; set; }
    }
}