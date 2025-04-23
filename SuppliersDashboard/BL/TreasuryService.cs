
using Microsoft.Ajax.Utilities;
using ScoposERB.Helper;
using ScoposERB.Models.AccModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ScoposERB.BL
{
    public class TreasuryService
    {
        private DeepHelper CRUD = new DeepHelper();

        public List<Select> GetMainTreasures(int? ComId ,int BranchId )
        {
            try
            {
               // string q = $"SELECT RecordID Id ,  EngName Name , ArabName ARName  FROM Acc_Accounts_tbl  Where ComID = {ComId} and MainOrSub = 1 and ParentId In ( 52,54 , 55 , 29 )";
                string q = $@"SELECT RecordID Id ,  EngName Name , ArabName ARName from [dbo].[Acc_Accounts_tbl] 
                                        where AccountCategory= 6 and state = 1 and Level = 4 
and ComID = {ComId}  and Branch_ID = {BranchId}";
                                        //sand MainOrSub = 1
                List<Select> list = CRUD.GetList<Select>(q);
                return list;

            } catch (Exception ex)  {return new List<Select>();}
        }
        public TresuryData GetTresuryTransactionInCurrentMonth(int AccountId )
        {
            TresuryData tresury = new TresuryData();
            tresury.Month = TbiServer.Time(DateTime.Now).ToString("yyyy-MMMM");
            int Year = TbiServer.Time(DateTime.Now).Year;  
            int Month = TbiServer.Time(DateTime.Now).Month;
            try
            {
                /// Get Cash Balance Of The Tresure Of All Time First 
                string Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code =  {AccountId} and Tran_Status = 1 and (Tran_payment_id=1 )
									 group by Tran_currency_id
									 order by Tran_currency_id ";
                
                tresury.Balance = CRUD.GetList<TresuryBalance>(Q);

                /// Get UnCollected Checks Balance Of The Tresure Of All Time First 
                 Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code =  {AccountId} and Tran_Status = 1 and Tran_payment_id=2 and CheckIsCollected = 0  
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.UnCollectedChecksBalance = CRUD.GetList<TresuryBalance>(Q); 
                /// Get Credits  Balance Of The Tresure Of All Time First 
                 Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code =  {AccountId} and Tran_Status = 1 and Tran_payment_id=3 
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.CreditsBalance = CRUD.GetList<TresuryBalance>(Q);  
                /// Get Account Transfere   Balance Of The Tresure Of All Time First 
                 Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code =  {AccountId} and Tran_Status = 1 and Tran_payment_id=4 
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.AccountTransfereBalance = CRUD.GetList<TresuryBalance>(Q);
                // Get All Transaction Credit And Debit 
                Q = $@" SELECT 
                        T.Tran_account_code TranCode,Acc.ArabName TranAccountName, T.Tran_Debit_Amt , T.Tran_Credit_Amt, convert(varchar, T.Tran_date , 25)TranDate , 
                        T.Tran_refernce TranReference , T.Tran_type TranType , T.Tran_descripation TranDescription , 
                        T.Tran_payment_id TranPaymentId , [PI].EngName Payment , [PI].ArName ARPayment,
                        T.Tran_user_id TranUserId , U.UserName , T.Tran_currency_id TranCurrency , tran_ExchangeRate TranExchangeRate ,
                        isnull(T.BalanceAfterTran,0.00) BalanceAfterTran , isnull(T.AttachFilePath ,'NO') AttachFilePath 
                        FROM ACC_Transaction T
                        left join [ACC_PaymentMethod] [PI] on T.Tran_payment_id = [PI].RecordID
                        join TblUsers U on U.RecordId = T.Tran_user_id
                        join ACC_ACCOUNTS_Tbl Acc on Acc.RecordID = T.Tran_account_code
                        where T.Tran_account_code =  {AccountId}
                        and Year(T.Tran_date) = {Year} and Month(T.Tran_date) = {Month} 
                        and Tran_Status = 1 
                       Order By T.recordId DESC";
                // This List Have Two Credits And Debits 
                List<TresuryTransaction> C_And_Dtrans = CRUD.GetList<TresuryTransaction>(Q);
                C_And_Dtrans.Select(s => { s.UserName = CRUD.TryDecrypt(s.UserName); return s; }).ToList();
                tresury.CreditsAndDebits = C_And_Dtrans;
                tresury.Credits = C_And_Dtrans.Where(s => s.TranType.Trim() == "C").ToList();
                tresury.Debits = C_And_Dtrans.Where(s => s.TranType.Trim() == "D").ToList();

                /// Get Sum Of Credits And Debits In Curent MOnth 
                //Q = $"select isnull(sum(Tran_Credit_Amt),0) Credit  from ACC_Transaction T where T.Tran_account_code =  {AccountId} and Year(T.Tran_date) = {Year} and Month(T.Tran_date) = {Month}";
                //tresury.Credit = CRUD.GetValue<decimal>(Q, "Credit");    
                //Q = $"select isnull(sum(Tran_Debit_Amt),0) Debit  from ACC_Transaction T where T.Tran_account_code =  {AccountId} and Year(T.Tran_date) = {Year} and Month(T.Tran_date) = {Month}";
                //tresury.Debit = CRUD.GetValue<decimal>(Q, "Debit");


                //// GEt Name Of Tresury 
                tresury.TresuryName = CRUD.GetValue<string>($"Select Concat(ArabName , ' - ' , EngName) TresuryName from [Acc_Accounts_tbl]  where RecordID = {AccountId}", "TresuryName");
               //return 
                return tresury;

            }
            catch (Exception ex) { return new TresuryData(); }
        }

        public int GetUserTresury(int comid , int branchid)
        {
            int Tresury = 0;
            string q = $@"SELECT Top 1 RecordID Id ,  EngName Name , ArabName ARName from [dbo].[Acc_Accounts_tbl] 
                                        where AccountCategory= 6 and state = 1 
                                    and ComID = {comid}  and level=4 and Branch_ID = {branchid}";
                                        //and MainOrSub = 1 

            try
            {
                Tresury = CRUD.GetValue<int>(q, "Id");
            }
            catch { };
            return Tresury;
        }
       
        public List<ACC_Transaction_Entity> GetUnCollectedChecks(int TresuryId)
        {
            string q = $@"select isnull(Tran_account_code,0)Tran_account_code,isnull(Tran_check_No,0)Tran_check_No,Tran_account_code , Convert(  nvarchar,Tran_date ,0) Tran_date,  Tran_descripation,Tran_refernce,
                          Tran_user_id , Tran_currency_id , Tran_company_id , isnull(Tran_ID,0) ,Tran_Credit_Amt , Tran_Debit_Amt , isnull(bank_ID,0)bank_ID
                                from ACC_Transaction
                                where Tran_account_code = {TresuryId}
                                and Tran_payment_id =2 and Tran_type = 'C' and Tran_Status = 1 
                                and  CheckIsCollected = 0 ";
            try
            {
                var result = CRUD.GetList<ACC_Transaction_Entity>(q);
                return result;
            }
            catch { return new List<ACC_Transaction_Entity>(); };
        }


        #region Deep Editions 10/12/2023 


        /// <summary>
        /// //بترجع الاكونتات الي تحت الخزنة بتاعة اليوزرلا 
        /// </summary>
        public List<Acc_Accounts_tbl> UserTresuryChildsAccounts(int AccId = 0 , int withparent = 0 )
        {
            var user = Coookie.Get().User;
            int treauryofuser = GetUserTresury(Convert.ToInt32(user.ComID), user.Branch_RecordID);
            if (AccId != 0)
                treauryofuser = AccId;
            List<int> currentParentsIds = new List<int> { treauryofuser };///// ITERATORS 
             List<Acc_Accounts_tbl> CurrentParentsInLevel ;


            List<Acc_Accounts_tbl> LastChilds = new List<Acc_Accounts_tbl>();

            string q; 
            while (true)
            {
                q = $"select * from ACC_ACCOUNTS_Tbl where ParentId  in {GetIn(currentParentsIds)}";

               CurrentParentsInLevel = CRUD.GetList<Acc_Accounts_tbl>(q);
                if (CurrentParentsInLevel.Count == 0)// end 
                    break;
                currentParentsIds = CurrentParentsInLevel.Select(x => x.RecordID).ToList();// childs in the next level 
                
                foreach(var item in CurrentParentsInLevel)
                {
                    if(item.MainOrSub == 1 )//Last Child 
                        LastChilds.Add(item);
                }

            }
          
            if(withparent == 1)
            {
                q = $"select * from ACC_ACCOUNTS_Tbl where RecordId = {treauryofuser} ";
                var parent = CRUD.GetList<Acc_Accounts_tbl>(q);
                LastChilds = parent.Union(LastChilds).ToList();

            }
            return LastChilds;
        }
        /// //بترجع الايديهات الاكونتات الي تحت الخزنة بتاعة اليوزرلا 

        public List<int> UserTresuryChildsAccountIds(int AccId = 0 ) => UserTresuryChildsAccounts(AccId).Select(x => x.RecordID).ToList();
        public List<int> UserTresuryChildsAccountWithParentIds(int AccId  ) => UserTresuryChildsAccounts(AccId).Select(x => x.RecordID).ToList().Union(new List<int> { AccId}).ToList();
        /// <summary>
        /// / االفرق ان ددي بتجيب كل الاكونتات الي تحت الخزنة وتجمعهم 
        /// </summary>
        /// <param name="AccountId"> الخزنة بتاعة اليوزر </param>
        /// <returns></returns>
        public TresuryData GetTresuryTransactionInCurrentMonthV2(int AccountId , int Year = 0 , int Month = 0 )
        {
            TresuryData tresury = new TresuryData();
            if(Year ==0 )
              Year = TbiServer.Time(DateTime.Now).Year;
            if(Month ==0)
             Month = TbiServer.Time(DateTime.Now).Month;
            tresury.Month = DateTime.Parse($"{Year}-{Month}-01").ToString("yyyy-MMMM");
            var x = UserTresuryChildsAccountWithParentIds(AccountId);
            try
            {
                /// Get Cash Balance Of The Tresure Of All Time First 
                string Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code In {GetIn(UserTresuryChildsAccountWithParentIds(AccountId))} and Tran_Status = 1 and (Tran_payment_id=1 )
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.Balance = CRUD.GetList<TresuryBalance>(Q);

                /// Get UnCollected Checks Balance Of The Tresure Of All Time First 
                Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code In {GetIn(UserTresuryChildsAccountWithParentIds(AccountId))} and Tran_Status = 1 and Tran_payment_id=2 and CheckIsCollected = 0  
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.UnCollectedChecksBalance = CRUD.GetList<TresuryBalance>(Q);
                /// Get Credits  Balance Of The Tresure Of All Time First 
                Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code  In {GetIn(UserTresuryChildsAccountWithParentIds(AccountId))} and Tran_Status = 1 and Tran_payment_id=3 
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.CreditsBalance = CRUD.GetList<TresuryBalance>(Q);
                /// Get Account Transfere   Balance Of The Tresure Of All Time First 
                Q = $@" Select Tran_currency_id Currency,  isnull(Sum(Tran_Credit_Amt),0) -isnull(Sum(Tran_Debit_Amt),0)   Value 
                                     From ACC_Transaction
                                     where Tran_account_code In {GetIn(UserTresuryChildsAccountWithParentIds(AccountId))} and Tran_Status = 1 and Tran_payment_id=4 
									 group by Tran_currency_id
									 order by Tran_currency_id ";

                tresury.AccountTransfereBalance = CRUD.GetList<TresuryBalance>(Q);
                // Get All Transaction Credit And Debit 
                Q = $@" SELECT 
                        T.Tran_account_code TranCode,Acc.ArabName TranAccountName, T.Tran_Debit_Amt , T.Tran_Credit_Amt, convert(varchar, T.Tran_date , 25)TranDate , 
                        T.Tran_refernce TranReference , T.Tran_type TranType , T.Tran_descripation TranDescription , 
                        T.Tran_payment_id TranPaymentId , [PI].EngName Payment , [PI].ArName ARPayment,
                        T.Tran_user_id TranUserId , U.UserName , T.Tran_currency_id TranCurrency , tran_ExchangeRate TranExchangeRate ,
                        isnull(T.BalanceAfterTran,0.00) BalanceAfterTran , isnull(T.AttachFilePath ,'NO') AttachFilePath 
                        FROM ACC_Transaction T
                        left join [ACC_PaymentMethod] [PI] on T.Tran_payment_id = [PI].RecordID
                        join TblUsers U on U.RecordId = T.Tran_user_id
                         join ACC_ACCOUNTS_Tbl Acc on Acc.RecordID = T.Tran_account_code
                        where T.Tran_account_code  In {GetIn(UserTresuryChildsAccountWithParentIds(AccountId))}
                        and Year(T.Tran_date) = {Year} and Month(T.Tran_date) = {Month} 
                        and Tran_Status = 1 
                       Order By T.recordId DESC";
                // This List Have Two Credits And Debits 
                List<TresuryTransaction> C_And_Dtrans = CRUD.GetList<TresuryTransaction>(Q);
                C_And_Dtrans.Select(s => { s.UserName = CRUD.TryDecrypt(s.UserName); return s; }).ToList();
                tresury.CreditsAndDebits = C_And_Dtrans;
                tresury.Credits = C_And_Dtrans.Where(s => s.TranType.Trim() == "C").ToList();
                tresury.Debits = C_And_Dtrans.Where(s => s.TranType.Trim() == "D").ToList();

                /// Get Sum Of Credits And Debits In Curent MOnth 
                //Q = $"select isnull(sum(Tran_Credit_Amt),0) Credit  from ACC_Transaction T where T.Tran_account_code =  {AccountId} and Year(T.Tran_date) = {Year} and Month(T.Tran_date) = {Month}";
                //tresury.Credit = CRUD.GetValue<decimal>(Q, "Credit");    
                //Q = $"select isnull(sum(Tran_Debit_Amt),0) Debit  from ACC_Transaction T where T.Tran_account_code =  {AccountId} and Year(T.Tran_date) = {Year} and Month(T.Tran_date) = {Month}";
                //tresury.Debit = CRUD.GetValue<decimal>(Q, "Debit");


                //// GEt Name Of Tresury 
                tresury.TresuryName = CRUD.GetValue<string>($"Select Concat(ArabName , ' - ' , EngName) TresuryName from [Acc_Accounts_tbl]  where RecordID = {AccountId}", "TresuryName");
                //return 
                return tresury;

            }
            catch (Exception ex) { return new TresuryData(); }
        }
        public string TresuryName (int TresuryId) => CRUD.GetValue<string>($"Select Concat(ArabName , ' - ' , EngName) TresuryName from [Acc_Accounts_tbl]  where RecordID = {TresuryId}", "TresuryName");
        public string GetIn(List<int> values)
        {
            string q = "(";
            for(int i = 0; i<values.Count; i++)
            {
                if (i == 0)
                    q += values[i];
                 else
                    q += "," +values[i];   
            }
            q += ")";
            return q;
        }

        /// الفانكشن دي عملتها عشان كان الريكويست بيكيش فهرنها مرة واحدة تظبط الداتا القديمة 
        public void FixBroData()
                {
                    int id = GetMainTreasures(Convert.ToInt32(Coookie.Get().ComID), Coookie.Get().User.Branch_RecordID).FirstOrDefault().Id;
                    var minetresuries = UserTresuryChildsAccountWithParentIds(id);
                    var rfrnss = $"select *  from ACC_Transaction where Tran_account_code not in {GetIn(minetresuries)}";
                    DataTable dt = CRUD.fireDT(rfrnss);
                  for(int i = 0; i < dt.Rows.Count; i++)
                    {
                         int tranacc = (int) dt.Rows[i]["Tran_account_code"];
                            string gle = (string)dt.Rows[i]["Tran_refernce"]; 
                            if(AccountIsRequestServiceAccountChild(tranacc))
                            {

                            }
                            else
                            {
                                 CRUD.fire($"update ACC_Transaction set request_id = 0 where Tran_refernce = N'{gle}'");
                            }
                    }



                }

        public bool CheckIfParent(int ParentId, int ChildId)
        {



            while (ChildId != 0)
            {
                int x = CRUD.GetValue<int>($"Select ParentID from Acc_Accounts_tbl where RecordID ={ChildId} ", "ParentID");
                if (x == ParentId)
                {
                    return true;
                }
                else
                {
                    ChildId = x;
                }
            }
            return false;
        }
        public bool AccountIsRequestServiceAccountChild(int accountId)
        {
            return CheckIfParent(22, accountId);
        }
        #endregion
    }
    public class TresuryData{
        public TresuryData()
        {
            this.Credits = new List<TresuryTransaction>();
            this.Debits = new List<TresuryTransaction>();
            this.CreditsAndDebits = new List<TresuryTransaction>();
            this.Balance = new List<TresuryBalance>();
            this.CreditsBalance = new List<TresuryBalance>();
            this.UnCollectedChecksBalance = new List<TresuryBalance>();
            this.AccountTransfereBalance = new List<TresuryBalance>();
                
        }
      
        public string TresuryName { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public string Month { get; set; }
        public List<TresuryBalance> Balance { get; set; }
        public List<TresuryBalance> UnCollectedChecksBalance { get; set; }
        public List<TresuryBalance> CreditsBalance { get; set; }
        public List<TresuryBalance> AccountTransfereBalance { get; set; }
        public  List<TresuryTransaction> Credits { get; set; }
       public List<TresuryTransaction> Debits { get; set; }
       public List<TresuryTransaction> CreditsAndDebits { get; set; }
    }
    public class TresuryBalance
    {
        public string Currency { get; set; }
        public decimal Value { get; set; }
    }
    public class TresuryTransaction
    {
        public int TranCode { get; set; }
        public string TranAccountName { get; set; }
        public string TranDate { get; set; }
        public string TranReference { get; set; }
        public string TranType { get; set; }
        public string TranDescription { get; set; }
        public int TranPaymentId { get; set; }
        public string Payment { get; set; }
        public string ARPayment { get; set; }
        public int TranUserId { get; set; }
        public string UserName { get; set; }
        public string TranCurrency { get; set; }
        public decimal TranExchangeRate { get; set; }
        public decimal Tran_Credit_Amt { get; set; }
        public decimal Tran_Debit_Amt { get; set; }
        public decimal BalanceAfterTran { get; set; }
        public string AttachFilePath { get; set; }

        // 											
    }
}