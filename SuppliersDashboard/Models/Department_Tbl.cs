using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class Department_Tbl
    {
        public int Record_ID { get; set; }
        public string Department { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<int> branchID { get; set; }
        public Nullable<int> ComID { get; set; }
    }
}