using Aspose.Cells;
using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Models.ReportModels;
using SuppliersDashboard.ViewModels;
using SuppliersDashboard.ViewModels.ReportVM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SuppliersDashboard.Services
{
    public class NewReportService
    {
        private HttpClientHelper htphelp = new HttpClientHelper();
        /// ريبورت اجماليات مبيعات بالاصناف 
        public Response3<List<AA_ItemSalesByDay_pro>> GetItemTotalSales(int ItemId , string DateFrom , string DateTo)
        {
            string response = htphelp.Get($"/api/ItemTotal3Sales?ItemId={ItemId}&DateFrom={DateFrom}&DateTo={DateTo}");
            Response3<List<AA_ItemSalesByDay_pro>> Result = JsonConvert.DeserializeObject<Response3<List<AA_ItemSalesByDay_pro>>>(response);
            return Result;
        }
        /// ريبورت اجماليات مبيعات بمجموعات الاصناف 
        public Response3<List<AA_GetItemSalesBranchDistriutorDateByCategories_V>> GetCategoresTotalSales(int CategoryID, int UserID, int BranchID, string DateFrom, string DateTo, int AgentId)
        {
            string response = htphelp.Get($"/api/CategoriesTotal3Sales?CategoryID={CategoryID}&UserID={UserID}&BranchID={BranchID}&DateFrom={DateFrom}&DateTo={DateTo}&AgentId={AgentId}");
            Response3<List<AA_GetItemSalesBranchDistriutorDateByCategories_V>> Result = JsonConvert.DeserializeObject<Response3<List<AA_GetItemSalesBranchDistriutorDateByCategories_V>>>(response);
          if(Result.Data!=null)
            Result.Data.ForEach(x => x.TotalPrice = x.TotalPrice - (x.Discount + x.ITEM_Discount));
          if(Result.Data2!=null)
                Result.Data2.ForEach(x => x.TotalPrice = x.TotalPrice - (x.Discount + x.ITEM_Discount));
        if (Result.Data3 != null)
            Result.Data3.ForEach(x => x.TotalPrice = x.TotalPrice - (x.Discount + x.ITEM_Discount));
        if (Result.Data4 != null)
            Result.Data4.ForEach(x => x.TotalPrice = x.TotalPrice - (x.Discount + x.ITEM_Discount));
            return Result;
        }
        // ريبورتات مجاميع الفواتير
        public Response<List<BillTotalReport>> GetBillTotalReort(string DateForm,string DateTo)
        {
            string response= htphelp.Get($"/api/BillTotalsReport?DateFrom={DateForm}&DateTo={DateTo}");
            Response<List<BillTotalReport>> Result= JsonConvert.DeserializeObject<Response<List<BillTotalReport>>>(response);
            return Result;
        }


        public Response<List<MasrofReport>>  ExpensesReport(string FromDate, string ToDate)
        {
            string res = htphelp.Get($"/api/MasrofReport?DateFrom={FromDate}&DateTo={ToDate}").ToString();

            Response<List<Expenses_v>> response = JsonConvert.DeserializeObject<Response<List<Expenses_v>>>(res);
            Response<List<MasrofReport>> newresponse = new Response<List<MasrofReport>>();

            newresponse.Status = response.Status;
            newresponse.State = response.State;
            newresponse.Message = response.Message;
            if(response.Data !=null && response.Data.Count > 0)
            {
                newresponse.Data = response.Data.Select(x => new MasrofReport()
                {
                    Manager = x.ResponseMan,
                    MasrofAmount = Convert.ToDecimal( x.Amount),
                    MasrofDateString = x.Add_dateString,
                    MasrofId =Convert.ToInt32( x.ExpenseID) ,
                    Sales = x.SalesName,
                    ExpenseType = x.ExpenseType,
                    AccountId=x.AccountId,
                    AccountName = x.AccountName,


                }).ToList();
            }
            return newresponse; 
        }
        public Response <List<StoreGuardDefaultVM>> ShortfallReport (int UserId , string DateFrom , string DateTo)
        {
            string res = htphelp.Get($"/api/ShortfallReport?UserId={UserId}&DateFrom={DateFrom}&DateTo={DateTo}").ToString();
            Response<List<StoreGuardDefaultVM>> response = JsonConvert.DeserializeObject<Response<List<StoreGuardDefaultVM>>>(res);
            return response;
        }
        public Response <List<MoneySortfallModel>> MoneyShortfallReport(int UserId , string DateFrom , string DateTo)
        {
            string res = htphelp.Get($"/api/MoneyShortfallReport?UserId={UserId}&DateFrom={DateFrom}&DateTo={DateTo}").ToString();
            Response<List<MoneySortfallModel>> response = JsonConvert.DeserializeObject<Response<List<MoneySortfallModel>>>(res);
            return response;
        }
        public Response <List<MoneyPaperModel>> MoneyPaperReport(int UserId , string DateFrom , string DateTo)
        {
            string res = htphelp.Get($"/api/MoneyPaperReport?UserId={UserId}&DateFrom={DateFrom}&DateTo={DateTo}").ToString();
            Response<List<MoneyPaperModel>> response = JsonConvert.DeserializeObject<Response<List<MoneyPaperModel>>>(res);
            return response;
        }
        public Response <List<StoreGuardDefaultVM>> SubWareHouseGuardReport (int UserId , string DateFrom , string DateTo)
        {
            string res = htphelp.Get($"/api/SubWareHouseGuardReport?UserId={UserId}&DateFrom={DateFrom}&DateTo={DateTo}").ToString();
            Response<List<StoreGuardDefaultVM>> response = JsonConvert.DeserializeObject<Response<List<StoreGuardDefaultVM>>>(res);
            return response;
        }

        public Response<List<ItemSalesREportVM>> ItemsDistributorsReport(string DateFrom, string DateTo, int SalesId = 0)
        {
            return htphelp.Get<Response<List<ItemSalesREportVM>>>($"/api/ItemSalesReport1?DateFrom={DateFrom}&DateTo={DateTo}&SalesId={SalesId}");
        }

        public Response<List<ItemSalesREportVM>> ItemsSalesReport(string DateFrom, string DateTo, int SalesId = 0)
        {
            return htphelp.Get<Response<List<ItemSalesREportVM>>>($"/api/ItemSalesReport?DateFrom={DateFrom}&DateTo={DateTo}&SalesId={SalesId}");
        }  
        
        public Response<List<BillLatesReport_V>> BillLatesReport()
        {
            return htphelp.Get<Response<List<BillLatesReport_V>>>($"/api/BillLatersReport");
        }




        public string ChangeDocState(int BillNo , int status )
        {
            string res = htphelp.Get($"/api/Sale/ChangeBillDocumnentStatus?BillNo={BillNo}&Status={status}");
            return res; 

        }

    }
}