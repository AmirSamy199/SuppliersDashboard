using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class AddTranVM
    {
        public string TranRef { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
    public class AccountGrid
    {
        public int RecordID { get; set; }
        public string ArabName { get; set; }
        public string EngName { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string DateS { get; set; }
        public string AccNumber { get; set; }
        public string CostCenter { get; set; }
        public decimal Balance { get; set; }
        public string Category { get; set; }
        public string Account_SerialNumber { get; set; }
        public bool Editable { get; set; }
        public byte state { get; set; }
    }
}