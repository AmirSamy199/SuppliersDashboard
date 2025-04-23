using Aspose.Cells;
using Newtonsoft.Json;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Models.ReportModels;
using SuppliersDashboard.Services;
using SuppliersDashboard.ViewModels;
using SuppliersDashboard.ViewModels.ReportVM;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [MyAuthFilter]
    public class NewReportsController : BaseController
    {

        //  Total Items Sales From To تقرير يومية  اجماليات مبيعات صنف 
        // Total Categories Items Report تقرير  اجماليات مبيعات يومية لمجاميع الاصناف 
        //  expenses Reports تقرير المصروفات 
        // region total pills مجاميع الفواتير
        // shortfall report  تقرير العجز
        // sub warehouse guard تقرير جرد مخزن فرعي  
        private EldeebExcel xl = new EldeebExcel();
        private NewReportService _RS = new NewReportService();
        private HttpClientHelper httphelp = new HttpClientHelper();


        #region Total Items Sales From To تقرير يومية  اجماليات مبيعات صنف 
        [FunctionFilter(key = "صفحة تقرير مجموع مبيعات صنف")]
        public ActionResult TotalItemsSales()
        {
            return View();
        }
        public JsonResult TotalItemsSalesJSON(int ItemId, string DateFrom, string DateTo) => Json(new { data = _RS.GetItemTotalSales(ItemId, DateFrom, DateTo) });
        #endregion

        #region Total Categories Items Report تقرير  اجماليات مبيعات يومية لمجاميع الاصناف 
       
        [FunctionFilter(key = "صفحة تقرير مجموع مبيعات مجموعة")]

        public ActionResult TotalCategoriesSalesReport()
        {

            ViewBag.PageMsg = "هذة الصفحة لمتابعة كل مبيعات مجموعات الاصناف    ";


            var response = httphelp.Get("/api/Suppliers/GetSuppliers");
            dynamic deContent = JsonConvert.DeserializeObject<object>(response);
            ViewBag.Suppliers = deContent.data;
            string branchresponse = httphelp.Get("/api/Selector/GetAllBranchesFromTable");
            ViewBag.Branches = JsonConvert.DeserializeObject<Response<List<Select>>>(branchresponse).Data;
            string userresponse = httphelp.Get("/api/Selector/GetUsers");
            ViewBag.Users = JsonConvert.DeserializeObject<Response<List<Select>>>(userresponse).Data;
             string agents = httphelp.Get("/api/Selector/GetCompanmyTypes");
            ViewBag.Agents = JsonConvert.DeserializeObject<Response<List<Select>>>(agents).Data;


            return View();
        }
        [HttpPost]
        public JsonResult TotalCategoriesSalesReportJSON(int CategoryID, int UserID, int BranchID, string DateFrom, string DateTo, int AgentId)
        {
            return Json(new { data = _RS.GetCategoresTotalSales(CategoryID, UserID, BranchID, DateFrom, DateTo,AgentId) });
        }
        #endregion

        #region expenses Reports تقرير المصروفات
        [FunctionFilter(key = "تقرير المصاريف")]

        public ActionResult ExpensesReports()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ExpensesReportJson(string FromDate, string ToDate)
        {
            var response = _RS.ExpensesReport(FromDate, ToDate);
            return Json(new { data = response.Data, state = response.State, message = response.Message });
        }

        #endregion

        #region total pills مجاميع الفواتير

        [FunctionFilter(key = "تقرير اجماليات الفواتير")]

        public ActionResult TotalPillsReports()
        {

            //ViewBag.PageMsg = "هذة الصفحة لمتابعة مجاميع الفواتير";
            //DateTime currentDate = DateTime.UtcNow;
            //string DateNow = currentDate.ToString("yyyy-MM-dd");
            //ViewBag.TotalPills = _RS.GetBillTotalReort(DateNow, DateNow);
            ////ViewBag.TotalPills=JsonConvert.DeserializeObject<Response<CLASS>>(TotalPills)
            return View();
        }
        [HttpPost]
        public JsonResult GetTotalBillReportByDateJson(string DateForm, string DateTo)
        {

            return Json(new { data = _RS.GetBillTotalReort(DateForm, DateTo) });
        }



        [HttpPost]
        public JsonResult ChangeDocumentState(int BillNo, int State) => Json(new { data = _RS.ChangeDocState(BillNo, State) });



        #endregion
        #region Shortfall REport 
        [FunctionFilter(key = "تقرير العجوزات")]

        public ActionResult ShortFalls()
        {
            ViewBag.ShowDistributors = true;
            return View();
        }
        [HttpPost]
        public JsonResult ShortFallsJson(int UserId, string DateFrom, string DateTo)
        {
            return Json(_RS.ShortfallReport(UserId, DateFrom, DateTo));
        }
        [FunctionFilter(key = "تقرير العجوزات")]

        public ActionResult MoneyShortFalls()
        {
            ViewBag.ShowDistributors = true;
            return View();
        }
        [HttpPost]
        public JsonResult MoneyShortFallsJson(int UserId, string DateFrom, string DateTo)
        {
            return Json(_RS.MoneyShortfallReport(UserId, DateFrom, DateTo));
        }
        #endregion   
        #region SubwareHouse Guard REport 
        [FunctionFilter(key = "تقربر جرد المخزن الفرعي")]

        public ActionResult SubWareHouseGuard()
        {
            ViewBag.ShowDistributors = true;
            return View();
        }
        public JsonResult SubWareHouseGuardJson(int UserId, string DateFrom, string DateTo)
        {

            return Json(_RS.SubWareHouseGuardReport(UserId, DateFrom, DateTo));
        }

        #endregion


        #region MoneyPaper Report 
    
        [FunctionFilter(key = "تقرير اوراق الدفع")]

        public ActionResult MoneyPaper()
        {
            ViewBag.ShowDistributors = true;
            return View();
        }
        [HttpPost]
        public JsonResult MoneyPaperJson(int UserId, string DateFrom, string DateTo)
        {
            return Json(_RS.MoneyPaperReport(UserId, DateFrom, DateTo));
        }
        #endregion
        public ActionResult itemDistributors()
        {
            ViewBag.ShowDistributors = true;
            return View();
        }
        [HttpGet]
        public JsonResult ItemsDistributorsJSON(string DateFrom, string DateTo, int SalesId = 0)
        {
            return Json(_RS.ItemsDistributorsReport(DateFrom, DateTo, SalesId), JsonRequestBehavior.AllowGet);
        }

        #region ItemSalesReport 
        [FunctionFilter(key = "صفحة تقرير مجموع مبيعات صنف")]

        public ActionResult ItemsReport()
        {
            ViewBag.ShowDistributors = true;
            return View();
        }
        [HttpGet]
        public JsonResult ItemsReportJSON(string DateFrom, string DateTo, int SalesId = 0)
        {
            return Json(_RS.ItemsSalesReport(DateFrom, DateTo, SalesId), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ItemsReportExcel(string DateFrom, string DateTo, int SalesId = 0)
        {
            var response = _RS.ItemsSalesReport(DateFrom, DateTo, SalesId);

            var headers = xl.GetHeaders("ItemName:اسم الصنف/ItemCode:الباركود/UnitType:الوحدة /Count:الكمية /Average:متوسط السعر/Price:اجمالي المبيعات ");
            Workbook exc = xl.GetExcelWithHeader<ItemSalesREportVM>(response.Data, headers);

            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx);
            return Json(new { url = "/Content/Excels/Excel.xlsx" });

        }
        public JsonResult Excl(string DateFrom, string DateTo, int SalesId = 0)
        {
            var response = _RS.ItemsDistributorsReport(DateFrom, DateTo, SalesId);

            var headers = xl.GetHeaders("UserName:اسم المندوب/ItemName:اسم الصنف/ItemCode:الباركود/UnitType:الوحدة /Count:الكمية /Average:متوسط السعر/Price:اجمالي المبيعات ");
            Workbook exc = xl.GetExcelWithHeader<ItemSalesREportVM>(response.Data, headers);

            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });

        }
        #endregion

        #region BillLatersReport
        [FunctionFilter(key = "صفحة تقرير المتاخرات")]

        public ActionResult BillLatersReport() { return View(); }
        [HttpGet]
        public JsonResult BillLatersJSON() => Json(_RS.BillLatesReport(), JsonRequestBehavior.AllowGet);
        public JsonResult BillLatersExcel()
        {
            var response = _RS.BillLatesReport();

            var headers = xl.GetHeaders("BranchName:اسم الفرع /SalesName : المندوب/ BillNo : رقم الفاتورة/ BillAmount : سعر الفاتورة ظ BillDate : تاريخ الفاتورة/ LastCollection : تاريخ اخر تحصيل/BillDaysCountLater : عدد ايام التاخير / BillDaysCountLaterFromFirstOfMonth : عدد ايام التاخير من بداية الشهر/ BillDeffered : الباقي في الفاتورة /PlusThirty : +30/PlusSixty : +60/ PlusNighnty: +90");
            Workbook exc = xl.GetExcelWithHeader<BillLatesReport_V>(response.Data, headers);

            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });

        }
        #endregion
        #region Excel Methods 
        public JsonResult ExpensesReportExcel(string FromDate, string ToDate)
        {
            var response = _RS.ExpensesReport(FromDate, ToDate);

            List<ExcelHeader> headers = new List<ExcelHeader>();
            headers.Add(new ExcelHeader { Key = "MasrofId", Value = "رقم اذن المصروف" });
            headers.Add(new ExcelHeader { Key = "MasrofDateString", Value = "تاريخ الصرف" });
            headers.Add(new ExcelHeader { Key = "MasrofAmount", Value = "قيمة المصروف" });
            headers.Add(new ExcelHeader { Key = "Sales", Value = "المندوب" });
            headers.Add(new ExcelHeader { Key = "Manager", Value = "المسئول عن الصرف " });
            Workbook exc = xl.GetExcelWithHeader<MasrofReport>(response.Data, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }


        public JsonResult BillReportByDateExcel(string FromDate, string ToDate)
        {
            var response = _RS.GetBillTotalReort(FromDate, ToDate);

            List<ExcelHeader> headers = new List<ExcelHeader>();
            headers.Add(new ExcelHeader { Key = "BillNo", Value = "رقم الفاتورة" });
            headers.Add(new ExcelHeader { Key = "TransactionType", Value = "نوع الحركة" });
            headers.Add(new ExcelHeader { Key = "TransactionDate", Value = "التاريخ" });
            headers.Add(new ExcelHeader { Key = "NameOfBranch", Value = "اسم العميل" });
            headers.Add(new ExcelHeader { Key = "NameOfSales", Value = "المندوب " });
            headers.Add(new ExcelHeader { Key = "TotalAmount", Value = "االاجمالي " });
            headers.Add(new ExcelHeader { Key = "CollectionAmount", Value = "المحصل " });
            headers.Add(new ExcelHeader { Key = "DefferedAmount", Value = "الباقي " });
            headers.Add(new ExcelHeader { Key = "IsNoDocument", Value = "المستند  " });
            Workbook exc = xl.GetExcelWithHeader<BillTotalReport>(response.Data, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult SubWareHouseGuardExcel(int UserId, string DateFrom, string DateTo)
        {
            var response = _RS.SubWareHouseGuardReport(UserId, DateFrom, DateTo);
            List<ExcelHeader> headers = new List<ExcelHeader>();
            headers.Add(new ExcelHeader { Key = "UserName", Value = " اسم الموزع " });
            headers.Add(new ExcelHeader { Key = "ItemName", Value = " اسم الصنف" });
            headers.Add(new ExcelHeader { Key = "CountBefore", Value = "قبل العملية " });
            headers.Add(new ExcelHeader { Key = "Wared", Value = " وارد " });
            headers.Add(new ExcelHeader { Key = "Sader", Value = " صادر " });
            // headers.Add(new ExcelHeader { Key = "Count", Value = " العدد " });
            headers.Add(new ExcelHeader { Key = "CountAfter", Value = "بعد العملية  " });
            headers.Add(new ExcelHeader { Key = "_Date", Value = "الوقت  " });
            headers.Add(new ExcelHeader { Key = "Message", Value = "التفاصيل " });

            Workbook exc = xl.GetExcelWithHeader<StoreGuardDefaultVM>(response.Data, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult ShortFallsExcel(int UserId, string DateFrom, string DateTo)
        {
            var response = _RS.ShortfallReport(UserId, DateFrom, DateTo);
            // List<ExcelHeader> headers = new List<ExcelHeader>();
            var headers = xl.GetHeaders("UserName: اسم الموزع/ItemName: اسم الصنف/SupplyAmount:سعر البيع/Count:العدد/Date:الوقت");
            //headers.Add(new ExcelHeader { Key = "UserName", Value = " اسم الموزع " });
            //headers.Add(new ExcelHeader { Key = "ItemName", Value = " اسم الصنف" });
            //headers.Add(new ExcelHeader { Key = "Count", Value = " العدد " });
            //headers.Add(new ExcelHeader { Key = "_Date", Value = "الوقت  " });

            Workbook exc = xl.GetExcelWithHeader<StoreGuardDefaultVM>(response.Data, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult MoneyShortFallsExcel(int UserId, string DateFrom, string DateTo)
        {
            var response = _RS.MoneyShortfallReport(UserId, DateFrom, DateTo);
            var headers = xl.GetHeaders("Sales:المندوب/Date:الوقت/MoneyFall:عجز القلوس/MoneyPaperCountFall:عجز عدد اوراق الدفع /MoneyPaperAmountFall:عجز قيمة اوراق الدفع/DefferedPaperCountFall:عجز عدد اوراق الاجل /DefferedPaperAmountFall:عجز قيمة اوراق الاجل ");
            Workbook exc = xl.GetExcelWithHeader<MoneySortfallModel>(response.Data, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        public JsonResult MoneyPaperExcel(int UserId, string DateFrom, string DateTo)
        {
            var response = _RS.MoneyPaperReport(UserId, DateFrom, DateTo);
            var headers = xl.GetHeaders("BranchName:الفرع/Date:الوقت/UserName:المندوب /Amount:الكمية /Bank:   البنك/CheckNumber:   رقم الشيك  ");
            Workbook exc = xl.GetExcelWithHeader<MoneyPaperModel>(response.Data, headers);
            exc.Save(Server.MapPath("~/Content/Excels/Excel.xlsx"), SaveFormat.Xlsx); ;
            return Json(new { url = "/Content/Excels/Excel.xlsx" });
        }
        #endregion
    }
}