using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ACIDModel
    {
        public int RecordID { get; set; }
        public string ACIDNumber { get; set; }
        public string shipMethod { get; set; }
        public string shipType { get; set; }
        public string comment { get; set; }

    }
}