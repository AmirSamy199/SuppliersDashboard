namespace SuppliersDashboard.Models.Employee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class collection_tbl
    {
        [Key]
        public int Record_id { get; set; }

        public int? Branch_id { get; set; }

        public int? User_ID { get; set; }

        public int? BillNo { get; set; }

        public DateTime? Add_date { get; set; }

        public decimal? Old_RemainingAmount { get; set; }

        public decimal? SalesAmount { get; set; }

        public decimal? CollectionAmount { get; set; }

        public decimal? ReturnAmount { get; set; }

        public decimal? Amount_Required { get; set; }

        public decimal? RemainingAmount { get; set; }

        public DateTime? dailyClosing { get; set; }

        public int? Payment_Method_Id { get; set; }

        public bool? settled { get; set; }

        public decimal? TotalPaymet { get; set; }

        public decimal? MoneyTakeFromBranch { get; set; }

        [StringLength(50)]
        public string CheckNumber { get; set; }

        [StringLength(50)]
        public string bank { get; set; }

        [StringLength(50)]
        public string UserEditCheck { get; set; }
    }
}
