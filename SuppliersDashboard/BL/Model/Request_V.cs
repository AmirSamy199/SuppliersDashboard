using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Request_V
    {
        public string EngName { get; set; }
        public string ArabName { get; set; }
        public string Account { get; set; }
        public string Currency { get; set; }
        public decimal Tran_Credit_Amt { get; set; }
        public decimal VAT { get; set; }
        public decimal Tran_Debit_Amt { get; set; }
        public string Tran_descripation { get; set; }
        public string general_entry_reference { get; set; }

         
        public int Tran_account_code { get; set; }
        /// made it to be override in java script only 
        public int BaseExpensesId { get; set; }

        public string TranStatus { get; set; }
    }
}