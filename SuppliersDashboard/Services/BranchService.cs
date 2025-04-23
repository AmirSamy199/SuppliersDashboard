using Newtonsoft.Json;
using SuppliersDashboard.BL.Model;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SuppliersDashboard.Services
{
    public class BranchService
    {
        private HttpClientHelper htp = new HttpClientHelper();
        /// Get Branch Report Details 
        /// 
        public Response<Branch_Info_V> GetBranchReportDetails (int BranchID)
        {
            string EndPoint = $"/api/Customer/GetBranchReportDetails?BranchID={BranchID}";
            string response = htp.Get(EndPoint);
            return JsonConvert.DeserializeObject<Response<Branch_Info_V>>(response);
        } 
        public Response<ComVM> GetCompanyDataByID(int Id)
        {
            string EndPoint = $"/api/Company/GetCompaniesById?Id={Id}";
            string response = htp.Get(EndPoint);
            return JsonConvert.DeserializeObject<Response<ComVM>>(response);
        } 
        public Response<string> UpdateCompany(ComVM Company)
        {
            string EndPoint = $"/api/Company/UpdateComData";
            var response = htp.Post<Response<string> , ComVM>(EndPoint , Company);
            return response; 
        }
         public Response<List<Branch_Info_V>> GetAllBranchReportDetails (int RegionID , int ComID , int TypeID )
        {
            string EndPoint = $"/api/Customer/GetAllBranchesDetails?RegionID={RegionID}&ComID={ComID}&TypeID={TypeID}";
            string response = htp.Get(EndPoint);
            return JsonConvert.DeserializeObject<Response<List<Branch_Info_V>>>(response);
        }



        public Response<string> AddNewOpeningbalance(AddOpenningBalanceInfo model)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (HttpClient htttp = new HttpClient())
            {
                string response = htttp.PostAsync(Setting.Host + "/api/Customer/AddOpeningBalance", body).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Response<string>>(response);
            }
        }

        
    }

    public class ComVM
    {
        public int Record_ID { get; set; }
        public string CompanyName { get; set; }
        public int CompanyType { get; set; }
        public int PriceListId { get; set; }
     
    }
}