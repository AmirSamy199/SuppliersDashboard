using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class LevelsGrid
    {
        public int RecordID { get; set; }
        public string LevelName { get; set; }
        public string ArabicName { get; set; }
        public Nullable<int> SuppLevel { get; set; }
        public Nullable<int> ComId { get; set; }
        public Nullable<byte> Status { get; set; }
        public DateTime Date { get; set; }
        public string CreationDateS { get; set; }
        public string Editor { get; set; }
        public int LevelOrder { get; set; }
        public string LevelType { get; set; }
    }
}