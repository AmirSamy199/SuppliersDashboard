using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Com_Tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Com_Tbl()
        {
            this.C_costcenter_Tbl = new HashSet<C_costcenter_Tbl>();
            this.C_Default_Tbl = new HashSet<C_Default_Tbl>();
            this.C_Tran_Module_TBL = new HashSet<C_Tran_Module_TBL>();
        }

        public Nullable<int> id { get; set; }
        public string type { get; set; }
        public Nullable<int> branchID { get; set; }
        public int CompanyType { get; set; }
        public string eta_TAX_nO { get; set; }
        public string R_country { get; set; }
        public string R_GOVERNATE { get; set; }
        public string R_STREET { get; set; }
        public string R_BUILDINGNUMBER { get; set; }
        public string R_Type { get; set; }
        public int TXA_ID { get; set; }
        public string Name { get; set; }
        public string country { get; set; }
        public string governate { get; set; }
        public string regionCity { get; set; }
        public string street { get; set; }
        public string buildingNumber { get; set; }
        public string postalCode { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string landmark { get; set; }
        public string additionalInformation { get; set; }
        public string taxpayerActivityCode { get; set; }
        public int RecordID { get; set; }
        public Nullable<byte> RunType { get; set; }
        public Nullable<decimal> ArrangeWorkTimes { get; set; }
        public Nullable<System.DateTime> NextRunTime { get; set; }
        public Nullable<byte> RunStutes { get; set; }
        public string NoticeMail { get; set; }
        public int ComID { get; set; }
        public Nullable<byte> Status { get; set; }
        public byte PriceIncludesTax { get; set; }
        public string ScopocOrUno { get; set; }
        public byte SalesModule { get; set; }
        public byte InvConfirmation { get; set; }
        public byte DepartmentModule { get; set; }
        public byte CategoryModule { get; set; }
        public byte SubCategoryModule { get; set; }
        public byte TbiAdmin { get; set; }
        public byte SupplierModule { get; set; }
        public string digitalSignatureFeedback { get; set; }
        public Nullable<byte> AutomaticVAT { get; set; }
        public string Aname { get; set; }
        public Nullable<int> company_nationailty { get; set; }
        public string company_register { get; set; }
        public string company_tax_card { get; set; }
        public Nullable<int> company_attach { get; set; }
        public string city_code { get; set; }
        public string company_address { get; set; }
        public Nullable<byte> MultiGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_costcenter_Tbl> C_costcenter_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Default_Tbl> C_Default_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Tran_Module_TBL> C_Tran_Module_TBL { get; set; }
    }
}