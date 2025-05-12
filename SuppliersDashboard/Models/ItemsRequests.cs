using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class ItemsRequests
    {
        public int Record_ID { set; get; }
        public int ConfirmStatus { set; get; }
        public string CompanyName { set; get; }
        public string TypeSupplier { set; get; }
        public string ItemName { set; get; }
        public decimal size { set; get; }
        public string Barcode { set; get; }
        public string unitType_Ar { set; get; }
        public string CategoryName { set; get; }
        public string Date { set; get; }
    }
}