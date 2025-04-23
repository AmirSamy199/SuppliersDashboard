namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BankInfo_tbl
    {
        [Key]
        public int RecordID { get; set; }

        public int? TAX_ID { get; set; }

        [StringLength(100)]
        public string bankName { get; set; }

        [StringLength(400)]
        public string bankAddress { get; set; }

        [StringLength(50)]
        public string bankAccountNo { get; set; }

        [StringLength(200)]
        public string bankAccountIBAN { get; set; }

        [StringLength(200)]
        public string swiftCode { get; set; }

        [StringLength(400)]
        public string terms { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? status { get; set; }

        public int? ComID { get; set; }
    }
}
