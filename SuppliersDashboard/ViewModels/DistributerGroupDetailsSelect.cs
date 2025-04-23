using SuppliersDashboard.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class DistributerGroupDetailsSelect
    {
        public int Record_ID { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Distributor { get; set; }
        public Nullable<byte> Status { get; set; }

        public List<SmallUserDetails> Users { get; set; }
    }
    public class DistributerGroupSelect
    {
        public int RecordID { get; set; }
        public string UserName { get; set; }
    }
}