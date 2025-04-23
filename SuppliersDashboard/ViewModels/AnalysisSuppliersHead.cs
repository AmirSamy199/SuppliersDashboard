using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class AnalysisSuppliersHead
    {
        public int CountRegion { set; get; }
        public int CountRanges { set; get; }
        public int CountBranchs { set; get; }
        public int CountCats { set; get; }
        public int CountItems { set; get; }
        public decimal TotalRemainingAmount { set; get; }
        public decimal TotalMoneyTakeFromBranch { set; get; }
        public decimal TotalSalesAmount { set; get; }
    }
}