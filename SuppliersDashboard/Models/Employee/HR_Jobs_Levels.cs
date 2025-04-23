namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Jobs_Levels
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(150)]
        public string Arabic_Name { get; set; }

        [StringLength(150)]
        public string En_Name { get; set; }

        [StringLength(50)]
        public string Categories { get; set; }

        [StringLength(50)]
        public string degree_ID { get; set; }

        public int? ComID { get; set; }
    }
}
