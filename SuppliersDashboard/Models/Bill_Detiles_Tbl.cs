namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Detiles_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        public int? SR_No { get; set; }

        [StringLength(100)]
        public string Items { get; set; }

        public string Description { get; set; }

        public decimal? NumberOfUnits { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? Suppier_id { get; set; }

        public int? BillNo { get; set; }

        public decimal? size { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Supply_Price { get; set; }

        public int? ItemID { get; set; }

        [StringLength(5)]
        public string documentType { get; set; }

        [StringLength(1000)]
        public string discount_reason { get; set; }

        [StringLength(50)]
        public string discountType { get; set; }

        public decimal? discountItemSize { get; set; }
    }
}
