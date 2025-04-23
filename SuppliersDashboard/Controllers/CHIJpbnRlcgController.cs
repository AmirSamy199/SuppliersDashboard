using Newtonsoft.Json;
using SuppliersDashboard.Helper;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SuppliersDashboard.Controllers
{
    public class CHIJpbnRlcgController : Controller
    {
        HttpClientHelper http = new HttpClientHelper();
        // GET: CHIJpbnRlcg
        [HttpGet, Route("~/T1UHSfl6oRmBLZg7E44aAg/{QmlsbE5v}")]
        public ActionResult T1UHSfl6oRmBLZg7E44aAg(string QmlsbE5v)
        {
          
            string bill = Decrypt(QmlsbE5v);
            ViewBag.Title = " فاتورة رقم " + bill;
             string response = http.Get($"/api/Report/Get_Pill_Details?PillNo={bill}&Cusid=0");

            Response<Bill_Details_model> res = new Response<Bill_Details_model>();
            try
            {
                res = JsonConvert.DeserializeObject<Response<Bill_Details_model>>(response);
                ViewBag.requiredamount = decimal.Parse(res.Item.headers.Where(a => a.subject == "قيمة الفاتورة").FirstOrDefault().data.Replace("|", "")) + decimal.Parse(res.Item.headers.Where(a => a.subject == "مديونية سابقة").FirstOrDefault().data.Replace("|", ""));

            }
            catch (Exception ex) 
            {
                ViewBag.requiredamount =0 ;

            }
            ViewBag.Model = res.Item;
           // return View(res.Item);
            return View();
        }
        [HttpPost]
        public string Encrypt(string key)
        {
            string x = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
            return x;

        }
        public string Decrypt(string key)
        {
            string x = Encoding.UTF8.GetString(System.Convert.FromBase64String(key));
            return x;
        }

        //private Response<Bill_Details_model> getBillDetails ()
        //{

        //}
    }
}