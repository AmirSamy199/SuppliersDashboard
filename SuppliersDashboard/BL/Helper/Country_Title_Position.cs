using Connibrary;
using ScoposERB.Helper;
using ScoposERB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.HR_Models
{
    public class Country_Title_Position
    {
        public static MyFunctions fun = new MyFunctions();
        public static void CTP( out List<SelectListItem> CountryList,out List<SelectListItem> TitleList,out List<SelectListItem> PostionList)
        {
            CountryList = new List<SelectListItem>();
            var CountryQuery = "SELECT * FROM Country_TBL";
            DataTable Countrydt = fun.fireDataTable(CountryQuery);
            foreach (var row in Converter.ConvertDataTable<Country>(Countrydt).ToList())
            {
                if (string.IsNullOrEmpty(row.CODE))
                    continue;

                CountryList.Add(new SelectListItem { Text = row.EN + " - " + row.AR, Value = row.CODE });
            }           
            //--------------------------------------------------//
            //--------------------------------------------------//
            TitleList = new List<SelectListItem>();
            var SelectT = "Select * From Title_Tbl";
            DataTable Titledt = fun.fireDataTable(SelectT);

           
            //--------------------------------------------------//
            //--------------------------------------------------//
            PostionList = new List<SelectListItem>();
            var SelectQ = "Select * From PositionType_Tbl";
            DataTable positiondt = fun.fireDataTable(SelectQ);
       
            
        }
    }
}