using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Services
    {
        public int RecordID { get; set; }
        public string ItemName { get; set; }
        public decimal VAT { get; set; }
        public string Account { get; set; }
    }
}