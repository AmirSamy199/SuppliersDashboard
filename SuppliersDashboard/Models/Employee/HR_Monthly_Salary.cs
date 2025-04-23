namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Monthly_Salary
    {
        [Key]
        public int RecordID { get; set; }

        public int? Employee_ID { get; set; }

        public decimal? ExchangeAmount { get; set; }

        public int? Bouns_ID { get; set; }

        public decimal? Bouns_Amount { get; set; }

        public int? Exchange_ID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }
    }
}
