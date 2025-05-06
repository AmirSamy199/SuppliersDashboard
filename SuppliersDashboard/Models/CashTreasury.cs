using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class CashTreasury
    {

        public double CreditAmount { set; get; }
        public double DebitAmount { set; get; }
        public string NameAccount { set; get; }
        public int AccountId { set; get; }
        public string TransactionDate { set; get; }
        public string Comment {  set; get; }
    }
}