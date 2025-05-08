using FastReport.Export.Pdf;
using FastReport.Web;
using Newtonsoft.Json;
using ScoposERB.Helper;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Select = SuppliersDashboard.ViewModels.Select;
using SimpleClass = SuppliersDashboard.ViewModels.SimpleClass;

namespace SuppliersDashboard.Controllers
{
    public class ReportParamters
    {
        public int ReportType { get; set; }
        public int SalesId { get; set; }
        public int AgentId { get; set; }
        public int BaseId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Search { get; set; } = "";
    }
    [MyAuthFilter]
    public class FastReportController : Controller
    {


        public ActionResult test()
        {

            FastReport.Report report = new FastReport.Report();
            var path = Server.MapPath("~") + @"Content\FastReport\BillReports.frx";
            report.Report.Load(path);
            report.Report.SetParameterValue("SalesId", 1);
            report.Report.SetParameterValue("AgentId", 1);
            report.Report.SetParameterValue("DateFrom","2024-09-01");
            report.Report.SetParameterValue("DateTo", "2024-09-30");
            report.Prepare();

            PDFExport export = new PDFExport();
            using (MemoryStream ms = new MemoryStream())
            {
                export.Export(report, ms);
                ms.Flush();
                return File(ms.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("Simple List") + ".pdf");
            }
        }
    

        //protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        //{
        //    //string lang = null;
        //    //HttpCookie langCookie = Request.Cookies["culture"];
        //    //if (langCookie != null)
        //    //{
        //    //    lang = langCookie.Value;
        //    //}
        //    //else
        //    //{

        //    //    var userLang = "en";
        //    //    if (userLang != "")
        //    //    {
        //    //        lang = userLang;
        //    //    }
        //    //    else
        //    //    {
        //    //        lang = LanguageMang.GetDefaultLanguage();
        //    //    }
        //    //}
        //    //new LanguageMang().SetLanguage(lang);
        //  //  Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        //    new LanguageMang().SetLanguage("en");
        //    return base.BeginExecuteCore(callback, state);
        //}




        private HttpClientHelper _http = new HttpClientHelper();
        public List<SimpleClass> _reportTypes = new List<SimpleClass>();
        public static string from { get; set; } = null;
        public static string to { get; set; } = null;
        public static int reporttype { get; set; } = 0;
        public static int salesid { get; set; } = 0;
        public static int agentid { get; set; } = 0;
        public static int baseId { get; set; } = 0;

        public FastReportController()
        {
            _reportTypes.Add(new SimpleClass { Id = 0, Page = "salesman agent company branch", Name = "اختر نوع التقرير " });
            _reportTypes.Add(new SimpleClass { Id = 1, Page = "salesman", Name = "تفيصليات الفواتير " });
            _reportTypes.Add(new SimpleClass { Id = 2, Page = "salesman", Name = "تفيصليات المصاريف " });
            _reportTypes.Add(new SimpleClass { Id = 3, Page = "salesman", Name = "طلبات نقل البضاعة تفصيلي" });
            _reportTypes.Add(new SimpleClass { Id = 4, Page = "agent", Name = "اجمالي مبيعات  " });
            _reportTypes.Add(new SimpleClass { Id = 5, Page = "salesman", Name = "اجمالي مبيعات  " });
            _reportTypes.Add(new SimpleClass { Id = 6, Page = "company", Name = "اجمالي مبيعات  " });
            _reportTypes.Add(new SimpleClass { Id = 7, Page = "branch", Name = "اجمالي مبيعات  " });
            _reportTypes.Add(new SimpleClass { Id = 8, Page = "dashboarduser", Name = "اجماليات الخزنة" });
            _reportTypes.Add(new SimpleClass { Id = 9, Page = "dashboarduser", Name = "تفاصيل الخزنة" });
            _reportTypes.Add(new SimpleClass { Id = 10, Page = "dashboarduser", Name = "سلة المهملات" });
            _reportTypes.Add(new SimpleClass { Id = 11, Page = "salesman", Name = "طلبات نقل بضاعة" });
            _reportTypes.Add(new SimpleClass { Id = 12, Page = "salesman", Name = "وقود" });

            _reportTypes.Add(new SimpleClass { Id = 14, Page = "salesman", Name = "مرتجعات تفصيلي" });
            _reportTypes.Add(new SimpleClass { Id = 15, Page = "salesman", Name = "مرتجعات" });
            _reportTypes.Add(new SimpleClass { Id = 16, Page = "branch", Name = "مرتجعات" });
            _reportTypes.Add(new SimpleClass { Id = 17, Page = "branch", Name = "مرتجعات تفصيلي" });
            _reportTypes.Add(new SimpleClass { Id = 18, Page = "dashboarduser", Name = " تسوية مرتجعات" });
            _reportTypes.Add(new SimpleClass { Id = 19, Page = "salesman", Name = " مجلات " });
            _reportTypes.Add(new SimpleClass { Id = 20, Page = "branch", Name = " مجلات " });
            _reportTypes.Add(new SimpleClass { Id = 21, Page = "agent", Name = " مجلات " });
            _reportTypes.Add(new SimpleClass { Id = 22, Page = "salesman", Name = "ايرادات" });
            _reportTypes.Add(new SimpleClass { Id = 23, Page = "branch", Name = "كشف حساب" });
            _reportTypes.Add(new SimpleClass { Id = 24, Page = "salesman", Name = "مديونيات ومتاخرات" });
            _reportTypes.Add(new SimpleClass { Id = 25, Page = "branch", Name = "اخر فاتورة" });
            _reportTypes.Add(new SimpleClass { Id = 26, Page = "item", Name = "ربح" });
            _reportTypes.Add(new SimpleClass { Id = 27, Page = "salesman", Name = "كشف حساب" });


        }
        // GET: FastReport

        #region SalesMAn المندوب
        [FunctionFilter(key = "تقارير المندوب")]
        public ActionResult Index()
        {
            loadViewBags("salesman");
            return View();
        }
        [HttpPost]
        public ActionResult Index(ReportParamters Paramters)
        {
            from = Paramters.DateFrom;
            to = Paramters.DateTo;
            salesid = Paramters.SalesId;
            reporttype = Paramters.ReportType;
            baseId = Paramters.BaseId;
            agentid = Paramters.AgentId;
            ViewBag.WebReport = null;
            loadViewBags("salesman");
            try
            {
                //Data Source=108.181.168.89,1497;AttachDbFilename=;Initial Catalog=SCOPOS_Caigo_DB;Integrated Security=False;Persist Security Info=True;User ID=ENKIMA;Password=T81@1NV#2o2IT02oo2
                //data source=108.181.168.89,1497;initial catalog=SCOPOS_Caigo_DB;user id=ENKIMA;password=T81@1NV#2o2IT02oo2;encrypt=False;MultipleActiveResultSets=True;
                string path = "";
                WebReport report = new WebReport();
                switch (Paramters.ReportType)
                {
                    case 1:
                        path = Server.MapPath("~") + @"Content\FastReport\BillReports.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);


                        break;
                    case 2:
                        path = Server.MapPath("~") + @"Content\FastReport\ExpensesReports.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                    case 3:
                        path = Server.MapPath("~") + @"Content\FastReport\Report1SubWareHouseRequests.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);
                        report.Report.SetParameterValue("RequestNo", Paramters.BaseId);

                        break;
                    case 5:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXSalesManBillReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                    case 11:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXWarehouseTransactionHeadrs.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                    case 12:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXSalesFuelReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                    case 14:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXSalesmanReturnsDetailsReport 14.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                    case 15:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXSalesmanReturnsHeadersReport 15.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);

                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                    case 19:
                        path = Server.MapPath("~") + @"Content\FastReport\19MagalatReportforSalesMan.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                             case 22:
                        path = Server.MapPath("~") + @"Content\FastReport\22SalesManCollection.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;case 24:
                        path = Server.MapPath("~") + @"Content\FastReport\24SalesDefferedsReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        //report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        //report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;
                         case 27:
                        path = Server.MapPath("~") + @"Content\FastReport\27SalesManAccountStateMent.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramters.SalesId);
                        report.Report.SetParameterValue("SalesId", Paramters.SalesId);
                        report.Report.SetParameterValue("AgentId", Paramters.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramters.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramters.DateTo);

                        break;

                    default:


                        break;



                }
                report.Width = Unit.Percentage(100);
                report.Height = Unit.Percentage(100);

                ViewBag.WebReport = report.GetHtml();
            }
            catch
            {

            }
            return View();
        }
        #endregion

        #region  قنوات البيع
        [FunctionFilter(key = "تقارير القنوات")]

        public ActionResult Agent()
        {
            loadViewBags("agent");
            return View();
        }
        [HttpPost]
        public ActionResult Agent(ReportParamters Paramter)
        {

            from = Paramter.DateFrom;
            to = Paramter.DateTo;
            agentid = Paramter.AgentId;
            reporttype = Paramter.ReportType;

            ViewBag.WebReport = null;
            loadViewBags("agent");

            try
            {

                string path = "";
                WebReport report = new WebReport();
                switch (Paramter.ReportType)
                {
                    case 4:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXAgentBillReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break; 
                    case 21:
                        path = Server.MapPath("~") + @"Content\FastReport\21MagalatReportforAgents.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;


                    default:
                        break;



                }
                report.Width = Unit.Percentage(100);
                report.Height = Unit.Percentage(100);

                ViewBag.WebReport = report.GetHtml();
            }
            catch
            {

            }

            return View();
        }

        #endregion

        #region الشركة
        [FunctionFilter(key = "تقارير الشركات")]
        public ActionResult Company()
        {
            loadViewBags("company");

            return View();
        }
        [HttpPost]
        public ActionResult Company(ReportParamters Paramter)
        {

            from = Paramter.DateFrom;
            to = Paramter.DateTo;
            baseId = Paramter.BaseId;
            reporttype = Paramter.ReportType;
            agentid = Paramter.AgentId;

            ViewBag.WebReport = null;
            loadViewBags("company");

            try
            {

                string path = "";
                WebReport report = new WebReport();
                switch (Paramter.ReportType)
                {
                    case 6:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXCompanyBillReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;


                    default:
                        break;



                }
                report.Width = Unit.Percentage(100);
                report.Height = Unit.Percentage(100);

                ViewBag.WebReport = report.GetHtml();
            }
            catch
            {

            }

            return View();
        }

        #endregion
        #region الفروع
        [FunctionFilter(key = "تقارير الشركات")]
        public ActionResult Branch(int branchId = 0, int reporttype = 0)
        {
            loadViewBags("branch");
            if (branchId != 0)
            {
                ViewBag.BaseId = branchId;
                ViewBag.autoOpen = true;
                ViewBag.reporttype = reporttype;
                var datenow = DateTime.Now;
                if (datenow.Year < 2000)
                {
                    HijriCalendar hijriCalendar = new HijriCalendar();

                    ViewBag.from = hijriCalendar.ToDateTime(datenow.Year, datenow.Month, datenow.Day, 0, 0, 0, 0).ToString("yyyy-MM-01");
                    ViewBag.to = hijriCalendar.ToDateTime(datenow.Year, datenow.Month, datenow.Day, 0, 0, 0, 0).ToString("yyyy-MM-dd");
                }
                else
                {
                    ViewBag.from = $"{datenow.Year}-{datenow.Month}-01";
                    ViewBag.to = $"{datenow.Year}-{datenow.Month}-{datenow.Day}";
                }
             
            }
            return View();
        }
        [HttpPost]
        public ActionResult Branch(ReportParamters Paramter)
        {

            from = Paramter.DateFrom;
            to = Paramter.DateTo;
            baseId = Paramter.BaseId;
            reporttype = Paramter.ReportType;
            agentid = Paramter.AgentId;

            ViewBag.WebReport = null;
            loadViewBags("branch");

            try
            {

                string path = "";
                WebReport report = new WebReport();
                switch (Paramter.ReportType)
                {
                    case 7:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXBranchBillReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                    case 16:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXBranchReturnsHeaderReport 16.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);

                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                    case 17:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXBranchReturnsDetailsReport 17.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);

                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                            case 20:
                        path = Server.MapPath("~") + @"Content\FastReport\20MagalatReportforBranches.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);

                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                            case 23:
                        path = Server.MapPath("~") + @"Content\FastReport\23BranchCollection.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);

                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                                   case 25:
                        path = Server.MapPath("~") + @"Content\FastReport\25BranchLastInvoice.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);

                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;


                    default:
                        break;



                }
                report.Width = Unit.Percentage(100);
                report.Height = Unit.Percentage(100);

                ViewBag.WebReport = report.GetHtml();
            }
            catch
            {

            }

            return View();
        }

        #endregion
        #region الشركة
        [FunctionFilter(key = "تقارير الاصناف")]
        public ActionResult Items()
        {
            loadViewBags("item");

            return View();
        }
        [HttpPost]
        public ActionResult Items(ReportParamters Paramter)
        {

            from = Paramter.DateFrom;
            to = Paramter.DateTo;
            baseId = Paramter.BaseId;
            reporttype = Paramter.ReportType;
            agentid = Paramter.AgentId;

            ViewBag.WebReport = null;
            loadViewBags("item");

            try
            {

                string path = "";
                WebReport report = new WebReport();
                switch (Paramter.ReportType)
                {
                    case 26:
                        path = Server.MapPath("~") + @"Content\FastReport\26netprofitbyitem.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("AgentId", Paramter.AgentId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;


                    default:
                        break;



                }
                report.Width = Unit.Percentage(100);
                report.Height = Unit.Percentage(100);

                ViewBag.WebReport = report.GetHtml();
               
            }
            catch
            {

            }

            return View();
        }

        #endregion

        #region مستخدمين الداشبوؤد
        [FunctionFilter(key ="تقارير الامناء والمحاسبين")]
        public ActionResult Safe()
        {
            loadViewBags("dashboarduser");
            return View();
        }

        [HttpPost]
        public ActionResult Safe(ReportParamters Paramter)
        {
            from = Paramter.DateFrom;
            to = Paramter.DateTo;
            baseId = Paramter.BaseId;
            reporttype = Paramter.ReportType;
            agentid = Paramter.AgentId;

            ViewBag.WebReport = null;
            loadViewBags("dashboarduser");

            try
            {

                string path = "";
                WebReport report = new WebReport();
                switch (Paramter.ReportType)
                {
                    case 8:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXMoneySafeTotals.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                    case 9:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXMoneySafeDetails.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                    case 10:
                        path = Server.MapPath("~") + @"Content\FastReport\XXXBinReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;
                    case 18:
                        path = Server.MapPath("~") + @"Content\FastReport\18XXXSettleReturnsReport.frx";
                        report.Report.Load(path);
                        report.Report.SetParameterValue("BaseId", Paramter.BaseId);
                        report.Report.SetParameterValue("DateFrom", Paramter.DateFrom);
                        report.Report.SetParameterValue("DateTo", Paramter.DateTo);


                        break;


                    default:
                        break;



                }
                report.Width = Unit.Percentage(100);
                report.Height = Unit.Percentage(100);

                ViewBag.WebReport = report.GetHtml();
            }
            catch
            {

            }

            return View();
        }
        #endregion
        void loadViewBags(string Page)
        {


            var datenow = TbiServer.Time(DateTime.Now);
            if (from == null)
                from = to = $"{datenow.Year}-{datenow.Month.ToString("D2")}-{datenow.Day.ToString("D2")}";




            ViewBag.ReportTypes = _reportTypes.Where(x => x.Page.Contains(Page));
            ViewBag.from = from;
            ViewBag.to = to;
            ViewBag.reporttype = reporttype;
            var baseselect = new List<Select>();
            
            ViewBag.Agents = JsonConvert.DeserializeObject<Response<List<Select>>>(_http.Get("/api/GetLastAgents?Parent=0 ")).Data;
            ViewBag.AgentId = agentid;


            if (Page.Contains("salesman"))
            {
                string userresponse = _http.Get("/api/Selector/GetUsers");
                List<Select> usrs = new List<Select>();
                usrs.Add(new Select() { Id = 0, Value = "كل المناديب" });
                usrs.AddRange(JsonConvert.DeserializeObject<Response<List<Select>>>(userresponse).Data);

                ViewBag.Users = usrs;
                ViewBag.salesid = salesid;
                ViewBag.baseid = baseId;
            }
            //if (Page.Contains("agent"))
            //{

         
            //}


            if (Page.Contains("company"))
            {
                baseselect.Add(new Select() { Id = 0, Value = "اختر الشركة" });
                baseselect.AddRange(_http.Get<Response<List<Select>>>("/api/Selector/GetCompanies").Data);
                ViewBag.Companies = baseselect;
                ViewBag.BaseId = baseId;
            }
            if (Page.Contains("branch"))
            {
                baseselect.Add(new Select() { Id = 0, Value = "اختر الفرع" });
                baseselect.AddRange(_http.Get<Response<List<Select>>>("/api/Selector/GetAllBranchesFromTable").Data);

                ViewBag.Branches = baseselect;
                ViewBag.BaseId = baseId;

            }
            if (Page.Contains("dashboarduser"))
            {
                baseselect.Add(new Select() { Id = 0, Value = "اختر الامين" });
                baseselect.AddRange(_http.Get<Response<List<Select>>>("/api/Selector/GetDashboardUsers").Data);

                ViewBag.Keepers = baseselect;
                ViewBag.BaseId = baseId;

            } 
            if (Page.Contains("item"))
            {
                baseselect.Add(new Select() { Id = 0, Value = "اخترالصنف" });
                baseselect.AddRange(_http.Get<Response<List<Models.Items_Tbl>>>("/api/Items/GetAllItemsFromTable").Data.Select(x=>new Select { Id = x.Record_ID , Value = x.ItemName}).ToList());

                ViewBag.Items = baseselect;
                ViewBag.BaseId = baseId;

            }


        }
        [HttpPost]
        public ActionResult Excel(ReportParamters Paramters)
        {



            string query = GetReportQuery(Paramters);
            //string reportname = 
            string name = _reportTypes.FirstOrDefault(x => x.Id == Paramters.ReportType).Name + " FROM " + Paramters.DateFrom + " TO " + Paramters.DateTo;
            return RedirectToAction("DownloadExcel", new { Query = query, Name = name });
        }

        public ActionResult DownloadExcel(string Query, string Name)
        {
            var res = _http.Get<byte[]>($"/Excel?Query={Query}");
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{Name}.xlsx");

        }

        public string GetReportQuery(ReportParamters param)
        {
            string q = "";
            if (param.ReportType == 1)
            {
                //            _reportTypes.Add(new SimpleClass{ Id = 1, Name = "تفيصليات الفواتير " });
                 q = $"exec XXReport1SaleManBillsWithDetails {param.SalesId} ,N'{param.DateFrom}',N'{param.DateTo}' , N'{param.Search}' , {param.AgentId}";
//                q = $@"select r.BillNo , r.Branch_id , r.BranchName , r.BillDate , 
//                    r.TotalAmountBeforDiscount	,r.TotalAmountAfterDiscount , r.Cash , r.Deferred,
//                    d.SR_No , d.Items , d.NumberOfUnits , d.UnitPrice , d.TotalPrice
//                    from Bill_Report_V r
//                    join bill_detiles_tbl d on d.billno = r.billno
//                    where r.BillNo is not null and r. BillDate between '{param.DateFrom}' and Concat('{param.DateTo}' , ' 23:59:59')  
// and (Sales_ID  in (select recordId from tblUSers 
//where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
//select recordId from agents_v where Baseroot = {param.AgentId} ) )) or {param.AgentId} =0  )
//                        ";

//                if (param.SalesId != 0)
//                {
//                    q += $@" and Sales_ID = {param.SalesId}";
//                }

//                if (param.Search != null && param.Search != "")
//                {
//                    q += $@"";
//                }
            }
            if (param.ReportType == 2)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $"select * from [dbo].[Expenses_V] Where (User_ID = {param.SalesId} or {param.SalesId} = 0 )and Add_date between  '{param.DateFrom}' and Concat('{param.DateTo}' , ' 23:59:59')" +
                    $@"

                        and ( User_ID in (select RecordId from tblUSers 
                        where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
                        select recordId from agents_v where Baseroot = {param.AgentId}
                        ) ) ) or {param.AgentId} = 0 )
                        ";

            }
            if (param.ReportType == 3)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@" select * from ZZ1ReportWareHouseRequests_V 
                         where Edit_date between  CONCAt('{param.DateFrom}' , ' 00:00:00') and   CONCAt('{param.DateTo}' , ' 23:59:59') 
                         and( IsserId =  {param.SalesId}  or ReceiverId = {param.SalesId})
                         and ( RequstNo  = {param.BaseId}  or {param.BaseId} = 0)
                        ";

            }
            if (param.ReportType == 4)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from Bill_Report_V where BillNo <>0 and ComAgentId ={param.AgentId}  and billdate between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') ";

            }
            if (param.ReportType == 5)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from Bill_Report_V where BillNo <>0 and (Sales_ID ={param.SalesId} or {param.SalesId} =0 )  and billdate between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') 
and ( Sales_ID in (select RecordId from tblUSers 
where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
select recordId from agents_v where Baseroot =  {param.AgentId}
) ) ) or {param.AgentId} = 0 )
                    ";

            }
            if (param.ReportType == 6)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from Bill_Report_V where BillNo <>0 and
                    (ComId ={param.BaseId} or {param.BaseId }= 0) 
and  ComAgentId = {param.AgentId}
                    and billdate between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') ";

            }

            if (param.ReportType == 7)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from Bill_Report_V where BillNo <>0 and ( Branch_Id ={param.BaseId} or {param.BaseId } = 0 ) and ComAgentId = {param.AgentId} and billdate between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') ";

            }

            if (param.ReportType == 8)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"SELECT  * FROM ReportSafeMoneyTotalReport_V where 
                (KeeperId = '{param.BaseId}' or {param.BaseId} = 0 ) and
                ClosingDay between '{param.DateFrom}' and CONCAT('{param.DateFrom}' , ' 23:59:59')   order by Closingday desc";

            }
            if (param.ReportType == 9)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"SELECT *  FROM ReportSafeMoneyDetailsReport_V where
                       (KeeperId = {param.BaseId} or {param.BaseId} =0 ) and  Date between '{param.DateFrom}' and CONCAT('{param.DateTo}' , ' 23:59:59') order by  Date desc
                        ";

            }
            if (param.ReportType == 10)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select Id , UserId , UserName , Message , DateTime , SDate , STime,
                                Case 
                                When DeleteType ='expenses' Then N'مصروف'
                                When DeleteType ='bill' Then N'فاتورة'
                                When DeleteType ='collection' Then N'تحصيل'

                                Else '' End As DeleteType

                                from UsersDeletion_tbl where 
                                (USerId = {param.BaseId} or  {param.BaseId} = 0 )and 
                                DateTime between CONCAT('{param.DateFrom}' , ' 00:00:00' ) and  CONCAT('{param.DateTo}' , ' 23:59:59' )  
                                order by DateTime desc ";

            }
            if (param.ReportType == 11)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"  select * from Warehouse_Tran_V 
                         where 
                        Date between  CONCAt('{param.DateFrom}' , ' 00:00:00') and   CONCAt('{param.DateTo}' , ' 23:59:59') 
                         and( SalesId = {param.SalesId}  or  {param.SalesId} = 0 )
                        order by TranNo  asc";

            }

            if (param.ReportType == 12)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from FuelReport_V 
                    where (USERID = {param.SalesId} or {param.SalesId} = 0)
                    and Date between '{param.DateFrom}' and CONCAT('{param.DateTo}' , ' 23:59:59')
                    order by YEAR desc , MOnth desc , Day desc";

            }
            if (param.ReportType == 14)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from ReturnReportForSalesman_V where ( SalesID={param.SalesId} or {param.SalesId} = 0 ) 
                and Date between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') 
and ( SalesId in (select RecordId from tblUSers 
where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
select recordId from agents_v where Baseroot = {param.AgentId}
) ) ) or {param.AgentId} = 0 )
";

            }
            if (param.ReportType == 15)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select SalesId ,SalesName ,ItemId, ItemName , Concat(Sum(Weight) , ' KG') WeightS
                            from ReturnReportForSalesman_V

                             where ( SalesID={param.SalesId} or {param.SalesId} = 0 ) 

                            and Date between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') 
                                and ( SalesId in (select RecordId from tblUSers 
                                where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
                                select recordId from agents_v where Baseroot = {param.AgentId}
                                ) ) ) or {param.AgentId} = 0 )

                             group by SalesId ,SalesName ,ItemId, ItemName 
                            order by SalesId  asc ";

            }
            if (param.ReportType == 16)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select ItemId , ItemName , BranchId , BranchName , CONCAT(Sum(Weight) , ' Kg' ) WightS from ReturnReportForBranch_V
                            where 
                            (BranchId = {param.BaseId} or {param.BaseId} = 0 ) and
                            Date between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59') 
                            and Agent = {param.AgentId}
                            group by  ItemId , ItemName , BranchId , BranchName 
                            order by BranchId  ";

            }
            if (param.ReportType == 17)
            {
                //              _reportTypes.Add(new SimpleClass { Id = 2, Name = "تفيصليات المصاريف " });
                q = $@"select * from ReturnReportForBranch_V where ( BranchId = {param.BaseId} or {param.BaseId} = 0 ) 
                        and Date between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59')
                        and Agent = {param.AgentId}
            ";

            }
              if (param.ReportType == 18)
            {
   
                q = $@"
                        select * from SettledReturnsReport_V 
                        where
                        Date between  Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59')   
                        and (UserId = {param.BaseId}   or  {param.BaseId} =0 ) 
                        order by Date ";

            }
                if (param.ReportType == 19)
            {
   
                q = $@"
                       select * from [Bill_Details_Report_V] 
                        where DisSpecialPrice = 1
                        and ( Sales_ID = {param.BaseId} or {param.BaseId} =0 )
                        and BillDate between cast(concat('{param.DateFrom}' , ' 00:00:00') as datetime) and cast( concat('{param.DateTo}' , ' 23:59:59') as datetime)
                        and ( Sales_ID in (select RecordId from tblUSers 
                        where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
                        select recordId from agents_v where Baseroot = {param.AgentId}
                        ) ) ) or {param.AgentId} = 0 )
                        ";

            } 
            if (param.ReportType ==20)
            {
   
                q = $@"
                       select * from [Bill_Details_Report_V] 
                        where DisSpecialPrice = 1
                        and ( Branch_id = {param.BaseId} or {param.BaseId} =0 )
                        and ComAgentId = {param.AgentId} 
                        and BillDate between cast(concat('{param.DateFrom}' , ' 00:00:00') as datetime) and cast( concat('{param.DateTo}' , ' 23:59:59') as datetime)
                        and ComAgentId = {param.AgentId}
                        ";

            }  
            if (param.ReportType == 21)
            {
   
                q = $@"
                       select * from [Bill_Details_Report_V] 
                        where DisSpecialPrice = 1
                        and ( ComAgentId = {param.BaseId} or {param.BaseId} =0 )
                        and BillDate between cast(concat('{param.DateFrom}' , ' 00:00:00') as datetime) and cast( concat('{param.DateTo}' , ' 23:59:59') as datetime)
                        ";

            }


             if (param.ReportType == 22)
            {
   
                q = $@"
                       select Bill,SalesmanName,BranchName,Add_dateString,CollectionAmount,BillCash,TotalPaymet from collection_V
                            where  (SaleManId={param.SalesId} or {param.SalesId} = 0)  and Add_date between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59')

                                and ( SaleManId in (select RecordId from tblUSers 
                                where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
                                select recordId from agents_v where Baseroot = {param.AgentId}
                                ) ) ) or {param.AgentId} = 0 )
                                and  isnull(TotalPaymet , 0)  > 0
                                order by Add_date 
                                                             ";

            }
              if (param.ReportType == 23)
            {
   
                q = $@"
                       select Bill,SalesmanName,BranchName,Add_dateString ,Old_RemainingAmount,RemainingAmount,CollectionAmount,BillCash,TotalPaymet from collection_V
                            where  (BranchId={param.BaseId} or {param.BaseId} = 0)  and Add_date between Concat('{param.DateFrom}' , ' 00:00:00') and   Concat('{param.DateTo}' , ' 23:59:59')
                             and BranchId In(
                            select record_Id from branch_tbl where comid in (select Record_ID from com_tbl where CompanyType = {param.AgentId} ) )
                        order by Add_date 
                             ";

            }
                if (param.ReportType == 24)
            {
   
                q = $@"
                     select * from DefferdAndLaters_V where SalesId  in (select RecordId from TblUsers  where  (RecordId = {param.SalesId} or {param.SalesId}  = 0) ) 
and ( SalesId in (select RecordId from tblUSers 
where Distributor_Group_ID in (select Record_Id from Distributor_Group_Tbl where agentId in (
select recordId from agents_v where Baseroot = {param.AgentId}
) ) ) or {param.AgentId} = 0 )
order by SalesId asc, Remaining desc  ";

            }
   if (param.ReportType == 25)
            {
   
                q = $@"
                    exec branch_no_show_pro '{param.DateTo}',{param.AgentId} , {param.BaseId} ";

            }
     if (param.ReportType == 26)
            {
   
                q = $@"
exec usp_netprofitbyitem '{param.DateFrom}' ,  '{param.DateTo}',  '{param.BaseId}' ";

            }

      if (param.ReportType == 27)
            {

                q = $@"
                exec CalcThePocketTOSalesMan_pro  {param.SalesId} , '{param.DateFrom}',  '{param.DateTo}'";
            }










            return q;
        }
    }
}