using SuppliersDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SuppliersDashboard.Helper
{
    public static class ClienHelp 
    {
        public static HttpClient SetHeader(this HttpClient htp)
        {
            if (Cokie.UserGet().Id == 0)
            {
                string contentType = "application/json";
                htp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                htp.DefaultRequestHeaders.Add("DashboardUserId", "0");

                return htp;
            }
            else
            {
                int userid = Cokie.UserGet().Id;

                string contentType = "application/json";
                htp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                htp.DefaultRequestHeaders.Add("DashboardUserId", userid.ToString());

                return htp;
            }
          
           
        }

        public static HttpClient SetHeader(this HttpClient htp , int SalesId)
        {
          
                int userid = Cokie.UserGet().Id;

                string contentType = "application/json";
                htp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                htp.DefaultRequestHeaders.Add("DashboardUserId", userid.ToString());
                htp.DefaultRequestHeaders.Add("UserId", SalesId.ToString());

                return htp;
            


        }
    }
}