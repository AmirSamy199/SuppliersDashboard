using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class billsTrackingModel
    {					
        public int BillNo { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? TotalAmountAfterDiscount { get; set; }
        public decimal? Cash { get; set; }
        public decimal? BillCash { get; set; }
    }
}