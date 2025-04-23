using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.BL.New_Models
{
    public class AddBillModel
    {
        public string name { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public decimal vatindecimal { get; set; }
        public decimal vatamout { get; set; }
        public string description { get; set; }
        public bool sendtoeta { get; set; }
        public string currency { get; set; }
        public string account { get; set; }
        public string type { get; set; }// expense <> service // 

        
    }
}