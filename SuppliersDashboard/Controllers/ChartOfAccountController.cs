using Newtonsoft.Json;
using ScoposERB.Models;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class ChartOfAccountController : Controller
    {
        // GET: ChartOfAccount
        Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
        public ActionResult Index()
        {

            //users
            
            string Users = HTTP.Get("/api/Selector/GetUsers");
            ViewBag.Users = JsonConvert.DeserializeObject<Response<List<Select>>>(Users).Data;

            // Treasure
            string Treasury= HTTP.Get("/api/ChartOfAccount/GetTreasurys");
            ViewBag.Treasury= JsonConvert.DeserializeObject<Response<List<Select>>>(Treasury).data;
            // 

            return View();
        }

        [HttpGet]
        public ActionResult GetAllAcount(char AccountType)
        {
           
                string url = $"/api/ChartOfAccount/GetAllAcounts?AccountType={AccountType}";
                var res = HTTP.Get<Response<List<Select>>>(url);
                return Json(new { data = res }, JsonRequestBehavior.AllowGet);
           
           
        }

        [HttpPost]
        public ActionResult SubmitTransactionTreasury(AccountTransaction trransaction)
        {

            var User = Cokie.UserGet();
            trransaction.Editor = User.Id;
            //model.Editor = User.Id;
            StringContent requestbody = new StringContent(JsonConvert.SerializeObject(trransaction), Encoding.UTF8, "application/json");
            using (HttpClient htp = new HttpClient())
            {
                string res = htp.PostAsync(Setting.Host + "/api/ChartOfAccount/SubmitAccountTransaction", requestbody).Result.Content.ReadAsStringAsync().Result;
                Response<string> Resualt = JsonConvert.DeserializeObject<Response<string>>(res);
                
                return Json(new { msg = Resualt.Message, State = Resualt.State });
            }
        }

        public ActionResult AllAccountsCharts()
        {
            string url = $"/api/ChartOfAccount/GetAllAcounts?AccountType=T";
            var res = HTTP.Get<Response<List<ChartAccounts>>>(url);
            return View(res.data);
        }

        [HttpPost]
        public ActionResult ChangeActiveAccount(int AccountId, int IsActive)
        {
            string url = $"/api/ChartOfAccount/SubmitChangeAccountActive?AccountId={AccountId}&IsActive={IsActive}";
            var res = HTTP.Get<Response<List<string>>>(url);
            return Json(new { data = res });

        }

        [HttpGet]
        public ActionResult AddNewAccount()
        {
            return PartialView("_addAccount");
        }
        [HttpPost]
        public ActionResult SubmitAddAccount(ChartAccounts account)
        {
            StringContent requestbody = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
            using (HttpClient htp = new HttpClient())
            {
                string res = htp.PostAsync(Setting.Host + "/api/ChartOfAccount/SubmitAddNewAccount", requestbody).Result.Content.ReadAsStringAsync().Result;
                Response<string> Resualt = JsonConvert.DeserializeObject<Response<string>>(res);

                return Json(new { msg = Resualt.Message, State = Resualt.State });
            }

        }
        
        public ActionResult AccountsSuppliers()
        {
            string url = $"/api/ChartOfAccount/GetAcountOfSuppliers";
            var res = HTTP.Get<Response<List<AccountSuppliers>>>(url);
         
            return View(res.data);
        }



        public ActionResult CashTreasury()
        {
            string url = $"/api/ChartOfAccount/CashTreasury";
            var res = HTTP.Get<Response<List<CashTreasury>>>(url);
            List<CashTreasury> Cash = res.data;
            ViewBag.Income = Cash.Where(x => x.DebitAmount == 0);
            ViewBag.OutCome = Cash.Where(x => x.CreditAmount == 0);
            ViewBag.Cash = Cash.Sum(x => x.CreditAmount);
            ViewBag.OutCash=Cash.Sum(x =>x.DebitAmount);

            return View();
        }



    }
}