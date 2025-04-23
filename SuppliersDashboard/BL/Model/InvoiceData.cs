using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class InvoiceData
    {
        public int Pending { get; set; }
        public int Submitted { get; set; }
        public int Unsubmitted { get; set; }
        public int Valid { get; set; }
        public int InValid { get; set; }
        public int Canceled { get; set; }
        public int Rejected { get; set; }
        public int Received { get; set; }
        public int Hold { get; set; }
    }
}