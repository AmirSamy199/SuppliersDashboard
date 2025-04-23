

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using ScoposERB.Helper;
using SuppliersDashboard.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace SuppliersDashboard.Helper
{
    public static class Cokie
    {
        private static DeepHelper db = new DeepHelper();
        private static int DaysCount = 15 ;
       
        

        public static void UserSet(User us)
        {
            SetCookie<User>("DawarUser",us);
        }  
        public static User UserGet()
        {
           return  GetCookie<User>("DawarUser");
        }
        public static void UserFunctionsSet(List<string> functions)
        {
            SetCookie<List<string>>("DawarUserFunctions",functions);
        }  
        public static List<string> UserFunctionsGet()
        {
           return  GetCookie<List<string>>("DawarUserFunctions");
        }
      public static void LogOut()
        {
            HttpContext.Current.Response.Cookies["DawarUser"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["DawarUserFunctions"].Expires = DateTime.Now.AddDays(-1);

        }
        public static void Delete()
        {
            HttpContext.Current.Response.Cookies["mycookie"].Expires = DateTime.Now.AddDays(-1);
        }



        public static void SetCookie<T>(string key, T model)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Expires = TbiServer.Time(DateTime.Now).AddDays(DaysCount);
            cookie.Value = db.TryEncrypt(JsonConvert.SerializeObject(model));
            HttpContext.Current.Response.Cookies.Remove(key);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static T GetCookie<T>(string key)
        {
            try
            {
                var c = HttpContext.Current.Request.Cookies.Get(key);
                if (c == null)
                    return Activator.CreateInstance<T>();


                string json = c.Value;
                if (json == null || json == "")
                    return Activator.CreateInstance<T>();
                return JsonConvert.DeserializeObject<T>(db.TryDecrypt(json));
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
        }
        public static string GetStringCookie(string key)
        {
            try
            {
                string json = db.TryDecrypt(HttpContext.Current.Request.Cookies.Get(key).Value);
                return json;
            }
            catch
            {
                return null;
            }
        }
        public static void SetStringCookie(string key, string Value)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Expires = TbiServer.Time(DateTime.Now).AddDays(DaysCount);
            cookie.Value = db.TryEncrypt(Value);
            HttpContext.Current.Response.Cookies.Remove(key);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static void Delete(string key)
        {
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }

    }
}
