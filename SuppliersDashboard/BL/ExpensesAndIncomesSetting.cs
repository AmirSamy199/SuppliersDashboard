using Connibrary;
using FastReport.Export.Dbf;
using ScoposERB.Helper;
using ScoposERB.Models.AccModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ScoposERB.BL
{
    public class ExpensesAndIncomesSetting
    {
        private DeepHelper db = new DeepHelper();
       // private MyFunctions fun = new MyFunctions();
        


        /// Get Children By Parent Id 
    public List<Acc_Accounts_tbl> Children (int AccountId)
    {
        string q = $"select * from [Acc_Accounts_tbl] where ParentId= {AccountId} and state = 1";
        List<Acc_Accounts_tbl> models = db.GetList<Acc_Accounts_tbl>(q);
        return models;
    }
    public bool AddAccount (Acc_Accounts_tbl model)
    {
        try
        {
            string q = $@"INSERT INTO [dbo].[Acc_Accounts_tbl]
        ([ArabName]
        ,[EngName]
        ,[Editor]
        ,[AccNumber]
        ,[Date]
        ,[Level]
        ,[ParentID]
        ,[ComID]
        ,[Balance]
        ,[costCenter]
        ,[AccountCategory]
        ,[AccountType]
        ,[Account_SerialNumber]
        ,[MainOrSub]
        ,[currency]
        ,[state]
        ,[Branch_ID])
    VALUES
        (
		N'{model.ArabName}'
        ,N'{model.EngName}'
        ,N'{model.Editor}'
        ,N'{model.AccNumber}'
        ,N'{model.Date?.ToString("yyyy-MMM-dd hh:mm:ss")}'
        ,N'{model.Level}'
        ,N'{model.ParentID}'
        ,N'{model.ComID}'
        ,N'{model.Balance}'
        ,N'{model.costCenter}'
        ,N'{model.AccountCategory}'
        ,N'{model.AccountType}'
        ,N'{model.Account_SerialNumber}'
        ,N'{model.MainOrSub}'
        ,N'{model.currency}'
        ,N'{model.state}'
        ,N'{model.Branch_ID}'
		)";
            db.fire(q);
            db.fire($"update [Acc_Accounts_tbl] set MainOrSub = 0 where RecordId ={model.ParentID}");
            return true;
        }
        catch { return  false; }
    }

    public Acc_Accounts_tbl PrepareModelTOInsert(Acc_Accounts_tbl vm, string Editor , int ComId)
        {
            


            DataTable GetparentData = db.fireDT($"select Level Level , AccNumber AccNumber from [Acc_Accounts_tbl] where RecordId = {vm.ParentID}");
            int Level = (int)GetparentData.Rows[0]["Level"] + 1;
            string ParentSerial = (string)GetparentData.Rows[0]["AccNumber"];
            string accIdintree = "";
            string serial = "01";
            DataTable dddt = db.fireDT($"select top 1 cast( RIGHT(AccNumber,2) as int)+1 BrotherSerial from [Acc_Accounts_tbl] where parentId ={vm.ParentID} order by RecordId desc");
            if(dddt.Rows.Count > 0)
            {

                int x = (int)dddt.Rows[0]["BrotherSerial"];
                if (x < 10)
                {
                    serial = "0" + x;
                }
                else
                {
                    serial = x.ToString();
                }
            }
            accIdintree = ParentSerial + serial;


            Acc_Accounts_tbl Model = new Acc_Accounts_tbl
            {
                ArabName = vm.ArabName,
                Balance = 0,
                ComID = ComId,
                AccountCategory = vm.AccountCategory,
                AccountType = 0,
                Branch_ID = 0,
                currency = vm.currency,
                Date = TbiServer.Time(DateTime.Now),
                EngName = vm.EngName,
                Editor = Editor,
                MainOrSub = 1,
                ParentID = vm.ParentID,
                state = 1,
                costCenter = 11,
                AccNumber= accIdintree,
                Account_SerialNumber = accIdintree,
                Level = Level
                


            };
            return Model;
        }

       
        public List<Select> GetAccountCategories (int ComId)
    {
            string q = $"select EngName Name ,  ArabName ARName, RecordId Id  from [Acc_x_Category] where ComId = {ComId}";
            List<Select> models = db.GetList<Select>(q);
            return models;
    } 
    public List<Select> GetCurrencies()
    {
        string q = $"select Currency Name ,  Aname ARName, Record_Id Id  from [Currency_Tbl] ";
        List<Select> models = db.GetList<Select>(q);
        return models;
    }



        /// <summary>
        /// // الميثود دي عشان لو بضيف لاي حاجة اكونت زي العربية او ال فيندور بيكريتلي اكونت ويرجعلي  رقمه 
        /// </summary>
        /// <returns></returns>
        public int AutoAddAccount(int ParentId , string Name)
        {
            try
            {

                Acc_Accounts_tbl model = new Acc_Accounts_tbl
                {
                    ParentID = ParentId,
                    ArabName = Name,
                    EngName = Name,
                    AccountCategory = 6,
                    currency = 1
                };

                int comid = Int32.Parse(Coookie.Get().ComID.ToString());
          
                Acc_Accounts_tbl modell =PrepareModelTOInsert(model, Coookie.Get().UserName, comid);
                AddAccount(modell);
                return db.GetValue<int>($"select  max(RecordId) Id from Acc_Accounts_tbl", "Id");
            }
            catch { return 0;  }
        }
        ////Hoe Wo USe 
    //    int accountId = (new ExpensesAndIncomesSetting()).AutoAddAccount(1, "hammada");

    }
}