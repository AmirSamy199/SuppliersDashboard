using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class SalesTrackerModel
    {
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Message { get; set; }
        public int RecordID { get; set; }
        public int UserID { get; set; }
        public int? Count { get; set; }
        public int? MetersLimit { get; set; }
        // 			
        public int SerialNo { get; set; }


    }
    public class SalesTrackerModelWithName : SalesTrackerModel
    {
        public string Name { get; set; }
    }
}