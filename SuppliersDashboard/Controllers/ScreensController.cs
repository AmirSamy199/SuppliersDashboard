using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Services;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace SuppliersDashboard.Controllers
{
    [MyAuthFilter]
    public class ScreensController : BaseController
    {
        private HttpClientHelper http = new HttpClientHelper();
        // GET: Screens
        public ActionResult Index()
        {
            return View();
        }
        #region Deliver Store 
      
        [FunctionFilter(key = "صفحة تسليم المخزن")]

        public ActionResult DeliverStore()
        {
            
            var Us = Cokie.UserGet();
            Response<List<CloseStoreDay>> model = JsonConvert.DeserializeObject<Response<List<CloseStoreDay>>>(http.Get($"/api/Procedures/CheckStoreStateToBeDeliveredAndCloseDay?StoreKeeperId={Us.Id}"));
            ViewBag.State = model.State;
            ViewBag.Message = model.Message;
            if (model.State != 0)
            {
                ViewBag.StoreItems = model.Data;
            }
            return View();
        }
        [HttpPost]
        public JsonResult CloseStoreKeeperDay()
        {
            var Us = Cokie.UserGet();
            string response = http.Get($"/api/Procedures/CloseStoreKeeperDay?StoreKeeperId={Us.Id}");
            Response<string> model = JsonConvert.DeserializeObject<Response<string>>(response);
            return Json(new { data = model });

        }
        [HttpPost]
        public JsonResult ConfirmDeliverandReceiveStore(string type)
        {
            var US = Cokie.UserGet();
            //   string response = http.Get($"/api/Procedures/ConfirmCloseStoreWardia?Storekeeper={US.Id}&Type={type}");
            string response = new Response<string> { data = "res", State = 1 ,Message="hoooooo"}.ToString();
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(response) });
        }
        [HttpPost]
        public JsonResult SubmitChangeActualQuantity(int ID, decimal Value)
        {
            var US = Cokie.UserGet();
            string response = http.Get($"/api/Procedures/UpdateCloseWareHouseActualQuantity?ID={ID}&NewValue={Value}");
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(response) });
        }
        #endregion
        #region sale screen
        [FunctionFilter(key = "صفحة البيع")]

        public ActionResult Sale()
        {
            ViewBag.PageMsg = "شاشة البيع ";
            string companiesresponse = http.Get("/api/Company/GetCompaniesToFillSelect");
            ViewBag.Companies = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(companiesresponse).Data;
            return View();
        }
        [HttpPost]
        public JsonResult GetBranches(int ComID)
        {
            string branchresponse = http.Get($"/api/Company/GetCompanyBranches?ComID={ComID}");
            Response<List<SelectBranch>> model = JsonConvert.DeserializeObject<Response<List<SelectBranch>>>(branchresponse);
            return Json(new { data = model.Data });
        }
        [HttpPost]
        public JsonResult Getitems()
        {
            string branchresponse = http.Get($"/api/Company/AvailableWareHouseItems?FromWeb=1");
            Response<List<main_warehouse_items_availablilty_V>> model = JsonConvert.DeserializeObject<Response<List<main_warehouse_items_availablilty_V>>>(branchresponse);

            return Json(new { data = model.Data });
        }
        [HttpPost]
        public JsonResult SetPill(string bill)
        {
            var Userr = Cokie.UserGet();
            using (HttpClient htp = new HttpClient())
            {
                Billdetails model = JsonConvert.DeserializeObject<Billdetails>(bill);
                model.Editor = Userr.Id.ToString();
                model.Sales_ID = Userr.Id.ToString();
                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string response = htp.PostAsync(Setting.Host + "/api/Sale/setpill?FromWeb=1", body).Result.Content.ReadAsStringAsync().Result;
                Response<string> model2 = JsonConvert.DeserializeObject<Response<string>>(response);
                return Json(new { data = response, hashbillno = Convert.ToBase64String(Encoding.UTF8.GetBytes(model2.Message)) });
            }

        }

        #endregion
        #region buy screen
        [FunctionFilter(key = "صفحة المشتريات")]

        public ActionResult Buy()
        {
            ViewBag.UserId = Cokie.UserGet().Id;

            ViewBag.PageMsg = "شاشة الشراء    ";

            string suppliersselect = http.Get("/api/Suppliers/GetSuppliers");
            dynamic supplierlist = JsonConvert.DeserializeObject<object>(suppliersselect);
            ViewBag.Suppliers = supplierlist.data;
            return View();
        }
        public ActionResult PrintBuyBill(int RequestId)
        {

            string response = http.Get($"/api/Company/GetBuyBillDataByRequestNo?RequestId={RequestId}");
            Response<List<printBuyBill>> result = JsonConvert.DeserializeObject<Response<List<printBuyBill>>>(response);
            ViewBag.RequestId = RequestId;
            ViewBag.Items = result.Data;
            ViewBag.Supplier = result.Data.FirstOrDefault().CompanyName;
            ViewBag.History = result.Data.LastOrDefault()._Edit_date;
            ViewBag.Total = result.Data.Sum(s => s.TotalPrice);
            return View();
        }
        [HttpPost]
        public JsonResult GetCategories(int SupId)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Company/GetCategoriesItemsToSupplier?SupId={SupId}").Result;
                Response<List<SimpleClass>> res = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }

        }
        [HttpPost]
        public JsonResult GetMoshtrayat()
        {

            string response = http.Get("/api/WareHousing/GetPendingMoshtrayat");

            Response<List<warehouse_Requst_V>> res = JsonConvert.DeserializeObject<Response<List<warehouse_Requst_V>>>(response);

            return Json(res.Data);
        }
        [HttpPost]
        public JsonResult GetAllItems(int SupId = -1, int CatId = -1)
        {
            string response = http.Get($"/api/Items/GetAllItems?SupId={SupId}&CatId={CatId}");
            Response<List<AssignItems_V>> res = JsonConvert.DeserializeObject<Response<List<AssignItems_V>>>(response);
            return Json(new { data = res });

        }
        #endregion

        #region masrofat screen
        [FunctionFilter(key = "صفحة المصروفات")]

        public ActionResult Masrofat()
        {
            string usersresponse = http.Get("/api/Selector/GetUsers");
            string expensestyperesponse = http.Get("/api/Selector/GetExpensesTypes");
            ViewBag.Users = JsonConvert.DeserializeObject<Response<List<Select>>>(usersresponse).Data;
            ViewBag.expensesTypes = JsonConvert.DeserializeObject<Response<List<Select>>>(expensestyperesponse).Data;

            return View();
        }
        [HttpPost]
        public JsonResult AddnewMasrofType(string Name)
        {
            string x = http.Get($"/api/Expenses/AddNewExpensesType?Name={Name.Replace(" ", "_")}");
            return Json("");
        }
        [HttpPost]
        public JsonResult Addmasrof(SetExpenses model)
        {
            //  SetExpenses model = new SetExpenses() { }
            var User = Cokie.UserGet();
            model.Editor = User.Id;
            StringContent requestbody = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (HttpClient htp = new HttpClient())
            {
                string res = htp.PostAsync(Setting.Host + "/api/Expenses/AddExpenses", requestbody).Result.Content.ReadAsStringAsync().Result;
                Response<dynamic> respo = JsonConvert.DeserializeObject<Response<dynamic>>(res);
                decimal totalamount = (decimal)respo.data[0].Amount;
                return Json(new { msg = respo.Message, amount = totalamount });
            }
        }

        #endregion
        #region add range and region region 
 
        [FunctionFilter(key = "صفحة اضافة منطقة او حي")]
        public ActionResult AddRange()
        {
            string response2 = http.Get("/api/Selector/GetRanges");
            ViewBag.Ranges = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response2).Data;
            return View();
        }
        [HttpPost]
        public JsonResult SubmitAddRange(string Name)
        {
            var user = Cokie.UserGet();
            string content = http.Get($"/api/Selector/AddRangeOregion?Name={Name}&UserID={user.Id}&type=Range");
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(content) });
        }

        [HttpPost]
        public JsonResult SubmitAddRegion(string Name, int RangeId)
        {
            var user = Cokie.UserGet();
            string content = http.Get($"/api/Selector/AddRangeOregion?Name={Name}&RangeId={RangeId}&UserID={user.Id}&type=Region");
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(content) });
        }
        #endregion

        #region returns screen
        public ActionResult CreateMortg3at()
        {
            ViewBag.PageMsg = "شاشة المرتجعات ";
            return View();
        }

        #endregion

        #region collection 
       
        [FunctionFilter(key = "صفحة التحصيل")]

        public ActionResult Collection()
        {
            string response2 = http.Get("/api/Customer/Get_AllDebts?Distributor_ID=0");
            ViewBag.Debits = JsonConvert.DeserializeObject<Response<List<SelectAllcustomersOpeningBalance_Pro>>>(response2).data;
            return View();
        }
        public ActionResult Collect(int BranchId, string Name, decimal Amount)
        {

            ViewBag.Name = Name;
            ViewBag.Amount = Amount;
            ViewBag.BranchId = BranchId;


            return PartialView("_Collect");
        }
        [HttpPost]
        public JsonResult SubmitCollection(NewCollection collection) {
            var User = Cokie.UserGet();
            collection.UserID = User.Id.ToString();

            var requestbody = new StringContent(JsonConvert.SerializeObject(collection), Encoding.UTF8, "application/json");
            using (HttpClient htp = new HttpClient())
            {
                string res = htp.SetHeader().PostAsync(Setting.Host + "/api/Customer/AddCollection", requestbody).Result.Content.ReadAsStringAsync().Result;
                Response<string> respo = JsonConvert.DeserializeObject<Response<string>>(res);
                return Json(new { data = respo.State });
            }

        }
        #endregion
        #region CheckEdit 
        [FunctionFilter(key = "صفحة تعديل الشيكات")]

        public ActionResult EditChecks()
        {
            var checks = (new NewReportService()).MoneyPaperReport(0, "1900-01-01", "3000-01-01").Data;
            checks.Reverse();
            ViewBag.Checks = checks.Take(100).ToList();

            return View();
        }

        public JsonResult SubmitEditCheck(int TranId, decimal Amount)
        {
            string EndPoint = $"/api/Accounting/EditCheck?CollectId={TranId}&Amount={Amount}";
            string result = http.Get(EndPoint);
            var data = JsonConvert.DeserializeObject<Response<string>>(result);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Settle Distributor Account
        [FunctionFilter(key = "صفحة تصفية حساب اليوم")]

        public ActionResult SettleAccount()
        {
            var Us = Cokie.UserGet();
            string url = $"/api/ClosingDay/GetCloseSalesDayDatafForUser?sales={Us.Id}";
            var result = JsonConvert.DeserializeObject<dynamic>(http.Get(url));
            ViewBag.Account = result;
            return View();
        }
        public JsonResult SubmitCloseAccount ()
        {
            var Us = Cokie.UserGet(); 
            string EndPoint = $"/api/ClosingDay/ConfirmCompleteAccount?sales={Us.Id}&type=2";
            string result = http.Get(EndPoint);
            var data = JsonConvert.DeserializeObject<Response<string>>(result);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}