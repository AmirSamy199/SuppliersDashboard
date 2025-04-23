using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Services
{
    public class DistributorService
    {
        public Response<List<SimpleClass>> GetDistriburors()
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetDistributorsGroups").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<List<SimpleClass>> decontent = JsonConvert.DeserializeObject<Response<List<SimpleClass>>>(content);
                return decontent;
               
            }
        }
    }
}