using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models.ReportModels
{
    public class ItemSalesREportVM
    {
        // ItemCode	ItemName	Count	Price	Average	UnitType
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UserName { get; set; }
        public string UnitType { get; set; }

        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public decimal Average { get; set; }

    }
    public class BillLatesReport_V
    {

        //                            

        public int BranchId { get; set; }
        public int SalesId { get; set; }
        public int BillNo { get; set; }
        public int BillDaysCountLater { get; set; }
        public int BillDaysCountLaterFromFirstOfMonth { get; set; }
        public DateTime BillDate { get; set; }
        public string _BillDate { get; set; }
        public string SalesName { get; set; }
        public string BranchName { get; set; }
        public string PlusThirty { get; set; }
        public string PlusSixty { get; set; }
        public string PlusNighnty { get; set; }
        public string LastCollection { get; set; }
        public decimal BillDeffered { get; set; }
        public decimal BillAmount { get; set; }


    }
}