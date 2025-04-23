using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels.ReportVM
{
    public class StoreGuardDefaultVM
    {
        //No	UserId	UserName	RequestNo	BillNo	ItemId	ItemName	Status	ReportStatus	Count	Date	Message
        public int No { get; set; }
        public int UserId { get; set; }
        public int RequestNo { get; set; }
        public int BillNo { get; set; }
        public int ItemId { get; set; }
        public string Status { get; set; }
        public string ReportStatus { get; set; }
        public string UserName { get; set; }
        public string ItemName { get; set; }
        public decimal Count { get; set; }
        public decimal Amount { get; set; }
        public decimal SupplyAmount { get; set; }
        public decimal CountBefore { get; set; }
        public decimal CountAfter { get; set; }
        public DateTime Date { get; set; }
        public string _Date { get; set; }
        public string _Time { get; set; }
        public string Message { get; set; }
        public decimal Wared { get; set; }
        public decimal Sader { get; set; }
    }
    public class MoneySortfallModel
    {
        //RecordID	user_id	Sales	Date	MoneyFall	MoneyPaperCountFall	MoneyPaperAmountFall	DefferedPaperCountFall	DefferedPaperAmountFall
        public int RecordID { get; set; }
        public int user_id { get; set; }
       
        public string Sales { get; set; }
        public DateTime Date { get; set; }
        public string _Date { get; set; }
        public string _Time { get; set; }
        public decimal MoneyFall { get; set; }
        public decimal MoneyPaperCountFall { get; set; }
        public decimal MoneyPaperAmountFall { get; set; }
        public decimal DefferedPaperCountFall { get; set; }
        public decimal DefferedPaperAmountFall { get; set; }
    }
}