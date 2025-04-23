using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class BrotherItems
    {
        public int RecrodID { get; set; }
        public int AccID { get; set; }
        public int IntCode { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string GPC_Code { get; set; }
        public string Currency { get; set; }
        public decimal VATAmount { get; set; }
        public decimal VAT { get; set; }
        public decimal Price { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Desc { get; set; }
        public bool send { get; set; }
    }
}