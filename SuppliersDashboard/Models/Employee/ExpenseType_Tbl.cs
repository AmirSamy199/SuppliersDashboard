namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExpenseType_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(200)]
        public string ExpenseType { get; set; }

        public byte? Cost { get; set; }
    }
}
