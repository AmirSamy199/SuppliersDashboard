using SuppliersDashboard.Filters;
using SuppliersDashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class CPController : Controller
    {
        private CPService CP = new CPService();
        // GET: CP
        [FunctionFilter(key = "مشروع العمولة")]
        public ActionResult SalesCPReport()
        {
            ViewBag.DisChanged = "LoadPage()";
            return View();
        }
        public ActionResult SalesCPReportPartial(int SalesId)
        {
            var result = CP.CpMonthLatSixMonth(SalesId);
            return PartialView("_DisCPReport", result.Data);
        }

        public JsonResult CloseSalesMonth(int SalesId , string Month)=>Json(CP.CloseSalesMonth(SalesId, Month),JsonRequestBehavior.AllowGet);
        [HttpGet]
        public ActionResult CloseSalesMonth (int SalesId , int Year , int Month)
        {
            var result = CP.DistributorCommision(SalesId, Year, Month );
            ViewBag.Model = result;
            return PartialView("_CloseDistributorMonth", result);
        }
    }
}