namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country_TBL
    {
        [Key]
        [StringLength(10)]
        public string CODE { get; set; }

        [StringLength(150)]
        public string EN { get; set; }

        [StringLength(150)]
        public string AR { get; set; }
    }
}
