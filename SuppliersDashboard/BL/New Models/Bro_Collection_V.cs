namespace ScoposERB.BL.New_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bro_Collection_V
    {
       
        public int BillNo { get; set; }
        public int ComId { get; set; }

  
        public string Customer_ID { get; set; }

          public string CompanyName { get; set; }
          public string _Date { get; set; }
          public string _Time { get; set; }

        public string Currency { get; set; }

        public DateTime? BillDate { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? sendToEta { get; set; }
        public int HoldingTaxIsCollected { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? Deffered { get; set; }
    }
}
