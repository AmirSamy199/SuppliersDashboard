using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class BranchsGrid
    {
        public int Record_ID { get; set; }
        public string Branch_name { get; set; }
        public string Country { get; set; }
        public string Governate { get; set; }
        public string city_id { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string _date { get; set; }
        public string Start_date { get; set; }
        public DateTime Date { get; set; }
        public DateTime Branch_start_date { get; set; }
        public string Editor { get; set; }

    }
}