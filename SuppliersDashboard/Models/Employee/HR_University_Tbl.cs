namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_University_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        public string UniversityName { get; set; }
    }
}
