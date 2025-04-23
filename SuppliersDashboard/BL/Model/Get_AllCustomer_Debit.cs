using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Get_AllCustomer_Debit
    {
        public decimal Debts { get; set; }
        public string cus_id { get; set; }
        public string cusName { get; set; }
        public Nullable<System.DateTime> Add_date { get; set; }
        public string _Add_date { get; set; }
        public Nullable<decimal> CollectionAmount { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}