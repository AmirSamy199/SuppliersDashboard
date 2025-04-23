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
    [MyAuthFilter]
    public class PriceListController : Controller
    {
        private HttpClientHelper _http =  new HttpClientHelper();
        // GET: PriceList
        [FunctionFilter(key ="اعدادات قوائم الاسعار")]
        public ActionResult Index()
        {
            var lists = _http.Get<Response<List<Select>>>($"/api/Selector/GetPricesLists").Data; 

            return View(lists);
        }
        [HttpPost]
        public JsonResult AddPriceList(string Name)
        {
            return Json(_http.Get<Response<string>>($"/api/Supplier/AddPriceList?Name={Name}"));
        }    
        [HttpPost]
        public JsonResult EditPriceList(int Id ,string Name)
        {
            return Json(_http.Get<Response<string>>($"/api/Supplier/EditPriceList?Id={Id}&Name={Name}"));
        }  [HttpPost]
        public JsonResult DeletePriceList(int Id )
        {
            return Json(_http.Get<Response<string>>($"/api/Supplier/DeletePriceList?Id={Id}"));
        }
    }
}