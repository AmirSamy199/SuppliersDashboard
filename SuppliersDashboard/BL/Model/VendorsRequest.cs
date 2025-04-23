using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class VendorsRequest
    {
        public string VendorName { get; set; }
        public int CarsCount { get; set; }
        public int RecordID { get; set; }
        public string Description { get; set; }
    }
}