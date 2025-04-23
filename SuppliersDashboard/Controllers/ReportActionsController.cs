using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class ReportActionsController : Controller
    {
        private HttpClientHelper htp = new HttpClientHelper();
        [HttpPost]
      public JsonResult SettleWareHouseShortFall(int TranId , string Way)
        {
            string EndPoint = $"/api/Operation/SettleWareHouseShortFall?ShortId={TranId}&Way={Way}";
            var response = JsonConvert.DeserializeObject<Response<string>>(htp.Get(EndPoint));
            return Json(new { data = response });
        }
        [HttpPost]
        public JsonResult SettleMoneyFall(int TranId, string Way)
        {
            string EndPoint = $"/api/Operation/SetttleMoneyShortFall?ShortId={TranId}&Way={Way}";
            var response = JsonConvert.DeserializeObject<Response<string>>(htp.Get(EndPoint));
            return Json(new { data = response });
        }
    }
}