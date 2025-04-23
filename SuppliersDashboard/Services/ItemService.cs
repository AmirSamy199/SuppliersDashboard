using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;
using System.Web.Mvc;

namespace SuppliersDashboard.Services
{
    public class ItemService
    {
        private HttpClientHelper htp = new HttpClientHelper();
        // تقرير مبيعات الصنف باللتاريخ من الي 
        public Response<List<AA_ItemSalesByDay_pro>> GetItemSalesFromTo(int ItemID, string DateFrom, string DateTo)
        {
            string EndPoint = $"/api/Items/GetItemsSalesFromTo?ItemID={ItemID}&DateFrom={DateFrom}&DateTo={DateTo}";
            string response = htp.Get(EndPoint);
            return JsonConvert.DeserializeObject<Response<List<AA_ItemSalesByDay_pro>>>(response);
        }


        /// get All Items 
        public Response<List<Items_Tbl>> GetAllItemsFromTable()
        {
            var response2 = htp.Get($"/api/Items/GetAllItemsFromTable");
            Response<List<Items_Tbl>> res = JsonConvert.DeserializeObject<Response<List<Items_Tbl>>>(response2);
            return res;      
        }

    }
}