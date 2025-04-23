namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_leave_type_tbl
    {
        public int id { get; set; }

        [StringLength(50)]
        public string leavetype { get; set; }
    }
}
