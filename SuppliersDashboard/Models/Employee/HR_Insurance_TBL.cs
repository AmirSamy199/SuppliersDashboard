namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Insurance_TBL
    {
        [Key]
        public int RecordID { get; set; }

        public int? Employee_ID { get; set; }

        public decimal? EmployeeSalary { get; set; }

        public decimal? Insurance_Fee { get; set; }

        public decimal? Worker_share { get; set; }

        public decimal? Employers_share { get; set; }

        public decimal? Total { get; set; }
    }
}
