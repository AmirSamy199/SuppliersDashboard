using Newtonsoft.Json;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class SmallUserDetails
    {
        public int RecordID { get; set; }
        public string UserName { get; set; }
        public string Serial_No { get; set; }

        public string DisGroupName { get; set; }
    }
    [Filters.MyAuthFilter]
   
    [FunctionFilter(key = "صفحات ال KPIS")]

    public class KPISController : BaseController
    {
        private HttpClientHelper _httpClientHelper= new HttpClientHelper();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Distributors()
        {

            ViewBag.DISS = JsonConvert.DeserializeObject<Response<List<SmallUserDetails>>>(_httpClientHelper.Get("/api/KPIS/GetAllDisDetailsKPI")).Data; 
            return View();
        }

        public ActionResult ItemsKPI()
        {
            string Content = _httpClientHelper.Get("/api/KPIS/GetItemsKPI"); 
            var res = JsonConvert.DeserializeObject<Response<List<AssignItems_V>>>(Content);
            ViewBag.Items = res.Data;
            return View();
        }
        public ActionResult PriceListKPI()
        {
            string Content = _httpClientHelper.Get("/api/KPIS/PriceListKPI"); 
            var res = JsonConvert.DeserializeObject<Response<List<AssignItems_V>>>(Content);
            ViewBag.PriceList = res.Data;
            return View();
        }
          public ActionResult BranchesKPI()
        {
            string Content = _httpClientHelper.Get("/api/KPIS/BranchesKPI"); 
            var res = JsonConvert.DeserializeObject<Response<List<Branch_Info_V>>>(Content);
            ViewBag.Branches = res.Data;
            return View();
        }


    }
}