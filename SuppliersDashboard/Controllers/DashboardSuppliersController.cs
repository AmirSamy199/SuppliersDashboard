using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using SuppliersDashboard.ViewModels.ReportVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class DashboardSuppliersController : Controller
    {
        private HttpClient htp = new HttpClient();
        // GET: DashboardSuppliers
        //desgin reqest
        public ActionResult Request_online()
        {
           

            return View("ojd");


        }

        public ActionResult Index()
        {
               var response = htp.GetAsync(Setting.Host + "/api/KPIS/HeaderCountAnalysis").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<AnalysisSuppliersHead> AnalysisSuppliersHead = JsonConvert.DeserializeObject<Response<AnalysisSuppliersHead>>(content);

                return View(AnalysisSuppliersHead.Data);
            
       
        }

        [HttpPost]
        public ActionResult GetMostOrLessCountOrPriceItems(int Status,int StatusSales) {

            // Status For Ordering (0)-DESC  (1)-ASC
            // Status For Ordering
            // StatusSales For Sum By Count (1) Or Sum By Total Price(1) Items
            var response = htp.GetAsync(Setting.Host + $"/api/KPIS/SalesOrCountItems?Status={Status}&StatusSales={StatusSales}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<AnalysisGenere>> SalesOrCountItem = JsonConvert.DeserializeObject<Response<List<AnalysisGenere>>>(content);

                return Json(new { data= SalesOrCountItem });
                       
        }

        public ActionResult GetMostOrLessSalesForBranches(int Status,string year)
        {
            
                var response = htp.GetAsync(Setting.Host + $"/api/KPIS/SalesBranchesAnalysis?Status={Status}&Year={year}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<AnalysisGenere>> SalesBrances = JsonConvert.DeserializeObject<Response<List<AnalysisGenere>>>(content);

                return Json(new { data = SalesBrances });
           
        }
        [HttpPost]
        public ActionResult GetSalesAndCollectDistributor(int Status,string Year)
        {
            // Status For Ordering (0)-DESC  (1)-ASC
            // StatusSales For Sum By SalesAmount (0) Or Sum By MoneyTakeFromBranch (1)For Distributor
            var response = htp.GetAsync(Setting.Host + $"/api/KPIS/SalesDistributorAnalysis?Status={Status}&Year={Year}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Response<List<AnalysisGenere>> SalesDistributor= JsonConvert.DeserializeObject<Response<List<AnalysisGenere>>>(content);

            return Json(new { data = SalesDistributor });
        }

        [HttpPost]
        public ActionResult SelectAllDebtsForDistributor(int UserId)
        {

            var response = htp.GetAsync(Setting.Host + $"/api/Procedures/SelectAllDebts_Pro?UserID={UserId}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Response<List<SelectAllDebts_Pro>> SalesDistributor = JsonConvert.DeserializeObject<Response<List<SelectAllDebts_Pro>>>(content);
             
            return Json(new { data = SalesDistributor });
        }
    }
}