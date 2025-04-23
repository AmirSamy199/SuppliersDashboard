namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Payment_Methods
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(150)]
        public string AR_PmName { get; set; }

        [StringLength(150)]
        public string EN_PmName { get; set; }
    }
}
