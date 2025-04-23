using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models.CP
{
    public class CommisionModel
    {

        public CommisionModel()
        {
            
        }
        public CommisionModel(int SalesManId, decimal AllCommision, decimal CPSalesPer, decimal CPCoveragePer, decimal CPItemsPer, decimal CPReturnsPer)
        {


            this.AllCommision = AllCommision;

            this.CPSalesPer = CPSalesPer;
            this.CPCoveragePer = CPCoveragePer;
            this.CPItemsPer = CPItemsPer;
            this.CPReturnsPer = CPReturnsPer;
            this.AllCoverageCommision = Math.Round(CPCoveragePer / 100 * AllCommision, 2);
            this.AllSalesCommision = Math.Round(CPSalesPer / 100 * AllCommision, 2);
            this.AllItemCommision = Math.Round(CPItemsPer / 100 * AllCommision, 2);
            this.AllReturnCommision = Math.Round(CPReturnsPer / 100 * AllCommision, 2);
            this.ItemsCommision = new List<CommisionItemModel>();
            this.Messsages = new List<string>();
            this.SalesManId = SalesManId;

        }
        public CommisionModel(decimal AllCommision)
        {
            this.AllCommision = AllCommision;
            this.AllCoverageCommision = Math.Round(CPCoveragePer / 100 * AllCommision);
            this.AllSalesCommision = Math.Round(CPSalesPer / 100 * AllCommision);
            this.AllItemCommision = Math.Round(CPItemsPer / 100 * AllCommision);
            this.AllReturnCommision = Math.Round(CPReturnsPer / 100 * AllCommision);
        }

        public decimal BaseSalary { get; set; }
        public decimal FinalSalary { get; set; }
        public string Month { get; set; }

        public string SalesManName { get; set; }
 
        public decimal TransportInstead { get; set; }
        #region النسب الي هوزع عليها 
        public int SalesManId { get; set; }

        public decimal CPSalesPer { get; set; }
        public decimal CPCoveragePer { get; set; }
        public decimal CPItemsPer { get; set; }
        public decimal CPReturnsPer { get; set; }
        #endregion
        #region الفلوس الي المفروض ياخدها لو حقق ال 100 % منها 
        public decimal AllCommision { get; set; }
        public decimal AllSalesCommision { get; set; }
        public decimal AllItemCommision { get; set; }
        public decimal AllCoverageCommision { get; set; }
        public decimal AllReturnCommision { get; set; }
        public List<CommisionItemModel> ItemsCommision { get; set; }
        #endregion

        public decimal SalesAchievePer { get; set; }
        public decimal CoverageAchievePer { get; set; }
        public decimal ItemsAchievePer { get; set; }
        public decimal ReturnAchievePer { get; set; }

        public List<string> Messsages { get; set; }

        #region

        /// دي بقا الي المندوب هياخدة بعد شغلخ 
        /// 
        public decimal FinalCommision { get; set; }
        public decimal FinalSalesCommision { get; set; }
        public decimal FinalItemCommision { get; set; }
        public decimal FinalCoverageCommision { get; set; }
        public decimal FinalReturnCommision { get; set; }
        #endregion

    }

    public class CommisionItemModel
    {
        public int SalesManId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemAchievePer { get; set; }
        public decimal ItemCommision { get; set; }

    }
}