using FastReport.Design;
using ScoposERB.BL.New_Models;
using ScoposERB.Helper;
using SuppliersDashboard.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.BL
{
    public class CollectionService
    {
        private DeepHelper db = new DeepHelper();


        public void CollectValidInvoices()
        {
            var Invoices = GetUncollectdBills();
        }



        public List<Bro_Collection_V> Grid(){

            string q = $"select * from Bro_Collection_V where ComId = {Coookie.Get().ComID}";
            List<Bro_Collection_V> result = db.GetList<Bro_Collection_V>(q);
            result.Select(s => { s._Date = s.Date?.ToString("yyyy/MM/dd"); s._Time = s.Date?.ToString("hh:mm tt"); return s; }).ToList();
            return result;
            }
       
        public List<Bill_Tbl> GetUncollectdBills()
        {
            var ComId = Coookie.Get().ComID;
            string q = $@"select * from Bill_tbl 
                                where comid = {ComId} and  sendToEta = 3 and  (IsValidAndCollect = 0 or IsValidAndCollect is null) ";/// valid and Un Collected
            var result = db.GetList<Bill_Tbl>(q);
            return result;
        } 


        public decimal deci(decimal? value)
        {
            return Decimal.Parse(value.ToString());
        }
        public int inti(int? value)
        {
            return int.Parse(value.ToString());
        }


    }
}