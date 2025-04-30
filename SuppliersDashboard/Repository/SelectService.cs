using Aspose.Cells;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SuppliersDashboard.Repository
{
    public class SelectService
    {
        private HttpClientHelper htp = new HttpClientHelper();

        public List<AgentSelect> GetAgentsSelect(int Parent = -1)
        {
            string endpoint;
            endpoint = Parent == -1 ? "/api/GetLastAgents" : $"/api/GetLastAgents?Parent={Parent}";
            string response = htp.Get(endpoint);
            return JsonConvert.DeserializeObject<Response<List<AgentSelect>>>(response).Data; 
        }
        public List<Select> GetGroupDistributors(int Id)
        {
            string endpoint = $"/api/getDistrubuterOfGroup?GroupId={Id}";
          
            string response = htp.Get(endpoint);
            return JsonConvert.DeserializeObject<Response<List<Select>>>(response).Data; 
        } 
        public List<Select> GetAgentGroups(int Id)
        {
            string endpoint = $"/api/GetGroupsOfAgent?AgentId={Id}";
          
            string response = htp.Get(endpoint);
            return JsonConvert.DeserializeObject<Response<List<Select>>>(response).Data; 
        }
        //public string DeleteAgent(int Id)
        //{
        //    string endpoint =$"/api/DisableAgent?AgentId={Id}";
          
        //    string response = htp.Get(endpoint);
        //    return JsonConvert.DeserializeObject<Response<string>>(response).Data; 
        //}

        public string DeleteAgent(int Id)
        {
            

            var model = new { Id = Id, Value = "" };
            StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            string endpoint = Setting.Host + "/api/DisableAgent";
            using (HttpClient htp = new HttpClient())
            {
                string response =  htp.PostAsync(endpoint, body).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Response<string>>(response).Data;
            }
        }
    }
}