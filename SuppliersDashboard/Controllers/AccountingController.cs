using Newtonsoft.Json;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class AccountingController : BaseController
    {
        private AccountingService _as = new AccountingService();
        private HttpClientHelper HTTPHELPER = new HttpClientHelper();
        // GET: Accounting
        /// <summary>
        /// Close Accounter Day To deliver Money Save الخزنة To Second Accounter
        /// </summary>
        /// <returns></returns>
      //  [CloseAcconterDayFilter]
        [FunctionFilter(key = "صفحة اغلاق وتسليم الخزنة")]
        public ActionResult CloseAcconterDay()
        {

            var CUser = Cokie.UserGet();
            ViewBag.Name = CUser.UserName;
            Response<List<AccountReportModel>> Res = JsonConvert.DeserializeObject<Response<List<AccountReportModel>>>(HTTPHELPER.Get($"/api/Accounting/AccounterCloseDay?Accounter={CUser.Id}"));
            ViewBag.Details = Res.Data; // Details 
            ViewBag.Header = Res.Item; // Header
            return View(Res.Item); 
        }

        public JsonResult SubmitCloseAccounterDay()
        {
            int Accounter = Cokie.UserGet().Id;
            Response<string> res = JsonConvert.DeserializeObject<Response<string>>(HTTPHELPER.Get($"/api/Accounting/CloseAccounterDay?Accounter={Accounter}")); 
            return Json(new {data = res});
        }



        /// <summary>
        /// Close تصفير الخزنة والذها للمنزل 
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMoneySaveBalance()
        {
            return Json(new { data = _as.GetBalanceOfMoneySave() }); 
        } 
        [HttpPost]
        public JsonResult CloseAndCleanMoneySafeDay(int AccounterId)
        {
            var us = Cokie.UserGet();
            //return Json(new { data = 0 });
            return Json(new { data = _as.CloseMoneySaveAtEndOfDay(AccounterId) });
        }
    }
}