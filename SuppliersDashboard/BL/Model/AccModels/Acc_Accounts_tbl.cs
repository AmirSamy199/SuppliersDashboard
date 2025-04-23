namespace ScoposERB.Models.AccModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Accounts_tbl
    {
        
        public int RecordID { get; set; }

        public string ArabName { get; set; }

        public string EngName { get; set; }

        public string Editor { get; set; }

        public string AccNumber { get; set; }

        public DateTime? Date { get; set; }

        public int? Level { get; set; }

        public int? ParentID { get; set; }

        public int? ComID { get; set; }

        public decimal? Balance { get; set; }

        public int? costCenter { get; set; }

        public int? AccountCategory { get; set; }

        public byte? AccountType { get; set; }

        public string Account_SerialNumber { get; set; }

        public byte? MainOrSub { get; set; }

        public int? currency { get; set; }

        public byte? state { get; set; }

        public int? Branch_ID { get; set; }
    }
}
