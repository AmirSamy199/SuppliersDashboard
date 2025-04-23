using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class MainWarehouseReturnBalance_V
    {

        [System.ComponentModel.DataAnnotations.Key]
        public Int64 Num { get; set; }
        public int? CItemId { get; set; }
        public int? DItemId { get; set; }
        public int? CwId { get; set; }
        public int? DwId { get; set; }
        public decimal? Cweigth { get; set; }
        public decimal? Dweigth { get; set; }
        public decimal? CTotalAmount { get; set; }
        public decimal? DTotalAmount { get; set; }
        public decimal? CItemCount { get; set; }
        public decimal? DItemCount { get; set; }
        public decimal? WeightBalance { get; set; }
        public decimal? TotalAmountBalance { get; set; }
        public decimal? ItemCountBalance { get; set; }
        public string WareHouseName { get; set; }
        public string ItemName { get; set; }
    }


    public class SettlementVM
    {
       public     int itemId{get;set;}
       public     decimal subValue{get;set;}
       public     int SettleId{get;set;}
       public     string SettleDesc{get;set;}
       public     int debitwarehouseId{get;set;}
       public     int creditwarehouseId{get;set;}
       public     int SettledWarehouseItemId{get;set;}
       public     int SettledWarehouseItemCount{get;set;}
    }
}