namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Branch_tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string Telephone1 { get; set; }

        [StringLength(100)]
        public string Telephone2 { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public string Comment { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string SalesContact { get; set; }

        public int? Distributor_ID { get; set; }

        public byte? status { get; set; }

        public int? Region_ID { get; set; }

        public int? comid { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public string AddressUrl { get; set; }

        public int? UserId { get; set; }

        public int? DaysToBeLater { get; set; }

        public int? PaymentTermsId { get; set; }

        public string Tax_id { get; set; }
    }
}
