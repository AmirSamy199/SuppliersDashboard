namespace ScoposERB.Models.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class BGValidInvoices_V
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillNo { get; set; }
        public int RequestId { get; set; }

        [StringLength(50)]
        public string Customer_ID { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; }

        public DateTime? BillDate { get; set; }

        public DateTime? Date { get; set; }

        public decimal? TotalAmountBeforDiscount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TotalAmountAfterVAT { get; set; }

        public byte? sendToeta { get; set; }

        [StringLength(900)]
        public string ETAstatus { get; set; }

        public DateTime? sendToetaDate { get; set; }

        [StringLength(10)]
        public string DocumentType { get; set; }
        public string docType { get; set; }

        [StringLength(100)]
        public string uuid { get; set; }
    }
}
