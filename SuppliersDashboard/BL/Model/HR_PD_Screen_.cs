using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class HR_PD_Screen_
    {
        public int RecordID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EmployeeName { get; set; }
        public int Quarter_ID { get; set; }
        public string Quarter_Level { get; set; }

        public Nullable<int> Categories_ID { get; set; }
        public string CategoriesName { get; set; }

        public Nullable<decimal> Rate { get; set; }
        public string RateNOM { get; set; }
        public string Quarter { get; set; }
        public Nullable<decimal> Categorie { get; set; }
        public Nullable<int> Rate_No { get; set; }
        public Nullable<decimal> VacationAllowed { get; set; }
        
    }
}