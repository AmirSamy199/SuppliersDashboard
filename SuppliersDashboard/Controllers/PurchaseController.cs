using Connibrary;
using ScoposERB.Helper;
using ScoposERB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Collections;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using System.Net;
using System.Threading;
using System.Drawing;
using static SuppliersDashboard.Models.Document;
using static ScoposERB.Models.Purchases_Class;
using SuppliersDashboard.Controllers;
using SuppliersDashboard.Helper;
using Converter = ScoposERB.Helper.Converter;


namespace ScoposERB.Controllers
{
    
    public class PurchaseController : BaseController
    {
        Token token;
        APIHandler api = new APIHandler();
        public static MyFunctions fun = new MyFunctions();
        //[TimoutFilter]
        //[PurchaseFilter]
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult LoadGrid(int RecordID)
        {
            var User = Cokie.UserGet();
            var GridQuery = "";
            if (RecordID == 100)
            {
                GridQuery = "Select * FROM ETA_Purchases_Tbl Where ComID =1";
            }
            else
            {
                GridQuery = "Select * FROM ETA_Purchases_Tbl WHERE sendToeta = " + RecordID + " And ComID ='1'";
            }
            DataTable dt = fun.fireDataTable(GridQuery);
            List<Purchases_Class.Result> DataList = Converter.ConvertDataTable<Purchases_Class.Result>(dt);
            DataList.Select(c => { c._dateTimeIssued = c.dateTimeIssued?.ToString("yyyy-MM-dd"); return c; }).ToList();
            return Json(new { data = DataList });
        }
        public ActionResult GetData()
        {
            var User = Cokie.UserGet();
            var ValidQ = "SELECT COUNT(*) FROM ETA_Purchases_Tbl WHERE ComID ='1'  AND  sendToeta = '3'";
            int Valid = int.Parse(fun.fireSQL(ValidQ));
            var RejrctedQ = "SELECT COUNT(*) FROM ETA_Purchases_Tbl WHERE ComID ='1' AND  sendToeta = '6'";
            int Rej = int.Parse(fun.fireSQL(RejrctedQ));
            var Total = Valid + Rej;
            return Json(new { data = Valid, Rejected = Rej, Total = Total });
        }

        public ActionResult GetPurchase(string DocumentSubmissions_URL, string client_secret, string client_id, string Login_URL, string ValidBtn, string RejectedBtn, string TotalBtn)
        {
            var User = Cokie.UserGet();
          
            var NewValidBtn = "";
            var NewRejectedBtn = "";
            var NewTotalBtn = "";

            token = api.Login(Login_URL, client_id, client_secret, "InvoicingAPI");
            string x = api.Get_Recent_Documents(DocumentSubmissions_URL, token);
            Root getAllPurchases = JsonConvert.DeserializeObject<Root>(x);
            if (getAllPurchases.result != null)
            {
                if (getAllPurchases.result.Count > 0)
                {
                    //GVInv.DataSource = null;
                    //GVInv.DataBind();
                    double line = 0;
                    double NoOfRows = getAllPurchases.result.Count;
                    for (int i = 0; i < getAllPurchases.result.Count; i++)
                    {
                        double prs = (i + 1) / NoOfRows * 100;
                        int n = Convert.ToInt32(prs);
                        string uuid = getAllPurchases.result[i].uuid;
                        string submissionUUID = getAllPurchases.result[i].submissionUUID;
                        string longId = getAllPurchases.result[i].longId;
                        string internalId = getAllPurchases.result[i].internalId;
                        string typeName = getAllPurchases.result[i].typeName;
                        string documentTypeNamePrimaryLang = getAllPurchases.result[i].documentTypeNamePrimaryLang;
                        string documentTypeNameSecondaryLang = getAllPurchases.result[i].documentTypeNameSecondaryLang;
                        string typeVersionName = getAllPurchases.result[i].typeVersionName;
                        string issuerId = getAllPurchases.result[i].issuerId;
                        string issuerName = getAllPurchases.result[i].issuerName;
                        string receiverId = getAllPurchases.result[i].receiverId;
                        string receiverName = getAllPurchases.result[i].receiverName;
                        DateTime? dateTimeIssued = getAllPurchases.result[i].dateTimeIssued;
                        DateTime? dateTimeReceived = getAllPurchases.result[i].dateTimeReceived;
                        string totalSales = getAllPurchases.result[i].totalSales;
                        string totalDiscount = getAllPurchases.result[i].totalDiscount;
                        string netAmount = getAllPurchases.result[i].netAmount;
                        string total = getAllPurchases.result[i].total;
                        string maxPercision = getAllPurchases.result[i].maxPercision;
                        object invoiceLineItemCodes = getAllPurchases.result[i].invoiceLineItemCodes;
                        object cancelRequestDate = getAllPurchases.result[i].cancelRequestDate;
                        object rejectRequestDate = getAllPurchases.result[i].rejectRequestDate;
                        object cancelRequestDelayedDate = getAllPurchases.result[i].cancelRequestDelayedDate;
                        object rejectRequestDelayedDate = getAllPurchases.result[i].rejectRequestDelayedDate;
                        object declineCancelRequestDate = getAllPurchases.result[i].declineCancelRequestDate;
                        object declineRejectRequestDate = getAllPurchases.result[i].declineRejectRequestDate;
                        object documentStatusReason = getAllPurchases.result[i].documentStatusReason;
                        string status = getAllPurchases.result[i].status;
                        string createdByUserId = getAllPurchases.result[i].createdByUserId;
                        string Selectqoury = "select uuid from ETA_Purchases_Tbl where uuid ='" + uuid.Trim() + "' And ComID = "+User.Id + "";
                        DataTable dt_s = fun.fireDataTable(Selectqoury);
                        if (dt_s.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            int SendToEta = 0;
                            if (status == "Valid")
                            {
                                int v = int.Parse(ValidBtn) + 1;
                                NewValidBtn = v.ToString();
                                SendToEta = 3;
                            }
                            else
                            {
                                int R = int.Parse(RejectedBtn) + 1;
                                NewRejectedBtn = R.ToString();
                                SendToEta = 6;
                            }
                            int A = int.Parse(TotalBtn) + 1;
                            NewTotalBtn = A.ToString();
                            line += 1;
                            string ins = " INSERT INTO [ETA_Purchases_Tbl]([uuid] ,[submissionUUID] ,[longId] ,[internalId] ,[typeName] ,[documentTypeNamePrimaryLang] ,[documentTypeNameSecondaryLang] ,[typeVersionName] ,[issuerId] ,[issuerName] ,[receiverId] ,[receiverName] ,[dateTimeIssued] ,[dateTimeReceived] ,[totalSales] ,[totalDiscount] ,[netAmount] ,[total] ,[maxPercision] ,[invoiceLineItemCodes] ,[cancelRequestDate] ,[rejectRequestDate] ,[cancelRequestDelayedDate] ,[rejectRequestDelayedDate] ,[declineCancelRequestDate] ,[declineRejectRequestDate] ,[documentStatusReason] ,[status] ,[createdByUserId],ComID, sendToeta)VALUES('" + uuid + "','" + submissionUUID + "','" + longId + "','" + internalId + "','" + typeName +
                                "','" + documentTypeNamePrimaryLang + "',N'" + documentTypeNameSecondaryLang +
                                "','" + typeVersionName + "','" + issuerId + "',N'" + issuerName +
                                "','" + receiverId + "',N'" + receiverName + "','" + dateTimeIssued +
                                "','" + dateTimeReceived + "','" + totalSales + "','" + totalDiscount + "','" + netAmount +
                                "','" + total + "','" + maxPercision + "','" + invoiceLineItemCodes + "','" + cancelRequestDate +
                                "','" + rejectRequestDate + "','" + cancelRequestDelayedDate + "','" + rejectRequestDelayedDate +
                                "','" + declineCancelRequestDate + "','" + declineRejectRequestDate + "','" + documentStatusReason + "','" + status +
                                "','" + createdByUserId + "'," + User.ComID + ","+SendToEta+")";
                            fun.fireSQL(ins);
                        }

                    }

                }
            }
            return Json(new { data = true });
        }
    }
}