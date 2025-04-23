using Connibrary;
using ScoposERB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoposERB.Helper;
using RestSharp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using static SuppliersDashboard.Models.Document;
using System.Security.Cryptography.Xml;
using FastReport.Data;
using ScoposERB.BL;
using System.IO;
using SuppliersDashboard.BL.Model;
using SuppliersDashboard.Controllers;
using SuppliersDashboard.Models;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Helper;
using Converter = ScoposERB.Helper.Converter;
using SuppliersDashboard.Filters;

namespace ScoposERB.Controllers
{

    public class IntegrationController : BaseController
    {
        public static Token token = null;
        APIHandler api = new APIHandler();
        public static string _DocumentSubmissions_URL = "";
        public MyFunctions fun = new MyFunctions();
        private ETALoginService ETA = new ETALoginService();
        // GET: Integration

        [FunctionFilter(key = "الفاتورة الاكترونية")]
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetData()
        {
            DeepHelper db = new DeepHelper();
            var User = Cokie.UserGet();

            try
            {
                SuppliersDashboard.BL.Model.Model1 ob = new SuppliersDashboard.BL.Model.Model1();

                var data = ob.ETA_document_Tbl.Where(x => x.status == 1).Select(x => x.Environment_ID).ToList();
                var GetEnvID = "Select Environment_ID From ETA_document_Tbl Where status = 1 And ComID ='1'";
                // DataTable dt = fun.fireDataTable(GetEnvID);
                string DataQuery;
                // var EnviID = Converter.ConvertDataTable<ETA_document_Tbl>(dt).FirstOrDefault();
                var EnviID = db.GetObject<ETA_document_Tbl>(GetEnvID);


                DataQuery = "EXEC dbo.GetValidationDashboard_Pro @environment_ID = " + EnviID.Environment_ID + ", @ComID ='1'";


                string wx = fun.fireConnection().ConnectionString;
                DataTable Datadt = fun.fireDataTable(DataQuery);
                InvoiceData DataList = Converter.ConvertDataTable<InvoiceData>(Datadt).FirstOrDefault();
                int Total = DataList.Pending + DataList.InValid + DataList.Canceled + DataList.Hold + DataList.Received + DataList.Rejected + DataList.Submitted + DataList.Unsubmitted + DataList.Valid;

                return Json(new { data = DataList, Total = Total });
            }
            catch (Exception ex)
            {
                return Json(new { data = new InvoiceData(), Total = 0, message = ex.Message });

            }
        }
        [HttpPost]
        public ActionResult LoadGrid(int RecordID)
        {
            SuppliersDashboard.BL.Model.Model1 ob = new SuppliersDashboard.BL.Model.Model1();

            var data = ob.ETA_document_Tbl.Where(x => x.status == 1).Select(x => x.Environment_ID).ToList();
            var User = Cokie.UserGet();
            var GetEnvID = "Select Environment_ID From ETA_document_Tbl Where status = 1 And ComID ='1'";
            DataTable dt = fun.fireDataTable(GetEnvID);
            var EnviID = Converter.ConvertDataTable<ETA_document_Tbl>(dt).FirstOrDefault();
            var GridQuery = "";
            User.MultiGroup = 0;
            // login 
            //[GetInvoices_Info_WithGroups_Pro]
            if (User.MultiGroup == 0 /*|| @ScoposERB.Helper.Coookie.GetFunctions().Where(x => x.FunctionName == "Groups Handling").FirstOrDefault() != null*/)
            {
                if (RecordID == 100)
                {
                    GridQuery = "EXEC dbo.GetInvoices_Info_Pro @sendToeta = 100, @environment_ID = " + EnviID.Environment_ID + ", @ComID =1";
                }
                else
                {
                    GridQuery = "EXEC dbo.GetInvoices_Info_Pro @sendToeta = " + RecordID + " , @environment_ID = " + EnviID.Environment_ID + ", @ComID =1";
                }
            }
            else
            {
                if (RecordID == 100)
                {
                    GridQuery = "EXEC dbo.[GetInvoices_Info_WithGroups_Pro] @sendToeta = 100, @environment_ID = " + EnviID.Environment_ID + ", @MainGroup = " + User.MainGroupID;
                }
                else
                {
                    GridQuery = "EXEC dbo.[GetInvoices_Info_WithGroups_Pro] @sendToeta = " + RecordID + " , @environment_ID = " + EnviID.Environment_ID + ",@MainGroup = " + User.MainGroupID;
                }
            }

            DataTable Griddt = fun.fireDataTable(GridQuery);
            List<Integration> DataList = Converter.ConvertDataTable<Integration>(Griddt);
            DataList.Select(c => { c._transfer_date = c.transfer_date?.ToString("yyyy-MM-dd hh:mm tt"); return c; }).ToList();
            return Json(new { data = DataList });
        }
        [HttpPost]
        public ActionResult GetLogin()
        {
            try
            {
                DeepHelper db = new DeepHelper();

                string Connection = fun.fireConnection().ConnectionString;
                string GetEnvID = $"Select * From ETA_document_Tbl Where status = 1 And ComID ='1009'";
                var dt = db.fireDT(GetEnvID);
                var EnvironmentsIDs = Converter.ConvertDataTable<ETA_document_Tbl>(dt);
                var EnviID = EnvironmentsIDs.FirstOrDefault();


                var getLog = "Select * From ETA_document_Tbl WHERE status = '1' And ComID ='1009' AND Environment_ID =" + EnviID.Environment_ID;

                DataTable Logdt = fun.fireDataTable(getLog);
                ETA_document_Tbl LoginInfo = Converter.ConvertDataTable<ETA_document_Tbl>(Logdt).FirstOrDefault();
                return Json(new { data = LoginInfo });
            }
            catch (Exception ex)
            {
                return Json(new { data = new ETA_document_Tbl(), message = ex.Message + "// Inner // " });
            }
        }
        [HttpPost]
        public ActionResult Submit()
        {
            var User = Cokie.UserGet();
            string Up = "update ETA_Com_Tb1 set RunStutes=1 WHERE ComID = 1";
            fun.fireSQL(Up);
            return Json(new { data = true });
        }
        [HttpPost]

        public ActionResult EndLoop()
        {
            try
            {
                var User = Cokie.UserGet();
                var check = "select ETA_Com_Tb1.RunStutes As RunStutes FROM ETA_Com_Tb1 WHERE ComID ='1'";
                DataTable Checkdt = fun.fireDataTable(check);
                SuppliersDashboard.Models.Com_Tbl Checking = Converter.ConvertDataTable<SuppliersDashboard.Models.Com_Tbl>(Checkdt).FirstOrDefault();
                return Json(new { data = Checking });

            }
            catch (Exception Ex)
            {
                return Json(new { data = new SuppliersDashboard.Models.Com_Tbl() });

            }
        }
        public SubmittedDocument GetDocument(string url, Token token, string invoiceUID)
        {
            //url = "https://api.preprod.invoicing.eta.gov.eg";
            //url = "https://api.invoicing.eta.gov.eg";
            //  var client = new RestClient("https://api.preprod.invoicing.eta.gov.eg/api/v1/documents/ZZ0C7AMVSR50WT0KMQ6W906F10/raw");
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(url + "/api/v1/documents/" + invoiceUID + "/raw");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=eb44eac10ef20d32b2e68814a84fe545");
            IRestResponse response = client.Execute(request);
            var settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            SubmittedDocument result = JsonConvert.DeserializeObject<SubmittedDocument>(response.Content, settings);
            return result;
        }
        [HttpPost]
        public ActionResult GetValidation()
        {
            //// Get Company ETA DATA 
            var ComData = ETA.Login();
            string Login_URL = ComData.Login_URL;
            string DocumentSubmissions_URL = ComData.DocumentSubmissions_URL;
            string client_secret = ComData.client_secret;
            string client_id = ComData.client_id;





            int NoOfRows = 0;
            decimal line = 0;
            string getuuid;
            int Valid = 0;
            int Invalid = 0;
            int Cancelled = 0;
            int Rejected = 0;
            int pending = 0;
            int TotalAction = 0;

            var GetEnvID = "Select Environment_ID From ETA_document_Tbl Where status = 1 ";
            DataTable dt = fun.fireDataTable(GetEnvID);
            var EnviID = Converter.ConvertDataTable<ETA_document_Tbl>(dt).FirstOrDefault();
            getuuid = "select uuid,sendToETA  from  ETA_Bill_Tbl  where  sendToETA =1 And environment_ID =" + EnviID.Environment_ID + " And ComID =1";
            DataTable UUIDdt = fun.fireDataTable(getuuid);
            if (dt.Rows.Count > 0)
            {
                NoOfRows = UUIDdt.Rows.Count;
                {


                    foreach (DataRow row in UUIDdt.Rows)
                    {

                        line += 1;
                        decimal prs = line / NoOfRows * 100;
                        int n = Convert.ToInt32(prs);
                        int sendToeta = int.Parse(row["sendToETA"].ToString());
                        var (status, reason) = TheValidation(row["uuid"].ToString(), n);
                        string uuid = row["uuid"].ToString();
                        if (status == "Valid")
                        {
                            Valid += 1;
                            sendToeta = 3;
                        }
                        else if (status == "Invalid")
                        {
                            Invalid += 1;
                            sendToeta = 4;
                        }
                        else if (status == "Cancelled")
                        {
                            Cancelled += 1;
                            sendToeta = 5;
                        }
                        else if (status == "Rejected")
                        {
                            Rejected += 1;
                            sendToeta = 6;
                        }
                        if (status != "")
                        {
                            string AddResponse = "update ETA_Bill_Tbl  set Response = N'" + reason + "', validation = N'" + status + "',sendToETA  ='" + sendToeta + "' where uuid ='" + uuid + "' And environment_ID =" + EnviID.Environment_ID + "  ";

                            fun.fireSQL(AddResponse);
                        }

                    }
                    TotalAction = Valid + Invalid + Cancelled + Rejected;
                    pending = NoOfRows - TotalAction;



                }


                /// Collection 
               // (new CollectionService()).CollectValidInvoices(); 


            }


            (string status, string reason) TheValidation(string uuid, int pre)
            {
                var status = "";
                var reason = "";
                token = api.Login(Login_URL, client_id, client_secret, "InvoicingAPI");
                SubmittedDocument ss = GetDocument(DocumentSubmissions_URL, token, uuid);
                if (ss != null)
                {


                    status = ss.status;
                    if (status != "Valid")
                    {
                        string x = "";
                    }
                    if (status == "Invalid")
                    {
                        if (ss.validationResults != null)
                        {
                            for (int i = 0; i < ss.validationResults.validationSteps.Count; i++)
                            {
                                var validationResults = ss.validationResults.validationSteps[i].error;
                                string Stepstatus = ss.validationResults.validationSteps[i].status;
                                string name = ss.validationResults.validationSteps[i].name;
                                reason += Constants.vbCrLf + name + " | " + Stepstatus;
                                if (Stepstatus == "Invalid")
                                {
                                    for (int ii = 0; ii < validationResults.innerError.Count; ii++)
                                    {
                                        var ccccc = validationResults.innerError[ii].error;
                                        reason += " | " + ccccc;
                                    }
                                }


                            }
                        }
                    }
                }

                return (status, reason.Replace(",", " ").Replace("'", " "));

            }
            return Json(new { Valid = Valid, Invalid = Invalid, Cancelled = Cancelled, Rejected = Rejected, Pending = pending, TotalAction = TotalAction });

        }
        public ActionResult ViewResons(int RecordID)
        {
            string Reason = "SELECT ETA_Bill_Tbl.Response As Response FROM ETA_Bill_Tbl WHERE RecordID = " + RecordID + "";
            DataTable dt = fun.fireDataTable(Reason);
            var ReasonInfo = Converter.ConvertDataTable<SuppliersDashboard.BL.Model.Bill_Tbl>(dt).FirstOrDefault();
            return PartialView("_ViewReasons", ReasonInfo);
        }
        public ActionResult ViewAction(int RecordID)
        {
            string ETACheck = "SELECT ETA_Bill_Tbl.uuid As uuid, ETA_Bill_Tbl.RecordID As RecordID, ETA_Bill_Tbl.sendToeta As sendToeta From ETA_Bill_Tbl Where RecordID = " + RecordID + "";
            DataTable dt = fun.fireDataTable(ETACheck);
            var Actionnfo = Converter.ConvertDataTable<SuppliersDashboard.BL.Model.Bill_Tbl>(dt).FirstOrDefault();
            return PartialView("_ViewActions", Actionnfo);
        }
        public ActionResult Resubmit(int RecordID)
        {
            var User = Coookie.Get().User;
            string Up = "update Com_Tbl set RunStutes=1 WHERE ComID = " + User.ComID + "";
            fun.fireSQL(Up);
            string Re = "update ETA_Bill_Tbl set sendToETA=0 And validation = 'Pending' Where RecordID = " + RecordID + "";
            fun.fireSQL(Re);
            return Json(new { data = true });
        }
        public ActionResult Cancel(int RecordID)
        {
            string url = _DocumentSubmissions_URL + "/";
            string GetUUID = "select * from ETA_Bill_Tbl where RecordID = " + RecordID;
            DataTable tb = fun.fireDataTable(GetUUID);
            if (tb.Rows.Count > 0)
            {
                string UUID = tb.Rows[0]["uuid"].ToString();
                string res = DocumentCancellation(url, UUID, "فاتورة غير صحيحة", token);

                if (res.Contains("ValidationError"))
                {
                    string Can = "update Bill_Tbl set sendToETA = 5, validation = 'Canceled' Where RecordID = " + RecordID + "";
                    fun.fireSQL(Can);
                    var BillNo = Converter.ConvertDataTable<SuppliersDashboard.BL.Model.Bill_Tbl>(tb).FirstOrDefault();
                    var Update = "Update collection_tbl set Stutes = 5 Where BillNo = " + BillNo.BillNo + " and documentType = '" + BillNo.documentType + "'";
                    fun.fireSQL(Update);
                    return Json(new { data = true });
                }
            }
            return Json(new { data = false });
        }
        public string DocumentCancellation(string url, string invoiceUID, string reason, Token token)
        {
            var client = new RestClient(url + "/api/v1.0/documents/state/" + invoiceUID + "/state");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            request.AddParameter("application/json", "{\n\t\"status\":\"cancelled\",\n\t\"reason\":\"" + reason + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string result = response.Content;

            return result;
        }
        public ActionResult Hold(int RecordID)
        {
            string Can = "update ETA_Bill_Tbl set sendToeta = 10, validation = 'Holding' Where RecordID = " + RecordID + "";
            fun.fireSQL(Can);
            return Json(new { data = true });
        }

        public ActionResult ViewDocument(string UUID)
        {
            var ETALoginData = ETA.Login();
            var tttoken = ETA.Token();
            string url = ETALoginData.DocumentSubmissions_URL + "/";
            /// Before Save Delete All Last PDFS in folder not to attack Server 
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Invoice Printed"));
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            catch { }
            /// Saved File To Server THen Get Open on Browser 
            var SavedPath = DocumentPrint(url, UUID, tttoken);
            return File(SavedPath, "application/pdf");
            // Return File without Saving To Server But Downloded in Cient Downloaded Folder and Open in His Own Computer  
            //   var fileBytes = GetPdfAsArrayOfByte(url, UUID, tttoken);
            //  return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, UUID + ".pdf");

        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
        public string DocumentPrint(string url, string invoiceUID, Token token)
        {
            string filepath = Server.MapPath($"~/Content/Invoice Printed/{invoiceUID}.pdf");
            try
            {
                var request = new RestRequest(Method.GET);
                var client = new RestClient(url + "api/v1/documents/" + invoiceUID + "/pdf");
                client.Timeout = -1;
                request.AddHeader("Authorization", "Bearer " + token.access_token);
                request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
                var response = client.DownloadData(request);
                if (response != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", response.Length.ToString());
                    Response.BinaryWrite(response);
                    Response.OutputStream.Write(response, 0, response.Length);
                    Response.OutputStream.Flush();
                    System.IO.File.WriteAllBytes(filepath, response);

                }
            }
            catch (Exception ex)
            {
            }
            return filepath;
        }

        public byte[] GetPdfAsArrayOfByte(string url, string invoiceUID, Token token)
        {
            var request = new RestRequest(Method.GET);
            var client = new RestClient(url + "api/v1/documents/" + invoiceUID + "/pdf");
            client.Timeout = -1;
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            var response = client.DownloadData(request);
            return response;
        }
        [FunctionFilter(key = "الفاتورة الاكترونية")]
        public ActionResult Get_All_Bill()
        { Model3 o = new Model3();
            var databank = o.BankInfo_tbl.ToList();
            ViewBag.bank = databank;
            var data = "select * from getallBill_V";
            DataTable Griddt = fun.fireDataTable(data);
            List<SuppliersDashboard.BL.Model.Bill_Tbl> DataList = Converter.ConvertDataTable<SuppliersDashboard.BL.Model.Bill_Tbl>(Griddt);
            ViewBag.data = DataList;


            return View();
        }
        [HttpPost]
        public ActionResult AddInvoise(int id, int s, int bankid)
        {
            Model2 obj = new Model2();
            Model4 obj1 = new Model4();
            var data = $"select * from  [dbo].[Bill_Detiles_Tbl] where billno={id}";
            var data1 = $"select * from  [dbo].[Bill_Tbl] where billno={id}";

            var dat = obj.Branch_tbl.Where(x => x.Record_ID == s).Select(x=>x.Tax_id).FirstOrDefault();
            var data2 = obj1.VAT_tbl.Where(x => x.Record_ID.ToString() == dat).FirstOrDefault();
            var data3 = $"select * from  [dbo].[Bill_Detiles_Tbl] where billno={id}";
            DataTable Gridd1 = fun.fireDataTable(data1);
            DataTable Gridd11 = fun.fireDataTable(data3);

          
            List<SuppliersDashboard.BL.Model.Bill_Tbl> DataList1 = Converter.ConvertDataTable<SuppliersDashboard.BL.Model.Bill_Tbl>(Gridd1);
            foreach (var item in DataList1)
            {
                if (item.Currency == null && s < 0 && dat==null&& item.Currency=="")
                {
                    return Json("flase");
                }
                else if (Gridd11.Rows.Count<0)
                {
                    return Json("fase");

                }
               
                else if (item.Currency == "")
                {
                    return Json("flase");
                }
                var branch = item.Branch_id;
                
                var comid = obj.Branch_tbl.Where(x => x.Record_ID == branch).Select(x => x.comid).FirstOrDefault();
                //                var slect = @"INSERT INTO [dbo].[ETA_Bill_Detiles_Tbl]([SR_No],[Items],[IntCode],[GPC_Code],[Description],[NumberOfUnits],[UnitPrice],[TotalPrice],[Suppier_id],[BillNo],[ItemDiscount_rate],[ItemDiscount_amount],[sysItemID],[documentType],[environment_ID],[comid],[unitType_Ar],[Currency],[currencyExchangeRate],[CusID],[ServiceID],[posserial],[Editor],[Request_id],[branchid],[Editor_id],[Date],[SubmittionUUID],[GrossTotal],[Vat],[ETASend])
                //VALUES('" + item.SR_No + "',N'" + item.Items + "','','','',N'" + item.NumberOfUnits + "',N'" + item.UnitPrice + "',N'" + item.TotalPrice + "',N'" + item.Suppier_id + "','N" + item.Suppier_id + "',N'" + item.BillNo + "','',N'0','','',N'0',N'1009',N'1','EGB')";
                var posserial = $"select top 1 posserial from dbo.pos_machin_v ";
                var time = DateTime.Now;
                DataTable Gri = fun.fireDataTable(posserial);
                string pos = Gri.Rows[0]["posserial"].ToString();
              var slect = $@"INSERT INTO [dbo].[ETA_Bill_Tbl]
           ([BillNo]
          
           ,[Currency]
           ,[BillDate]
           ,Customer_ID
           ,[Bill_Stutes]
           ,[Editor]
           ,[Date]
          
          
           ,[TotalAmountBeforDiscount]
           ,[TotalAmountAfterDiscount]
           ,[TotalAmountAfterVAT]
           ,taxType,branchid,environment_ID,VAT,sendToeta,comid,documentType,posserial,BankInfoID
        )VALUES({item.BillNo} ,'EGP','{time}',
{comid},{item.Bill_Stutes},{item.Editor},'{time}',{item.TotalAmountBeforDiscount},{item.TotalAmountAfterDiscount},{item.TotalAmountAfterVAT},
'T1',{s},{Setting.envirementId},{item.VAT},0,1,'I','{pos}',{bankid})";
                //VALUES(1, N'كريمه مبستره الدوار 100جرام ', '', '', '', 1.00, 9.00, 9.00, 0, 1, 0, 0, 0, '', 0, 1009, '', N'EGB')

                fun.fireSQL(slect);
                var updata = $@"UPDATE [dbo].[Bill_Tbl] set sendtoeta=1
where [BillNo]={id}";
                fun.fireSQL(updata);
            }
           
            DataTable Gridd= fun.fireDataTable(data);
            List<Evn_Bill_Detiles_Tbl> DataList = Converter.ConvertDataTable<Evn_Bill_Detiles_Tbl>(Gridd);
            foreach (var item in DataList)
            {
                var daa = obj.Bill_Detiles_Tbl.FirstOrDefault(x=>x.Record_ID == id);
                var itemcode = obj.Items_Tbl.FirstOrDefault(x => x.Record_ID == daa.ItemID);
                //                var slect = @"INSERT INTO [dbo].[ETA_Bill_Detiles_Tbl]([SR_No],[Items],[IntCode],[GPC_Code],[Description],[NumberOfUnits],[UnitPrice],[TotalPrice],[Suppier_id],[BillNo],[ItemDiscount_rate],[ItemDiscount_amount],[sysItemID],[documentType],[environment_ID],[comid],[unitType_Ar],[Currency],[currencyExchangeRate],[CusID],[ServiceID],[posserial],[Editor],[Request_id],[branchid],[Editor_id],[Date],[SubmittionUUID],[GrossTotal],[Vat],[ETASend])
                //VALUES('" + item.SR_No + "',N'" + item.Items + "','','','',N'" + item.NumberOfUnits + "',N'" + item.UnitPrice + "',N'" + item.TotalPrice + "',N'" + item.Suppier_id + "','N" + item.Suppier_id + "',N'" + item.BillNo + "','',N'0','','',N'0',N'1009',N'1','EGB')";
                var slect = $@"INSERT INTO [dbo].[ETA_Bill_Detiles_Tbl]([SR_No],[Items],[IntCode],[GPC_Code],[Description],
[NumberOfUnits],[UnitPrice],[TotalPrice],[Suppier_id],[BillNo],[ItemDiscount_rate],[ItemDiscount_amount]
,[sysItemID],[documentType],[environment_ID],[comid],[unitType_Ar],[Currency])
VALUES( {item.SR_No} ,N'{ item.Items} ','',999999999,'',{item.NumberOfUnits},{ item.UnitPrice},{ item.TotalPrice},{item.Suppier_id},{item.BillNo},0,0,0,'',0,1,N'',N'EGP')";
                //VALUES(1, N'كريمه مبستره الدوار 100جرام ', '', '', '', 1.00, 9.00, 9.00, 0, 1, 0, 0, 0, '', 0, 1009, '', N'EGB')

                fun.fireSQL(slect);
            }

            return Json("tey");
        }
        [HttpGet]
        public ActionResult getdatils(int id)
        {
            var data = $"select * from  [dbo].[Bill_Detiles_Tbl] where billno={id}";
            var data1 = $"select * from  [dbo].[Bill_Tbl] where billno={id}";
            DataTable Gridd1 = fun.fireDataTable(data);
            
            List<Evn_Bill_Detiles_Tbl> DataList1 = Converter.ConvertDataTable<Evn_Bill_Detiles_Tbl>(Gridd1);
            return Json(DataList1, JsonRequestBehavior.AllowGet);

        }

    }

}