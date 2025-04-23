namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Jobs_Tbl
    {
        public int id { get; set; }

        [StringLength(50)]
        public string job_code { get; set; }

        [StringLength(50)]
        public string job_adescipation { get; set; }

        [StringLength(50)]
        public string job_edescipation { get; set; }

        [StringLength(50)]
        public string job_degree { get; set; }

        [StringLength(50)]
        public string job_tasks { get; set; }

        [StringLength(50)]
        public string job_experince { get; set; }

        [StringLength(150)]
        public string job_terms { get; set; }

        [StringLength(150)]
        public string job_responsabilities { get; set; }

        public decimal? budget { get; set; }

        public int? JobID { get; set; }

        public int? ComID { get; set; }
    }
}
