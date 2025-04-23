using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Services;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
  
    public class HomeController : BaseController
    {
    [Filters.MyAuthFilter]

        public ActionResult Index()
        {
            HttpClientHelper htp = new HttpClientHelper();







            ViewBag.ProductCount = 0;
            ViewBag.BillsCountThisMonth = 0; 
            ViewBag.SuppliersCount = 0;

            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetCounters").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic descontent = JsonConvert.DeserializeObject<dynamic>(content);
                ViewBag.ProductCount = descontent.ProductsCount;
                ViewBag.BillsCountThisMonth = descontent.BillsCountThisMonth;
                ViewBag.SuppliersCount = descontent.SuppliersCount;

            }
           
            return View();
        } 
        [Filters.MyAuthFilter]

        public ActionResult Location()
        {
            return View();
        }
        public ActionResult ChangeLanguage(string lang, string BackUrl)
        {
            new LanguageMang().SetLanguage(lang);
            string[] UrlList = BackUrl.Split('/');
            string Action = UrlList.Length >= 3 ? UrlList[2] : "";
            string Controller = UrlList.Length >= 2 ? UrlList[1] : "Home";
            string x = Path.Combine(Server.MapPath("~/"), BackUrl);
            if(UrlList.Any(s=>s.Contains ("?")) || UrlList.Length == 4)
                return RedirectToAction("Index", "Home");
            return RedirectToAction(Action, Controller);
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult GetDistributorGroups()
        {
            DistributorService ds = new DistributorService();
            Response<List<SimpleClass>> decontent = ds.GetDistriburors();
            return Json(decontent,JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public JsonResult CancelInvoice(int BillNo)
        {
                HttpClientHelper hp = new HttpClientHelper();
                var res = hp.Get<Response<string>>($"/api/CancelInvoice?Number={BillNo}");
                 return Json(res,JsonRequestBehavior.AllowGet);
           
        }

        [HttpPost]
        public JsonResult TestHeader()
        {

            using (HttpClient htp = new HttpClient())
            {
                string content = htp.SetHeader().GetAsync(Setting.Host + "/TestHeader").Result.Content.ReadAsStringAsync().Result;
                return Json(new {message = content});
            }
        }
       
    }
}