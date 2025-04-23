using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class CompanySettings
    {
        public int RecordID { get; set; }
        public Nullable<int> comid { get; set; }
        public string CompanyName { get; set; }
        public Nullable<bool> OverTimeStatus { get; set; }
        public string OverTimeStatus_ { get; set; }
        public Nullable<bool> flexibilityTimeStatus { get; set; }
        public string flexibilityTimeStatus_ { get; set; }

        public Nullable<bool> shiftingStatus { get; set; }
        public string shiftingStatus_ { get; set; }

        public Nullable<byte> Leave_balance_transfer_Rule { get; set; }
        public string Leave_balance_ { get; set; }

    }
}