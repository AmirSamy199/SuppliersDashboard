using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Item
    {
        public int Item_ID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
        public Nullable<int> ItemGroup_ID { get; set; }
        public Nullable<byte> Status { get; set; }
        public string IntCode { get; set; }
        public string GPC_Code { get; set; }
        public Nullable<int> Units_id { get; set; }
        public string Measurement_Units { get; set; }
        public string unitType { get; set; }
        public string itemType { get; set; }
        public Nullable<int> comid { get; set; }
        public string TAX_DESCRIPTION { get; set; }
        public Nullable<int> TAX_Id { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> SubGroup { get; set; }

    }
}