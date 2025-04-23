
using FastReport.Utils;
using Newtonsoft.Json;
using ScoposERB.Helper;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class AsSalesmanController : BaseController
    {
        private HttpClientHelperAsDistributor _httpSalesMan = new HttpClientHelperAsDistributor();
        // GET: AsSalesman
        [FunctionFilter(key = "صفحة البيع لقناة بيعية")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ConfirmSettlementItems(int UserId)
        {
            var url = $"/api/Items/SubmitReturnMardodat?UserID={UserId}";
            return Json(_httpSalesMan.Get<Response<string>>(UserId,url));
        }

        [HttpPost]
       public ActionResult CarBalance(int Id)
        {

            string url = $"/api/Report/GetItemsSummryReport?UserID={Id}";
            var res = _httpSalesMan.Get<Response<List<SelectBalanceOfTheItems>>>(Id, url);

               string url2 = $"/api/SubWarehouseReturnBalance?SalesId={Id}";
                var res2 = _httpSalesMan.Get<Response<List<SubWarehouseReturnBalance_V>>>(Id, url2);

            ViewBag.Returns = res2;
            return PartialView("_CarBalance" , res);
        } 
        [HttpPost]
       public ActionResult pendingReceiveItems(int Id)
        {
            // Response<List<warehouse_Requst_V>>
            string url = $"/api/WareHousing/GetPendingRequests?sales={Id}";
            var res = _httpSalesMan.Get<Response<List<warehouse_Requst_V>>>(Id, url);
            return PartialView("_pendingReceiveItems", res);
        }
            [HttpPost]
       public ActionResult pendingMardodatItems(int Id)
        {
            // Response<List<warehouse_Requst_V>>
            string url = $"/api/WareHousing/GetPendingRequests?sales={Id}&mardod=1";
            var res = _httpSalesMan.Get<Response<List<warehouse_Requst_V>>>(Id, url); 
            try {
                string url2 = $"/api/WareHousing/getPendingMortaga3at?sales={Id}";
                var res2 = _httpSalesMan.Get<Response<List<Mortaga3>>>(Id, url2);
                ViewBag.Morttaaga = res2;
            }
            catch(Exception ex)
            {
                ViewBag.Morttaaga = new Response<string> { State = 2 };

            }

            return PartialView("_pendingMardodatItems", res);
        }


        [HttpPost]
        public ActionResult addWarehouseRequestPartial(int Id) {


            var url = $"/api/Company/AvailableWareHouseItems?UserId={Id}";
            var res = _httpSalesMan.Get<Response<List<main_warehouse_items_availablilty_V>>>(Id, url);
            ViewBag.Items = res.Data;
            return PartialView("_addWarehouseRequestPartial");
        }
        
        [HttpPost]
        public ActionResult SalePartial(int Id) {
            return PartialView("_SalePartial");
           
        } 
        [HttpPost]
        public JsonResult loadCompanies(int Id) {
            var url = $"/api/Company/GetCompaniesToFillSelect";
            var res = _httpSalesMan.Get<Response<List<ScoposERB.Helper.Select>>>(Id, url).Data;
            return Json(res);

        }   
        
        [HttpPost]
        public JsonResult loadBranches(int Id , int comId) {
            var url = $"/api/Company/GetCompanyBranches?ComID={comId}&UserId={Id}";
            var res = _httpSalesMan.Get<Response<List<SelectBranch>>>(Id, url).Data;
            return Json(res);

        }
           [HttpPost]
        public JsonResult getItemsToSale(int Id , int branchId) {
            var url = $"/api/Sale/GetItemsWithCusDeffered?UserID={Id}&CustID={branchId}";
            var res = _httpSalesMan.Get<Response<List<SelectItem_Pro_WithCus>>>(Id, url);
            return Json(res);

        }
        [HttpPost]
        public JsonResult setPill(int Id , Billdetails json)
        {
            var url = $"/api/Sale/setpill";
            var res = _httpSalesMan.Post<Response<string>, Billdetails>(Id, url, json);
            return Json(res);
        }


        [HttpPost]
        public JsonResult SubmitAddWarehouseRequest(int Id ,warehouse_Requst_Tbl model)
        {
            model.Edit_date = TbiServer.Time(DateTime.Now);
            var url = $"/api/Warehousing/AddWareHouseRequest";
            var res = _httpSalesMan.Post<Response<string>, warehouse_Requst_Tbl>(Id, url, model);
            return Json("");
        }
        [HttpPost]
        public JsonResult salesmanacceptgetrequest(int Id)
        {
            var url = $"/api/WareHousing/ConfirmSalesrRequest?ID={Id}";
            var res = _httpSalesMan.Get<Response<string>>(Id, url);
            return Json(res);
        } 
        [HttpPost]
        public JsonResult salesmanacceptmardodatrequest(int Id)
        {
            // /api/WareHousing/ConfirmSalesrRequest
            var url = $"/api/WareHousing/ConfirmSalesrRequest?ID={Id}&mortaga3=1";
            var res = _httpSalesMan.Get<Response<string>>(Id, url);
            return Json(res);
        } 
        [HttpPost]
        public JsonResult salesmanacceptclosingsettlement(int Id)
        {
            // /api/WareHousing/ConfirmSalesrRequest
            var url = $"/api/ClosingDay/ConfirmCompleteAccount?sales={Id}&type=2";
            var res = _httpSalesMan.Get<Response<string>>(Id, url);
            return Json(res);
        }

        [HttpPost]
        public ActionResult closeDayRevision(int Id)
        {
            var url = $"/api/ClosingDay/GetCloseSalesDayDatafForUser?sales={Id}";
            var res = _httpSalesMan.Get<Response<settlementViewModel>>(Id, url);


            if(res.State == 1 && res.Item != null)
            {
                res.Item.moneyfall = res.Item.required_amount - res.Item.actual_amount == 0 ? "" : (res.Item.required_amount - res.Item.actual_amount).ToString(); 
                res.Item.collectionpapercountfall = res.Item.colection_paper_count_required - res.Item.Actual_DeferredMoneyPaper_count == 0 ? "" : (res.Item.colection_paper_count_required - res.Item.Actual_DeferredMoneyPaper_count).ToString(); 
                res.Item.collectionpaperamountfall = res.Item.colection_paper_amount - res.Item.Actual_DeferredMoneyPaper_Amount == 0 ? "" : (res.Item.colection_paper_amount - res.Item.Actual_DeferredMoneyPaper_Amount).ToString(); 
                res.Item.moneypapercountfall = res.Item.payment_paper_count_required - res.Item.Actual_MoneyReceiptPapers_count == 0 ? "" : (res.Item.payment_paper_count_required - res.Item.Actual_MoneyReceiptPapers_count).ToString(); 
                res.Item.moneypaperamountfall = res.Item.payment_paper_amount - res.Item.Actual_MoneyReceiptPapers_Amount == 0 ? "" : (res.Item.payment_paper_amount - res.Item.Actual_MoneyReceiptPapers_Amount).ToString(); 
            }
            return PartialView("_closeDayRevision", res);
        }

        [HttpPost]
        public JsonResult submitsettlespecificItem(int salesId , List<ItemSettleVM> Items)
        {
           foreach(var item in Items)
            {
                item.salesId = salesId;
            }

            string url = "/api/Warehousing/AddSpecificMardodat";
            var response = _httpSalesMan.Post<Response<string>, List<ItemSettleVM>>(salesId, url, Items);
            return Json(response);
        }  
        [HttpPost]
        public JsonResult submitsettlereturnspecificItem(int salesId , List<ItemSettleVM> Items)
        {
           foreach(var item in Items)
            {
                item.salesId = salesId;
            }

            string url = "/api/Warehousing/AddSpecificMortg3at";
            var response = _httpSalesMan.Post<Response<string>, List<ItemSettleVM>>(salesId, url, Items);
            return Json(response);
        }
        [HttpGet]
        public ActionResult AddReturnPartial(int salesId)
        {
            ViewBag.BaseId = salesId;
            var response2 = _httpSalesMan.Get(salesId,$"/api/Items/GetAllItemsFromTable");
            Response<List<Models.Items_Tbl>> res = JsonConvert.DeserializeObject<Response<List<Models.Items_Tbl>>>(response2);
            ViewBag.Items = res.Data;

            return PartialView("_addReturnPartial");
        }

        [HttpPost]
        public JsonResult SubmitReturnRequest(int Id , ReturnModel Model)
        {
            Model.user_id = Id;
            Model.Date = TbiServer.Time(DateTime.Now).ToString("yyyy-MMM-dd hh:mm:ss");
            string url = $"/api/Sale/ReturnItems";
            var res = _httpSalesMan.Post<Response<string>, ReturnModel>(Id,url, Model);
            return Json(res);
        }
        [HttpPost]
        public JsonResult SubmitReturnRequestAsList(int Id , List<ReturnModel> Model)
        {
            foreach (var item in Model)
            {

            item.user_id = Id;
            item.Date = TbiServer.Time(DateTime.Now).ToString("yyyy-MMM-dd hh:mm:ss");
            }
            string url = $"/api/Sale/ReturnItemsAsList";
            var res = _httpSalesMan.Post<Response<string>, List<ReturnModel>>(Id,url, Model);
            return Json(res);
        }

        [HttpPost]
        public JsonResult LastUnitPriceForMortaga3(int branchId, int itemId)
        {
            
            string url = $"/api/LastUnitPriceForMortaga3?branchId={branchId}&itemId={itemId}";
            var res = _httpSalesMan.Get<Response<string>>(0, url);

            return Json(Convert.ToDecimal(res.Data));
        }

    }














    #region Classes

    public class ItemSettleVM
    {
        public int itemId { get; set; }
        public decimal itemValue { get; set; }
        public decimal amount { get; set; }
        public int salesId { get; set; }
    }
    public class SelectBalanceOfTheItems
    {
        public decimal Purchases { get; set; }
        public decimal sales { get; set; }
        public decimal Balance { get; set; }
        public string itemname { get; set; }
        public int Item_ID { get; set; }
        public int ITEM_ID { get; set; }
    }

    public class SelectItem_Pro_WithCus
    {
        //public Nullable<decimal> Selling_Price { get; set; }
        public Nullable<decimal> Supply_Price { get; set; }
        public Nullable<decimal> size { get; set; }
        public int Supplier_ID { get; set; }
        public string item { get; set; }
        public int Item_ID { get; set; }
        public Nullable<decimal> CustomerSellingPrice { get; set; }
        public string Barcode { get; set; }
        public decimal bal { get; set; }
        //public int Cus_id { get; set; }

    }

    public class settlementViewModel
    {
        public decimal actual_amount { get; set; }
        public decimal required_amount { get; set; }
        public decimal Actual_MoneyReceiptPapers_count { get; set; }
        public decimal Actual_MoneyReceiptPapers_Amount { get; set; }
        public decimal Actual_DeferredMoneyPaper_count { get; set; }
        public decimal Actual_DeferredMoneyPaper_Amount { get; set; }
        public int payment_paper_count_required { get; set; }
        public decimal payment_paper_amount { get; set; }
        public int colection_paper_count_required { get; set; }
        public decimal colection_paper_amount { get; set; }
        public string  moneyfall { get; set; }
        public string  collectionpapercountfall { get; set; }
        public string  collectionpaperamountfall { get; set; }
        public string  moneypapercountfall { get; set; }
        public string  moneypaperamountfall { get; set; }
    }

    public class ReturnModel
    {
        public int item_id { get; set; }
        public int Branch_id { get; set; }
        public int user_id { get; set; }
        public decimal size { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string BillNo { get; set; }

    }
    #endregion
}







