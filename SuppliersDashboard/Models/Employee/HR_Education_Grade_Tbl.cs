namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Education_Grade_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string GradeENName { get; set; }

        [StringLength(50)]
        public string GradeARName { get; set; }
    }
}
