using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class completedRequest_V
    {
        public int GLE { get; set; }
        public int BillNo { get; set; }
        public int BillID { get; set; }
        public int RequestID { get; set; }
        public Nullable<byte> sendToeta { get; set; }
        public Nullable<int> ComID { get; set; }
        public string CompanyName { get; set; }
        public string validation { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string _BillDate { get; set; }
        public string Orgin { get; set; }
        public string Destination { get; set; }
        public string Editor { get; set; }
        public string DocType { get; set; }

    }
}