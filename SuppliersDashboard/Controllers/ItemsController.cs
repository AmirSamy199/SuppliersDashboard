using IronSoftware.Drawing;
using Newtonsoft.Json;
using RestSharp;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
using Items_Tbl = SuppliersDashboard.ViewModels.Items_Tbl;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class ItemsController : BaseController
    {
        Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
        // For Test Signlr
        public ActionResult TestSend()
        {
            return View();
        }
        
        
        
        // GET: Items
        public ActionResult Index()
        {
            ViewBag.PageMsg = "هذة الصفحة لعرض المنتجات واجراء تقارير ";
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetSuppliers").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(content);

                if (deContent.State == 200)
                {
                    ViewBag.Suppliers = deContent.data;
                }
            }
            return View();
        }
        [FunctionFilter(key = "صفحة اضافة او وقف صنف")]
        public ActionResult ItemSetting ()
        {
            ViewBag.PageMsg = "هذة الصفحة لاضافة او وقف او تعديل  صنف   ";
            using (HttpClient c = new HttpClient())
            {

                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetSuppliers").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(content);

                if (deContent.State == 200)
                {
                    ViewBag.Suppliers = deContent.data;
                }
               

            }

            return View()
;        }
        [FunctionFilter(key = "صفحة تعديل الاسعار")]

        public ActionResult AddItemPrice()
        {
            ViewBag.PageMsg = "هذة الصفحة لاضافة السعر للمنتجات   ";
            using (HttpClient c = new HttpClient())
            {
                
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetSuppliers").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(content);

                if (deContent.State == 200)
                {
                    ViewBag.Suppliers = deContent.data;
                }
            }

            return View()
;
        }

        [FunctionFilter(key = "صفحة تعديل الاسعار الخاصة")]

        public ActionResult Specialprice()
        {
            string response = HTTP.Get("/api/Company/GetCompaniesToFillSelect");

            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);
             ViewBag.Companies = deContent.Data;
            var response2 = HTTP.Get($"/api/Items/GetAllItemsFromTable");
            Response<List<Items_Tbl>> res = JsonConvert.DeserializeObject<Response<List<Items_Tbl>>>(response2);
            ViewBag.Items = res.Data;

            var specials = HTTP.Get($"/api/Items/GetAvailableSpecialPrices");
            var data = JsonConvert.DeserializeObject<Response<List<Special_Price_VV>>>(specials).Data;
            return View(data);
        }
        [HttpPost]
        public JsonResult CancelSpecialPrice(int Id)
        {
            var response2 = HTTP.Get<dynamic>($"/api/Items/DisableSpecialPrice?Id={Id}");
            string msg = response2.Message;
            return Json(new {data = msg });
        }
        #region Ajax Calls
        //--- Ajaxs ---- 
        [HttpPost]
        public JsonResult AddnewCategory(int supplier , string name)
        {
            var User = Cokie.UserGet(); 
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Company/AddNewCategory?Name={name}&SupplierId={supplier}&Editor={User.UserName}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }

        }     
        [HttpPost]
        public JsonResult GetAllItems(int SupId = -1, int CatId = -1 , string ToBuyPage = "NO")
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Items/GetAllItems?SupId={SupId}&CatId={CatId}&ToBuyPage={ToBuyPage}").Result;
                Response<List<AssignItems_V>> res = JsonConvert.DeserializeObject<Response<List<AssignItems_V>>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }

        }     
        [HttpPost]
        public JsonResult GetAllItemsFromTable(int SupId = -1, int CatId = -1)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Items/GetAllItemsFromTable?SupId={SupId}&CatId={CatId}").Result;
                Response<List<Items_Tbl>> res = JsonConvert.DeserializeObject<Response<List<Items_Tbl>>>(response.Content.ReadAsStringAsync().Result);
              //  res.Data = res.Data.Select(s => s._Date = s.Date?.ToString("yyyy-MM-dd")).ToList() ;
                return Json(new { data = res });
            }

        }
        [HttpPost]
        public JsonResult SetSpecialPrice(string Item_Selling_Price , string Item_ID , string Cus_id,string fromDate , string toDate , bool isAll , int comid )
        {
            var User = Cokie.UserGet();
            UpdateSellingPrice model = new UpdateSellingPrice { isAll = isAll , comid = comid , Cus_id = Cus_id ,Item_ID=Item_ID , Item_Selling_Price = Item_Selling_Price , User_Id = User.Id.ToString()  , fromDate = fromDate , toDate = toDate};
            StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (HttpClient htp = new HttpClient())
            {
                string response = htp.PostAsync(Setting.Host + "/api/Items/SetSpecialItemPrice", body).Result.Content.ReadAsStringAsync().Result;
                Response<string> result = JsonConvert.DeserializeObject<Response<string>>(response);
                return Json(new { data = result });


            }

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
        public JsonResult ActiveORDeactiveb(int id , int type , int disGroupId)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Items/ActiveORDeactive?id={id}&type={type}&disGroupId={disGroupId}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        } 
        [HttpPost]
        public JsonResult SubmitChangeItemPrice(int id , int dis , decimal suppliervalue, decimal sellvalue)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Items/SubmitChangeItemPrice?id={id}&dis={dis}&suppliervalue={suppliervalue}&sellvalue={sellvalue}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }
            [HttpPost]
        public JsonResult SubmitEditItem(int id , string description, string name, string barcode,decimal size)
        {
            Items_Tbl model = new Items_Tbl
            {
                Record_ID = id,
                ItemName = name,
                Barcode = barcode,
                Description = description,
                size= size
            };
            using (HttpClient http = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + $"/api/Items/EditItemByRecordId" , body).Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }


        [HttpPost]
        public JsonResult SubmitEditItemStatus(int id, int Status)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + $"/api/Items/EditItemStatus?Id={id}&Staus={Status}").Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }

        [HttpGet]
        public ActionResult GetAddItemPartialView()
        {
            using (HttpClient c = new HttpClient())
            {
                Model4 obj =new Model4();
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetSuppliers").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(content);
                ViewBag.Suppliers = deContent.data;
                string UnitsResponse = c.GetAsync(Setting.Host + "/api/Selector/GetUnitTypes").Result.Content.ReadAsStringAsync().Result;
                Response<List<Select>> unites = JsonConvert.DeserializeObject<Response<List<Select>>>(UnitsResponse);
                var vat = obj.VAT_tbl.Where(x => x.ForCustomerOrItems == "I").ToList();
                ViewBag.vat = vat;
                ViewBag.Units = unites.Data;
            }
            return PartialView("_AddItem");
        }
        [HttpPost]
        public JsonResult SubmitAddNewItem(int supid ,string type,int vat, string code,string name , string itemgroupid , decimal size ,decimal supplyprice , string barcode ,decimal  sellprice,int unittype )
        {
            int userId = Cokie.UserGet().Id; 
            NewItem model = new NewItem { ETA_item_code= code, itemtype=type,tax_id=vat, Barcode = barcode, Distributor_Group_id = "0", ItemGroup_ID = itemgroupid, ItemName = name, Selling_Price = sellprice.ToString(), Supply_Price = supplyprice.ToString(), size = size.ToString(), Supplier_ID = supid.ToString(), User_ID = userId.ToString() , unittype = unittype };
            using (HttpClient http = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + $"/api/Items/Set_New_Item", body).Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }
        }

        [HttpPost]
        public JsonResult SubmitAddNewItemPrice(decimal supplyprice , decimal sellprice , int itemid ,int distributor)
        {
            string editor = Cokie.UserGet().UserName;
            price_list_tbl model = new price_list_tbl() { Item_ID =itemid , Distributor_Group_id = distributor,Selling_Price = sellprice, Supply_Price=supplyprice,Editor=editor};
            using(HttpClient http = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + $"/api/Items/addPriceListItem", body).Result;
                Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                return Json(new { data = res });
            }

        }

        [HttpPost]
        public JsonResult GetItemSelect (int supplier, int category)
        {
            string response = HTTP.Get($"/api/Selector/GetItems?supplier={supplier}&category={category}");
            return Json(new { data = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response) });
        }
    [HttpPost]
        public JsonResult Getdistributors ()
        {
            string response = HTTP.Get($"/api/Selector/GetDistributors");
            
            return Json(new { data = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response) });
        }
        [HttpGet]
        [FunctionFilter(key = "قبول الاسعار")]
        public ActionResult ConfirmUpdatePrice()
        {
            ConfirmUpdateListPriceModel model = new ConfirmUpdateListPriceModel();
            var apiresult = HTTP.Get<Response<List<ConfirmUpdatePriceModel>>>("/api/PendingUpdatePrices");
           if(apiresult?.Data != null)
            {
                model.PriceList = apiresult.Data.Where(x=>x.TypeNameId == "PriceList").ToList();
                model.Distributor = apiresult.Data.Where(x=>x.TypeNameId == "DistributorPrice").ToList();
                model.SpecialPrice = apiresult.Data.Where(x=>x.TypeNameId == "SpecialPrice").ToList();

            }
            return View(model);
        }
        [HttpPost]
        public JsonResult ConfirmUpdatePrice(int BaseTableId, int NewStatus, string PriceType)
        {
            var x = HTTP.Get<Response<string>>($"/api/ConfirmUpdatePrice?BaseTableId={BaseTableId}&NewStatus={NewStatus}&PriceType={PriceType}");
            return Json(x );
        }
          [HttpPost]
        public JsonResult ConfirmAllUpdatePrice( int NewStatus, string PriceType)
        {
            var x = HTTP.Get<Response<string>>($"/api/ConfirmAllUpdatePrice?NewStatus={NewStatus}&PriceType={PriceType}");
            return Json(x );
        }

        #endregion

   
    }
    public class ConfirmUpdatePriceModel
    {
        public string TypeNameId { get; set; }
        public int BaseTableId { get; set; }
        public int BaseId { get; set; }
        public string BaseName { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public decimal Selling { get; set; }
        public decimal Supply { get; set; }
    }
    public class ConfirmUpdateListPriceModel
    {
        public List<ConfirmUpdatePriceModel> Distributor = new List<ConfirmUpdatePriceModel>();
        public List<ConfirmUpdatePriceModel> PriceList = new List<ConfirmUpdatePriceModel>();
        public List<ConfirmUpdatePriceModel> SpecialPrice = new List<ConfirmUpdatePriceModel>();

    }
}

