
using FastReport.Data;
using ScoposERB.Helper;
using ScoposERB.Helper.Statics;
using ScoposERB.Models.AccModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace ScoposERB.BL
{
    public class TransactionsService
    {
        private DeepHelper db = new DeepHelper();

        public bool UpdateLastbalanceAfterTranasction(int Tresury1, int Tresury2, string Currency,int paymentId)
        {
            // Update The Balance Of Currency To Two Tresures 
            try
            {
                db.fire($@"
                            update ACC_Transaction set BalanceAfterTran = (select isnull(Sum(Tran_Credit_Amt),0) - isnull(Sum(Tran_Debit_Amt),0) 
                                                    from ACC_Transaction Where Tran_account_code = {Tresury1}  and Tran_currency_id = N'{Currency}'  and Tran_payment_id = '{paymentId}' )
                                                    where ( BalanceAfterTran is Null or BalanceAfterTran = 0   ) and Tran_currency_id = N'{Currency}'  and Tran_payment_id = '{paymentId}'
                                                    and Tran_account_code ={Tresury1}
                        ");

                if(Tresury1 != Tresury2)
                {
                    db.fire($@"
                            update ACC_Transaction set BalanceAfterTran = (select isnull(Sum(Tran_Credit_Amt),0) - isnull(Sum(Tran_Debit_Amt),0) 
                                                    from ACC_Transaction Where Tran_account_code = {Tresury2}  and Tran_currency_id = N'{Currency}'  and Tran_payment_id = '{paymentId}' )
                                                    where  ( BalanceAfterTran is Null or BalanceAfterTran = 0   )  and Tran_currency_id = N'{Currency}'  and Tran_payment_id = '{paymentId}'
                                                    and Tran_account_code ={Tresury2}
                        ");
                }
                return true;
            }
            catch { return false; };
        }

        public bool InsertCheck(Acc_Bank_Check_Tbl_Entity Model)
        {
            try
            {
                string q = $@"
                    INSERT INTO [dbo].[Acc_Bank_Check_Tbl]
                               ([ComId]
                               ,[CheckNumber]
                               ,[CheckAmount]
                               ,[CheckType]
                               ,[TransactionNumber]
                               ,[Date]
                               ,[BankId]
                               ,[BankName]
                               ,[BankAddress]
                               ,[SenderId]
                               ,[SenderName]
                               ,[ReceiverId]
                               ,[ReceiverName])
                         VALUES
                               (
		                        N'{Model.ComId}'
                               ,N'{Model.CheckNumber}'
                               ,N'{Model.CheckAmount}'
                               ,N'{Model.CheckType}'
                               ,N'{Model.TransactionNumber}'
                               ,N'{Model.Date}'
                               ,N'{Model.BankId}'
                               ,N'{Model.BankName}'
                               ,N'{Model.BankAddress}'
                               ,N'{Model.SenderId}'
                               ,N'{Model.SenderName}'
                               ,N'{Model.ReceiverId}'
                               ,N'{Model.ReceiverName}'
		                       )
                                ";

                db.fire(q);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool Insert(ACC_Transaction_Entity Model)
        {
            if (Model.AddAttachTime == new DateTime())
            {
                Model.AddAttachTime = Convert.ToDateTime("2000-01-01 00:00:00");
            }
            Model.Tran_descripation = db.TryDecrypt(Model.Tran_descripation);
            Model.Tran_refernce = db.TryDecrypt(Model.Tran_refernce);
            

            try
            {

                string q = $@"
INSERT INTO [dbo].[ACC_Transaction]
           ([Tran_account_code]
           ,[Tran_date]
           ,[Tran_Amount]
           ,[Tran_Status]
           ,[Tran_isposted]
           ,[Tran_refernce]
           ,[Tran_type]
           ,[Tran_descripation]
           ,[Tran_reconciled]
           ,[Tran_purchase_bill_id]
           ,[Tran_sales_bill_id]
           ,[Tran_purchase_return_bil_id]
           ,[Tran_sales_return_sales_id]
           ,[Tran_receipt_id]
           ,[Tran_purchase_bill_item_id]
           ,[Tran_sales_bill_item_id]
           ,[Tran_item_receipt_id]
           ,[Tran_purchase_return_item_id]
           ,[Tran_sales_return_item_id]
           ,[Tran_general_ledger_id]
           ,[Tran_payment_id]
           ,[Tran_receive_id]
           ,[Tran_assets_id]
           ,[Tran_isbegining_balance]
           ,[Tran_check_No]
           ,[Tran_inventory_adustement_item_id]
           ,[Tran_buildingunbuild_id]
           ,[Tran_assembply_combonines]
           ,[Tran_before_beginning_balance]
           ,[Tran_after_beginning_balance]
           ,[Tran_vendor_id]
           ,[Tran_customer_id]
           ,[Tran_user_id]
           ,[Tran_rfernce2]
           ,[Tran_costcenter]
           ,[Tran_discount]
           ,[Tran_currency_id]
           ,[Tran_company_id]
           ,[Tran_check_book_id]
           ,[Tran_item_recipt_id]
           ,[Tran_Comment]
           ,[Tran_Credit_Amt]
           ,[Tran_Debit_Amt]
           ,[Request_id]
           ,[bank_ID]
           ,[Credit_Card]
           ,[Car_Id]
           ,[tran_ExchangeRate]
           ,[Tran_Return]
           ,[Tran_ID]
           ,[IS_Returned]
           ,[BalanceAfterTran]
           ,[AttachFilePath]
           ,[UserAddAttach]
           ,[AddAttachTime],[CheckIsCollected])
     VALUES
           (
		    '{Model.Tran_account_code}'
           ,'{Model.Tran_date}'
           ,'{Model.Tran_Amount}'
           ,'{Model.Tran_Status}'
           ,'{Model.Tran_isposted}'
           ,N'{Model.Tran_refernce}'
           ,'{Model.Tran_type}'
           ,N'{Model.Tran_descripation}'
           ,'{Model.Tran_reconciled}'
           ,'{Model.Tran_purchase_bill_id}'
           ,'{Model.Tran_sales_bill_id}'
           ,'{Model.Tran_purchase_return_bil_id}'
           ,'{Model.Tran_sales_return_sales_id}'
           ,'{Model.Tran_receipt_id}'
           ,'{Model.Tran_purchase_bill_item_id}'
           ,'{Model.Tran_sales_bill_item_id}'
           ,'{Model.Tran_item_receipt_id}'
           ,'{Model.Tran_purchase_return_item_id}'
           ,'{Model.Tran_sales_return_item_id}'
           ,'{Model.Tran_general_ledger_id}'
           ,'{Model.Tran_payment_id}'
           ,'{Model.Tran_receive_id}'
           ,'{Model.Tran_assets_id}'
           ,'{Model.Tran_isbegining_balance}'
           ,'{Model.Tran_check_No}'
           ,'{Model.Tran_inventory_adustement_item_id}'
           ,'{Model.Tran_buildingunbuild_id}'
           ,'{Model.Tran_assembply_combonines}'
           ,'{Model.Tran_before_beginning_balance}'
           ,'{Model.Tran_after_beginning_balance}'
           ,'{Model.Tran_vendor_id}'
           ,'{Model.Tran_customer_id}'
           ,'{Model.Tran_user_id}'
           ,N'{db.TryDecrypt(Model.Tran_rfernce2)}'
           ,'{Model.Tran_costcenter}'
           ,'{Model.Tran_discount}'
           ,N'{Model.Tran_currency_id}'
           ,'{Model.Tran_company_id}'
           ,'{Model.Tran_check_book_id}'
           ,'{Model.Tran_item_recipt_id}'
           ,'{Model.Tran_Comment}'
           ,'{Model.Tran_Credit_Amt}'
           ,'{Model.Tran_Debit_Amt}'
           ,'{Model.Request_id}'
           ,'{Model.bank_ID}'
           ,'{Model.Credit_Card}'
           ,'{Model.Car_Id}'
           ,'{Model.tran_ExchangeRate}'
           ,'{Model.Tran_Return}'
           ,'{Model.Tran_ID}'
           ,'{Model.IS_Returned}'
           ,'{Model.BalanceAfterTran}'
           ,'{Model.AttachFilePath}'
           ,'{Model.UserAddAttach}'
           ,'{Model.AddAttachTime}'
           ,'{Model.CheckIsCollected}'
		   )";



                db.fire(q);
                return true;
            }
            catch { return false; };

        }
        public bool InsertGereralJourney(Acc_general_journal_entryEntity AccGeneral)
        {


            try
            {
                string q = $@"

INSERT INTO [dbo].[Acc_general_journal_entry]
           ([general_entry_date]
           ,[general_entry_reference]
           ,[general_entry_isactive]
           ,[general_entry_comment]
           ,[general_entry_reverse]
           ,[general_entry_costcenter_id]
           ,[general_entry_category]
           ,[general_entry_branch]
           ,[general_entry_user]
           ,[general_entry_isposted]
           ,[general_entry_company]
           ,[general_entry_TotalCredit]
           ,[general_entry_TotalDebits]
           ,[Request_id]
           ,[general_entry_vendorId] , SecondPartyPersonName)
     VALUES
           (
		    N'{AccGeneral.general_entry_date}'
           ,N'{AccGeneral.general_entry_reference}'
           ,N'{AccGeneral.general_entry_isactive}'
           ,N'{AccGeneral.general_entry_comment}'
           ,N'{AccGeneral.general_entry_reverse}'
           ,N'{AccGeneral.general_entry_costcenter_id}'
           ,N'{AccGeneral.general_entry_category}'
           ,N'{AccGeneral.general_entry_branch}'
           ,N'{AccGeneral.general_entry_user}'
           ,N'{AccGeneral.general_entry_isposted}'
           ,N'{AccGeneral.general_entry_company}'
           ,N'{AccGeneral.general_entry_TotalCredit}'
           ,N'{AccGeneral.general_entry_TotalDebits}'
           ,N'{AccGeneral.Request_id}'
           ,N'{AccGeneral.general_entry_vendorId}',N'{AccGeneral.SecondPartyPersonName}'
		   )
                            ";
                db.fire(q);
                return true;
            }
            catch { return false; };

        }
        public bool InsertTwoTransaction(Acc_general_journal_entryEntity AccGeneral, ACC_Transaction_Entity Model1, ACC_Transaction_Entity Model2)
        {
            bool joournalist = InsertGereralJourney(AccGeneral);
            if (joournalist)
            {

                /// This Method To Ensure Two Transaction Are Saved ToGhethrt 
                int x1 = Insert(Model1) == true ? 1 : 0;
                int x2 = 0;

                if (Model2 == null) ///// This Is If I Want To Save One Tran Only With Journalist 
                    x2 = 1;
                else
                    x2 = Insert(Model2) == true ? 1 : 0;


                if (x1 + x2 == 2) /// Two Transaction Saved
                    return true;
                if (x1 + x2 == 1)
                {
                    // Only One Transaction Saved So Delete It 
                    db.fire($"delete from [ACC_Transaction] where RecordId in (select max(RecordId) from [ACC_Transaction] )");
                    db.fire($"delete from  [Acc_general_journal_entry] where RecordId in (select max( recordid) from [Acc_general_journal_entry] )");
                    return false;
                }
                else /// No Transaction Saved {
                {
                    db.fire($"delete from  [Acc_general_journal_entry] where RecordId in (select max( recordid) from [Acc_general_journal_entry] )");
                    return false;
                }
            }


            return false; /// No Any Record Added 

        }
        public bool CollectCheck(string checkNumber, string pay, string bank, string creditCard,string desc)
        {
            bool result = false;
            var user = Coookie.Get().User;
            try
            {

            int comid = Int32.Parse(user.ComID.ToString());
           
            string q = $@"select Tran_account_code , Tran_company_id ,Tran_currency_id,
                    isnull(bank_ID,0)bank_ID , isnull(tran_ExchangeRate,0.00)tran_ExchangeRate ,Tran_Debit_Amt , Tran_Credit_Amt
                    from Acc_Transaction where Tran_check_No = '{checkNumber}' order by Tran_Credit_Amt desc";
            List<ACC_Transaction_Entity> oldcheck = db.GetList<ACC_Transaction_Entity>(q) ;// Result two Column 
            int GLE = NewGLE(comid);
            var journalist = new Acc_general_journal_entryEntity()
            {
                general_entry_date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                general_entry_reference = "GLE -" + GLE,
                general_entry_user = user.RecordID,
                general_entry_branch = user.Branch_RecordID,
                general_entry_isposted = 0,
                general_entry_company = comid,
                general_entry_TotalCredit = oldcheck[0].Tran_Credit_Amt,
                general_entry_TotalDebits = oldcheck[0].Tran_Credit_Amt
            };
             var Tran1 = new ACC_Transaction_Entity
            {
                Tran_account_code = oldcheck[0].Tran_account_code,
                Tran_date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                Tran_Status = 1,
                Tran_isposted = 0,
                Tran_refernce = "GLE -" + GLE,
                Tran_user_id = user.RecordID,
                Tran_currency_id = oldcheck[0].Tran_currency_id,
                tran_ExchangeRate =oldcheck[0].tran_ExchangeRate,
                Tran_company_id = GetInt(user.ComID),
                Tran_Debit_Amt = 0,
                Tran_Credit_Amt = oldcheck[0].Tran_Credit_Amt,
                Tran_rfernce2 = oldcheck[0].Tran_refernce,
                Tran_payment_id = GetInt(pay),
                bank_ID = GetInt(bank),
                Credit_Card = GetInt(creditCard),
                Tran_descripation = desc,
                Tran_ID = GLE,
                Tran_Return = 0
            };
            var Tran2 = new ACC_Transaction_Entity
            {
                Tran_account_code =ApplicationSetting.BrotherAccountofCollectChecks,
                Tran_date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                Tran_Status = 1,
                Tran_isposted = 0,
                Tran_refernce = "GLE -" + GLE,
                Tran_user_id = user.RecordID,
                Tran_currency_id = oldcheck[0].Tran_currency_id,
                tran_ExchangeRate = oldcheck[0].tran_ExchangeRate,
                Tran_company_id = GetInt(user.ComID),
                Tran_Debit_Amt = oldcheck[0].Tran_Credit_Amt,
                Tran_Credit_Amt =0,
                Tran_rfernce2 = oldcheck[0].Tran_refernce,
                Tran_payment_id = GetInt(pay),
                bank_ID = GetInt(bank),
                Credit_Card = GetInt(creditCard),
                Tran_descripation = desc,
                Tran_ID = GLE,
                Tran_Return = 0
            };
            InsertTwoTransaction(journalist, Tran1, Tran2);
            UpdateLastbalanceAfterTranasction(Tran1.Tran_account_code, Tran2.Tran_account_code, Tran1.Tran_currency_id,Tran1.Tran_payment_id);
                 q = $"update Acc_Transaction set CheckIsCollected = {Tran1.Tran_payment_id} where Tran_check_No = '{checkNumber}'";
                db.fire(q);
                result = true;
            }

            catch { }


            return result;
        }
        public int NewGLE(int ComID)
        {
            string sql = $"select max(RecordID) as RecordID From[dbo].[Acc_general_journal_entry] where general_entry_company = {ComID}";
            try
            {
                return db.GetValue<int>(sql, "RecordID")+1;
            }
            catch { return 1; }
        }
        public string TranUserName (int GLE)
        {
            try
            {
                string q = $@"select UserName UserName from TblUsers where RecordId = 
                    (select top 1 Tran_user_id from Acc_Transaction where Tran_refernce = Concat('GLE -','{GLE}') )";
                string k = db.GetValue<string>(q, "UserName");
                var UserName =  db.TryDecrypt(k);
                if (UserName == k)
                    return "";
                return UserName;
            }
            catch { return ""; };
        }
        public string AppropriateReportFilePath(string TranType , int PaymentMethod )// return Appropriate file Path 
        {
            string BasePath = HttpContext.Current.Server.MapPath("~")+ @"Reports\Brothers\";
            switch (TranType)
            {
                case "C":
                    switch (PaymentMethod)
                    {
                        //cash 
                        case 1:
                            BasePath += "_BrotherRecieve_C_Cash.frx";
                            break;
                        // Bank Check 
                        case 2:
                            BasePath += "_BrotherRecieve_C_BankCheck.frx";

                            break;
                        // Credit Card 
                        case 3:
                            BasePath += "_BrotherRecieve_C_Credit Card.frx";
                            break;
                        // Account Transfere 
                        case 4:
                            BasePath += "_BrotherRecieve_C_AccountTransfere.frx";
                            break;
                        default:
                   
                            break;
                    }
                    break;
                case "D":
                    switch (PaymentMethod)
                    {
                        //cash 
                        case 1:
                            BasePath += "_BrotherRecieve_D_Cash.frx";
                            break;
                        // Bank Check 
                        case 2:
                            BasePath += "_BrotherRecieve_D_BankCheck.frx";
                            break;
                        // Credit Card 
                        case 3:
                            BasePath += "_BrotherRecieve_D_Credit Card.frx";
                            break;
                        // Account Transfere 
                        case 4:
                            BasePath += "_BrotherRecieve_D_AccountTransfere.frx";
                            break;
                        default:break;
                    }
                    break;

               default :
                    BasePath += "";
                        break;
                    ;
            }

            return BasePath;
        }
        public int GetInt(string Key)
        {
            try
            {
                return Int32.Parse(Key);
            }
            catch { return 0; };
        }
        public int GetInt(int? Key)
        {
            try
            {
                if (Key == null)
                    return 0;
                return Int32.Parse(Key.ToString());
            }
            catch { return 0; };
        }

      
        public decimal GetDecimal(decimal? Key)
        {
            try
            {
                if (Key == null)
                    return 0;
                return Decimal.Parse(Key.ToString());
            }
            catch { return 0; };
        }
    }
}