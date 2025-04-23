namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_leaveBalance_tbl
    {
        [Key]
        public int LeaveID { get; set; }

        public int? Employee_ID { get; set; }

        public int? DEP_ID { get; set; }

        public int? com_ID { get; set; }

        public int? lineManagerID { get; set; }

        public int? HR_ID { get; set; }

        public DateTime? leaveFrom { get; set; }

        public DateTime? leaveTo { get; set; }

        public DateTime? submationDate { get; set; }

        [StringLength(50)]
        public string RM_confirm { get; set; }

        public DateTime? RM_confirm_time { get; set; }

        [StringLength(50)]
        public string HR_Confirm { get; set; }

        public DateTime? HR_Confirm_time { get; set; }

        public byte? status { get; set; }

        public string comment { get; set; }
    }
}
