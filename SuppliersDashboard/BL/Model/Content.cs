using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class Content
    {
        public int RecordID { get; set; }
        public string EngName { get; set; }
        public string ArabicName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> ComId { get; set; }
        public Nullable<int> LevelId { get; set; }
        public Nullable<byte> Status { get; set; }
        public string InernalCode { get; set; }
        public DateTime OpenDate { get; set; }
        public string OpenDateS { get; set; }
        public DateTime Date { get; set; }
        public string DateS { get; set; }
        public string Telephone { get; set; }
        public string Editor { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }
}