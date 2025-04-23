using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class RegisterRequestDT
    {
        public int Record_ID { get; set; }
        public string UserName { get; set; }
        public string Serial_No { get; set; }
        public string android_id { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<System.DateTime> Request_date { get; set; }
        public string _Request_date { get; set; }
        public string RejectionNote { get; set; }
        public int Distributor_Group_ID { get; set; }
        public string Distributor_Group_Name { get; set; }
    }
}