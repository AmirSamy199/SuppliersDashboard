using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class User
    {
        public int RecordID { get; set; }
        public int Branch_RecordID { get; set; }
        public string Branch_name { get; set; }
        public string UserName { get; set; }
        public string UserAccount { get; set; }
        public Nullable<int> Group_RecordID { get; set; }
        public string Password { get; set; }
        public Nullable<int> ComID { get; set; }
        public Nullable<int> TAX_ID { get; set; }
        public string Com_Name { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<byte> PriceIncludesTax { get; set; }
        public string ScopocOrUno { get; set; }
        public byte SalesModule { get; set; }
        public byte InvConfirmation { get; set; }
        public byte DepartmentModule { get; set; }
        public byte CategoryModule { get; set; }
        public byte SupplierModule { get; set; }
        public byte SubCategoryModule { get; set; }
        public byte TbiAdmin { get; set; }
        public byte AutomaticVAT { get; set; }
        public int MainGroupID { get; set; }
        public int MultiGroup { get; set; }
    }

    public class Function
    {
        public Nullable<int> Function_RecordID { get; set; }
        public string FunctionName { get; set; }
    }
}