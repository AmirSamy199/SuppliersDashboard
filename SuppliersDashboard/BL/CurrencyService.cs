using ScoposERB.Helper;
using ScoposERB.Models.AccModels;
using SuppliersDashboard.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;


namespace ScoposERB.BL
{

    public class CurrencyService
    {
        
        private readonly DeepHelper db; 
        private readonly TreasuryService _tresury; 
        private readonly TransactionsService _tran; 
        private readonly InvoiceRepo _inv; 

        public CurrencyService()
        {
            this.db = new DeepHelper();
            this._tresury = new TreasuryService();
            this._tran = new TransactionsService();
            this._inv=  new InvoiceRepo();
        }

       public List<BroTresuryCashBalances_V> TresuresBalances()
        {
            int baseTresury = _tresury.GetUserTresury(Convert.ToInt32(Coookie.Get().ComID) , Coookie.Get().User.Branch_RecordID);
            List<int> usertresures = _tresury.UserTresuryChildsAccountWithParentIds(baseTresury);
            string condition = _tresury.GetIn(usertresures);
            string q = $"select * from BroTresuryCashBalances_V where Tran_account_code in {condition}  order by tran_account_code";

            return db.GetList<BroTresuryCashBalances_V>(q);
        }

        public string CurrencyTranformation(int From, int To, string CurrencyFrom, string CurrencyTo, decimal? AmountFrom, decimal? AmountTo, string Message , string Reference)
        {
            try
            {

            if (AmountFrom < 0 || AmountTo < 0)
                return "Enter Valid Amounts";
            var user = Coookie.Get().User;
            int comid = Convert.ToInt32(Coookie.Get().ComID);
            int GLE = _tran.NewGLE(comid);

            var journalist = new Acc_general_journal_entryEntity()
            {
                general_entry_date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                general_entry_reference = "GLE -" + GLE,
                general_entry_user = user.RecordID,
                general_entry_branch = user.Branch_RecordID,
                general_entry_isposted = 0,
                general_entry_company = comid,
                general_entry_TotalCredit = Convert.ToDecimal(AmountTo),
                general_entry_TotalDebits = Convert.ToDecimal(AmountTo)
            };
            var Tran1 = new ACC_Transaction_Entity
            {
                Tran_account_code = From,
                Tran_date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                Tran_Status = 1,
                Tran_isposted = 0,
                Tran_refernce = "GLE -" + GLE,
                Tran_user_id = user.RecordID,
                Tran_currency_id = CurrencyFrom,
                tran_ExchangeRate = _inv.GetExchangeRate(CurrencyFrom),
                Tran_company_id = comid,
                Tran_Debit_Amt = Convert.ToDecimal(AmountFrom),
                Tran_Credit_Amt =0,
                Tran_rfernce2 = Reference,
                Tran_payment_id =1,
                bank_ID =0,
                Credit_Card =0,
                Tran_descripation = Message,
                Tran_ID = GLE,
                Tran_Return = 0
            };
            var Tran2 = new ACC_Transaction_Entity
            {
                Tran_account_code = To,
                Tran_date = TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                Tran_Status = 1,
                Tran_isposted = 0,
                Tran_refernce = "GLE -" + GLE,
                Tran_user_id = user.RecordID,
                Tran_currency_id = CurrencyTo,
                tran_ExchangeRate = _inv.GetExchangeRate(CurrencyTo),
                Tran_company_id = comid,
                Tran_Debit_Amt = 0,
                Tran_Credit_Amt = Convert.ToDecimal(AmountTo),
                Tran_rfernce2 = Reference,
                Tran_payment_id = 1,
                bank_ID = 0,
                Credit_Card = 0,
                Tran_descripation = Message,
                Tran_ID = GLE,
                Tran_Return = 0
            };

            _tran.InsertTwoTransaction(journalist, Tran1, Tran2);
            _tran.UpdateLastbalanceAfterTranasction(From, From, CurrencyFrom,1);
            _tran.UpdateLastbalanceAfterTranasction(To, To, CurrencyTo,1);
                return "ok";
            }
            catch
            {
                return "حدث خطا اثناء اجراء العملية ";
            }
        }
    }



    public class BroTresuryCashBalances_V
    {
        //				
        

        public int Tran_account_code { get; set; }
        public string TresuryName { get; set; }
        public string Tran_currency_id { get; set; }
        public decimal Credits { get; set; }
        public decimal Debits { get; set; }
        public decimal Balance { get; set; }

    }
}