using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class AccountSuppliers
    {
        public string Supplier { set; get; }
        public double DebitAmount { set; get; }
        public double CreditAmount { set; get; }
    }
}