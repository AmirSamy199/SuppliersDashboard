using SuppliersDashboard.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    public partial class C_Default_Tbl
    {
        public int id { get; set; }
        public string default_country { get; set; }
        public string default_city { get; set; }
        public Nullable<int> default_company { get; set; }
        public Nullable<int> default_branch { get; set; }
        public Nullable<int> default_costcenter { get; set; }
        public Nullable<System.DateTime> default_start_date { get; set; }
        public string default_password { get; set; }

        public virtual C_City_Tbl C_City_Tbl { get; set; }
        public virtual Country_TBL Country_TBL { get; set; }
        public virtual Com_Tbl Com_Tbl { get; set; }
    }
}