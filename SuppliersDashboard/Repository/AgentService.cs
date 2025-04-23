using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SuppliersDashboard.Repository
{
    public class AgentService
    {
        public Response<string> AddAgent(string Name, int ParentId)
        {
            var model = new { Name = Name, ParentId = ParentId };
            StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            string endpoint = Setting.Host + "/api/AddAgent";
            using (HttpClient htp = new HttpClient())
            {
                string response = htp.PostAsync(endpoint, body).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Response<string>>(response);
            }
        }

        public Response<string> EditAgent(string name,int id)
        {
            string endpoint = Setting.Host + $"/api/EditAgentName?AgentId={id}&name={name}";
            using (HttpClient htp = new HttpClient())
            {
                string response = htp.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
                    
                return JsonConvert.DeserializeObject<Response<string>>(response);
            }

        }
    }
}