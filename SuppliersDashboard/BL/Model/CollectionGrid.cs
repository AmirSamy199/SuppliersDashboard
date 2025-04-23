using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class CollectionGrid
    {
        public string R_Name { get; set; }
        public string R_ID { get; set; }
        public string R_Type { get; set; }
        public int BillNo { get; set; }
        public string documentType { get; set; }
        public Nullable<decimal> totalDiscountAmount { get; set; }
        public string purchaseOrderReference { get; set; }
        public string purchaseOrderDescription { get; set; }
        public string salesOrderReference { get; set; }
        public string salesOrderDescription { get; set; }
        public string proformaInvoiceNumber { get; set; }
        public Nullable<decimal> TotalAmountBeforDiscount { get; set; }
        public Nullable<decimal> TotalAmountAfterDiscount { get; set; }
        public Nullable<decimal> TotalAmountAfterVAT { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> VAT_Prs { get; set; }
        public string taxType { get; set; }
        public string taxSubType { get; set; }
        public Nullable<byte> sendToeta { get; set; }
        public Nullable<decimal> WTHOLDINGTAX_Rate { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<System.DateTime> sendToetaDate { get; set; }
        public string uuid { get; set; }
        public string Response { get; set; }
        public Nullable<decimal> currencyExchangeRate { get; set; }
        public string validation { get; set; }
        public Nullable<byte> environment_ID { get; set; }
        public int Bill_RecordID { get; set; }
        public string approach { get; set; }
        public string packaging { get; set; }
        public string exportPort { get; set; }
        public string countryOfOrigin { get; set; }
        public string grossWeight { get; set; }
        public string netWeight { get; set; }
        public Nullable<int> CusTaxID { get; set; }
        public Nullable<decimal> CusTaxRate { get; set; }
        public string CusTaxType { get; set; }
        public string CusTaxSubType { get; set; }
        public Nullable<decimal> CuspriceWithTAX { get; set; }
        public string Customer_Code { get; set; }
        public byte collection_Stutes { get; set; }
        public Nullable<byte> PaymentMethod { get; set; }
        public decimal CollectionAmount { get; set; }
        public Nullable<decimal> WTHOLDINGTAX { get; set; }
        public Nullable<decimal> VAT { get; set; }
        public Nullable<byte> Bill_Stutes { get; set; }
        public string PaymentMethod_des { get; set; }
        public string _BillDate { get; set; }
        public decimal Old_Remain { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal Total_Debit { get; set; }

    }
}