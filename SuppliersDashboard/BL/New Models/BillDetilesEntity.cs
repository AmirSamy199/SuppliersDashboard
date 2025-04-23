namespace ScoposERB.BL.New_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class BillDetilesEntity
    {
        public int Record_ID { get; set; }

        public int SR_No { get; set; }
        public string Items { get; set; }
        public string IntCode { get; set; }
        public string GPC_Code { get; set; }
        public string Description { get; set; }

        public decimal NumberOfUnits { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public int Suppier_id { get; set; }

        public int BillNo { get; set; }

        public decimal ItemDiscount_rate { get; set; }

        public decimal ItemDiscount_amount { get; set; }

        public int sysItemID { get; set; }
        public string documentType { get; set; }

        public byte environment_ID { get; set; }

        public int comid { get; set; }
        public string unitType_Ar { get; set; }
        public string Currency { get; set; }
        public decimal currencyExchangeRate { get; set; }

        public int CusID { get; set; }

        public int ServiceID { get; set; }
        public string posserial { get; set; }

        public string Editor { get; set; }

        public int Request_id { get; set; }

        public int branchid { get; set; }

        public int Editor_id { get; set; }

        public string Date { get; set; }
        public string SubmittionUUID { get; set; }
        public decimal Vat { get; set; }
        public decimal GrossTotal { get; set; }
        public string ETASend { get; set; }
    }
}
