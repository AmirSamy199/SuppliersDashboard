namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Military_Status_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string MilitaryENName { get; set; }

        [StringLength(50)]
        public string MilitaryARName { get; set; }
    }
}
