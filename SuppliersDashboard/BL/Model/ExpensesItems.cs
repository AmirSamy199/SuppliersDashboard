using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ExpensesItems
    {
        public int RecrodID { get; set; }
        public int? Tran_ID { get; set; }
        public int AccID { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string PayMethod { get; set; }
        public string Bank { get; set; }
        public string CreditCard { get; set; }
        public string CheckNo { get; set; }
        public string CheckBook { get; set; }
        public string Reference { get; set; }
        public string Desc { get; set; }
        public string CurrencyRate { get; set; }
        public string CurrencyName { get; set; }
        public int? IS_Returned { get; set; }
        public string CheckDate { get; set; }

    }
}