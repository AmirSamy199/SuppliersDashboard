namespace SuppliersDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ETA_document_Tbl
    {
        public int? Environment_ID { get; set; }

        [StringLength(50)]
        public string Environment { get; set; }

        [StringLength(50)]
        public string documentTypeVersion { get; set; }

        [StringLength(50)]
        public string documentType { get; set; }

        [StringLength(200)]
        public string Login_URL { get; set; }

        [StringLength(200)]
        public string client_id { get; set; }

        [StringLength(200)]
        public string client_secret { get; set; }

        [StringLength(200)]
        public string client_secret_2 { get; set; }

        [StringLength(50)]
        public string TokenPin { get; set; }

        [StringLength(200)]
        public string DocumentSubmissions_URL { get; set; }

        [Key]
        public int Recourd_id { get; set; }

        public byte? status { get; set; }

        [StringLength(50)]
        public string TokenCompny { get; set; }

        public int? ComID { get; set; }
    }
}
