using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [MyAuthFilter]
    public class CompanyController : BaseController
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult WareHouse()
        {
            ViewBag.PageMsg = "هذة الصفحة لمعرفة البضاعة الموجودة فالمخزن ";
            ViewBag.Suppliers = "";
            using (HttpClient c = new HttpClient())
            {
                var response = c.SetHeader().GetAsync(Setting.Host + "/api/Suppliers/GetSuppliers").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic deContent = JsonConvert.DeserializeObject<object>(content);

                if (deContent.State == 200)
                {
                    ViewBag.Suppliers = new SelectList(deContent.data, "Record_ID", "CompanyName");
                }
            }
            return View();
        }














        // Ajaxs Area 
        [HttpPost]
        public JsonResult LoadData(int SupID)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.SetHeader().GetAsync(Setting.Host  + $"/api/Items/GetWareHouseItems?supplier={SupID}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var deContent = JsonConvert.DeserializeObject<Response<List<warehouse_main_V>>>(content);

                    return Json(new {data = deContent });
                
            }
           
        }
        [HttpPost]
        public JsonResult AddItemCount(int itemId, decimal count , string type , int user,int supplier)
        {
            var Cuser = Cokie.UserGet();  
            using (HttpClient c = new HttpClient())
            {
                var response = c.SetHeader().GetAsync(Setting.Host+ $"/api/Items/AddItemCount?UserID={Cuser.Id}&itemId={itemId}&count={count}&type={type}&user={user}&supplier={supplier}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var deContent = JsonConvert.DeserializeObject<Response<string>>(content);

                    return Json(new {data = deContent });
                
            }
           
        }


        [HttpPost]
        //اضافة في مخزن المشريات
        public JsonResult AddItemMaterials(int itemId, decimal count, string type, int user, int supplier,decimal Supply_Price)
        {
            var Cuser = Cokie.UserGet();
            using (HttpClient c = new HttpClient())
            {
                var response = c.SetHeader().GetAsync(Setting.Host + $"/api/Items/AddItemMaterials?UserID={Cuser.Id}&itemId={itemId}&count={count}&type={type}&user={user}&supplier={supplier}&Supply_Price={Supply_Price}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var deContent = JsonConvert.DeserializeObject<Response<string>>(content);

                return Json(new { data = deContent });

            }

        }
    }
}