namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Degree_Tbl
    {
        public int id { get; set; }

        [StringLength(50)]
        public string degree_code { get; set; }

        [StringLength(50)]
        public string degree_adescription { get; set; }

        [StringLength(50)]
        public string degree_edescription { get; set; }

        public int? ComID { get; set; }
    }
}
