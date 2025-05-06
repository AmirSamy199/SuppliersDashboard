using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class MaterialsItems
    {
        public int Id { get; set; }
        public string ItemName { set; get; }
        public double ItemCount { set; get; }
        public int SupplierId { set; get; }
        public int ItemId { set; get; }
        public decimal PriceItem { set; get; }
        public int UserId { set; get; }
        public decimal TotalPrices { set; get; }
        public string DataTransaction { set; get; }
        public int AcconntID { set; get; }
        public int TypeSupplier { set; get; }
        public string CompanyName { set; get; }
    }
}