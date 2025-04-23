using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public partial class Com_Tbl
    {
        

        public Nullable<int> id { get; set; }
        public string type { get; set; }
        public Nullable<int> branchID { get; set; }
        public string Name { get; set; }
        public string country { get; set; }
        public string governate { get; set; }
        public string regionCity { get; set; }
        public string street { get; set; }
        public string buildingNumber { get; set; }
        public string postalCode { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string landmark { get; set; }
        public string additionalInformation { get; set; }
        public string taxpayerActivityCode { get; set; }
        public int RecordID { get; set; }
        public Nullable<byte> RunType { get; set; }
        public Nullable<decimal> ArrangeWorkTimes { get; set; }
        public Nullable<System.DateTime> NextRunTime { get; set; }
        public Nullable<byte> RunStutes { get; set; }
        public string NoticeMail { get; set; }
        public int ComID { get; set; }
        public Nullable<byte> Status { get; set; }
        public byte PriceIncludesTax { get; set; }
        public string ScopocOrUno { get; set; }
        public byte SalesModule { get; set; }
        public byte InvConfirmation { get; set; }
        public byte DepartmentModule { get; set; }
        public byte CategoryModule { get; set; }
        public byte SubCategoryModule { get; set; }
        public byte TbiAdmin { get; set; }
        public byte SupplierModule { get; set; }
        public string digitalSignatureFeedback { get; set; }
        public Nullable<byte> AutomaticVAT { get; set; }
        public string Aname { get; set; }
        public Nullable<int> company_nationailty { get; set; }
        public string company_register { get; set; }
        public string company_tax_card { get; set; }
        public Nullable<int> company_attach { get; set; }
        public string city_code { get; set; }
        public string company_address { get; set; }
        public Nullable<byte> MultiGroup { get; set; }
        public Nullable<System.DateTime> Expiration_Date { get; set; }
        public Nullable<int> SendToEtaWay { get; set; }

  
    }
}