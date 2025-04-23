using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class SupplierVM
    {
        public int RecordID { get; set; }
        public string ClientName { get; set; }
        public int Status { get; set; }
        public string AndroidID { get; set; }
    }
}