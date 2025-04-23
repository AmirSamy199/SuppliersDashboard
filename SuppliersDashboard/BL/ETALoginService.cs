
using ScoposERB.Helper;
using ScoposERB.Models;
using SuppliersDashboard.BL.Model;
using SuppliersDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ScoposERB.BL
{
    public class ETALoginService
    {
        private DeepHelper db = new DeepHelper();
        private  APIHandler api = new APIHandler();
        public ETA_document_Tbl Login()
        {
              
                string GetEnvID = $"Select * From ETA_document_Tbl Where status = 1 ";
                var dt = db.fireDT(GetEnvID);
                var EnvironmentsIDs = Converter.ConvertDataTable<ETA_document_Tbl>(dt);
                var EnviID = EnvironmentsIDs.FirstOrDefault();
                var getLog = "Select * From ETA_document_Tbl WHERE status = '1' AND Environment_ID =" + EnviID.Environment_ID ;
                var LoginInfo = db.GetObject<ETA_document_Tbl>(getLog);
                return LoginInfo;

        }


        public Token Token()
        {
            var ComETAdata = Login();
            var token = api.Login(ComETAdata.Login_URL, ComETAdata.client_id, ComETAdata.client_secret, "InvoicingAPI");
            return token;

        }
   
      



           
   
    }
}