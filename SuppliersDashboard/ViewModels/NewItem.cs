using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class NewItem
    {
        public string ItemName { get; set; }
        public string ItemGroup_ID { get; set; }
        public string User_ID { get; set; }
        public string Supplier_ID { get; set; }
        public string size { get; set; }
        public string Selling_Price { get; set; }
        public string Supply_Price { get; set; }
        public string Distributor_Group_id { get; set; }
        public string Barcode { get; set; }
        public string ETA_item_code { get; set; }
        public string itemtype { get; set; }
        public int tax_id { get; set; }
        public int unittype { get; set; }
    }
}