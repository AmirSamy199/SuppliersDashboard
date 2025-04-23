using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    using System;
    using System.Collections.Generic;

    public partial class C_Tran_Module_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Tran_Module_TBL()
        {
            this.C_Screen_TBL = new HashSet<C_Screen_TBL>();
        }

        public int Tran_Module_ID { get; set; }
        public string Module_Code { get; set; }
        public Nullable<int> Tran_Company_ID { get; set; }

       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Screen_TBL> C_Screen_TBL { get; set; }
        public virtual Com_Tbl Com_Tbl { get; set; }
    }
}