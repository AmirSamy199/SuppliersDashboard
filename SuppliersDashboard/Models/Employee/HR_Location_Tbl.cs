namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Location_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        public int? Level_ID { get; set; }

        public int? Employee_ID { get; set; }

        public int? State { get; set; }
    }
}
