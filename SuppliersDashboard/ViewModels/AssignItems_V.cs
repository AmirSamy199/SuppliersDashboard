
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class AddOpenningBalanceInfo
    {
        public string Cus_id { get; set; }
        public string UserID { get; set; }
        public string Amount { get; set; }
    }

    public class AA_ItemSalesByDay_pro
    {
        // 										
        public int BillNO { get; set; }
        public int Branch_id { get; set; }
        public int Sales_ID { get; set; }
        public int ItemID { get; set; }
        public string Items { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public decimal NumberOfUnits { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DefaultTotalPrice { get; set; }
        


    }
    public partial class Branch_Info_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string Telephone1 { get; set; }

        [StringLength(100)]
        public string Telephone2 { get; set; }

        public int? comid { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public int? UserId { get; set; }

        [StringLength(150)]
        public string UserName { get; set; }

        public int? Region_ID { get; set; }

        [StringLength(50)]
        public string Region { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int RecordID { get; set; }

        [StringLength(50)]
        public string Range { get; set; }
        public int RangeId { get; set; }

        public int? Type { get; set; }
        public string TypeName { get; set; }
        public string DistributorGroup { get; set; }
        public string Address { get; set; }
        public int? DaysToBeLater { get; set; }

        public int? FirstDay { get; set; }
        public int? SecondDay { get; set; }
        public int? ThirdDay { get; set; }
        public string FirstDay_ar { get; set; }
        public string SecondDay_ar { get; set; }
        public string ThirdDay_ar { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string Email { get; set; }
        public int? Distributor_ID { get; set; }
        public decimal? MaxDefferedAmount { get; set; }
        public int? PriceListId { get; set; }
        public string PriceListName { get; set; }

        public int? PaymentTermsId { get; set; }

    }
    public class CloseStoreDay
    {
        //iTEMnAME  Item_ID   QUNTTATY
        public int RecordID { get; set; }
        public int Item_ID { get; set; }
        public decimal QUNTTATY { get; set; }
        public string iTEMnAME { get; set; }
        public decimal Difference { get; set; }
        public decimal Actual_QUANTITY { get; set; }
    }
    public class ItemTransactionV2
    {
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public int Item_ID { get; set; }
        public DateTime date { get; set; }
        public string _date { get; set; }
        public decimal Item_Count { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public string transactionType { get; set; }
        public decimal Item_New_Count { get; set; }

    }
    public class ItemTransaction
    {
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public int Item_ID { get; set; }
        public decimal Item_Count { get; set; }
        public DateTime date { get; set; }
        public string _date { get; set; }
        public string transaction { get; set; }
        public string transactionType { get; set; }
    }
    public class Branch_tbl
    {
        public int Record_ID { get; set; }

        public string BranchName { get; set; }

        public string ContactName { get; set; }

        public string Telephone1 { get; set; }

        public string Telephone2 { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Comment { get; set; }

        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public string SalesContact { get; set; }

        public int? Distributor_ID { get; set; }

        public byte? status { get; set; }

        public int? Region_ID { get; set; }

        public int? comid { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public string AddressUrl { get; set; }
        public int UserId { get; set; }
        public int DaysToBeLater { get; set; }
        public int PaymentTermsId { get; set; }
        public int CompanyType { get; set; }
        public decimal? MaxDefferedAmount { get; set; } = 0;
        public int PricesListId { get; set; }
    }
    public class UpdateSellingPrice
    {
        public string User_Id { get; set; }
        public string Item_ID { get; set; }
        public string Cus_id { get; set; }
        public string Item_Selling_Price { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public bool isAll { get; set; }
        public int comid { get; set; }

    }
    public class printBuyBill
    {
        public int Item_Id { get; set; }
        public int Supplier_Id { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public decimal Item_Count { get; set; }
        public decimal Supply_Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Edit_date { get; set; }
        public string _Edit_date { get; set; }


    }
    public class SetExpenses
    {
        public string UserID { get; set; }
        public string Amount { get; set; }
        public string comment { get; set; }
        public int? Editor { get; set; }
        public string ExpenseID { get; set; }

    }
    public class SalesAndReturns 
    {
        public string SR_No { get; set; }
        public string Items { get; set; }
        public string NumberOfUnits { get; set; }
        public string size { get; set; }
        public string UnitPrice { get; set; }
        public string Discount { get; set; }
        public string TotalPrice { get; set; }
        public string ItemID { get; set; }
        public string Suppier_id { get; set; }
        public string Supply_Price { get; set; }
        public double itemcount { get; set; }
        public int TransactionType { get; set; }
        public string sals { get; set; }
        public string returns { get; set; }
        public string discount_reason { get; set; }
        public decimal? discountItemSize { get; set; }
        public string discountType { get; set; }
    }
    public class Billdetails
    {
        //public List<Sales> pil_Details { get; set; }
        public string CusID { get; set; }
        public string PillDiscount { get; set; }
        public string Editor { get; set; }
        public string Sales_ID { get; set; }
        public string TotalAmountBeforDiscount { get; set; }
        public string TotalAmountAfterDiscount { get; set; }
        public string Cash { get; set; }
        public string Deferred { get; set; }
        public string collection { get; set; }
        public string ReturnAmount { get; set; }
        public List<SalesAndReturns> Bill_Details { get; set; }
        public string discount_reason { get; set; }
        //public List<Returns> PillReturn { get; set; }
    }
    public partial class main_warehouse_items_availablilty_V
    {
        public int ItemID { get; set; }
        public int? Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }

        public string ItemName { get; set; }

        public string Barcode { get; set; }

        public decimal? availableCount { get; set; }
        public decimal? Selling_Price { get; set; }
        public decimal? Supply_Price { get; set; }
    }

    public class kashfSelsela
    {

        public int BillNo { get; set; }
        public DateTime Add_Date { get; set; }
        public int Branch_Id { get; set; }
        public string BranchName { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal ReturnAmount { get; set; }
        public decimal bal { get; set; }
        public string _Add_Date { get; set; }
    }
    public class SelectBranch
    {

        public int UserId { get; set; }
        public string salesStatus { get; set; }
        public string SalesName { get; set; }
        public int comid { get; set; }
        public decimal Unpaid_deferred { get; set; }
        public string item { get; set; }
        public string branchName { get; set; }
        public string Region { get; set; }
        public string Range { get; set; }
        public int Region_ID { get; set; }
        public int Range_ID { get; set; }
        public int Branch_ID { get; set; }
    }
    public class SelectAllDebts_Pro
    {

        public int cus_id { get; set; }
        public int Branch_id { get; set; }
        public int COMID { get; set; }
        public decimal Debts { get; set; }
        public decimal Laters { get; set; }
        public string region { get; set; }
        public string BranchName { get; set; }
        public string CompanyName { get; set; }
        public DateTime TranDate { get; set; }
        public string _TranDate { get; set; }
        public int salesid { get; set; }


    }
    public class salemortg3atVM
    {

        public int RecordID { get; set; }
        public int Item_ID { get; set; }
        public string ItemName { get; set; }
        public decimal Item_Count { get; set; }
        public decimal total_amount { get; set; }
        public int User_Id { get; set; }
        public string _Edit_date { get; set; }
    }
    public class AssignItems_V
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Editor { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ItemGroup_ID { get; set; }
        public Nullable<byte> Item_Status { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
        public Nullable<decimal> size { get; set; }
        public Nullable<int> Item_ID { get; set; }
        public Nullable<int> Distributor_Group_id { get; set; }
        public Nullable<decimal> Selling_Price { get; set; }
        public Nullable<decimal> Supply_Price { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<byte> Price_Status { get; set; }
        public int Price_ID { get; set; }
        public string CompanyName { get; set; }
        public string Distributor { get; set; }
        public string unitType_En { get; set; }
        public string unitType_Ar { get; set; }

    }
    public class Bill_Detiles_sales
    {
        public string Items { get; set; } = "";
        public Nullable<decimal> NumberOfUnits { get; set; } = 0;
        public Nullable<decimal> UnitPrice { get; set; } = 0;
        public Nullable<decimal> TotalPrice { get; set; } = 0;
        public Nullable<decimal> size { get; set; } = 0;
        public Nullable<decimal> Discount { get; set; } = 0;
    }
    public class Select_Pill_Heder_Pro {
        public string  subject { get; set; }
        public string  data { get; set; }
    }

    public class Bill_Detiles_Returns
    {
        public Nullable<decimal> size { get; set; } = 0;
        public Nullable<decimal> Amount { get; set; } = 0;
        public string ItemName { get; set; } = "";
    }
    public class Bill_Details_model
    {
        public List<Bill_Detiles_sales> Sales { get; set; }
        public List<Bill_Detiles_Returns> Returns { get; set; }
         public List<Select_Pill_Heder_Pro> headers { get; set; }
        public string CompanyName { get; set; }


    }
}