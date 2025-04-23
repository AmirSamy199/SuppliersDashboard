namespace SuppliersDashboard.BL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Evn_Bill_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        public int BillNo { get; set; }

        [StringLength(50)]
        public string Customer_ID { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public decimal? Discount_Amt { get; set; }

        public decimal? Discount_Rate { get; set; }

        public decimal? WTHOLDINGTAX { get; set; }

        public decimal? WTHOLDINGTAX_Rate { get; set; }

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

        [StringLength(50)]
        public string RefInv { get; set; }

        public byte? sendToeta { get; set; }

        [StringLength(50)]
        public string purchaseOrderReference { get; set; }

        [StringLength(50)]
        public string purchaseOrderDescription { get; set; }

        [StringLength(50)]
        public string salesOrderReference { get; set; }

        [StringLength(50)]
        public string salesOrderDescription { get; set; }

        [StringLength(50)]
        public string proformaInvoiceNumber { get; set; }

        [StringLength(50)]
        public string taxType { get; set; }

        [StringLength(50)]
        public string taxSubType { get; set; }

        public DateTime? sendToetaDate { get; set; }

        [StringLength(10)]
        public string documentType { get; set; }

        [StringLength(100)]
        public string uuid { get; set; }

        [StringLength(900)]
        public string Response { get; set; }

        public decimal? currencyExchangeRate { get; set; }

        [StringLength(50)]
        public string validation { get; set; }

        public byte? environment_ID { get; set; }

        public int? comid { get; set; }

        [StringLength(50)]
        public string approach { get; set; }

        [StringLength(50)]
        public string packaging { get; set; }

        [StringLength(50)]
        public string exportPort { get; set; }

        [StringLength(50)]
        public string countryOfOrigin { get; set; }

        [StringLength(50)]
        public string grossWeight { get; set; }

        [StringLength(50)]
        public string netWeight { get; set; }

        [StringLength(500)]
        public string Delivery_terms { get; set; }

        [StringLength(50)]
        public string BankInfoID { get; set; }

        [StringLength(50)]
        public string editor_id { get; set; }

        [StringLength(500)]
        public string CancelReason { get; set; }

        [StringLength(200)]
        public string digitalSignatureFeedback { get; set; }

        [StringLength(200)]
        public string Payment_terms { get; set; }

        public int? MainGroup_ID { get; set; }

        public int? Request_id { get; set; }

        [StringLength(50)]
        public string posserial { get; set; }

        public int? ReceiptNumber { get; set; }

        public DateTime? transferDate { get; set; }

        public int? branchid { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        public int? ClientConfirmation { get; set; }

        [StringLength(200)]
        public string submissionUuid { get; set; }

        public int? R_ReceiptNumber { get; set; }

        [StringLength(500)]
        public string R_UUID { get; set; }
    }
}
