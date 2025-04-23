using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class Supplier_Tbl
    {
        public int Record_ID { get; set; }

        public string CompanyName { get; set; }
        public string Responsible_Person { get; set; }

        public string Telephone1 { get; set; }

        public string Telephone2 { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Comment { get; set; }

        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? Status { get; set; }

        public int? UserID { get; set; }
    }
}