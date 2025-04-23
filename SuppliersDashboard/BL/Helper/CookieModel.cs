
using Connibrary;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ScoposERB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ScoposERB.Helper
{

    public static class Coookie
    {
       private static  DeepHelper db = new DeepHelper();
        public static void Set(CookieModel model)
        {
            HttpCookie cookie = new HttpCookie("mycookie");
            cookie.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie.Value=db.TryEncrypt(JsonConvert.SerializeObject(model));
            HttpContext.Current.Response.Cookies.Remove("mycookie");
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static void SetFunctions(List<Function> funcs )
        {
            HttpCookie cookie = new HttpCookie("functions");
            HttpCookie cookie1 = new HttpCookie("functions2");
            HttpCookie cookie2 = new HttpCookie("functions3");
            HttpCookie cookie3 = new HttpCookie("functions4");
            HttpCookie cookie4 = new HttpCookie("functions5");
            cookie.Value = db.TryEncrypt(JsonConvert.SerializeObject(funcs.Skip(0).Take(20)));
            cookie1.Value = db.TryEncrypt(JsonConvert.SerializeObject(funcs.Skip(20).Take(20)));
            cookie2.Value = db.TryEncrypt(JsonConvert.SerializeObject(funcs.Skip(40).Take(20)));
            cookie3.Value = db.TryEncrypt(JsonConvert.SerializeObject(funcs.Skip(60).Take(20)));
            cookie4.Value = db.TryEncrypt(JsonConvert.SerializeObject(funcs.Skip(80).Take(20)));
            cookie.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie1.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie2.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie3.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie4.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            HttpContext.Current.Response.Cookies.Remove("functions");
            HttpContext.Current.Response.Cookies.Remove("functions2");
            HttpContext.Current.Response.Cookies.Remove("functions3");
            HttpContext.Current.Response.Cookies.Remove("functions4");
            HttpContext.Current.Response.Cookies.Remove("functions5");
            HttpContext.Current.Response.Cookies.Set(cookie);
            HttpContext.Current.Response.Cookies.Set(cookie1);
            HttpContext.Current.Response.Cookies.Set(cookie2);
            HttpContext.Current.Response.Cookies.Set(cookie3);
            HttpContext.Current.Response.Cookies.Set(cookie4);
        }
        public static CookieModel Get()
        {
            try
            {

             var cook = HttpContext.Current.Request.Cookies.Get("mycookie");
                if(cook == null )
                    return null;
                if (cook.Value == null || cook.Value == "")
                    return null;
                return JsonConvert.DeserializeObject<CookieModel>(db.TryDecrypt(cook.Value));
            }
            catch
            {
                return null;
            }
        }
        public static List<Function> GetFunctions()
        {
            try
            {
             List<Function> funcs = new List<Function>();
             string json = HttpContext.Current.Request.Cookies.Get("functions").Value;
            if (json == null || json == "")
                return null;

                try
                {
                    funcs.AddRange(JsonConvert.DeserializeObject<List<Function>>(db.TryDecrypt(HttpContext.Current.Request.Cookies.Get("functions").Value)));
                }
                catch { } try
                {
                    funcs.AddRange(JsonConvert.DeserializeObject<List<Function>>(db.TryDecrypt(HttpContext.Current.Request.Cookies.Get("functions2").Value)));
                }
                catch { } try
                {
                    funcs.AddRange(JsonConvert.DeserializeObject<List<Function>>(db.TryDecrypt(HttpContext.Current.Request.Cookies.Get("functions3").Value)));
                }
                catch { } try
                {
                    funcs.AddRange(JsonConvert.DeserializeObject<List<Function>>(db.TryDecrypt(HttpContext.Current.Request.Cookies.Get("functions4").Value)));
                }
                catch { } try
                {
                    funcs.AddRange(JsonConvert.DeserializeObject<List<Function>>(db.TryDecrypt(HttpContext.Current.Request.Cookies.Get("functions5").Value)));
                }
                catch { }
            return funcs;
            }
            catch
            {
                return null;
            }
        }
        public static void Delete()
        {
            HttpContext.Current.Response.Cookies["mycookie"].Expires= DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["functions"].Expires= DateTime.Now.AddDays(-1);
        }



        public static void SetCookie<T>(string key , T model)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie.Value = db.TryEncrypt(JsonConvert.SerializeObject(model));
            HttpContext.Current.Response.Cookies.Remove(key);
            HttpContext.Current.Response.Cookies.Set(cookie);
            // HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static T GetCookie<T>(string key )
        {
            try
            {
                var c = HttpContext.Current.Request.Cookies.Get(key);
                if(c==null)
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
            cookie.Expires = TbiServer.Time(DateTime.Now).AddDays(3);
            cookie.Value = db.TryEncrypt(Value);
            HttpContext.Current.Response.Cookies.Remove(key);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static void Delete(string key )
        {
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }

    }
    public class CookieModel
    {

        public CookieModel(User U, string UN,  int? C  , string CN , List<Function> F, string E)
        {
            this.User = U;
            this.Functions = F;
            this.UserName = UN;
            this.ComID = C;
            this.ComName = CN;
            this.Environment = E;

        }
        public User User { get; set; }
        public List<Function> Functions { get; set; }
        public int? ComID { get; set; }
        public string UserName { get; set; }
        public string ComName { get; set; }
        public string Environment { get; set; }
    }
}