using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Category
    {
        public int Record_ID { get; set; }
        public string CategoryName { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<int> ComID { get; set; }
    }
}