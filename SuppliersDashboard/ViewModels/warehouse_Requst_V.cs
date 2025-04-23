using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class warehouse_Requst_V
    {
        public int RecordID { get; set; }

        public int? Item_ID { get; set; }
        public string SalesName { get; set; }

        public string ItemName { get; set; }

        public decimal? Item_Count { get; set; }

        public int? User_ID { get; set; }

        public DateTime? Edit_date { get; set; }
        public string _Edit_date { get; set; }

        public int? Supplier_ID { get; set; }

        public DateTime? dailyClosing { get; set; }

        public byte? Storekeeper_confirm { get; set; }


        public string StorekeeperName { get; set; }

        public byte? sales_confirm { get; set; }

        public int? Storekeeper_id { get; set; }

        public int? sales_id { get; set; }

        public DateTime? sales_confirm_date { get; set; }

        public DateTime? Storekeeper_confirm_date { get; set; }

        public byte? Settlement { get; set; }

        public byte? type { get; set; }
        public int? RequstNo { get; set; }
    }
}