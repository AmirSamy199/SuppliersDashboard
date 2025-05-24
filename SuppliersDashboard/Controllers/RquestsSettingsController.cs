using Aspose.Cells;
using Newtonsoft.Json;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class RquestsSettingsController : Controller
    {
        // GET: RquestsSettings
        Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SuppliersRequests()
        {
            string res = HTTP.Get($"/api/RquestsSettings/RquestsSettings");
            Response<List<Supplier_Tbl>> suppliers = JsonConvert.DeserializeObject<Response<List<Supplier_Tbl>>>(res);
            return View(suppliers.data);
        }
        [HttpPost]
        public ActionResult ConfirmRequestSuppliers(int Requestid,int ConfirmStatus)
        {
            string res = HTTP.Get($"/api/RquestsSettings/ConfirmRequestSuppliers?Requestid={Requestid}&ConfirmStatus={ConfirmStatus}");
            var re = JsonConvert.DeserializeObject<Response<string>>(res);
            return Json(new { data = res  });
        }


        public ActionResult ItemsRequests()
        {
            string res = HTTP.Get($"/api/RquestsSettings/RquestsItems");
            Response<List<ItemsRequests>> Items = JsonConvert.DeserializeObject<Response<List<ItemsRequests>>>(res);
            return View(Items.data);
        }
        [HttpPost]
        public ActionResult ConfirmRequestItems(int Requestid, int ConfirmStatus)
        {
            string res = HTTP.Get($"/api/RquestsSettings/ConfirmRequestItems?Requestid={Requestid}&ConfirmStatus={ConfirmStatus}");
            var re = JsonConvert.DeserializeObject<Response<string>>(res);
            return Json(new { data = res });
        }

        public ActionResult BranchesRequests()
        {
            string res = HTTP.Get($"/api/RquestsSettings/RquestsBranches");
            Response<List<RequestBranches>> Items = JsonConvert.DeserializeObject<Response<List<RequestBranches>>>(res);
            return View(Items.data);
        }

        [HttpPost]
        public ActionResult ConfirmRequestBranches(int Requestid, int ConfirmStatus)
        {
            string res = HTTP.Get($"/api/RquestsSettings/ConfirmRequestBranches?Requestid={Requestid}&ConfirmStatus={ConfirmStatus}");
            var re = JsonConvert.DeserializeObject<Response<string>>(res);
            return Json(new { data = res });
        }

    }
}