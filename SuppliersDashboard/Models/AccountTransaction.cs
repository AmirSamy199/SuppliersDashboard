using SuppliersDashboard.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class AccountTransaction
    {
        public int AcountType { set; get; }
        public  int Treasury { set; get; }
        public decimal Amount { set; get; }
        public int UserId { set; get; } = 0;
        public DateTime DateOfTransactio = DateTime.Now;
        public string GuidReference = Guid.NewGuid().ToString();
        public int IsActive = 1;
        public int Editor { get; set; }
       
        public string Ref { set; get; }
       
    }
}