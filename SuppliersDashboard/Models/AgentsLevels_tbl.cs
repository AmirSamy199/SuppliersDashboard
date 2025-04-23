namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AgentsLevels_tbl
    {
        [Key]
        public int RecordId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Level { get; set; }

        public byte? IsRoot { get; set; }

        public byte? IsLastChild { get; set; }

        public byte? ParentId { get; set; }

        public byte? IsActive { get; set; }
    }
}
