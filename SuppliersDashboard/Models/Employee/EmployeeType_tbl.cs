namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeType_tbl
    {
        [Key]
        public int RecordId { get; set; }

        [StringLength(50)]
        public string NameAr { get; set; }

        [StringLength(50)]
        public string NameEn { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public decimal? BaseSalary { get; set; }

        public decimal? Commision { get; set; }

        public decimal? TransportInstead { get; set; }
    }
}
