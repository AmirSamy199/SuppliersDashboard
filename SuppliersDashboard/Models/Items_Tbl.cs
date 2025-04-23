namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Items_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public int? ItemGroup_ID { get; set; }

        public byte? Status { get; set; }

        public decimal? size { get; set; }

        public int? Supplier_ID { get; set; }

        public Guid? GuId { get; set; }

        [StringLength(150)]
        public string Barcode { get; set; }

        public int? Unit_id { get; set; }

        public string itemtype { get; set; }

        public int? tax_id { get; set; }
    }
}
