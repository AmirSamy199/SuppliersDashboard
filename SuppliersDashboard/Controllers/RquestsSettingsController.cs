using Aspose.Cells;
using Newtonsoft.Json;
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
            Response<List<Supplier_Tbl>> suppliers = JsonConvert.DeserializeObject<Response<List<Supplier_Tbl>>>(res);
            return View(suppliers.data);
        }

    }
}