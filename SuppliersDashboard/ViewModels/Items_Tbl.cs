using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class price_list_tbl
    {
        public int Record_ID { get; set; }
        public Nullable<int> Item_ID { get; set; }
        public Nullable<int> Distributor_Group_id { get; set; }
        public Nullable<decimal> Selling_Price { get; set; }
        public Nullable<decimal> Supply_Price { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<byte> Status { get; set; }
    }
    public class Items_Tbl
    {
        public int Record_ID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
        public Nullable<int> ItemGroup_ID { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<decimal> size { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
        public Nullable<System.Guid> GuId { get; set; }
        public string Barcode { get; set; }
    }
    
}