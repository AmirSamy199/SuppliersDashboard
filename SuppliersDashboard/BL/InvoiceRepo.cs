
using ScoposERB.BL.New_Models;
using ScoposERB.Helper;
using ScoposERB.Models;
using ScoposERB.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoposERB.BL
{
    public class InvoiceRepo
    {
        private readonly DeepHelper db = new DeepHelper();
        public string defaultdate { get; set; } = "1900-01-01";

      

        public List<Request_V> RequestExpenses(int RequestId)
        {
            int? comid = Coookie.Get().ComID;
            string q = $"select * From [dbo].[Request_V] where Request_id = {RequestId}  and general_entry_company= {comid} and Tran_Credit_Amt > 0";
            List<Request_V> result = db.GetList<Request_V>(q);

            TreasuryService _ts = new TreasuryService();
            int minetresury = _ts.GetMainTreasures(Convert.ToInt32(Coookie.Get().ComID), Coookie.Get().User.Branch_RecordID).FirstOrDefault().Id;
            List<int> minetresureies = _ts.UserTresuryChildsAccountWithParentIds(minetresury);

            var lastresult = new List<Request_V>();
            foreach (var req in result)
            {
                if (!minetresureies.Contains(req.Tran_account_code))
                    lastresult.Add(req);



            }

            return lastresult;
        }

        public (List<Request_V> Headers, List<Request_V> Details) RequestExpensesByGroups(int RequestId)
        {
            List<Request_V> details = RequestExpenses(RequestId);
            List<Request_V> Totals = new List<Request_V>();
            // بجيب الاكونتات الي مصاريف الريكويستات 
            string q = "select RecordID Id , EngName Name, ArabName Name1 ,AccNumber Name2   from Acc_Accounts_tbl where parentid = 22";
            List<SimpleClass> types = db.GetList<SimpleClass>(q);

            int itertor = 0;
            foreach (var item in details)
            {// بلف علي التفاصيل عشان اجمعم في التوتالز 
                var isexist = Totals.FirstOrDefault(x => item.Account.Contains(x.Account) && item.Currency == x.Currency);
                if (isexist == null)
                {

                    var type = types.Where(x => item.Account.Contains(x.Name2)).FirstOrDefault();
                    if(type != null)
                    {

                        Totals.Add(new Request_V
                        {
                            Account = type.Name2,
                            ArabName = type.Name1,
                            Tran_Credit_Amt = item.Tran_Credit_Amt,
                            Tran_Debit_Amt = item.Tran_Debit_Amt,
                            Currency = item.Currency,
                            EngName = type.Name,
                            VAT = item.VAT,
                            BaseExpensesId = ++itertor
                        });
                        item.BaseExpensesId = itertor;
                    }
                }
                else
                {
                    isexist.Tran_Credit_Amt += item.Tran_Credit_Amt;
                    isexist.Tran_Debit_Amt += item.Tran_Debit_Amt;
                    if (isexist.VAT != item.VAT)
                    {
                        isexist.VAT = 0;
                    }

                    /// Here Where Iam Override to Catch base of expenses 
                    item.BaseExpensesId = isexist.BaseExpensesId;
                }



            }
            return (Totals, details);
        }

        //public int SaveAndGetBillNo(string Customer, decimal TotalTax, decimal ItemTotal, decimal WithDiscount, decimal TotalAfterVAT, Byte Env, int id)
        //{
        //    var us = Coookie.Get().User;
        //    int BillNo = NewInvoiceNo(TryParseInt(us.ComID));
        //    int Bill_stuts = us.InvConfirmation == 99 ? 3 : 2;///need confirm stutes = 3, else = 2
        //    BillEntity bill = new BillEntity
        //    {
        //        documentType = "I",
        //        BillNo = BillNo,
        //        Customer_ID = Customer,
        //        Discount_Amt = 0,
        //        Discount_Rate = 0,
        //        WTHOLDINGTAX = 0,
        //        WTHOLDINGTAX_Rate = 0,
        //        VAT = TotalTax,
        //        BillDate = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd"),
        //        Editor = us.UserName,
        //        Date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
        //        Sales_ID = 0,
        //        Department_ID = 0,
        //        TotalAmountBeforDiscount = ItemTotal,
        //        TotalAmountAfterDiscount = WithDiscount,
        //        TotalAmountAfterVAT = TotalAfterVAT,
        //        comid = TryParseInt(us.ComID),
        //        validation = "pending",
        //        sendToeta = us.InvConfirmation,
        //        editor_id = us.RecordID.ToString(),
        //        environment_ID = Env,
        //        Bill_Stutes = TryParseByte(Bill_stuts),
        //        MainGroup_ID = us.MainGroupID,
        //        Request_id = id
        //    };
        //    AddInvoice(bill);
        //    return BillNo; 
        //}


        public int NewInvoiceNo(int ComId)
        {
            int billno = 0;
            try
            {
                string getq = $"select max(BillNo) as No from dbo.Bill_Tbl where documentType = 'I' and ComID = '{ComId}' ";
                billno = db.GetValue<int>(getq, "No");
                return billno + 1;
            }
            catch { return 0; }

        }
        public int AddInvoice(BillEntity Model)
        {
            try
            {

                // Avoid Date Errors 
                if (Model.Date == null || Model.Date == "")
                    Model.Date = defaultdate;
                if (Model.BillDate == null || Model.BillDate == "")
                    Model.BillDate = defaultdate;
                if (Model.Del_Date == null || Model.Del_Date == "")
                    Model.Del_Date = defaultdate;
                if (Model.sendToetaDate == null || Model.sendToetaDate == "")
                    Model.sendToetaDate = defaultdate;
                if (Model.transferDate == null || Model.transferDate == "")
                    Model.transferDate = defaultdate;
                string q = $@"
                    INSERT INTO [dbo].[Bill_Tbl]
                               ([BillNo]
                    ,[Customer_ID]
                    ,[Currency]
                    ,[Discount_Amt]
                    ,[Discount_Rate]
                    ,[WTHOLDINGTAX]
                    ,[WTHOLDINGTAX_Rate]
                    ,[VAT]
                    ,[Payment]
                    ,[Del_Date]
                    ,[Delivery]
                    ,[ShipmentMod]
                    ,[SalesOrderNo]
                    ,[Comment]
                    ,[BillDate]
                    ,[Payment_Stutes]
                    ,[Bill_Stutes]
                    ,[Editor]
                    ,[Date]
                    ,[Sales_ID]
                    ,[Department_ID]
                    ,[TotalAmountBeforDiscount]
                    ,[TotalAmountAfterDiscount]
                    ,[TotalAmountAfterVAT]
                    ,[VAT_Prs]
                    ,[RefInv]
                    ,[sendToeta]
                    ,[purchaseOrderReference]
                    ,[purchaseOrderDescription]
                    ,[salesOrderReference]
                    ,[salesOrderDescription]
                    ,[proformaInvoiceNumber]
                    ,[taxType]
                    ,[taxSubType]
                    ,[sendToetaDate]
                    ,[documentType]
                    ,[uuid]
                    ,[Response]
                    ,[currencyExchangeRate]
                    ,[validation]
                    ,[environment_ID]
                    ,[comid]
                    ,[approach]
                    ,[packaging]
                    ,[exportPort]
                    ,[countryOfOrigin]
                    ,[grossWeight]
                    ,[netWeight]
                    ,[Delivery_terms]
                    ,[BankInfoID]
                    ,[editor_id]
                    ,[CancelReason]
                    ,[digitalSignatureFeedback]
                    ,[Payment_terms]
                    ,[MainGroup_ID]
                    ,[Request_id]
                    ,[posserial]
                    ,[ReceiptNumber]
                    ,[transferDate]
                    ,[branchid]
                    ,[Url]
                    ,[ClientConfirmation]
                    ,[submissionUuid]
                    ,[R_ReceiptNumber]
                    ,[R_UUID])
                         VALUES
                               (N'{Model.BillNo}'
                               ,N'{Model.Customer_ID}'
                               ,N'{Model.Currency}'
                               ,N'{Model.Discount_Amt}'
                               ,N'{Model.Discount_Rate}'
                               ,N'{Model.WTHOLDINGTAX}'
                               ,N'{Model.WTHOLDINGTAX_Rate}'
                               ,N'{Model.VAT}'
                               ,N'{Model.Payment}'
                               ,N'{Model.Del_Date}'
                               ,N'{Model.Delivery}'
                               ,N'{Model.ShipmentMod}'
                               ,N'{Model.SalesOrderNo}'
                               ,N'{Model.Comment}'
                               ,N'{Model.BillDate}'
                               ,N'{Model.Payment_Stutes}'
                               ,N'{Model.Bill_Stutes}'
                               ,N'{Model.Editor}'
                               ,N'{Model.Date}'
                               ,N'{Model.Sales_ID}'
                               ,N'{Model.Department_ID}'
                               ,N'{Model.TotalAmountBeforDiscount}'
                               ,N'{Model.TotalAmountAfterDiscount}'
                               ,N'{Model.TotalAmountAfterVAT}'
                               ,N'{Model.VAT_Prs}'
                               ,N'{Model.RefInv}'
                               ,N'{Model.sendToeta}'
                               ,N'{Model.purchaseOrderReference}'
                               ,N'{Model.purchaseOrderDescription}'
                               ,N'{Model.salesOrderReference}'
                               ,N'{Model.salesOrderDescription}'
                               ,N'{Model.proformaInvoiceNumber}'
                               ,N'{Model.taxType}'
                               ,N'{Model.taxSubType}'
                               ,N'{Model.sendToetaDate}'
                               ,N'{Model.documentType}'
                               ,N'{Model.uuid}'
                               ,N'{Model.Response}'
                               ,N'{Model.currencyExchangeRate}'
                               ,N'{Model.validation}'
                               ,N'{Model.environment_ID}'
                               ,N'{Model.comid}'
                               ,N'{Model.approach}'
                               ,N'{Model.packaging}'
                               ,N'{Model.exportPort}'
                               ,N'{Model.countryOfOrigin}'
                               ,N'{Model.grossWeight}'
                               ,N'{Model.netWeight}'
                               ,N'{Model.Delivery_terms}'
                               ,N'{Model.BankInfoID}'
                               ,N'{Model.editor_id}'
                               ,N'{Model.CancelReason}'
                               ,N'{Model.digitalSignatureFeedback}'
                               ,N'{Model.Payment_terms}'
                               ,N'{Model.MainGroup_ID}'
                               ,N'{Model.Request_id}'
                               ,N'{Model.posserial}'
                               ,N'{Model.ReceiptNumber}'
                               ,N'{Model.transferDate}'
                               ,N'{Model.branchid}'
                               ,N'{Model.Url}'
                               ,N'{Model.ClientConfirmation}'
                               ,N'{Model.submissionUuid}'
                               ,N'{Model.R_ReceiptNumber}'
                               ,N'{Model.R_UUID}'
		                       )
                ";
                db.fire(q);
                return 1;
            }
            catch { return 0; }
        }
        public int AddInvoiceDetails(List<BillDetilesEntity> Models)
        {


            /// avoid date errors 
            /// 
            string q = "Begin Tran  ";
            foreach (var Model in Models)
            {
                if (Model.Date == null || Model.Date == "")
                    Model.Date = defaultdate;
                q += $@"
                INSERT INTO [dbo].[Bill_Detiles_Tbl]
                           ([SR_No]
                           ,[Items]
                           ,[IntCode]
                           ,[GPC_Code]
                           ,[Description]
                           ,[NumberOfUnits]
                           ,[UnitPrice]
                           ,[TotalPrice]
                           ,[Suppier_id]
                           ,[BillNo]
                           ,[ItemDiscount_rate]
                           ,[ItemDiscount_amount]
                           ,[sysItemID]
                           ,[documentType]
                           ,[environment_ID]
                           ,[comid]
                           ,[unitType_Ar]
                           ,[Currency]
                           ,[currencyExchangeRate]
                           ,[CusID]
                           ,[ServiceID]
                           ,[posserial]
                           ,[Editor]
                           ,[Request_id]
                           ,[branchid]
                           ,[Editor_id]
                           ,[Date]
                           ,[SubmittionUUID],Vat , GrossTotal,ETASend)
                     VALUES
                           (
		                    N'{Model.SR_No}'
                           ,N'{Model.Items}'
                           ,N'{Model.IntCode}'
                           ,N'{Model.GPC_Code}'
                           ,N'{Model.Description}'
                           ,N'{Model.NumberOfUnits}'
                           ,N'{Model.UnitPrice}'
                           ,N'{Model.TotalPrice}'
                           ,N'{Model.Suppier_id}'
                           ,N'{Model.BillNo}'
                           ,N'{Model.ItemDiscount_rate}'
                           ,N'{Model.ItemDiscount_amount}'
                           ,N'{Model.sysItemID}'
                           ,N'{Model.documentType}'
                           ,N'{Model.environment_ID}'
                           ,N'{Model.comid}'
                           ,N'{Model.unitType_Ar}'
                           ,N'{Model.Currency}'
                           ,N'{Model.currencyExchangeRate}'
                           ,N'{Model.CusID}'
                           ,N'{Model.ServiceID}'
                           ,N'{Model.posserial}'
                           ,N'{Model.Editor}'
                           ,N'{Model.Request_id}'
                           ,N'{Model.branchid}'
                           ,N'{Model.Editor_id}'
                           ,N'{Model.Date}'
                           ,N'{Model.SubmittionUUID}'
                           ,N'{Model.Vat}'
                           ,N'{Model.GrossTotal}' , N'{Model.ETASend}'
		                   )  
                ";
            }

            q += " Commit Tran ";
            try
            {
                db.fire(q);
                return 1;
            }
            catch { return 0; }
        }


        public (int GLE, int BillNo, int RequestId, int ComId) CreateInvoice(int RequestId, string receipt, List<AddBillModel> Models)
        {
            try
            {
                var Us = Coookie.Get().User;
                int ComId = TryParseInt(Us.ComID);
                // GET Customer Data 
                string CusDataQ = $@"
                                    select br.CustomerID, br.RecordID,br.Editor, br.Date,br.Comment,
                                    [dbo].[Cus_Tbl].CompanyName as Customer, 
                                    CONCAT(country,' , ' ,governate, ' , ' , regionCity, ' , ' , street) AS CustomerAddress 
                                    from dbo.BRO_Request_Tbl br 
                                    left join [dbo].[Cus_Tbl] on br.CustomerID = [dbo].[Cus_Tbl].Customer_Code 
                                    where br.RecordID ={RequestId}
                                    ";
                RequestGrid CusData = db.GetObject<RequestGrid>(CusDataQ);
                int Environment = GetEnvironmentToCompany(ComId);

                /// Calculate Invoice Totals 
                decimal ItemTotal = 0;
                decimal TotalTax = 0;
                decimal TotalAfterVAT = 0;
                decimal TotalAfterVATTrans = 0;

                foreach (var item in Models)
                {
                    /// For Printed  Bill 
                    ItemTotal += (item.price * GetExchangeRate(item.currency));
                    TotalAfterVAT += (item.price * GetExchangeRate(item.currency));
                    if (item.sendtoeta)
                    {
                        TotalTax += (item.vatamout * GetExchangeRate(item.currency));
                        TotalAfterVAT += (item.vatamout * GetExchangeRate(item.currency));
                    }
                    // For Transactions 
                    TotalAfterVATTrans += (item.vatamout * GetExchangeRate(item.currency));
                    TotalAfterVATTrans += (item.price * GetExchangeRate(item.currency));
                }
                /// Create Invoice in Bill Tbl 
                /// 
                int Bill_status = Us.InvConfirmation == 99 ? 3 : 2;///need confirm stutes = 3, else = 2
              // BillHeader
                BillEntity Bill = new BillEntity
                {
                    BillNo = NewInvoiceNo(ComId),
                    Bill_Stutes = TryParseByte(Bill_status),
                    documentType = "I",
                    Customer_ID = CusData.CustomerID,
                    VAT = TotalTax,
                    BillDate = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss"),
                    Editor = Us.UserName,
                    Date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss"),
                    TotalAmountBeforDiscount = ItemTotal,
                    TotalAmountAfterDiscount = ItemTotal,
                    TotalAmountAfterVAT = TotalAfterVAT,
                    comid = ComId,
                    validation = "pending",
                    sendToeta = Us.InvConfirmation,
                    editor_id = Us.RecordID.ToString(),
                    environment_ID = TryParseByte(Environment),
                    MainGroup_ID = Us.MainGroupID,
                    Request_id = RequestId
                };
                int AddInvoiceResult = AddInvoice(Bill);


                if (AddInvoiceResult > 0)
                {// Success 
                    // insert details
                    // 
                    int iterator = 1;
                    /////// Bill Details
                    ///
                    List<BillDetilesEntity> billdetails = new List<BillDetilesEntity>();
                    if (Models.Where(x => x.type == "service").Any())
                    {
                        foreach (var item in Models.Where(x => x.type == "service"))//Bill  services
                        {
                            BillDetilesEntity e = new BillDetilesEntity
                            {
                                SR_No = iterator++,
                                Items = item.name,
                                IntCode = item.account,
                                GPC_Code = "GS1",
                                Description = item.description,
                                NumberOfUnits = 1,
                                UnitPrice = item.price,
                                TotalPrice = item.price,
                                BillNo = Bill.BillNo,
                                sysItemID = int.Parse(item.account),
                                documentType = "I",
                                comid = ComId,
                                unitType_Ar = "وحده",
                                environment_ID = TryParseByte(Environment),
                                Currency = item.currency,
                                currencyExchangeRate = GetExchangeRate(item.currency),
                                Vat = item.vatamout,
                                GrossTotal = item.price + item.vatamout ,
                                ETASend = item.sendtoeta?"SEND":"NOTSEND"
                            };
                            billdetails.Add(e);
                        }
                    }
                    if (Models.Where(x => x.type == "expense").Any())
                    {
                        foreach (var item in Models.Where(x => x.type == "expense")) //Bill expense
                        {
                            BillDetilesEntity e = new BillDetilesEntity
                            {
                                SR_No = iterator++,
                                Items = item.name,
                                // IntCode = GetItemIntCodeFromAccountNumber(item.account),
                                IntCode = item.account,
                                GPC_Code = "GS1",
                                Description = item.description,
                                NumberOfUnits = 1,
                                UnitPrice = item.price,
                                TotalPrice = item.price,
                                BillNo = Bill.BillNo,
                                sysItemID = TryParseInt(GetItemIntCodeFromAccountNumber(item.account)),
                                documentType = "I",
                                comid = ComId,
                                unitType_Ar = "وحده",
                                environment_ID = TryParseByte(Environment),
                                Currency = item.currency,
                                currencyExchangeRate = GetExchangeRate(item.currency),
                                Vat = item.vatamout,
                                GrossTotal = item.price + item.vatamout,
                                ETASend = item.sendtoeta ? "SEND" : "NOTSEND"

                            };
                            billdetails.Add(e);

                        }
                    }
                    AddInvoiceDetails(billdetails);
                    ////// Update The REquest That IS Finished  
                    ///// status 3 is that request now have been invoice 
                    db.fire($"Update dbo.BRO_Request_Tbl  set status = 3 ,  thc_Receipt = N'{receipt}' where RecordID ={RequestId}");

                    return (0, Bill.BillNo, RequestId, ComId);

                }
                else
                {// Error 
                    return (0, 0, 0, 0);
                }

            }
            catch (Exception ex) {
                return (0, 0, 0, 0);
            }

        }

        public int GetCustomerId(string CustomerCode, int ComId)
        {
            string sql = $@"select accountID Acc from [dbo].[Cus_Tbl] where Customer_Code = '{CustomerCode}' and ComID ={ComId}";
            return db.GetValue<int>(sql, "Acc");
        }

        public int GetEnvironmentToCompany(int ComId)
        {
            string sql = $@"select Environment_ID ENV from dbo.ETA_document_Tbl where status = 1 and ComID = {ComId}";
            return db.GetValue<int>(sql, "ENV");
        }
        public decimal GetExchangeRate(string Currency)
        {
            string q = $"select currencyExchangeRate Rate from Currency_Tbl  where Currency ='{Currency}'";
            return db.GetValue<decimal>(q, "Rate");
        }
        public string GetItemIntCodeFromAccountNumber(string Acc)
        {
            try
            {

                string q = $@"select IntCode Code from items_tbl where accId in (select RecordId from Acc_Accounts_tbl where AccNumber='{Acc}' )";
                return db.GetValue<string>(q, "Code");
            } catch { return "0"; }

        }

        public int ChangeInvoiceState(int BillNo,string documentType ,  int State, string comment)
        {
            try
            {

                string qq = $"select count(*) Count from Bill_Detiles_Tbl where BillNo = N'{BillNo}' and documentType = N'{documentType}' and ETASend ='SEND'";
                int senttoetacount = db.GetValue<int>(qq, "Count");


                string validation = "";
                switch (State)
                {
                    case (0):
                        {
                            if (senttoetacount == 0)
                            {///// مش هيبعتها للضرائب 
                                State = 10;
                                validation = "NotSendToETA";
                            }
                            else
                            {/// هيبعتها للضرائب 
                                 validation = "pending";

                            }
                        }
                        break;
                    case (5):
                        validation = "cancelled";
                        break;
                    case (6):
                        validation = "rejected";
                        break;
                    default:
                        break;
                }

               
                string UpdateQuery = $"UPDATE Bill_tbl  SET SendTOETA = {State} , validation = N'{validation}' , comment = N'{comment}' where BillNo = {BillNo} and COMID = {Coookie.Get().ComID} and documentType =N'{documentType}'";

                db.fire(UpdateQuery);
                return 1;
            }
            catch { return 0; }
        }


        public List<BGValidInvoices_V> ValidInvoicesGrid() {
            var Models = db.Getable<BGValidInvoices_V>("BGValidInvoices_V");
            return Models; 
            }


        public void ChangeNote(string InvoiceNumber , string Doc, string Note)
        {
            db.fire($"NoteValidInvoice_pro '{InvoiceNumber}' , '{Doc}' , '{Note}','{Coookie.Get().User.RecordID}'");

        }
        private int TryParseInt(int? value)
        {
            try
            {
                return Int32.Parse(value.ToString());
            }catch{ return 0;  }
        } 
        public int TryParseInt(string value)
        {
            try
            {
                return Int32.Parse(value);
            }catch{ return 0;  }
        } 
        public Byte TryParseByte(int value)
        {
            try
            {
                return Byte.Parse(value.ToString());
            }catch{ return 0;  }
        }
    }

    public class SimpleClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
}