using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ChequeGrid
    {
        public int count { get; set; }
        public int firstNo { get; set; }
        public DateTime date { get; set; }
        public string dateS { get; set; }
        public string editor { get; set; }
        public int AvailableCheck { get; set; }
        public int CheckNo { get; set; }
        public string CostCenter { get; set; }
        public string bankName { get; set; }
        public int RecordID { get; set; }
    }
}