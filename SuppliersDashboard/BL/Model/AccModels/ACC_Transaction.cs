namespace ScoposERB.Models.AccModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACC_Transaction_Entity
    {
     
        public int RecordID { get; set; }

        public int Tran_account_code { get; set; }

        public string Tran_date { get; set; }

        public decimal Tran_Amount { get; set; }

        public int Tran_Status { get; set; }

        public int Tran_isposted { get; set; }
        public string Tran_refernce { get; set; }
        public string Tran_type { get; set; }
        public string Tran_descripation { get; set; }

        public int Tran_reconciled { get; set; }

        public int Tran_purchase_bill_id { get; set; }

        public int Tran_sales_bill_id { get; set; }

        public int Tran_purchase_return_bil_id { get; set; }

        public int Tran_sales_return_sales_id { get; set; }

        public int Tran_receipt_id { get; set; }

        public int Tran_purchase_bill_item_id { get; set; }

        public int Tran_sales_bill_item_id { get; set; }

        public int Tran_item_receipt_id { get; set; }

        public int Tran_purchase_return_item_id { get; set; }

        public int Tran_sales_return_item_id { get; set; }

        public int Tran_general_ledger_id { get; set; }

        public int Tran_payment_id { get; set; }

        public int Tran_receive_id { get; set; }

        public int Tran_assets_id { get; set; }

        public int Tran_isbegining_balance { get; set; }

        public string Tran_check_No { get; set; }

        public int Tran_inventory_adustement_item_id { get; set; }

        public int Tran_buildingunbuild_id { get; set; }
        public string Tran_assembply_combonines { get; set; }

        public decimal Tran_before_beginning_balance { get; set; }

        public decimal Tran_after_beginning_balance { get; set; }

        public int Tran_vendor_id { get; set; }

        public int Tran_customer_id { get; set; }

        public int Tran_user_id { get; set; }
        public string Tran_rfernce2 { get; set; }

        public int Tran_costcenter { get; set; }

        public decimal Tran_discount { get; set; }
        public string Tran_currency_id { get; set; }

        public int Tran_company_id { get; set; }

        public int Tran_check_book_id { get; set; }

        public int Tran_item_recipt_id { get; set; }
        public string Tran_Comment { get; set; }

        public decimal Tran_Credit_Amt { get; set; }

        public decimal Tran_Debit_Amt { get; set; }

        public int Request_id { get; set; }

        public int bank_ID { get; set; }

        public int Credit_Card { get; set; }

        public int Car_Id { get; set; }

        public decimal tran_ExchangeRate { get; set; }

        public int Tran_Return { get; set; }

        public int Tran_ID { get; set; }
       
        public int IS_Returned { get; set; }

        public decimal BalanceAfterTran { get; set; }
        public string AttachFilePath { get; set; }
        public string UserAddAttach { get; set; }
        public DateTime AddAttachTime { get; set; }
        public int CheckIsCollected { get; set; }
    }
}
