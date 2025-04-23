using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SuppliersDashboard.Helper
{
    public class HttpClientHelper
    {
        public string Get(string URI)
        {
            using(HttpClient http =new HttpClient())
            {
                var response = http.SetHeader().GetAsync(Setting.Host + URI ).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        public string GetWithoutAuth(string URI)
        {
            using(HttpClient http =new HttpClient())
            {
                var response = http.GetAsync(Setting.Host + URI ).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        public T Get<T>(string URI)
        {
            using(HttpClient http =new HttpClient())
            {
                var response = http.SetHeader().GetAsync(Setting.Host + URI ).Result;
                var x = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(x);
            }
        }
        public string Post(string URI , string body)
        {
            using(HttpClient http =new HttpClient())
            {
                var bbody = new StringContent(body, Encoding.UTF8, "application/json"); 
                var response = http.SetHeader().PostAsync(Setting.Host + URI , bbody ).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        public T Post<T,Y>(string URI, Y body)
        {
            using (HttpClient http = new HttpClient())
            {
                var bbody = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                var response = http.SetHeader().PostAsync(Setting.Host + URI, bbody).Result;
                string res =  response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(res);
            }
        }
    }


    public class HttpClientHelperAsDistributor
    {
        public string Get(int SalesId , string URI )
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.SetHeader(SalesId).GetAsync(Setting.Host + URI).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
       
        public T Get<T>( int SalesId ,string URI)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.SetHeader(SalesId).GetAsync(Setting.Host + URI).Result;
                var x = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(x);
            }
        }
        public string Post(int SalesId, string URI, string body)
        {
            using (HttpClient http = new HttpClient())
            {
                var bbody = new StringContent(body, Encoding.UTF8, "application/json");
                var response = http.SetHeader(SalesId).PostAsync(Setting.Host + URI, bbody).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        public T Post<T, Y>(int SalesId, string URI, Y body)
        {
            using (HttpClient http = new HttpClient())
            {
                var bbody = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                var response = http.SetHeader(SalesId).PostAsync(Setting.Host + URI, bbody).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(res);
            }
        }
    }
}