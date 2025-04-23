using ScoposERB.Helper;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL
{
    public class WarehouseService
    {
        private HttpClientHelper _http = new HttpClientHelper();
        

        public List<ScoposERB.Helper.Select> AllWarehouses()
        {
            var result = _http.Get<Response<List<ScoposERB.Helper.Select>>>("/api/Selector/GetWareHouses");
            return result.Data;
        }
    }


    #region Classes
    
    #endregion
}