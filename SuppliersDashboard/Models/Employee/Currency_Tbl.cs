namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Currency_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }
    }
}
