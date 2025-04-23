namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_TerminationOfStaff
    {
        [Key]
        public int RecordID { get; set; }

        public int? Employee_ID { get; set; }

        [StringLength(50)]
        public string JobID { get; set; }

        public int? LeavingType { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Indemnity { get; set; }

        public DateTime? DateOfRejoin { get; set; }
    }
}
