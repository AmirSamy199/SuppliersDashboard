using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Cars_Grid
    {

        public int Record_ID { get; set; }
        public string Name { get; set; }
        public string CarNumber { get; set; }
        public Nullable<int> status { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string _Date { get; set; }
    }
}