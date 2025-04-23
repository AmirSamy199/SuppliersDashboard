using Newtonsoft.Json;
using ScoposERB.Models;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.Services;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
using Branch_tbl = SuppliersDashboard.ViewModels.Branch_tbl;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class BranchController : BaseController
    {


        Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
        private BranchService BRANCHSERVICE = new BranchService();
        private Getter get = new Getter();
        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }
        [FunctionFilter(key = "صفحة اضافة عميل")]

        public ActionResult AddBranch()
        {
            Model4 obj = new Model4();
            string response = HTTP.Get("/api/Company/GetCompaniesToFillSelect");
            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);
            ViewBag.Companies = deContent.Data;
            string response2 = HTTP.Get("/api/Selector/GetRanges");
            ViewBag.Ranges = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response2).Data;
            string response3 = HTTP.Get("/api/Selector/AllGetDistributorUsers");
            ViewBag.Diss = JsonConvert.DeserializeObject<Response<List<Select>>>(response3).Data;
            string Res = HTTP.Get("/api/Selector/GetCompanmyTypes");
            var vat = obj.VAT_tbl.Where(x=>x.ForCustomerOrItems== "C").ToList();
            ViewBag.vat = vat;

            ViewBag.CompanyTypes = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(Res).Data;


            string priceLists = HTTP.Get("/api/Selector/GetPricesLists");
            ViewBag.PricesLists = JsonConvert.DeserializeObject<Response<List<Select>>>(priceLists).Data;
            return View();
        }

        
      
        [FunctionFilter(key = "صفحة تقرير بيانات العملاء")]

        public ActionResult BranchDetails() {
            string response = HTTP.Get("/api/Company/GetCompaniesToFillSelect");
            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);
            ViewBag.Companies = deContent.Data;
            string response2 = HTTP.Get("/api/Selector/GetRanges");
            ViewBag.Ranges = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(response2).Data;
            // BranchService BRANCHSERVICE = new BranchService();

            string Res = HTTP.Get("/api/Selector/GetCompanmyTypes");
          
            ViewBag.CompanyTypes = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(Res).Data;
            return View();
        }


        [HttpPost]
        public JsonResult GetBranchesDetailsJson(int RegionID , int ComID , int TypeID)
        {
            return Json(new { data = BRANCHSERVICE.GetAllBranchReportDetails(RegionID, ComID , TypeID) });
        }
        [FunctionFilter(key = "صفحة اضافة رصيد افتتاحي")]
        public ActionResult AddOpeningBalance()
        {
            string response = HTTP.Get("/api/Company/GetCompaniesToFillSelect");
            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);
            ViewBag.Companies = deContent.Data;
            return View();
        }
        [HttpPost]
        public JsonResult AddOpeningBalanceJson(AddOpenningBalanceInfo model)
        {
            var Us = Cokie.UserGet();
            model.UserID = Us.Id.ToString(); 
            return Json (new { data = BRANCHSERVICE.AddNewOpeningbalance(model) });
        }
        [HttpPost]
        public JsonResult SubmitAddbranch(Branch_tbl model)
        {
            using (HttpClient htp = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string response = htp.PostAsync(Setting.Host + "/api/Company/AddBranch", body).Result.Content.ReadAsStringAsync().Result;
                Response<string> result = JsonConvert.DeserializeObject<Response<string>>(response);
                return Json(new { data=result});
            }
        }
        [HttpPost]
      
        public JsonResult SubmitAddCompany(string Name , int Type, string phone, string taxno, string REGIONCITY, string street, string cuntry, string R_GOVERNATE1, string buildnu, int TaxId,int pricelistid)
        {
            var model = new { CompanyName = Name , CompanyType = Type, Telephone1= phone, TXA_ID = TaxId, R_country = cuntry, R_GOVERNATE = R_GOVERNATE1, R_STREET=street, R_BUILDINGNUMBER = buildnu, R_Type = 'B', eta_TAX_nO =taxno,  PriceListId = pricelistid };

            using (HttpClient htp = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string response = htp.PostAsync(Setting.Host + "/api/Company/AddCompany", body).Result.Content.ReadAsStringAsync().Result;
                Response<dynamic> result = JsonConvert.DeserializeObject<Response<dynamic>>(response);
                return Json(new { data = result });
            }

        } 
        [HttpPost]
        public JsonResult SubmitAddCompanyType(string Name )
        {
            string res = HTTP.Get($"/api/Selector/AddCompanyType?TypeName={Name}");

                return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(res) });
           

        }
        [HttpGet]
        [FunctionFilter(key = "صفحة تعديل بيانات عميل")]

        public ActionResult EditBranchData()
        {
            string responserange = HTTP.Get("/api/Selector/GetRanges");
            string branchresponse = HTTP.Get("/api/Selector/GetAllBranchesFromTable");
            string userresponse = HTTP.Get("/api/Selector/GetUsers");
            string response3 = HTTP.Get("/api/Selector/AllGetDistributorUsers");
            string response4 = HTTP.Get("/api/Selector/GetWeekDays");
            string Res = HTTP.Get("/api/Selector/GetCompanmyTypes");
            ViewBag.CompanyTypes = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(Res).Data;
            ViewBag.Ranges = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(responserange).Data;
            ViewBag.Branches = JsonConvert.DeserializeObject<Response<List<Select>>>(branchresponse).Data;
            ViewBag.Users = JsonConvert.DeserializeObject<Response<List<Select>>>(userresponse).Data;
            ViewBag.Diss = JsonConvert.DeserializeObject<Response<List<Select>>>(response3).Data;
            ViewBag.WeekDays = JsonConvert.DeserializeObject<Response<List<Select>>>(response4).Data;
            string priceLists = HTTP.Get("/api/Selector/GetPricesLists");
            ViewBag.PricesLists = JsonConvert.DeserializeObject<Response<List<Select>>>(priceLists).Data;
            string response = HTTP.Get("/api/Company/GetCompaniesToFillSelect");
            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);
            ViewBag.Companies = deContent.Data;
            return View();
        }
        [FunctionFilter(key = "صفحة تعديل بيانات عميل")]

        public ActionResult EditoCompanyData()
        {

            string response = HTTP.Get("/api/Company/GetCompaniesToFillSelect");
            Response<IEnumerable<Select>> deContent = JsonConvert.DeserializeObject<Response<IEnumerable<Select>>>(response);
            ViewBag.Companies = deContent.Data;
            string priceLists = HTTP.Get("/api/Selector/GetPricesLists");
            ViewBag.PricesLists = JsonConvert.DeserializeObject<Response<List<Select>>>(priceLists).Data;
            string Res = HTTP.Get("/api/Selector/GetCompanmyTypes");
            ViewBag.CompanyTypes = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(Res).Data;
            return View();
        }
        [HttpPost]
        public JsonResult GetCompanyDataByID(int Id)
        {
            var data = BRANCHSERVICE.GetCompanyDataByID(Id);
            return Json(new { data = data});
        } 
        [HttpPost]
        public JsonResult SubmitEditCompanyData(ComVM model)
        {
            return Json(new { data = BRANCHSERVICE.UpdateCompany(model) });
        }
        [HttpPost]
        public JsonResult GetBranchReportDetails(int BranchId)
        {
            return Json(new { data = BRANCHSERVICE.GetBranchReportDetails(BranchId)});
        }
        [HttpPost]
        public JsonResult SubmitEditBranch(Branch_tbl model)
        {
            var body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (HttpClient htp = new HttpClient())
            {
                string content = htp.PostAsync($"{Setting.Host}/api/Customer/EditBranchDetails", body).Result.Content.ReadAsStringAsync().Result;

            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(content) });
            }

        }
        [HttpPost]
        public JsonResult SubmitEditBranchDefaultDays(int BranchId , int First , int Second , int Third)
        {
            Models.User cs = Cokie.UserGet();
            string Response = HTTP.Get($"/api/Customer/EditBranchDefaultDays?BranchId={BranchId}&FirstDay={First}&SecondDay={Second}&ThirdDay={Third}&Editor={cs.Id}");
            return Json(new { data = JsonConvert.DeserializeObject<Response<string>>(Response)}); 
        }
        public ActionResult AddEditAgent() => View();
        [HttpPost]
        [Filters.MyAuthFilter]

        public JsonResult GetAgents (int Parent)
        {
            List<AgentSelect> s = (new SelectService()).GetAgentsSelect(Parent);
            return Json(new { data = s });
        }
        public ActionResult EditDisGroupPartial(int GroupId)
        {
            ViewBag.Id = GroupId;
           
            var result = get.GetDisGroupSetting(GroupId);
            
          ViewBag.Data = result.Data;
            

            return PartialView("_EditDisGroup");
        }
        [HttpPost]
        public JsonResult SubmitEditDisGroup(SaleManData Model)
        {
            var res = get.EditDisGroupDetails(Model);
            return Json(new { data = res });
        }

        [HttpPost]
        public JsonResult GetGroupDistributors(int Id)
        {
            List<Select> s = (new SelectService()).GetGroupDistributors(Id);
            return Json(new { data = s });
        }
        [HttpPost]
        [Filters.MyAuthFilter]

        public JsonResult GetAgentGroups(int Id)
        {
            List<Select> s = (new SelectService()).GetAgentGroups(Id);
            return Json(new { data = s });
        } 
        [HttpPost]
        public JsonResult DeleteAgent(int Id)
        {
            string s = (new SelectService()).DeleteAgent(Id);
            return Json(new { data = s });
        }
        [HttpPost]
        public JsonResult SubmitAddAgent(string Name ,int ParentId)
        {

            var instance = new AgentService();
            var response = instance.AddAgent(Name, ParentId); 
            return Json(response);
        }

        public JsonResult SubmitEditAgent(string Name, int Id)
        {
            var instance = new AgentService();
            var response = instance.EditAgent(Name, Id);
            return Json(response);
        }
    }
}