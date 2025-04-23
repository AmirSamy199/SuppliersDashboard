using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ExpensesNFeesGrid
    {
        public int RecordID { get; set; }
        public string Name { get; set; }
        public byte status { get; set; }
        public string Account { get; set; }
        public string Editor { get; set; }
        public string _Date { get; set; }
        public DateTime Date { get; set; }
    }
}