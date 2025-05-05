using Aspose.Cells;
using FastReport.Utils;
using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class DistributorController : BaseController
    {
        Getter get = new Getter();
        // GET: Distributor
        public ActionResult Index()
        {

            return View();
        }
        [Route("/Distributor/Details/{Id}")]

        public ActionResult Details(int Id)
        {

            ViewBag.Id = Id;
            return View();

        }
        [Route("/Distributor/AllDetails/{Id}")]
        public ActionResult AllDetails(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [Route("/Distributor/DistributorUsers/{Id}")]

        [FunctionFilter(key = "صفحة ادارة المناديب")]

        public ActionResult GroupUsers()
        {
            ViewBag.DisChanged = "dischanged()";
            //using (HttpClient c = new HttpClient())
            //{
            //    ViewBag.foundResult = 1;
            //    var response = c.GetAsync(Setting.Host + "/api/DistributorV2/GetUsersToDistributorGroup?Id=" + Id).Result;
            //    var content = response.Content.ReadAsStringAsync().Result;
            //    Response<List<DistributorUser>> deContent = JsonConvert.DeserializeObject<Response<List<DistributorUser>>>(content);
            //    if(deContent.Data != null && deContent.Data.Count != 0)
            //    {
            //    ViewBag.Users = deContent.Data;
            //    }
            //    else
            //    {
            //        ViewBag.foundResult = 0;
            //        ViewBag.Users = new List<DistributorUser>() { };
            //    }
            //return View();
            //}
            return View();
        }
        [HttpPost]
        public JsonResult GetUserDistributorIdandmonthtarget(int UserId)
        {
            List<SimpleClass> groups = get.GetDistributorGroups().data;
            decimal MonthTarget = get.GetUserMonthlyTarget(UserId);
            int disid = get.GetUserDistributorGroupId(UserId);

            return Json(new { groups = groups, monthtarget = MonthTarget, disid = disid });
        }
        public ActionResult EditSalesMenPartial(int UserId)
        {
            ViewBag.Id = UserId;
            ViewBag.Groups = get.GetDistributorGroups().data;
            ViewBag.MonthTarget = get.GetUserMonthlyTarget(UserId);

            var result = get.GetSalesManSetting(UserId);
            if (result.State == 1)
            {
                result.Data.DistributorGroupId = get.GetUserDistributorGroupId(UserId);
                ViewBag.Data = result.Data;
            }

            return PartialView("_EditSalesMen");
        }
        [HttpPost]
        public JsonResult SubmitEditSalesMen(SaleManData Model)
        {

            var res = get.EditUserDetails(Model);
            return Json(new { data = res });
        }
      
        [Route("/Distributor/ViewCustomer")]
        public ActionResult ViewCustomer(string UserId, string UserName)
        {
            ViewBag.PageMsg = "هذة الصفحة لمعرفة العملاء الذين يتعامل معهم المندوب  ";
            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;

            return View();

        }
        [Route("/Distributor/ViewUserWithCustomer")]
       
        [FunctionFilter(key = "w-calculation")]
        public ActionResult ViewUserWithCustomer(string UserId, string CustomerId, string CustomerName, string UserName)
        {
            ViewBag.PageMsg = "هذة الصفحة لمعرفة مجموع تعاملات البائع مع العميل ";
            ViewBag.User = UserName;
            ViewBag.Customer = CustomerName;
            string result = GetUserWithCustomers(UserId, CustomerId).ToString();
            Response<Select_SalesSummry_For_CusAndBranches_Pro> deResult = JsonConvert.DeserializeObject<Response<Select_SalesSummry_For_CusAndBranches_Pro>>(result);
            ViewBag.Model = deResult.Item;
            return View();

        }
        [Route("/Distributor/ViewUserCustomerBills")]
        public ActionResult ViewUserCustomerBills(string UserId, string CustomerId, string CustomerName, string UserName)
        {
            ViewBag.PageMsg = "هذة الصفحة لعرض فواتير البائع مع العميل  ";

            ViewBag.User = UserName;
            ViewBag.Customer = CustomerName;
            ViewBag.CustomerId = CustomerId;
            ViewBag.UserId = UserId;
            return View();

        }

        [Route("/Distributor/Accounting")]
        [FunctionFilter(key = "كشف حساب مندوب")]

        public ActionResult Accounting(string UserId, string UserName)
        {
            ViewBag.PageMsg = "هذة الصفحة لتسوية حساب المندوب   ";
            ViewBag.User = UserName;
            ViewBag.UserId = UserId;

            using (HttpClient http = new HttpClient())
            {
                string response = http.GetAsync(Setting.Host + $"/api/Report/GetselesSummry?Userid={UserId}").Result.Content.ReadAsStringAsync().Result;
                Response<SelectSales_Today_English_Pro> model = JsonConvert.DeserializeObject<Response<SelectSales_Today_English_Pro>>(response);
                ViewBag.RequiredcollectionPapercount = model.Item.DeferredMoneyPaper_count;
                ViewBag.RequiredcollectionPaperamount = model.Item.DeferredMoneyPaper_Amount;
                ViewBag.RequiredpaymentPapercount = model.Item.MoneyReceiptPapers_count;
                ViewBag.RequiredpaymentPaperamount = model.Item.MoneyReceiptPapers_Amount;

                ViewBag.requiredamount = model.Item.TotalPilNet - model.Item.MoneyReceiptPapers_Amount;
                return View(model.Item);
            }

        }
        [HttpGet]
        public ActionResult CustomerExcel(int UserId)
        {
            string Query = $"[SelectcustomerWithDefferedTest_Pro] {UserId}";
            var res = httphelp.Get<byte[]>($"/Excel?Query={Query}");
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{UserId} Customers.xlsx");
        }

        [HttpPost]
        public ActionResult showbillsreportpopup(int SalesId)
        {
            var url = $"/api/dailybillsreporttosalesman?UserId={SalesId}";
            var data = httphelp.Get<List<Bill_Report_V>>(url);
            return PartialView("_AccountingDetails", data);

        }
        [HttpPost]
        public ActionResult showbillscollectionreportpopup(int SalesId)
        {
            var url = $"/api/dailycollectionsreporttosalesman?UserId={SalesId}";
            var data = httphelp.Get<List<Collection_v>>(url);
            return PartialView("_AccountingCollectionDetails", data);

        }
        [HttpPost]
        public ActionResult showbillsexpensesreportpopup(int SalesId)
        {
            var url = $"/api/dailyexpensereporttosalesman?UserId={SalesId}";
            var data = httphelp.Get<List<Expenses_v>>(url);
            return PartialView("_AccountingExpensesDetails", data);

        }
        [FunctionFilter(key = "كشف شهرية مندوب")]

        public ActionResult DistributorMonth(int UserID)
        {
            Response<AllDistributorDay> Model = get.DistributorSalesMonth(UserID);

            decimal MonthTarget = get.GetUserMonthlyTarget(UserID);
            ViewBag.DefaultSales = MonthTarget;

            return View(Model.Item);
        }

        private HttpClientHelper httphelp = new HttpClientHelper();
   
        [FunctionFilter(key = "صفحة تقرير المديونيات")]

        public ActionResult CustomerDeffers(int UserId = 0, string UserName = "كل المديونات ")
        {
            ViewBag.UserId = UserId;
            ViewBag.Sales = UserName;

            // to send the all of presentatives in custom view bag
            string userresponse = httphelp.Get("/api/Selector/GetUsers");
            ViewBag.presentatives = JsonConvert.DeserializeObject<Response<List<Select>>>(userresponse).Data;
            return View();
        }
  
        [FunctionFilter(key = "صفحة تقرير المتاخرات")]

        public ActionResult CustomerLaters(int UserId = 0, string UserName = "كل المتاخرات  ")
        {
            ViewBag.UserId = UserId;
            ViewBag.Sales = UserName;

            // to send the all of presentatives in custom view bag
            string userresponse = httphelp.Get("/api/Selector/GetUsers");
            ViewBag.presentatives = JsonConvert.DeserializeObject<Response<List<Select>>>(userresponse).Data;

            return View();
        }


        [HttpPost]
        public JsonResult GetDebits(int UserId)
        {
            return Json(new { data = get.GetCustomerDebits(UserId) });
        }
        [HttpPost]
        public JsonResult GetLaters(int UserId)
        {
            var data = get.GetCustomerDebits(UserId);
            data.Data = data.Data.Where(s => (DateTime.Now - s.TranDate).Days > 30).ToList();
            return Json(new { data = data });
        }
        [FunctionFilter(key = "امكانية زيارة مندوب لعميل غير مسجل له")]

        public ActionResult AddBranchException(string UserId, string UserName)
        {

            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;
            using (HttpClient client = new HttpClient())
            {
                string response = client.GetAsync(Setting.Host + "/api/Selector/GetRanges").Result.Content.ReadAsStringAsync().Result;
                try
                {
                    ViewBag.Ranges = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response).Data;
                }
                catch { }
            }
            return View();

        }






        //Ajaxs

        public ActionResult GetDistributerNameByUserId(string Id)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetDistributerNameByUserId?Id=" + Id).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<string> deContent = JsonConvert.DeserializeObject<Response<string>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetselesSummry(string Userid)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Report/GetselesSummry?Userid=" + Userid).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<SelectSales_Today_English_Pro> deContent = JsonConvert.DeserializeObject<Response<SelectSales_Today_English_Pro>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAllselesSummry(string Userid)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Report/GetAllselesSummry?Userid=" + Userid).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<SelectSales_Today_English_Pro> deContent = JsonConvert.DeserializeObject<Response<SelectSales_Today_English_Pro>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetUserCustomers(string UserId)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Sale/AllCusWithDeffered?UserID=" + UserId).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<AllCusWithDeffered>> deContent = JsonConvert.DeserializeObject<Response<List<AllCusWithDeffered>>>(content);

                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        }
        [NonAction]
        public string GetUserWithCustomers(string UserId, string CustomerId)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Report/GetselesSummryForSpecificCustomerForUser?Userid=" + UserId + "&CusID=" + CustomerId).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                return content;
            }
        }

        public ActionResult GetUserCustomerBills(string UserID, string CusID)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + $"/api/Report/Get_CustomerWithUsers_Statement?CusID={CusID}&UserID={UserID}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<SelectCustomer_Statement_Pro>> deContent = JsonConvert.DeserializeObject<Response<List<SelectCustomer_Statement_Pro>>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]

        public ActionResult GetRangeRegions(int Range)
        {

            using (HttpClient client = new HttpClient())
            {
                string response = client.GetAsync(Setting.Host + $"/api/Selector/GetRegions?Range={Range}").Result.Content.ReadAsStringAsync().Result;
                try
                {
                    return Json(JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response).Data);
                }
                catch
                {
                    return Json("");
                }
            }
        }
        [HttpPost]
        public ActionResult GetRegionBranches(int Region)
        {

            using (HttpClient client = new HttpClient())
            {
                string response = client.GetAsync(Setting.Host + $"/api/Selector/GetBranches?Region={Region}").Result.Content.ReadAsStringAsync().Result;
                try
                {
                    return Json(JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response).Data);
                }
                catch
                {
                    return Json("");
                }
            }
        }
        [HttpPost]
        public ActionResult SubmitAddExceptionBranch(int UserId, int BranchId)
        {

            using (HttpClient client = new HttpClient())
            {
                string response = client.GetAsync(Setting.Host + $"/api/DistributorV2/SubmitAddExceptionBranch?UserId={UserId}&BranchId={BranchId}").Result.Content.ReadAsStringAsync().Result;
                try
                {
                    return Json(JsonConvert.DeserializeObject<Response<string>>(response).Message);

                }
                catch
                {
                    return Json("");
                }
            }
        }

        public JsonResult SubmitAddAccount(int sales, decimal actualamount, decimal requiredamount, decimal actualpaymentpaperCount, decimal actualpaymentpaperamount, decimal actualcollectionpaperCount, decimal actualcollectionpaperamount, decimal requiredcollectionpaperCount, decimal requiredcollectionpaperamount, decimal requiredpaymentpaperCount, decimal requiredpaymentpaperamount)
        {
            int account = Cokie.UserGet().Id;
            using (HttpClient client = new HttpClient())
            {
                string paramaters = $"?sales={sales}&actualamount={actualamount}&requiredamount={requiredamount}&account={account}&actualpaymentpaperCount={actualpaymentpaperCount}&actualpaymentpaperamount={actualpaymentpaperamount}&actualcollectionpaperCount={actualcollectionpaperCount}&actualcollectionpaperamount={actualcollectionpaperamount}";
                paramaters += $"&requiredcollectionpaperCount={requiredcollectionpaperCount}&requiredcollectionpaperamount={requiredcollectionpaperamount}&requiredpaymentpaperCount={requiredpaymentpaperCount}&requiredpaymentpaperamount={requiredpaymentpaperamount}";
                string response = client.GetAsync(Setting.Host + $"/api/ClosingDay/OpenAccount" + paramaters).Result.Content.ReadAsStringAsync().Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response);

                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult confirmreceivemoney(int sales)
        {

            using (HttpClient client = new HttpClient())
            {
                string response = client.GetAsync(Setting.Host + $"/api/ClosingDay/ConfirmCompleteAccount?sales={sales}&type=1").Result.Content.ReadAsStringAsync().Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response);



                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult submitcloseDay(int sales)
        {

            using (HttpClient client = new HttpClient())
            {
                string response = client.GetAsync(Setting.Host + $"/api/ClosingDay/CloseSalesDay?sales={sales}").Result.Content.ReadAsStringAsync().Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response);

                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteMasrof(int Id)
        {
            return Json(httphelp.Get<Response<string>>($"/api/Procedures/DeleteExpense?Id={Id}"));
        }
        [HttpPost]
        public JsonResult DeleteCollection(int Id)
        {
            return Json(httphelp.Get<Response<string>>($"/api/Procedures/DeleteCollection?Id={Id}"));
        }
    }
}