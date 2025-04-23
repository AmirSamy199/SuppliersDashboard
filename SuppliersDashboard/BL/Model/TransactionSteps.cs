using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class TransactionSteps
    {
        public int SR_No { get; set; }
        public string BookNo { get; set; }
        public int BookNoID { get; set; }
        public int CheckNo { get; set; }
        public string AccName { get; set; }
        public int AccID { get; set; }
        public string CoastCenter { get; set; }
        public string CreditNo { get; set; }
        public int LevelID { get; set; }
        public string PaymentMethod { get; set; }
        public string Currency { get; set; }
        public int CurrencyID { get; set; }
        public string TranType { get; set; }
        public string TranNo { get; set; }
        public string Bank { get; set; }
        public int BankID { get; set; }
        public string Refrence { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Credits { get; set; }
        public Nullable<decimal> Debits { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> MethodeNo { get; set; }


    }
}