using Connibrary;
using Newtonsoft.Json;
using ScoposERB.Helper;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class AccountController : BaseController
    {
        private HttpClientHelper _http = new HttpClientHelper();
        private static DeepHelper db = new DeepHelper();

        public ActionResult test()
        {
            return View();
        }
        public AccountController()
        {
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public JsonResult checkUserStatus()
        {
            var x = _http.Get<dynamic>($"/api/CheckUserState");
            bool xx = x.data;
            return Json(new { data = xx },JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult LogIn()
        {

            var User = Cokie.UserGet();
            if(User.Id !=0)
                return RedirectToAction("Index","Home");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LogInVM model)
        {
       
            using (HttpClient c = new HttpClient())
            {
                
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await c.PostAsync(Setting.Host + "/api/Account/LogIn", httpContent);
                var content = await response.Content.ReadAsStringAsync();
                loginResponse<User> deContent = JsonConvert.DeserializeObject<loginResponse<User>>(content);
                string message = deContent.Message;
                if (deContent.State == 200)
                {
                    User User = deContent.User;
                    if(User != null)
                    {
                        Cokie.UserSet(User);

                    }
                    List<string> functions = deContent.functions;
                    if (functions.Count > 0)
                    {
                        Cokie.UserFunctionsSet(functions);
                    }

                    // تأكيد إضافة الكوكي:
                    var cookie = Response.Cookies["DawarUserFunctions"];
                    if (cookie != null)
                    {
                        System.Diagnostics.Debug.WriteLine("Cookie Value: " + cookie.Value);
                    }

              

                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("modelstate", message);
                ViewBag.Message = message;
                return View(model);
            }

       
        }

        
        public ActionResult LogOut()
        {
            Cokie.LogOut();
          
            return RedirectToAction("LogIn");
        }

     
    }
}