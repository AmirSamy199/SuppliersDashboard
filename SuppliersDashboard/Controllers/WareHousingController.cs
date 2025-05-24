
using FastReport.Utils;
using Newtonsoft.Json;
using SuppliersDashboard.BL;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Items_Tbl = SuppliersDashboard.Models.Items_Tbl;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class WareHousingController : BaseController
    {
        // GET: WareHousing
        private Getter get = new Getter();
        private WarehouseService _wareService = new WarehouseService();
        private HttpClientHelper httphelp = new HttpClientHelper();
        public ActionResult Index()
        {
            return View();
        }

        [FunctionFilter(key = "صفحة تسليم بضاعة للمناديب")]

        public ActionResult PendingWareHouseRequests()
        {
            var Us = Cokie.UserGet();
            ViewBag.userName = Us.UserName;
            ViewBag.PageMsg = SuppliersDashboard.Resources.pages.saleswarehouserequestpagedescription;
            using (HttpClient http = new HttpClient())
            {
                var response1 = http.SetHeader().GetAsync(Setting.Host + "/api/Warehousing/GetSaleshavependinRequests").Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(response1.Content.ReadAsStringAsync().Result);

                ViewBag.Sales = new SelectList(deContent.Data, "Id", "Value");
                ViewBag.SalesCount = deContent.Data.Count;
            }


            return View();
        }
    

        [FunctionFilter(key = "صفحة المردودات")]

        public ActionResult PendingMardodatWareHouseRequests()
        {
            var Us = Cokie.UserGet();
            ViewBag.userName = Us.UserName;
            ViewBag.PageMsg = "هذه الصفحة لاستردادا المردودات من البائعين ";
            using (HttpClient http = new HttpClient())
            {
                var response1 = http.SetHeader().GetAsync(Setting.Host + "/api/Warehousing/GetSaleshavependinMardodatRequests").Result;
                Response<List<SimpleClass>> deContent = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response1.Content.ReadAsStringAsync().Result);
                List<SimpleClass> sales = new List<SimpleClass>();

                foreach (var item in deContent.Data.ToList())
                {
                    if (!sales.Any(im => im.Id == item.Id))
                    {
                        sales.Add(item);
                    }
                }

                ViewBag.Sales = new SelectList(sales, "Id", "Value");
                ViewBag.SalesCount = sales.Count;

            }


            return View();
        }

        [FunctionFilter(key = "w-store")]

        public ActionResult PendingMotg3atWareHouseRequests()
        {
            var Us = Cokie.UserGet();
            ViewBag.userName = Us.UserName;
            ViewBag.PageMsg = "هذه الصفحة لاستردادا المرتجعات من البائعين ";
            using (HttpClient http = new HttpClient())
            {
                var response1 = http.SetHeader().GetAsync(Setting.Host + "/api/Warehousing/GetSaleshavependinMardodatRequests").Result;
                Response<List<SimpleClass>> deContent = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response1.Content.ReadAsStringAsync().Result);
                List<SimpleClass> sales = new List<SimpleClass>();

                foreach (var item in deContent.Data.ToList())
                {
                    if (!sales.Any(im => im.Id == item.Id))
                    {
                        sales.Add(item);
                    }
                }

                ViewBag.Sales = new SelectList(sales, "Id", "Value");
                ViewBag.SalesCount = sales.Count;

            }

            return View();
        }

        [HttpPost]
        public JsonResult DeleteAllSalesMardodatMortg3atRequests(int SalesId)
        {
            var url = $"/api/Warehousing/DeleteAllMOrtg3atMardodatRequest?SalesId={SalesId}";
            var result = httphelp.Get<Response<string>>(url);
            return Json(result);
        }

        [FunctionFilter(key = "w-purchases")]

        public ActionResult PendingMoshtrayatWareHouseRequests()
        {
            ViewBag.PageMsg = "هذه الصفحة لمراجعة المشتريات قبل دخولها المخزن  ";
            return View(GetPendingWareHouseMoshtrayat());
        }


  
        [FunctionFilter(key = "صفحة جرد المخزن")]

        public ActionResult StoreGard()
        {
            string content = httphelp.Get("/api/Procedures/FromTowarehouse_main_pro");
            var models = JsonConvert.DeserializeObject<Response<List<warehouse_main_V>>>(content);
            ViewBag.msg = models.Message;
            return View(models.Data);
        }
        [HttpPost]
        public JsonResult StoreGardBYTime(string datefrom, string dateto)
        {
            string content = httphelp.Get($"/api/Procedures/FromTowarehouse_main_pro?datefrom={datefrom}&dateto={dateto}");
            var models = JsonConvert.DeserializeObject<Response<List<warehouse_main_V>>>(content);

            return Json(new { data = models.Data, msg = models.Message });
        }


        #region SettleReturns

        [FunctionFilter(key ="صفحة تسوية المرتجعات")]
        public ActionResult SettleReturns()
        { 
            return View();
        }
        [HttpPost]
        public JsonResult LoadPage()
        {
            var url = $"/api/WarehouseReturnBalance";
            var res = httphelp.Get<Response<List<MainWarehouseReturnBalance_V>>>(url);
            return Json(res);
        }

        [HttpPost]
        public ActionResult SettlePartial(int ItemId , decimal Size ,  int debitWarehouseId)
        {
            ViewBag.ItemId = ItemId;
            ViewBag.Size = Size;
            ViewBag.debitWarehouseId = debitWarehouseId;
            var items = httphelp.Get<List<Items_Tbl>>($"/api/GetItemCatogoriesByItemId?ItemId={ItemId}").Where(x=>x.Record_ID == ItemId).ToList();
            ViewBag.CategoryItems = items;
            ViewBag.ItemName = items.FirstOrDefault(x => x.Record_ID == ItemId).ItemName;
            var wars = httphelp.Get<Response<List<Select>>>($"/api/Selector/GetWareHouses");
            ViewBag.Warehouse = wars;
            var settleType = new List<Select>()
            {
                new Select(){Id = 0 , Value = "اختر نوع التسوية"},
                new Select(){Id = 1 , Value = "أهلاك"},
                new Select(){Id = 2 , Value = "أعادة تصنيع"},
                new Select(){Id = 3 , Value = "أعادة بيع"}

            };
            ViewBag.SettlmentTypes = settleType;
            return PartialView("_SettlePartial");
        }
        [HttpPost]
        public JsonResult submitsettelment(SettlementVM model )
        {
            var url = $"/api/SubmitSettleItemToWarehouse";
            var res = httphelp.Post<Response<string>, SettlementVM>(url, model);

            return Json(res.Message);
        }
        #endregion



        /// جرد المخازن لللادمن 
        [FunctionFilter(key ="صفحة جرد المخازن")]
        public ActionResult AnyWarehouseBalance()
        {
            var StoreTypes= new List<Select>() { 
            new Select(){Id = 0 , Value = "مخزن الريتيل"},
            new Select(){Id = 1 , Value = "مخزن مندوب"},
            new Select(){Id = 2 , Value = "مخزن بضاعة"}
            };
            ViewBag.StoreTypes = StoreTypes;
            var warehousesList = httphelp.Get<Response<List<Select>>>("/api/Selector/GetWareHouses").Data;
            ViewBag.WarehousesList = warehousesList;

            var usersList = httphelp.Get<Response<List<Select>>>("/api/Selector/AllGetDistributorUsers").Data;
            ViewBag.DistributorMan = usersList;


            return View();
        }
        [HttpPost]
        public JsonResult AnyWarehouseBalanceJson(int WarehouseId , int StoreTypeId)
        {
            var url = $"/api/AnyWarehouseBalance?WarehouseId={WarehouseId}&TypeId={StoreTypeId}";
            var response = httphelp.Get<Response<List<warehouse_Base_v>>>(url);
            return Json(response);
        }

        /// Ajaxs 
        /// 
        [HttpPost]
        public JsonResult GetPendingWareHouseRequests(int sales = -1, int mardod = 0)
        {
            using (HttpClient http = new HttpClient())
            {

                string req = "/api/WareHousing/GetPendingRequests";
                if (sales != -1)
                    req += $"?sales={sales}";
                if (mardod == 1)
                    req += $"&mardod=1";

                var response = http.SetHeader().GetAsync(Setting.Host + req).Result;
                Response<List<warehouse_Requst_V>> res = JsonConvert.DeserializeObject<Response<List<warehouse_Requst_V>>>(response.Content.ReadAsStringAsync().Result);

                return Json(new { data = res, msg = res.Message2 });
            }


        }
        [HttpPost]
        public JsonResult GetPendingWareHouseMortga3at(int sales = -1)
        {
            using (HttpClient http = new HttpClient())
            {

                string req = "/api/WareHousing/getPendingMortaga3at";
                req += $"?sales={sales}";

                var response = http.GetAsync(Setting.Host + req).Result;
                Response<List<Mortaga3>> res = JsonConvert.DeserializeObject<Response<List<Mortaga3>>>(response.Content.ReadAsStringAsync().Result);

                return Json(new { data = res });
            }

        }

        private List<warehouse_Requst_V> GetPendingWareHouseMoshtrayat()
        {
            using (HttpClient http = new HttpClient())
            {
                try
                {

                    string req = "/api/WareHousing/GetPendingMoshtrayat";

                    var response = http.SetHeader().GetAsync(Setting.Host + req).Result;
                    Response<List<warehouse_Requst_V>> res = JsonConvert.DeserializeObject<Response<List<warehouse_Requst_V>>>(response.Content.ReadAsStringAsync().Result);
                    // res.Data = res.Data.Select(s => { s._Edit_date = s.Edi + ; return s; }).ToList();
                    return res.Data;
                }
                catch
                {
                    return new List<warehouse_Requst_V>();
                }

            }

        }
        [HttpPost]
        public JsonResult ConfirmReq(int ID)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + "/api/WareHousing/ConfirmStoreKeeperReq?ID=" + ID + $"&storekeeper={Cokie.UserGet().Id}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                // res.Data = res.Data.Select(r => r._Edit_date = r.Edit_date?.ToString("yyyy-MM-dd hh:mm tt "); return ;
                return Json(new { data = res });
            }
        }



        [HttpPost]
        public JsonResult ReturnAsMardod(int ItemId, int UserId, decimal ReturnCount)
        {
            HttpClientHelper htp = new HttpClientHelper();
            var response = htp.Get<Response<string>>($"/api/ReturnAsMardod?ItemId={ItemId}&UserId={UserId}&ReturnCount={ReturnCount}");
            return Json(response);
        }

        [HttpPost]
        public JsonResult DeleteAllWareRequest(int ID)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + $"/api/Operation/DeleteAllDistributorRequest?UserID={ID}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);

                return Json(new { data = res });
            }
        }
        [HttpPost]
        public JsonResult DeleteRequest(int ID)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + $"/api/Warehousing/DeleteRequest?ID={ID}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                // res.Data = res.Data.Select(r => r._Edit_date = r.Edit_date?.ToString("yyyy-MM-dd hh:mm tt "); return ;
                return Json(new { data = res });
            }
        }

        [HttpPost]
        public ActionResult DeleteRequestMaterials(int ID)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + $"/api/Warehousing/DeleteRequestMaterials?ID={ID}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                // res.Data = res.Data.Select(r => r._Edit_date = r.Edit_date?.ToString("yyyy-MM-dd hh:mm tt "); return ;
                return Json(new { data = res });
            }
        }
        [HttpPost]
        public JsonResult ConfirmMoshtrayat()
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + "/api/Warehousing/ConfirmMoshtrayatRequest?Usertype=2").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }


        [HttpPost]
        public JsonResult ConfirmBuyMaterials()
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + "/api/Warehousing/ConfirmBuyMaterials").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }
        [HttpPost]
        public JsonResult ConfirmMardodReq(int ID)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + "/api/WareHousing/ConfirmStoreKeeperReq?ID=" + ID + "&mortaga3=0" + $"&storekeeper={Cokie.UserGet().Id}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                // res.Data = res.Data.Select(r => r._Edit_date = r.Edit_date?.ToString("yyyy-MM-dd hh:mm tt "); return ;
                return Json(new { data = res });
            }
        }
        [HttpPost]
        public JsonResult ConfirmMotaga3Req(int ID)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + $"/api/WareHousing/ConfirmStoreKeeperReq?ID={ID}&mortaga3=1" + $"&storekeeper={Cokie.UserGet().Id}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }
        [HttpPost]
        public JsonResult SubmitChange(int ID, decimal value)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + "/api/WareHousing/SubmitChangeQuantity?ID=" + ID + "&value=" + value).Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }

        [HttpPost]
        public JsonResult SubmitChangeMotaga3values(int ID, decimal value, decimal amount)
        {
            using (HttpClient http = new HttpClient())
            {

                var response = http.SetHeader().GetAsync(Setting.Host + $"/api/Warehousing/SubmitChangeMortaga3Quantity?value={value}&ID={ID}&amount={amount}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }

        /// <summary>
        /// / المخازن
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [FunctionFilter(key = "اعدادات المخازن")]

        public ActionResult WareHousesSetting()
        {
            ViewBag.Users = httphelp.Get<Response<List<Select>>>("/api/Selector/GetDashboardUsers");
            ViewBag.WareHouses = _wareService.AllWarehouses();
            return View();
        }
        [FunctionFilter(key ="صفحة تحويل بضاعة من مخزن لمخزن")]
        public ActionResult TranfereItemsBetweenTwoWareHouses()
        {

            var User = Cokie.UserGet();
            ViewBag.StoreName = User.StoreName;
            ViewBag.MyWarehouseId = User.StoreId;
            //   var mykeeperbalances = httphelp.Get<Response<List<warehouse_Base_v>>>($"/api/WareHousBalance?WarehouseId={User.StoreId}");

            var myrequests = httphelp.Get<Response<transferitems2balancesrequests>>("/api/MyWareHousTransfereRequests");

            List<requestwithheader> ArrangedSenders = new List<requestwithheader>();
            List<requestwithheader> ArrangedReceives = new List<requestwithheader>();
            if (myrequests.Data.Sender != null && myrequests.Data.Sender.Count > 0)
            {
                foreach (var s in myrequests.Data.Sender)
                {
                    var oldone = ArrangedSenders.FirstOrDefault(x => x.StoreId == s.WareHouse_ID);
                    if (oldone == null)
                    {
                        ArrangedSenders.Add(new requestwithheader(s.WareHouse_ID, s.WareHouse_Name, s));

                    }
                    else
                    {
                        oldone.requests.Add(s);
                    }
                }
            }

            if (myrequests.Data.Receiver != null && myrequests.Data.Receiver.Count > 0)
            {
                foreach (var xx in myrequests.Data.Receiver)
                {
                    var oldone = ArrangedReceives.FirstOrDefault(x => x.StoreId == xx.WareHouse_ID);
                    if (oldone == null)
                    {
                        ArrangedReceives.Add(new requestwithheader(xx.WareHouse_ID, xx.WareHouse_Name, xx));

                    }
                    else
                    {
                        oldone.requests.Add(xx);
                    }
                }
            }

            ViewBag.SendersRequests = ArrangedSenders;
            ViewBag.ReceivedRequests = ArrangedReceives;
            // return View(mykeeperbalances);
            return View();
        }
        public ActionResult AddWarehouseRequest()
        {
            var User = Cokie.UserGet();
            var mywarehouse = Cokie.UserGet().StoreId;
            ViewBag.MyWarehouseId = mywarehouse;
            var allwares = _wareService.AllWarehouses();
            var myware = allwares.FirstOrDefault(x => x.Id == mywarehouse);
            if (myware != null)
            {
                allwares.Remove(myware);
            }
            ViewBag.WareHouses = allwares;

            return View();
        }
        [HttpPost]
        public JsonResult AddWarehouse(string Name)
        {

            return Json(httphelp.Get<Response<string>>($"/api/Warehouse/Add?Name={Name}"));
        }
        [HttpPost]
        public JsonResult WarehouseBalance(int WarehouseId)
        {
            var result = httphelp.Get<Response<List<warehouse_Base_v>>>($"/api/WareHousBalance?WarehouseId={WarehouseId}");
            return Json(result);
        }
        [HttpPost]

        public JsonResult DeleteWarehouse(int Id)
        {
            return Json(httphelp.Get<Response<string>>($"/api/Warehouse/Delete?Id={Id}"));
        }
        [HttpPost]
        public JsonResult ShowKeepers(int Id)
        {
            return Json(httphelp.Get<Response<List<Select>>>($"/api/Warehouse/keepers?Id={Id}"));
        }

        [HttpPost]
        public JsonResult AddRemoveKeeper(int userId, int storeId, string state)
        {
            var url = $"/api/Warehouse/AddRemoveKeeper?userId={userId}&storeId={storeId}&state={state}";
            return Json(httphelp.Get<Response<string>>(url));
        }

        [HttpPost]
        public JsonResult SubmitAddRequests(int From, int To, List<warehouse_Requst_Tbl> models)
        {
            User User = Cokie.UserGet();
            var url = $"/api/WareHouseTransfereAddRequest?FromWareHouseId={From}&ToWareHouseId={To}&Userid={User.Id}";
            var result = httphelp.Post<Response<string>, List<warehouse_Requst_Tbl>>(url, models);
            return Json(result);
        }
        [HttpPost]
        public JsonResult AcceptWareRequest(int WareId, string type)
        {
            // /Warehousing/AcceptWareRequest?WareId=${}&type=${}
            var url = $"/api/WareHouseTransfereAcceptRequests?WarehouseId={WareId}&FromTo={type}";
            return Json(httphelp.Get<Response<string>>(url));

        }
          [HttpPost]
        public JsonResult RejectWareRequest(int WareId, string type)
        {
            // /Warehousing/AcceptWareRequest?WareId=${}&type=${}
            var url = $"/api/WareHouseTransfereRejectRequests?WarehouseId={WareId}&FromTo={type}";
            return Json(httphelp.Get<Response<string>>(url));

        }


        [HttpPost]
        public JsonResult EditDeleteWareRequest(int FromWareHouseId, int ToWareHouseId, string TypeId, int ItemId = 0, int All = 0, decimal NewQuantity = 0)
        {
            // var url = $"/Warehousing/EditDeleteWareRequest?FromWareHouseId={FromWareHouseId}&ToWareHouseId={ToWareHouseId}&TypeId={TypeId}&ItemId={ItemId}&All={All}&NewQuantity={NewQuantity}";
            var url = $"/api/WareHouseTransfereRemoveItemOrAll?FromWareHouseId={FromWareHouseId}&ToWareHouseId={ToWareHouseId}&TypeId={TypeId}&ItemId={ItemId}&All={All}&NewQuantity={NewQuantity}";
            return Json(httphelp.Get<Response<string>>(url));
        }

        // @*مخزن المواد الخام*@
        //  @*طلب بضاعه من مخزن المواد الخام*@ 

        //public ActionResult RequestMaterials()
        //{
        //    Response<List<SimpleClass>> res;
        //    using (HttpClient http = new HttpClient())
        //    {
        //        var response = http.GetAsync(Setting.Host + $"/api/Company/GetCategoriesItemsToSupplier?SupId={0}&TypeSuppliers=1").Result;
        //         res = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response.Content.ReadAsStringAsync().Result);
              
        //    }
        //    return View(res.Data);
        //}
        //  @* مراجعة الطلبات المواد الخام*@
        public ActionResult PenddingRequestsMaterials()
        {
            Response<List<RequestMaterials>> res;
            User User = Cokie.UserGet();
            using (HttpClient http = new HttpClient())
            {
              ///  keepers? Id = { 25 } id =مخزن المواد الخام
                var response = http.GetAsync(Setting.Host + $"/api/Warehouse/GetAllPenddingMaterialsRequests").Result;
                res = JsonConvert.DeserializeObject<Response<List<RequestMaterials>>>(response.Content.ReadAsStringAsync().Result);
                var Keepers = httphelp.Get<Response<List<Select>>>($"/api/Warehouse/keepers?Id={25}");
                if (!Keepers.Data.Any(x => x.Id == User.Id))
                {
                    res.Data = new List<RequestMaterials>();
                }
                
            }

            return View(res.Data);
        }

        
             [HttpPost]
        public ActionResult ConfirmRequestMaterials(int Requestid, int ConfirmStatus)
        {
            User user = Cokie.UserGet();
            string res = httphelp.Get($"/api/Warehouse/ConfirmRequestMaterials?Requestid={Requestid}&ConfirmStatus={ConfirmStatus}&KeeperId={user.Id}");
            var re = JsonConvert.DeserializeObject<Response<string>>(res);
            return Json(new { data = res });
        }


        
        
        //    @*  رصيد المواد الخام*@
        public ActionResult MaterialsStore()
        {
           
            var res = httphelp.Get($"/api/Warehouse/GetAllAvaialbleMaterials");
            var re = JsonConvert.DeserializeObject<Response<List<StoreMaterialsDto>>>(res);
          
            return View(re.Data);
        }

    }
}