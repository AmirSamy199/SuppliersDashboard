using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class SubWarehouseReturnBalance_V
    {

        // 						
        [Key]
        public int Row { get; set; }
        public int? ItemId { get; set; }
        public int? UserId { get; set; }
        public string SalesName { get; set; }
        public string ItemName { get; set; }
        public decimal SizeBal { get; set; }
        public decimal AmountBal { get; set; }
    }
}