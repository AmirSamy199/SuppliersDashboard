using FastReport.Preview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    public partial class Bill_Tbl
    {
        public string Tax { get; set; }
        public string BranchName { get; set; }
        public int Branch_id { get; set; }
        public int RecordID { get; set; }
        public int BillNo { get; set; }
        public string Customer_ID { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> Discount_Amt { get; set; }
        public Nullable<decimal> Discount_Rate { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> WTHOLDINGTAX { get; set; }
        public Nullable<decimal> WTHOLDINGTAX_Rate { get; set; }
        public Nullable<decimal> VAT { get; set; }
        public string Payment { get; set; }
        public Nullable<System.DateTime> Del_Date { get; set; }
        public string Delivery { get; set; }
        public string ShipmentMod { get; set; }
        public string SalesOrderNo { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<byte> Payment_Stutes { get; set; }
        public Nullable<byte> Bill_Stutes { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Sales_ID { get; set; }
        public Nullable<int> Department_ID { get; set; }
        public Nullable<decimal> TotalAmountBeforDiscount { get; set; }
        public Nullable<decimal> TotalAmountAfterDiscount { get; set; }
        public Nullable<decimal> TotalAmountAfterVAT { get; set; }
        public Nullable<decimal> VAT_Prs { get; set; }
        public string RefInv { get; set; }
        public Nullable<byte> sendToeta { get; set; }
        public string purchaseOrderReference { get; set; }
        public string purchaseOrderDescription { get; set; }
        public string salesOrderReference { get; set; }
        public string salesOrderDescription { get; set; }
        public string proformaInvoiceNumber { get; set; }
        public string taxType { get; set; }
        public string taxSubType { get; set; }
        public Nullable<System.DateTime> sendToetaDate { get; set; }
        public string documentType { get; set; }
        public string uuid { get; set; }
        public string Response { get; set; }
        public Nullable<decimal> currencyExchangeRate { get; set; }
        public string validation { get; set; }
        public Nullable<byte> environment_ID { get; set; }
        public Nullable<int> comid { get; set; }
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
        public Nullable<int> MainGroup_ID { get; set; }
        public Nullable<int> Request_id { get; set; }
    }
}