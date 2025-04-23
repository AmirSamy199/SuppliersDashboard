namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_ComRules_tbl
    {
        [Key]
        public int RecordID { get; set; }

        public int? comid { get; set; }

        public bool? OverTimeStatus { get; set; }

        public bool? flexibilityTimeStatus { get; set; }

        public bool? shiftingStatus { get; set; }

        public byte? Leave_balance_transfer_Rule { get; set; }

        public int? Branch_Company_id { get; set; }
    }
}
