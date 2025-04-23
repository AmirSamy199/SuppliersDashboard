using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class HR_Categories
    {
        public int RecordID { get; set; }
        public string Arabic_Name { get; set; }
        public string En_Name { get; set; }
        public string Rate { get; set; }
        public Nullable<decimal> Evaluation_Degree { get; set; }
    }
}