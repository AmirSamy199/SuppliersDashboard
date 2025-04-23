using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models.CP
{
    public class CPMonthModel
    {
        public string Month { get; set; }
        public string SalesName { get; set; }

        public int SalesManId { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal SalesTargetAmount { get; set; }
        public decimal SalesAchievePer { get; set; }
        public decimal CoverageAmount { get; set; }
        public decimal CoverageTargetAmount { get; set; }
        public decimal CoverageAchievePer { get; set; }
        // 														
        public decimal ReturnAmount { get; set; }
        public decimal ReturnTargetAmount { get; set; }
        public decimal ReturnAchievePer { get; set; }
        public decimal CPSalesPer { get; set; }
        public decimal CPCoveragePer { get; set; }
        public decimal CPItemsPer { get; set; }
        public decimal CPReturnsPer { get; set; }
        public bool MonthIsClosed { get; set; }

        public List<CPMonthItemModel> Items { get; set; }
    }
    public class CPMonthItemModel
    {

        public string Month { get; set; }
        public int SalesManId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemCountAchieved { get; set; }
        public decimal ItemTargetCount { get; set; }
        public decimal ItemAchievedPer { get; set; }
    }
}