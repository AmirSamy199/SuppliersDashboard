using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class BillTotalReport
    {
        public int BillNo { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string NameOfBranch { get; set; }
        public string NameOfSales { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CollectionAmount { get; set; }
        public decimal DefferedAmount { get; set; }
        //public decimal Balance { get; set; } 
        public int IsNoDocument { get; set; }
    }
}