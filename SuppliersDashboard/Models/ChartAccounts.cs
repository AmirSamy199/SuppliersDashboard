using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class ChartAccounts
    {

        public int Id { get; set; }
        public string Value { set; get; }
        public string AccountType { set; get; }
        public bool IsActive { set; get; }
        public string Account 
        {
            get
            {
                return GetTypeAccount(AccountType);
            }
        }

    private string GetTypeAccount(string AccountType)
        {
            switch (AccountType)
            {
                case "D": return"حساب مدين"; 
                case "C":return "حساب دائن";
                default:return "حساب الخزنة";


            }
        }
    }
}