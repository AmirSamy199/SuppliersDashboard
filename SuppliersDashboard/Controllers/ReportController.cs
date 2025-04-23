using Aspose.Cells;
using BitMiracle.LibTiff.Classic;

using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.Services;
using SuppliersDashboard.ViewModels;
using SuppliersDashboard.ViewModels.ReportVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace SuppliersDashboard.Controllers
{
    [MyAuthFilter]
    
    public class ReportController : BaseController
    {
        private HttpClientHelper httphelp = new HttpClientHelper();
        private Getter get = new Getter();
        private EldeebExcel xl = new EldeebExcel();
        // GET: Report
        public ActionResult AllDebits()
        {
            return View();
        }
   
        [FunctionFilter(key = "صفحة تقرير مبيعات مجموعة")]

        public ActionResult CatogriesSalesReport() {

            ViewBag.PageMsg = "هذة الصفحة لمتابعة مبيعات مجموعات الاصناف    ";
         

                var response = httphelp.Get( "/api/Suppliers/GetSuppliers");
                dynamic deContent = JsonConvert.DeserializeObject<object>(response);
                 ViewBag.Suppliers = deContent.data;
                string branchresponse = httphelp.Get("/api/Selector/GetAllBranchesFromTable");
                 ViewBag.Branches = JsonConvert.DeserializeObject<Response<List<Select>>>(branchresponse).Data;
                string userresponse = httphelp.Get("/api/Selector/GetUsers");
                 ViewBag.Users = JsonConvert.DeserializeObject<Response<List<Select>>>(userresponse).Data; 



            
            return View();
        } 
        [HttpPost]
        public JsonResult CatogriesSalesReportJson(int CategoryID , int UserID , int BranchID , string DateFrom , string DateTo)
        {
            // رييبورت بيجيب اجماليات مبيعات بمجاميع الاصناف بس القديم كان كله علي بعضه في جدول واحد 
            string content = httphelp.Get($"/api/Procedures/AA_GetItemSalesBranchDistriutorDateByCategories_pro?CategoryID={CategoryID}&UserID={UserID}&BranchID={BranchID}&DateFrom={DateFrom}&DateTo={DateTo}");
            Response<CetegoryReportHeadandDetails> res = JsonConvert.DeserializeObject<Response<CetegoryReportHeadandDetails>>(content);
            return Json(new { data = res });
        }

        #region warehouose

        [FunctionFilter(key = "w-store")]

        public ActionResult PendingRequest(string SaleId, string SalesName)
        {
            ViewBag.Sales = SalesName.Replace("'","");
            var Us = Cokie.UserGet();
            ViewBag.userName = Us.UserName;
            SaleId = SaleId.Replace(" ", "");
            SaleId = SaleId.Replace("'", "");
            using (HttpClient http = new HttpClient())
            {
                string req = $"/api/WareHousing/GetPendingRequests?sales={SaleId}";
                var response = http.GetAsync(Setting.Host + req).Result;
                Response<List<warehouse_Requst_V>> res = JsonConvert.DeserializeObject<Response<List<warehouse_Requst_V>>>(response.Content.ReadAsStringAsync().Result);
                ViewBag.Data = res.Data;
            }
            ViewBag.HasExcel = 0;
            return View();
        }

        #endregion
        #region Items 
        [FunctionFilter(key = "صفحة تقرير كشف حركة صنف")]

        public ActionResult Itemcard( )
        {

            return View();
        }
        [FunctionFilter(key = "صفحة تقرير مبيعات صنف")]

        public ActionResult ItemSales()
        {
            return View();
        }
     
        [FunctionFilter(key = "صفحة تقرير مبيعات المندوبين")]

        public ActionResult AllDistributorReportsDetails()
        {
            return View();
        }
      
        
        [HttpPost]
        public JsonResult AllDistributorReportsDetailsJSON(string DateFrom ="-" , string DateTo="-")
        {
            ReportService REPORTSERVICE = new ReportService();
           return Json(new { data = REPORTSERVICE.AllDistributorReportsDetails(DateFrom,DateTo)});
        }


        [HttpPost]
        public ActionResult ItemSalesFromTOJson(int ItemID , string DateFrom , string DateTo )
        {
            ItemService ITEMSERVICE = new ItemService();
            return Json(new { data=ITEMSERVICE.GetItemSalesFromTo(ItemID , DateFrom , DateTo)});
        }
        #endregion
        public ActionResult SalesMardodReport(int UserId , string UserName )
        {
            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;
                 try
                {
               
                        List<salemortg3atVM> model = getmardodatList(UserId);
                    return View(model);
                }
                catch
                {
                    return View(new List<salemortg3atVM>());
                }
          
           
        }
   
        public ActionResult SalesMortga3Report(int UserId, string UserName)
        {
            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;

            try
            {
                List<salemortg3atVM> model = getmortg3atList(UserId);

                return View(model);
            }
            catch
            {
                return View(new List<salemortg3atVM>());
            }


        }
        [HttpPost]
        public JsonResult GetItemTransaction(int itemId , string DateFrom , string DateTo)
        {
            return Json(new { data = GetItemTransactionList(itemId, DateFrom, DateTo) });
        }
        public ActionResult BranchReport (int BranchId , string BranchName )
        {
            ViewBag.BranchId = BranchId;
            ViewBag.BranchName = BranchName;
            return View(getbillsToBranch(BranchId));
        }
        //[StoreFilter]
        //public ActionResult StoreGard()
        //{
        //    ViewBag.HasExcel = 1;
        //    ViewBag.ExcelUrl = "StoregardExcel";
        //    ViewBag.ExcelName = "جرد مخزن "+ DateTime.Now.ToString("yyyy/MM/dd");
        //    return View(getstoregards());
        //}

        #region Excels Method 
       [HttpPost]
       public JsonResult GetItemCardExcel(int ItemId , string DateFrom , string DateTo)
        {
           
            using (HttpClient http = new HttpClient())
            {
              
                try
                {
                    
                    List<ItemTransactionV2> modellist = GetItemTransactionList(ItemId, DateFrom, DateTo).Data;
                 
                    Workbook exc = xl.GetExcel<ItemTransactionV2>(modellist);
                    exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"),SaveFormat.Xlsx);
                    return Json(new { url = "/Content/Excels/Excel.xlsx" });
                }
                catch
                {
                    return Json(new warehouse_main_V());
                }
            }
           
        }
        public JsonResult GetUserDeffered(int Id)
        {
            List<SelectAllDebts_Pro> model = get.GetCustomerDebits(Id).Data;
            List<ExcelHeader> headers = new List<ExcelHeader>();
            headers.Add(new ExcelHeader { Key = "region", Value = "الفرع" });
            headers.Add(new ExcelHeader { Key = "BranchName", Value = "الشركة" });
            headers.Add(new ExcelHeader { Key = "Debts", Value = "مديونية" });
            headers.Add(new ExcelHeader { Key = "Laters", Value = "متأخرات" });
            headers.Add(new ExcelHeader { Key = "TranDate", Value = "الوقت" });
            Workbook exc = xl.GetExcelWithHeader<SelectAllDebts_Pro>(model, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
            ////......

            //Workbook excel = xl.GetExcel<SelectAllDebts_Pro>(model);
            //excel.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
            //return Json(new { url = "/Content/Excels/Excel.xlsx" });
        } 
        public JsonResult GetUserLaters(int Id)
        {
            List<SelectAllDebts_Pro> model = get.GetCustomerDebits(Id).Data.Where(s => (DateTime.Now - s.TranDate).Days > 30).ToList();
            Workbook excel = xl.GetExcel<SelectAllDebts_Pro>(model);
          excel.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"),SaveFormat.Xlsx);
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
       public JsonResult getMardodatExcel(int UserId)
        {
            try
            {
               
                List<salemortg3atVM> modellist = getmardodatList(UserId);           
                Workbook exc = xl.GetExcel<salemortg3atVM>(modellist);
                exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
            
                return Json(new { url = "/Content/Excels/Excel.xlsx" });
            }
            catch
            {
                return Json("");
            }
        }
       public JsonResult getMortga3Excel(int UserId)
        {
            try
            {
              
                List<salemortg3atVM> modellist = getmortg3atList(UserId);           
              
                Workbook exc = xl.GetExcel<salemortg3atVM>(modellist);
                exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
                return Json(new { url = "/Content/Excels/Excel.xlsx" });
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult GetBranchBillsExcel(int BranchId)
        {
            try
            {
              
                List<SelectCustomer_Statement_Pro> modellist = getbillsToBranch(BranchId);           
               
                Workbook exc = xl.GetExcel<SelectCustomer_Statement_Pro>(modellist);
                
                exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
              
                return Json(new { url = "/Content/Excels/Excel.xlsx" });
            }
            catch
            {
                return Json("");
            }
        }
        #endregion

        public JsonResult StoregardExcel(string datefrom = "", string dateto = "")
        {
            List <StoreGardVM> storgards = getstoregards(datefrom,dateto).Select(s => new StoreGardVM { Item_Name = s.ItemName, bal = s.bal, Company_Name = s.CompanyName, Item_Credit = s.iTEM_C, Item_Debit = s.iTEM_d }).ToList();
          
            Workbook exc = xl.GetExcel<StoreGardVM>(storgards);
                exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);

            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult BranchAccountStateMent(int BranchID)
        {
            List<SelectCustomer_Statement_Pro> models = get.GetCustomerStatement(BranchID).Data;
            Workbook exc = xl.GetExcel<SelectCustomer_Statement_Pro>(models);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult ItemSalesFromToExcel(int ItemID, string DateFrom, string DateTo)
        {
            ItemService ITEMSERVICE = new ItemService();
            Response<List<AA_ItemSalesByDay_pro>> ITEMS = ITEMSERVICE.GetItemSalesFromTo(ItemID, DateFrom, DateTo);
            Workbook exc = xl.GetExcel<AA_ItemSalesByDay_pro>(ITEMS.Data);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult ItemCategoriesSalesFromToExcel(int CategoryID, int UserID, int BranchID, string DateFrom, string DateTo)
        {
            
            string content = httphelp.Get($"/api/Procedures/AA_GetItemSalesBranchDistriutorDateByCategories_pro?CategoryID={CategoryID}&UserID={UserID}&BranchID={BranchID}&DateFrom={DateFrom}&DateTo={DateTo}");
            Response<CetegoryReportHeadandDetails> res = JsonConvert.DeserializeObject<Response<CetegoryReportHeadandDetails>>(content);
            Workbook exc = xl.GetExcel<CategoriesReportSums>(res.Data.Heads);



                            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult KashfSelselaExcel(int ComID)
        {
            string response = httphelp.Get($"/api/Company/GetViewBillsChain?ComID={ComID}");
            Response<List<kashfSelsela>> result = JsonConvert.DeserializeObject<Response<List<kashfSelsela>>>(response);
            Workbook exc = xl.GetExcel<kashfSelsela>(result.Data);
                            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }

        [HttpPost]
        public JsonResult AllDistributorReportsDetailsExcel(string DateFrom = "-", string DateTo = "-")
        {
            ReportService REPORTSERVICE = new ReportService();
            List<SelectSales_Today_English_Pro> model = REPORTSERVICE.AllDistributorReportsDetails(DateFrom, DateTo).Data; 
            Workbook exc = xl.GetExcel<SelectSales_Today_English_Pro>(model);
               exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        #region helper methods 
        private List<salemortg3atVM> getmardodatList(int UserId)
        {
            string response = httphelp.Get($"/api/ReportV2/SalemMardodat?UserId={UserId}");
            List<salemortg3atVM> modellist = JsonConvert.DeserializeObject<Response<List<salemortg3atVM>>>(response).Data;
            return modellist;
        }  
        private List<salemortg3atVM> getmortg3atList(int UserId)
        {
            string response = httphelp.Get($"/api/ReportV2/SaleMortg3at?UserId={UserId}");
            List<salemortg3atVM> modellist = JsonConvert.DeserializeObject<Response<List<salemortg3atVM>>>(response).Data;
            return modellist;
        }
        private List<SelectCustomer_Statement_Pro> getbillsToBranch(int BranchId)
        {
            string response = httphelp.Get($"/api/Report/Get_CustomerWithUsers_Statement?CusID={BranchId}&UserID={0}");
            List<SelectCustomer_Statement_Pro> modellist = JsonConvert.DeserializeObject<Response<List<SelectCustomer_Statement_Pro>>>(response).data;
            return modellist; 
        }
        private List<warehouse_main_V> getstoregards(string datefrom="" , string dateto ="")
        {
            string content = httphelp.Get($"/api/Procedures/FromTowarehouse_main_pro?datefrom={datefrom}&dateto={dateto}");
            var models = JsonConvert.DeserializeObject<Response<List<warehouse_main_V>>>(content);
            return models.Data;
        }
        private Response<List<ItemTransactionV2>> GetItemTransactionList(int ItemId , string DateFrom="" , string DateTo="")
        {
            string url = $"/api/Procedures/R_Item_transaction_Pro?ItemId={ItemId}&DateFrom={DateFrom}&DateTo={DateTo}";
            string response = httphelp.Get(url);
            var model = JsonConvert.DeserializeObject<Response<List<ItemTransactionV2>>>(response);
            return model;
        }
        #endregion






   
    }
}