namespace ScoposERB.BL.New_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillEntity
    {
        public int RecordID { get; set; }

        public int BillNo { get; set; }
        public string Customer_ID { get; set; }
        public string Currency { get; set; }

        public decimal Discount_Amt { get; set; }

        public decimal Discount_Rate { get; set; }

        public decimal WTHOLDINGTAX { get; set; }

        public decimal WTHOLDINGTAX_Rate { get; set; }

        public decimal VAT { get; set; }
        public string Payment { get; set; }

        public string Del_Date { get; set; }
        public string Delivery { get; set; }
        public string ShipmentMod { get; set; }
        public string SalesOrderNo { get; set; }
        public string Comment { get; set; }
        public string BillDate { get; set; }
        public byte Payment_Stutes { get; set; }
        public byte Bill_Stutes { get; set; }
        public string Editor { get; set; }
        public string Date { get; set; }
        public int Sales_ID { get; set; }
        public int Department_ID { get; set; }
        public decimal TotalAmountBeforDiscount { get; set; }

        public decimal TotalAmountAfterDiscount { get; set; }
        public decimal TotalAmountAfterVAT { get; set; }
        public decimal VAT_Prs { get; set; }
        public string RefInv { get; set; }
        public byte sendToeta { get; set; }
        public string purchaseOrderReference { get; set; }
        public string purchaseOrderDescription { get; set; }
        public string salesOrderReference { get; set; }
        public string salesOrderDescription { get; set; }
        public string proformaInvoiceNumber { get; set; }
        public string taxType { get; set; }
        public string taxSubType { get; set; }
        public string sendToetaDate { get; set; }
        public string documentType { get; set; }
        public string uuid { get; set; }
        public string Response { get; set; }
        public decimal currencyExchangeRate { get; set; }
        public string validation { get; set; }
        public byte environment_ID { get; set; }
        public int comid { get; set; }
        public string approach { get; set; }
        public string packaging { get; set; }
        public string exportPort { get; set; }
        public string countryOfOrigin { get; set; }
        public string grossWeight { get; set; }
        public string netWeight { get; set; }
        public string Delivery_terms { get; set; }
        public string BankInfoID { get; set; }
        public string editor_id { get; set; }
        public string CancelReason { get; set; }
        public string digitalSignatureFeedback { get; set; }
        public string Payment_terms { get; set; }
        public int MainGroup_ID { get; set; }
        public int Request_id { get; set; }
        public string posserial { get; set; }
        public int ReceiptNumber { get; set; }

        public string transferDate { get; set; }

        public int branchid { get; set; }
        public string Url { get; set; }
        public int ClientConfirmation { get; set; }
        public string submissionUuid { get; set; }
        public int R_ReceiptNumber { get; set; }
        public string R_UUID { get; set; }
    }
}
