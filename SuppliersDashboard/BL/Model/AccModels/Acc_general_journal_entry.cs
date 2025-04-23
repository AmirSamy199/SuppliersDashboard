namespace ScoposERB.Models.AccModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_general_journal_entry
    {
        [Key]
        public int RecordID { get; set; }

        public DateTime? general_entry_date { get; set; }

        [StringLength(100)]
        public string general_entry_reference { get; set; }

        [StringLength(100)]
        public string general_entry_isactive { get; set; }

        [StringLength(100)]
        public string general_entry_comment { get; set; }

        [StringLength(100)]
        public string general_entry_reverse { get; set; }

        public int? general_entry_costcenter_id { get; set; }

        [StringLength(100)]
        public string general_entry_category { get; set; }

        public int? general_entry_branch { get; set; }

        public int? general_entry_user { get; set; }

        public int? general_entry_isposted { get; set; }

        public int? general_entry_company { get; set; }

        public decimal? general_entry_TotalCredit { get; set; }

        public decimal? general_entry_TotalDebits { get; set; }

        public int? Request_id { get; set; }

        public int? general_entry_vendorId { get; set; }
    }
     public partial class Acc_general_journal_entryEntity
    {
        [Key]
        public int RecordID { get; set; }

        public string general_entry_date { get; set; }

        [StringLength(100)]
        public string general_entry_reference { get; set; }

        [StringLength(100)]
        public string general_entry_isactive { get; set; }

        [StringLength(100)]
        public string general_entry_comment { get; set; }

        [StringLength(100)]
        public string general_entry_reverse { get; set; }

        public int general_entry_costcenter_id { get; set; }

        [StringLength(100)]
        public string general_entry_category { get; set; }

        public int general_entry_branch { get; set; }

        public int general_entry_user { get; set; }

        public int general_entry_isposted { get; set; }

        public int general_entry_company { get; set; }

        public decimal general_entry_TotalCredit { get; set; }

        public decimal general_entry_TotalDebits { get; set; }

        public int Request_id { get; set; }

        public int general_entry_vendorId { get; set; }
        public string SecondPartyPersonName { get; set; }
    }


}
