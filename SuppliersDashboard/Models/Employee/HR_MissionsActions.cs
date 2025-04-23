namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_MissionsActions
    {
        [Key]
        public int RecordID { get; set; }

        public int? Employee_ID { get; set; }

        public int? Missions_ID { get; set; }

        public decimal? Deduction_Amount { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }
    }
}
