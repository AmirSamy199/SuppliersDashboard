using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Repository;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class MarketController : BaseController
    {
        private HttpClientHelper http = new HttpClientHelper();
        private Getter get = new Getter();
        
        [FunctionFilter(key = "صفحة العملاء")]
        public ActionResult Index()
        {
            ViewBag.Companies = new SelectList("","اختر الشركة ");
            string response = http.Get("/api/Company/GetCompaniesToFillSelect");

            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);

                if (deContent.State == 1)
                {
                    ViewBag.Companies  = new SelectList(deContent.Data, "Id", "Value");
                }
       
            return View();
        }

        public ActionResult LoadData(int ComID)
        {
            var Data = new List<SelectBranch>();
            string response = http.Get($"/api/Company/GetCompanyBranches?ComID={ComID}");
            Response<List<SelectBranch>> result = JsonConvert.DeserializeObject<Response<List<SelectBranch>>>(response);
            if(result.State == 1 )
                Data = result.Data;
          return Json(new { data = result.Data });
                
         
        }
        public ActionResult ViewChain(int ComID , string ComName)
        {
            ViewBag.ComID = ComID;
            ViewBag.ComName = ComName.Replace("'","");
          ///  string UpdateAllSettelet = http.Get($"/api/Company/UpdateAllSetteledOfBillToBeReadyToViewChain?ComID={ComID}");
            return View();
        }
        [HttpPost]
        public JsonResult GetViewChain (int ComID)
        {
            string datefrom = "2000/01/01";
            string dateto = "2050/12/31";
            string response = http.Get($"/api/Company/GetViewBillsChain?ComID={ComID}");
            Response<List<kashfSelsela>> result = JsonConvert.DeserializeObject<Response<List<kashfSelsela>>>(response);
            if(result.Data!=null && result.Data.Count >0)
            {

              result.Data = result.Data.OrderBy(s=>s.Add_Date).ToList();
             datefrom = result.Data.FirstOrDefault().Add_Date.Year.ToString() + "/" + result.Data.FirstOrDefault().Add_Date.Month.ToString() + "/1";
             dateto = result.Data.LastOrDefault().Add_Date.Year.ToString() + "/" + result.Data.LastOrDefault().Add_Date.Month.ToString() + "/" + DateTime.DaysInMonth(result.Data.LastOrDefault().Add_Date.Year, result.Data.LastOrDefault().Add_Date.Month);
            }
                
                return Json(new { data = result ,datefrom = datefrom , dateto = dateto});
        }

        [HttpGet]
        public ActionResult AccountStatement (int BranchID , string BranchName )
        {
            ViewBag.BranchName= BranchName.Replace("\"" , "").Replace("'","");
            ViewBag.BranchID = BranchID;
            return View();
        }
        [HttpPost]
        public JsonResult GetAccountStatement(int BranchID)=> Json(new { data = get.GetCustomerStatement(BranchID) });

        [HttpGet]
        public ActionResult Details(int MarketID, int SupID)
        {
            ViewBag.SupID = SupID;
            ViewBag.MarketID = MarketID;
            return View();
        }

        public ActionResult LoadDetailsTable(int MarketID, int SupID)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + $"/api/Market/GetAllBillsByMarketID?MarketID={MarketID}&SupID={SupID}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var deContent = JsonConvert.DeserializeObject<DetailsVM>(content);

                if (deContent.State == 1)
                {
                    var Data = deContent.data;
                    var numberOfPages = Math.Ceiling((decimal)deContent.data.Count() / 20);
                    return Json(new { data = Data, Pages = numberOfPages });
                }
            }
            return Json(new { data = "" });
        }
    }
}