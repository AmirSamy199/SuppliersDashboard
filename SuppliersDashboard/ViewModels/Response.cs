using SuppliersDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class Response<T>
    {
        public int Status { get; set; }
        public int State { get; set; }
        public string message { get; set; }
        public string Message { get; set; }
        public string Message2 { get; set; }
        public T data { get; set; }
        public T Data { get; set; }
        public T User { get; set; }
        public T Item { get; set; }
        public string SupplierName { get; set; }
     
       public string ErrorMessage { get; set; } 
        
    }
    public class TrackingResponse
    {
        public int count { get; set; }
        public int state { get; set; }
        public int day { get; set; }
        public string message { get; set; }
        public List<SalesTrackerModel> data { get; set; }
        public List<Small_Branch_tbl> branches { get; set; }
        public List<billsTrackingModel> bills { get; set; }
             
    }
    public class Response3<T> : Response<T> where T : class
    {
        public T Data2 { get; set; }
        public T Data3 { get; set; }
        public T Data4 { get; set; }
        public string Message3 { get; set; }
        public string Message4 { get; set; }


    }
    public class loginResponse<T> : Response<T>
    {
        public List<string> functions { get; set; }
    
    }
}