using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Repository
{
    public class AccountingService
    {
        private HttpClientHelper HTTP = new HttpClientHelper();

        public Response<closing_day_settelment_amount> GetBalanceOfMoneySave()
        {
            string content = HTTP.Get("/api/MoneySafe/GetBalanceOfMoneySafe");
            Response<closing_day_settelment_amount> model = JsonConvert.DeserializeObject<Response<closing_day_settelment_amount>>(content);
            return model;
        }
         public Response<string> CloseMoneySaveAtEndOfDay(int AccounterId )
        {
            string content = HTTP.Get($"/api/MoneySafe/CloseMOneySaveInTheOfDay?AccounterId={AccounterId}");
            Response<string> model = JsonConvert.DeserializeObject<Response<string>>(content);
            return model;
        }

    }
}