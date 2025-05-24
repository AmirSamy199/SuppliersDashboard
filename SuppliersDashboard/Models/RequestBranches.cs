using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class RequestBranches
    {
        public int Record_ID { set; get; }
        public string BranchName { set; get; }
        public string ContactName { set; get; }
        public string Telephone1 { set; get; }
        public string Address { set; get; }
        public string Date { set; get; }
        public string CompanyName { set; get; }
        public string Range { set; get; }
        public string Region { set; get; }
    }
}