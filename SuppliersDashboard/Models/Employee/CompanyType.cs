namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyType")]
    public partial class CompanyType
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        public byte? status { get; set; }
    }
}
