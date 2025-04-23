namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Distributor_Group_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        public int? UserId { get; set; }

        [StringLength(100)]
        public string Distributor { get; set; }

        public byte? Status { get; set; }

        public int? AgentId { get; set; }
    }
}
