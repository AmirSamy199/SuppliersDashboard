namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ETA_Bill_Detiles_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        public int? SR_No { get; set; }

        [StringLength(50)]
        public string Items { get; set; }

        [StringLength(50)]
        public string IntCode { get; set; }

        [StringLength(50)]
        public string GPC_Code { get; set; }

        public string Description { get; set; }

        public decimal? NumberOfUnits { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? Suppier_id { get; set; }

        public int? BillNo { get; set; }

        public decimal? ItemDiscount_rate { get; set; }

        public decimal? ItemDiscount_amount { get; set; }

        public int? sysItemID { get; set; }

        [StringLength(50)]
        public string documentType { get; set; }

        public byte? environment_ID { get; set; }

        public int? comid { get; set; }

        [StringLength(50)]
        public string unitType_Ar { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public decimal? currencyExchangeRate { get; set; }

        public int? CusID { get; set; }

        public int? ServiceID { get; set; }

        [StringLength(50)]
        public string posserial { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public int? Request_id { get; set; }

        public int? branchid { get; set; }

        public int? Editor_id { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string SubmittionUUID { get; set; }

        public decimal? GrossTotal { get; set; }

        public decimal? Vat { get; set; }

        [StringLength(20)]
        public string ETASend { get; set; }
    }
}
