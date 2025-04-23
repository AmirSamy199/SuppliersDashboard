namespace ScoposERB.Models.AccModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Bank_Check_Tbl_Entity
    {
      
        public int RecordId { get; set; }

        public int ComId { get; set; }

        public string CheckNumber { get; set; }

        public decimal CheckAmount { get; set; }

        [StringLength(10)]
        public string CheckType { get; set; }

        public int TransactionNumber { get; set; }

        public string Date { get; set; }

        public int BankId { get; set; }

        public string BankName { get; set; }

        [StringLength(100)]
        public string BankAddress { get; set; }

        [StringLength(50)]
        public string SenderId { get; set; }

        [StringLength(50)]
        public string SenderName { get; set; }

        [StringLength(50)]
        public string ReceiverId { get; set; }

        [StringLength(50)]
        public string ReceiverName { get; set; }
    }
}
