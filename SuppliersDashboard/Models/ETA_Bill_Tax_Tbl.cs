namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ETA_Bill_Tax_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string TAX_Code { get; set; }

        [StringLength(50)]
        public string TAX_SubtCode { get; set; }

        [StringLength(10)]
        public string TAX_Rate { get; set; }

        public int? BillNo { get; set; }

        public decimal? TaxAmount { get; set; }

        [StringLength(5)]
        public string documentType { get; set; }

        public byte? environment_ID { get; set; }

        public int? comid { get; set; }
    }
}
