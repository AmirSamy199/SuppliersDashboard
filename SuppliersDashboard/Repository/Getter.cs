using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Repository
{
    public class Getter
    {
        private Helper.HttpClientHelper http = new Helper.HttpClientHelper();
        public Response<List<SelectCustomer_Statement_Pro>> GetCustomerStatement(int CustID) //كشف حساب عميل 
        {
            string response = http.Get($"/api/Procedures/SelectCustomer_Statement_Pro?CustID={CustID}");
            Response<List<SelectCustomer_Statement_Pro>> result = JsonConvert.DeserializeObject<Response<List<SelectCustomer_Statement_Pro>>>(response);
            return result;
        }
        public Response<List<SelectAllDebts_Pro>> GetCustomerDebits(int UserID = 0) //مديونيات   
        {
            string response = http.Get($"/api/Procedures/SelectAllDebts_Pro?UserID={UserID}");
            Response<List<SelectAllDebts_Pro>> result = JsonConvert.DeserializeObject<Response<List<SelectAllDebts_Pro>>>(response);

            return result;
        }


        public Response<AllDistributorDay> DistributorSalesMonth(int UserID = 0)
        {
            string response = http.Get($"/api/DistributorV2/GetAllDayDataForDistributors?UserId={UserID}&DateFrom=*&DateTo=*");
            Response<AllDistributorDay> result = JsonConvert.DeserializeObject<Response<AllDistributorDay>>(response);

            return result;
        }
        public decimal GetUserMonthlyTarget(int UserID = 0)
        {
            string response = http.Get($"/api/DistributorV2/GetSalesMonthlyTarget?SalesId={UserID}");
            Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response);
            return Decimal.Parse(res.Data);
        }
        public int GetUserDistributorGroupId(int UserID = 0)
        {
            string response = http.Get($"/api/DistributorV2/GetSalesMonthlyTarget?SalesId={UserID}");
            Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response);
            return Int32.Parse(res.Message);
        }
        public Response<List<SimpleClass>> GetDistributorGroups()
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetDistributorsGroups").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<SimpleClass>> decontent = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(content);

                return decontent;

            }

        }
        public Response<string> EditUserDetails(SaleManData Model)
        {
            string route = $"/api/DistributorV2/EditUserDetails";
            var res = http.Post<Response<string>, SaleManData>(route, Model);

            return res;
        }
        public Response<string> EditUserDetails1(HR_Employee_TBLvm Model)
        {
            string route = $"~/api/Employee/Index1";
            var res = http.Post<Response<string> , HR_Employee_TBLvm>(route , Model);

            return res;
        }
        public Response<string> EditDisGroupDetails(SaleManData Model)
        {
            string route = $"/api/DistributorV2/EditDisGroupDetails";
            var res = http.Post<Response<string> , SaleManData>(route , Model);

            return res;
        }
       
        public Response<SaleManData> GetSalesManSetting(int SalesId)
        {
            string url = $"/api/DistributorV2/GetSalesManSetting?SalesId={SalesId}";
            return http.Get<Response<SaleManData>>(url);
        } 
        public Response<SaleManData> GetDisGroupSetting(int GroupId)
        {
            string url = $"/api/DistributorV2/GetDisGroupSetting?GroupId={GroupId}";
            return http.Get<Response<SaleManData>>(url);
        }

    }
}