using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
namespace ScoposERB.Models
{
    public class APIHandler
    {
        public Token Login(string url, string client_id, string client_secret, string scope)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "3f6bf69972563c3e0e619b78edf73035=d9c1a20894c4897c5b2a999aef6c20e7");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("scope", scope);
            IRestResponse response = client.Execute(request);

            //Console.WriteLine(response.Content);
            var settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            Token result = JsonConvert.DeserializeObject<Token>(response.Content, settings);
            if (response.Content != null && response.Content != "")
            {
                string s = result.ToString();
                return result;
            }
            else
            {
                throw (new Exception(response.ErrorMessage));
            }


        }
        public string DocumentSubmissions(string url, Token token, string body)
        {
            var client = new RestClient(url + "/api/v1/documentsubmissions");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string result = response.Content;
            return result;
        }

        public string DocumentRejection(string url, Token token, string invoiceUID, string reason)
        {
            var client = new RestClient(url + "/api/v1.0/documents/state/" + invoiceUID + "/state");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            request.AddParameter("application/json", "{\n\t\"status\":\"rejected\",\n\t\"reason\":\"" + reason + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string result = response.Content;
            return result;
        }
        public string Get_Recent_Documents(string url, Token token)
        {
            var client = new RestClient(url + "/api/v1.0/documents/recent?pageNo=1&pageSize=3000&InvoiceDirection=received");


            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            // request.AddParameter("application/json", "{\n\t\"Accept-Language\":\"ar\",\n\t\"reason\":\"" + reason + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string result = response.Content;
            return result;
        }
        public void DocumentPrint(string url, Token token, string invoiceUID, string path)
        {
            var client = new RestClient("https://api.preprod.invoicing.eta.gov.eg/api/v1/documents/" + invoiceUID + "/pdf");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            var response = client.DownloadData(request);
            File.WriteAllBytes(Path.Combine(path, invoiceUID + ".pdf"), response);
        }
    }
}