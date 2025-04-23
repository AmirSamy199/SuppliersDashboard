namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(100)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? Status { get; set; }

        public int? Supplier_ID { get; set; }
    }
}
