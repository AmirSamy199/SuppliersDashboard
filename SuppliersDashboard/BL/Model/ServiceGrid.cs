using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ServiceGrid
    {
        public int RecordID { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string ServiceName { get; set; }
        public string Editor { get; set; }
        public DateTime Date { get; set; }
        public string _date { get; set; }
    }
}