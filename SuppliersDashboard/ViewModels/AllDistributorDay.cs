using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public partial class closing_day_settelment_amount
    {
        [Key]
        public int RecordID { get; set; }

        public decimal? actual_amount { get; set; }

        public decimal? required_amount { get; set; }

        public decimal? short_fall { get; set; }

        public DateTime? dailyclosing { get; set; }

        public int? account_id { get; set; }

        public int? user_id { get; set; }

        public int? user_confirm { get; set; }

        public DateTime? user_confirm_date { get; set; }

        public int? account_confirm { get; set; }

        public DateTime? account_confirm_date { get; set; }

        public int? settlement { get; set; }

        public int? colection_paper_count_actual { get; set; }

        public decimal? colection_paper_amount { get; set; }

        public int? colection_paper_count_required { get; set; }

        public int? colection_paper_shortfall { get; set; }

        public int? payment_paper_count_actual { get; set; }

        public decimal? payment_paper_amount { get; set; }

        public int? payment_paper_count_required { get; set; }

        public int? payment_paper_shortfall { get; set; }

        public decimal? Actual_MoneyReceiptPapers_count { get; set; }

        public decimal? Actual_MoneyReceiptPapers_Amount { get; set; }

        public decimal? Actual_DeferredMoneyPaper_count { get; set; }

        public decimal? Actual_DeferredMoneyPaper_Amount { get; set; }

        public decimal? shortfall_MoneyReceiptPapers_count { get; set; }

        public decimal? shortfall_MoneyReceiptPapers_Amount { get; set; }

        public decimal? shortfall_DeferredMoneyPaper_count { get; set; }

        public decimal? shortfall_DeferredMoneyPaper_Amount { get; set; }

        public DateTime? AccounterDailyClosing { get; set; }

        public int? CloseLastOfDayAccounterId { get; set; }

        public DateTime? CloseLastOfDayDailyClose { get; set; }
        public decimal Masrofat { get; set; }

    }
    public class AllDistributorDay : SelectSales_Today_English_Pro
    {
        //public SelectSales_Today_English_Pro Sales { get; set; }


        public decimal CashShortFall { get; set; }
        public decimal CollectionPaperCountShortFall { get; set; } /// <summary>
        ///  ورق الاجل 
        /// </summary>
        public decimal CollectionPaperAmountShortFall { get; set; }
        public decimal MoneyPaperCountShortFall { get; set; }
       /// <summary>
       /// /ورق الدفع 
       /// </summary>
        public decimal MoneyPaperAmountShortFall { get; set; }
        public decimal Masrofat { get; set; }


    }
}