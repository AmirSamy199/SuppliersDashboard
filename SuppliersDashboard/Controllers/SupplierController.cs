using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.Services;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [MyAuthFilter]
   // [AdminFilter]
    [FunctionFilter(key = "w-admin")]
    public class SupplierController : BaseController
    {
        // GET: Supplier
        Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
        public ActionResult Index()
        {
            ViewBag.Suppliers = "";
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
        [FunctionFilter(key = "صفحة تعديل او ايقاف مورد")]

        public ActionResult Seting()
        {
            ViewBag.PageMsg = SuppliersDashboard.Resources.pages.supsettingpage;
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetSuppliers?All=1").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(content);

                if (deContent.State == 200)
                {
                    ViewBag.Suppliers = deContent.data;
                }
            }
            return View();
        }
        [FunctionFilter(key = "صفحة اضافة مورد او مجموعة مندوبين")]

        public ActionResult Add()
        {
            return View();
        }
        [FunctionFilter(key ="اضافة مجموعة مندوبين")]
        public ActionResult AddreprsntGroup()
        {
            ViewBag.Agents = (new SelectService()).GetAgentsSelect();
            ViewBag.Groups = HTTP.Get<Response<List<Select>>>($"/api/Selector/GetDistributors").Data;

            return View();
        }
        [HttpPost]
        public JsonResult AddSalesMan(string UserName , int GroupId)
        {
            return Json(HTTP.Get<Response<string>>($"/api/CreateSalesUser?GroupId={GroupId}&UserName={UserName}"));
        }

        [Route("/Supplier/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            ViewBag.Id = Id;
            return View();

        }


        [Route("/Supplier/AllDetails/{Id}")]

        public ActionResult AllDetails(int Id)
        {
            ViewBag.Id = Id;
            return View();

        }

        [FunctionFilter(key = "w-admin")]
        [Route("/Supplier/UsersRegistrationRequests")]
        public ActionResult UsersRegistrationRequests() {
            ViewBag.PageMsg = SuppliersDashboard.Resources.pages.userregistrationrequest;
            return View();
        }
        public ActionResult DistributorGroups()
        {
            DistributorService ds = new DistributorService();
            ViewBag.Distributors = ds.GetDistriburors().data;
            return View();
        }

        

        // Ajax Calls 
        public ActionResult SupplierDetails(string Id, string Year, string Month, string Day)
        {
            ViewBag.Suppliers = "";
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetSuppliersDataByday?Id=" + Id + "&Year=" + Year + "&Month=" + Month + "&Day=" + Day).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<Response<SupplierDetailsVM>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult GetAllSuppliersData(string Id)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetAllSuppliersData?Id=" + Id ).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<Response<SupplierDetailsVM>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult GetBillsToSupplierInDay(string Id, string Year, string Month, string Day)
        {
          
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetBillsToSupplierInDay?Id=" + Id + "&Year=" + Year + "&Month=" + Month + "&Day=" + Day).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<DistributorSupplierBill>> deContent = JsonConvert.DeserializeObject<Response<List<DistributorSupplierBill>>>(content);
                if(deContent.data != null)
                {

                foreach (var item in deContent.data)
                {
                    item.BillDateString = item.BillDate.ToString("yyyy-MM-dd hh:mm:ss");
                }
                }
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult GetDistributersToSupplier(string Id)
        {
          
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetDistributersToSupplier?Id=" + Id ).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<DistributerGroupDetails>> deContent = JsonConvert.DeserializeObject<Response<List<DistributerGroupDetails>>>(content);
               
                
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult GetPendingRegistrationRequests()
        {       
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetPendingRegistrationRequests" ).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<RegisterRequestDT>> deContent = JsonConvert.DeserializeObject<Response<List<RegisterRequestDT>>>(content);
               // deContent.data = deContent.data.Select(s => { s._Request_date = s.Request_date?.ToString("yyyy-MM-dd hh:mm tt"); return s; }).ToList();
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        } 
        public ActionResult AcceptRegistrationRequest(int Reg_Id)
        {       
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Account/AcceptRegistrationRequest?Reg_Id=" + Reg_Id).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<string>> deContent = JsonConvert.DeserializeObject<Response<List<string>>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult RejectRegistrationRequest(int Reg_Id)
        {       
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Account/RejectRegistrationRequest?Reg_Id=" + Reg_Id).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<string>> deContent = JsonConvert.DeserializeObject<Response<List<string>>>(content);
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }
        } 
        [HttpPost]
        public ActionResult DisableSupplier(int Id , int status )
        {       
            using (HttpClient c = new HttpClient())
            {

                
                var response = c.GetAsync(Setting.Host + $"/api/Company/EnableDisableSupplier?SupId={Id}&Status={status}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<string> deContent = JsonConvert.DeserializeObject<Response<string>>(content);
                return Json(new { data = deContent});
            }
        }
        [HttpPost]
        public ActionResult AddSupplier(string name, string responsableperson, string telephone, string address,int TypeSupplier)
        {
            Supplier_Tbl sup = new Supplier_Tbl()
            {
                CompanyName = name,
                Responsible_Person = responsableperson,
                Telephone1 = telephone,
                Address = address,
                TypeSupplier= TypeSupplier
            };
            using (HttpClient c = new HttpClient())
            {
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(sup), Encoding.UTF8, "application/json");

                var response = c.PostAsync(Setting.Host + $"/api/Supplier/AddSupplier", httpContent).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<Supplier_Tbl> deContent = JsonConvert.DeserializeObject<Response<Supplier_Tbl>>(content);
                return Json(new { data = deContent});
            }
        }




        [HttpPost]
        public ActionResult AddDisGroup(string name, int Agent)
        {


            string res = HTTP.Get($"/api/Company/AddNewDistributorGroup?Name={name}&Agent={Agent}");
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(res) });
        }


       [ MyAuthFilter]
        public ActionResult EditItemsPrices()
        {
            ViewBag.Suppliers = HTTP.Get<dynamic>("/api/Suppliers/GetSuppliers?All=1").data;
            return View();
        }
        [FunctionFilter(key = "اعدادات قوائم الاسعار")]

        public ActionResult EditItemsPricesList()
        {
            ViewBag.Suppliers = HTTP.Get<dynamic>("/api/Suppliers/GetSuppliers?All=1").data;
            ViewBag.PricesList = HTTP.Get<dynamic>("/api/Selector/GetPricesLists").Data;
            return View();
        }
        [HttpGet]
        public JsonResult SearchPrice(int DistributorId , int CategoryId)
        {
            string url = $"/api/Supplier/GetCategoryItemsPrice?DistributorGroupId={DistributorId}&CategoryId={CategoryId}";
            var res = HTTP.Get<Response<List<ItemPriceModel>>>(url);
            return Json(res , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubmitEditPrices(List<AddPriceModel> Models)
        {
            string Res = HTTP.Post($"/api/Supplier/EditItemPrice", JsonConvert.SerializeObject(Models));
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(Res) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SearchPriceListt(int pricelisttid, int CategoryId)
        {
            string url = $"/api/Supplier/GetCategoryItemsPriceList?pricelisttid={pricelisttid}&CategoryId={CategoryId}";
            var res = HTTP.Get<Response<List<ItemPriceModel>>>(url);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubmitEditPricesList(List<AddPriceModel> Models)
        {
            string Res = HTTP.Post($"/api/Supplier/EditItemPriceList", JsonConvert.SerializeObject(Models));
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(Res) }, JsonRequestBehavior.AllowGet);
        }

    }
}