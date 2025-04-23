using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class X_Category
    {
        public int RecordID { get; set; }
        public string EngName { get; set; }
        public string ArabName { get; set; }
        public string Discription { get; set; }
        public Nullable<int> ComID { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string DateS { get; set; }
    }
}