using FastReport.Export.Dbf;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class warehouse_Base_Requst_Tbl
    {
        public int RecordID                  {get;set;}
public int? WarehouseFromId                   {get;set;}
public int? WareHouseToId                     {get;set;}
public int? Item_ID                           {get;set;}
public decimal? Item_Count                        {get;set;}
public int? User_ID                           {get;set;}
public DateTime? Edit_date                         {get;set;}
public int? Supplier_ID                       {get;set;}
public DateTime? dailyClosing                      {get;set;}
public byte? Storekeeper_confirm               {get;set;}
public byte? sales_confirm                     {get;set;}
public int? Storekeeper_id                    {get;set;}
public int? sales_id                          {get;set;}
public DateTime? sales_confirm_date                {get;set;}
public DateTime? Storekeeper_confirm_date          {get;set;}
public byte? Settlement                        {get;set;}
public byte? type                              {get;set;}
public byte? ItemTransfer                      {get;set;}
public int? RequstNo                          {get;set;}
    }
    public class warehouse_Base_v
    {
        [Key]

        public int Row { get; set; }
        public int? WareHouse_ID { get; set; }
        public int? Supplier_Id { get; set; }
        public int? ItemId { get; set; }
        public string WareHouse_Name { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public decimal? bal { get; set; }
        public decimal? iTEM_C { get; set; }
        public decimal? iTEM_d { get; set; }
    }
    public class transferitems2balancesrequests
    {
        public List<TransfereItemRequest> Sender { get; set; }
        public List<TransfereItemRequest> Receiver { get; set; }
    }
    public partial class TransfereItemRequest : warehouse_main_V
    {
        public int WareHouse_ID { get; set; }
        public string WareHouse_Name { get; set; }

    }

    public partial class warehouse_Requst_Tbl
    {

        public int RecordID { get; set; }

        public int? Item_ID { get; set; }

        public decimal? Item_Count { get; set; }

        public int? User_ID { get; set; }

        public DateTime? Edit_date { get; set; }

        public int? Supplier_ID { get; set; }

        public DateTime? dailyClosing { get; set; }

        public byte? Storekeeper_confirm { get; set; }

        public byte? sales_confirm { get; set; }

        public int? Storekeeper_id { get; set; }

        public int? sales_id { get; set; }

        public DateTime? sales_confirm_date { get; set; }

        public DateTime? Storekeeper_confirm_date { get; set; }

        public byte? Settlement { get; set; }

        public byte? type { get; set; }

        public byte? ItemTransfer { get; set; }

        public int? RequstNo { get; set; }
    }


    public class requestwithheader
    {
        public requestwithheader()
        {
            
        }
        public requestwithheader(int storeid , string storename , TransfereItemRequest req )
        {
            this.StoreId = storeid;
            this.StoreName = storeid != -1 ?storename :"مخزن الريتيل";
            this.requests = new List<TransfereItemRequest> { req };
        }
        public string StoreName { get; set; }
        public int StoreId { get; set; }
        public List<TransfereItemRequest> requests { get; set; }
    }
}