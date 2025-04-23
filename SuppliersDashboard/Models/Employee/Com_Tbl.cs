namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Com_Tbl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

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

        public string AddressUrl { get; set; }

        public int? CompanyType { get; set; }
    }
}
