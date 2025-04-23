using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    public partial class C_costcenter_Tbl
    {
        public int id { get; set; }
        public int costcenter_code { get; set; }
        public string costcenter_aname { get; set; }
        public string costcenter_ename { get; set; }
        public Nullable<int> costcenter_telphone { get; set; }
        public Nullable<int> costcenter_fax { get; set; }
        public Nullable<System.DateTime> costcenter_start_date { get; set; }
        public string costcenter_email { get; set; }
        public Nullable<int> costcenter_building { get; set; }
        public string costcenter_comment { get; set; }
        public Nullable<int> costcenter_company { get; set; }
        public Nullable<int> costcenter_branch { get; set; }
        public string costcenter_city { get; set; }

        public virtual C_City_Tbl C_City_Tbl { get; set; }
        public virtual Com_Tbl Com_Tbl { get; set; }
    }
}