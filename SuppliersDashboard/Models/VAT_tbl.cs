namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VAT_tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public decimal? VAT { get; set; }

        [StringLength(50)]
        public string taxType { get; set; }

        [StringLength(50)]
        public string subType { get; set; }

        [StringLength(50)]
        public string Tax { get; set; }

        [StringLength(50)]
        public string DESCRIPTION { get; set; }

        public decimal? priceWithTAX { get; set; }

        [StringLength(50)]
        public string ForCustomerOrItems { get; set; }
    }
}
