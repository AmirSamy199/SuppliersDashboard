using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class HR_Vacation_Exchange
    {
        public int RecordID { get; set; }
        public string Arabic_Name { get; set; }
        public string En_Name { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public string User { get; set; }
        public string _Time { get; set; }
        public string Editor { get; set; }
    }
}