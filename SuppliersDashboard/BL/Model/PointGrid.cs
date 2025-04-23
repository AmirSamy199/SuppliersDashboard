using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class PointGrid
    {
        public int RecordID { get; set; }
        public string pointName { get; set; }
        public string Editor { get; set; }
        public string _Date { get; set; }
        public DateTime Date { get; set; }
    }
}