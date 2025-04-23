using Connibrary;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public static MyFunctions fun = new MyFunctions();
        // GET: Banks
        [FunctionFilter(key ="صغحة البنوك")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadTable()
        {
          
            string sql = "Select * from [dbo].[BankInfo_tbl]";
            DataTable tb = fun.fireDataTable(sql);
            List<BankInfo_tbl> Banks = Converter.ConvertDataTable<BankInfo_tbl>(tb);
            return Json(new { data = Banks });
        }
        public ActionResult NewBank()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult NewBank(string Bankname, string address, string accountNo, string IBANCode, string swiftCode, string terms)
        {
            var CUser = Cokie.UserGet();
           
            string name = CUser.UserName;
            var ComID =1;

            string sql = "insert into dbo.BankInfo_tbl(bankName,bankAddress,bankAccountNo,bankAccountIBAN,swiftCode,terms,Editor,Date,status,ComID) values("
                + "N'" + Bankname.Replace("'", "''") + "',N'" + address.Replace("'", "''") + "',N'" + accountNo + "',N'" + IBANCode + "',N'" + swiftCode + "',N'" + terms.Replace("'", "''") + "',N'" + name.Replace("'", "''") + "','" + ScoposERB.Helper.TbiServer.Time(DateTime.Now).ToString("yyyy-MM-dd") + "',1," + ComID + ")";
            fun.fireSQL(sql);

            return Json(new { data = true });
        }
        public ActionResult EditBank(string id)
        {
            string sql = "Select * from [dbo].[BankInfo_tbl] where RecordID = " + id;
            DataTable tb = fun.fireDataTable(sql);
            BankInfo_tbl Bank = Converter.ConvertDataTable<BankInfo_tbl>(tb).FirstOrDefault();
            return PartialView(Bank);
        }
        [HttpPost]
        public ActionResult EditBank(string Bankname, string address, string accountNo, string IBANCode, string swiftCode, string terms, string id)
        {
            string sql = "Update dbo.BankInfo_tbl set bankName = N'" + Bankname.Replace("'", "''") + "', bankAddress = N'" + address.Replace("'", "''") + "' ,bankAccountNo = N'" + accountNo + "', bankAccountIBAN = N'" + IBANCode + "' ,swiftCode = N'" + swiftCode + "',terms = N'" + terms.Replace("'", "''") + "' where RecordID =" + id;
            fun.fireSQL(sql);

            return Json(new { data = true });
        }
        [HttpPost]
        public ActionResult DeactiveBank(string id, string state)
        {
            string sql;
            if (bool.Parse(state))
                sql = "Update dbo.BankInfo_tbl set status = 1 where RecordID =" + id;
            else
                sql = "Update dbo.BankInfo_tbl set status = 0 where RecordID =" + id;
            fun.fireSQL(sql);

            return Json(new { data = true });
        }
    }
}