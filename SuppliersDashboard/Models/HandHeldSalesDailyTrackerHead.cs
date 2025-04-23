using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class HandHeldSalesDailyTrackerHead
    {
        public List<HandHeldSalesDailyTracker> SalesData { get; set; }
        public int AllSalesCount { get; set; }
        public int SalesCountHasBill { get; set; }
        public int SalesCountHasItem { get; set; }
        public int FirstBillManId { get; set; }
        public string FirstBillManName { get; set; }
    }

    public class HandHeldSalesDailyTracker
    {
        //	Name			
        public int Id { get; set; }
        public string Name { get; set; }//
        public int BranchCount { get; set; }


        public bool HasItem { get; set; }//
        public int DailyAchievedBillCount { get; set; }
        public decimal DailyAchievedBillAmount { get; set; }//
        public int MonthlyAchievedBillCount { get; set; }
        public decimal MonthlyAcheivedBillAmount { get; set; }

        /// 													
        public decimal DailyTargetAmount { get; set; }//
        public decimal MonthlyTargetAmount { get; set; }
        public decimal CurrentTargetAmount { get; set; }
        public decimal DailyPercentage { get; set; }//
        public decimal MonthlyPercentage { get; set; }
        public decimal CurrentPercentage { get; set; }//
        public DateTime? FirstDailyBillDate { get; set; }
        public string FirstDailyBillDateString { get; set; }//
    }
}