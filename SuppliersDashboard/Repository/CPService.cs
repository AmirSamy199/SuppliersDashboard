using SuppliersDashboard.Helper;
using SuppliersDashboard.Models.CP;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Repository
{
    public class CPService
    {
        private HttpClientHelper Htp = new HttpClientHelper();

       public Response<List<CPMonthModel>> CpMonthLatSixMonth (int SalesId)
        {
            string url = $"/api/CP/SalesManLastSixMonths?SalesManId={SalesId}";
            var result = Htp.Get<Response<List<CPMonthModel>>>(url);
            return result;
        }
        public Response<string> CloseSalesMonth (int SalesId, string Month)=> Htp.Get<Response<string>>($"/CP/CloseSalesMonth?SalesId={SalesId}&Month={Month}");
        public Response<CommisionModel> DistributorCommision(int SalesId, int Year, int Month)
        {
            string URI = $"/api/DistributorCommision?SalesId={SalesId}&Year={Year}&Month={Month}";
           var res =  Htp.Get<Response<CommisionModel>>(URI);
            return res; 
        }


    }
}