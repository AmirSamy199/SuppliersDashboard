using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class SelectorController : BaseController
    {
        private HttpClientHelper HttpClientHelper = new HttpClientHelper();
        public JsonResult GetAllCompanyTypes()
        {
            string Res = HttpClientHelper.Get("/api/Selector/GetCompanmyTypes");
            return Json(JsonConvert.DeserializeObject<Response<List<Select>>>(Res));
        }
        public JsonResult GetAllDistributorsUsers()
        {
            string Res = HttpClientHelper.Get("/api/Selector/AllGetDistributorUsers");
            return Json(new { data = JsonConvert.DeserializeObject<Response<List<Select>>>(Res) });
        }
        public JsonResult Getsales_representative()
        {
            string Res = HttpClientHelper.Get("/api/DistributorControl/Getsales_representative");
            var model= JsonConvert.DeserializeObject< Response<DistributerGroupDetailsSelect>>(Res);
            return Json(new { data = JsonConvert.DeserializeObject<Response<DistributerGroupDetailsSelect>>(Res) });
        }
          public JsonResult GetDistributors()
        {
            string Res = HttpClientHelper.Get("/api/Selector/GetDistributors");
            return Json(new { data = JsonConvert.DeserializeObject<Response<List<Select>>>(Res) }, JsonRequestBehavior.AllowGet);
        }

        
          public JsonResult GetPAymentTerms()
        {
            string Res = HttpClientHelper.Get("/api/Selector/GetPaymentTerms");
            return Json(new { data = JsonConvert.DeserializeObject<Response<List<Select>>>(Res) } , JsonRequestBehavior.AllowGet);
        }
          public JsonResult GetCategoriesToSupplier(int supplier)
        {
            string Res = HttpClientHelper.Get($"/api/Selector/GetCateogires?supplier={supplier}");
            return Json(new { data = JsonConvert.DeserializeObject<Response<List<Select>>>(Res) } , JsonRequestBehavior.AllowGet);
        }
      
    }
}