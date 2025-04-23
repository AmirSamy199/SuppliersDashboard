using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class AccTreeGrid
    {
        public int RecordID { get; set; }
        public string EngName { get; set; }
        public string ArabName { get; set; }
        public DateTime Date { get; set; }
        public string DateS { get; set; }
        public string Editor { get; set; }
        public int LevelOrder { get; set; }
    }
}