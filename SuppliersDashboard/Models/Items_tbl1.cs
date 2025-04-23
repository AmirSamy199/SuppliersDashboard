namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Items_tbl1
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(50)]
        public string IntCode { get; set; }

        [StringLength(50)]
        public string GPC_Code { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public int? ItemGroup_ID { get; set; }

        public byte? Status { get; set; }

        public int? Units_id { get; set; }

        [StringLength(50)]
        public string unitType { get; set; }

        [StringLength(50)]
        public string itemType { get; set; }

        public int? TAX_Id { get; set; }

        public int? comid { get; set; }

        public int? SubGroup { get; set; }

        public int? AccID { get; set; }

        public int? srvc_or_Expn { get; set; }
    }
}
