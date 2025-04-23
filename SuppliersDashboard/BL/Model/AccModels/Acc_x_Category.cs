namespace ScoposERB.Models.AccModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_x_Category
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string EngName { get; set; }

        [StringLength(50)]
        public string ArabName { get; set; }

        [StringLength(100)]
        public string Discription { get; set; }

        public int? ComID { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }
    }
}
