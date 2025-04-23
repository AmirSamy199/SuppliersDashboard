using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Transactions
    {
        public string TransActionNo { get; set; }
        public string EnLevel { get; set; }
        public string ArLevel { get; set; }
        public string CoastCenter { get; set; }
        public string UserName { get; set; }
        public string _Date { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int CoastCenterID { get; set; }
        public int EditorID { get; set; }
        public Nullable<decimal> Amount { get; set; }

    }
}