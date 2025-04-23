using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models.ReportModels;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Services
{
    public class ReportService
    {
        private HttpClientHelper htp = new HttpClientHelper();


        public Response<List<SelectSales_Today_English_Pro>> AllDistributorReportsDetails(string DateFrom = "-" , string DateTo = "-")
        {
            string URI = $"/api/Report/GetselesSummryForAllUsersReport?DateFrom={DateFrom}&DateTo={DateTo}";
            string content = htp.Get(URI);
            Response<List<SelectSales_Today_English_Pro>> model = JsonConvert.DeserializeObject<Response<List<SelectSales_Today_English_Pro>>>(content);
            return model;
        }

      
    }
}