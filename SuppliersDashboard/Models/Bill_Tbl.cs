namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Tbl
    {
        [Key]
        public int BillID { get; set; }

        public int BillNo { get; set; }

        public int? Branch_id { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public decimal? Discount { get; set; }

        public decimal? WTHOLDINGTAX { get; set; }

        public decimal? VAT { get; set; }

        [StringLength(50)]
        public string Payment { get; set; }

        public DateTime? Del_Date { get; set; }

        [StringLength(50)]
        public string Delivery { get; set; }

        [StringLength(50)]
        public string ShipmentMod { get; set; }

        [StringLength(50)]
        public string SalesOrderNo { get; set; }

        public string Comment { get; set; }

        public DateTime? BillDate { get; set; }

        public byte? Payment_Stutes { get; set; }

        public byte? Bill_Stutes { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public int? Sales_ID { get; set; }

        public int? Department_ID { get; set; }

        public decimal? TotalAmountBeforDiscount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TotalAmountAfterVAT { get; set; }

        public decimal? VAT_Prs { get; set; }

        public decimal? Cash { get; set; }

        public decimal? Deferred { get; set; }

        public decimal? ReturnAmount { get; set; }

        public decimal? CollectionAmount { get; set; }

        public DateTime? dailyClosing { get; set; }

        [StringLength(1000)]
        public string discount_reason { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? DistanceInMeters { get; set; }

        public int? NoDocument { get; set; }

        public decimal? BillCash { get; set; }

        [StringLength(60)]
        public string ClientDocumentNo { get; set; }

        public DateTime? BillWillBeLateDate { get; set; }
    }
}
