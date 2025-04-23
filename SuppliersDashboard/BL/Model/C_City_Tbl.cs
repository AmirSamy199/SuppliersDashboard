using SuppliersDashboard.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    public partial class C_City_Tbl
    {
       
        public C_City_Tbl()
        {
            this.C_costcenter_Tbl = new HashSet<C_costcenter_Tbl>();
            this.C_Default_Tbl = new HashSet<C_Default_Tbl>();
        }

        public int id { get; set; }
        public string city_code { get; set; }
        public string city_country { get; set; }
        public string city_ename { get; set; }
        public string city_aname { get; set; }

        public virtual Country_TBL Country_TBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_costcenter_Tbl> C_costcenter_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Default_Tbl> C_Default_Tbl { get; set; }
    }

}