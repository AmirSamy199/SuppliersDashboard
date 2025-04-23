using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int RecordID { get; set; }
        public int Branch_RecordID { get; set; }
        public string Branch_name { get; set; }

        public string UserAccount { get; set; }
        public Nullable<int> Group_RecordID { get; set; }
        public string Password { get; set; }
        public Nullable<int> ComID { get; set; }
        public Nullable<int> TAX_ID { get; set; }
        public string Com_Name { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<byte> PriceIncludesTax { get; set; }
        public string ScopocOrUno { get; set; }
        public byte SalesModule { get; set; }
        public byte InvConfirmation { get; set; }
        public byte DepartmentModule { get; set; }
        public byte CategoryModule { get; set; }
        public byte SupplierModule { get; set; }
        public byte SubCategoryModule { get; set; }
        public byte TbiAdmin { get; set; }
        public byte AutomaticVAT { get; set; }
        public int MainGroupID { get; set; }
        public int MultiGroup { get; set; }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public bool IsStoreKeeper { get; set; }
        public string groupname { get; set; }
    }

    public class ItemPriceModel
    {
        //               
        public int ItemCode { get; set; }
        public string ItemBarCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal SupplyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DistributorId { get; set; }
        public string DistributorName { get; set; }
        public int PriceListId { get; set; }
        public string PriceListName { get; set; }
    }
    public class AddPriceModel
    {

        public int ItemId { get; set; }
        public int pricelisttid { get; set; }
        public int DistributorGroupId { get; set; }
        public decimal SupplyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}