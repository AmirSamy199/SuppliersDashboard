using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    [Filters.MyAuthFilter]
    public class BillsController : BaseController
    {
        // GET: Bills
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int Id)
        {
            ViewBag.BaseId = Id;
            return View();
        }
        public ActionResult BillsDetails(int BillNo, int BranchNo)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + $"/api/Report/Get_Pill_Details?PillNo={BillNo}&Cusid={BranchNo}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response<Bill_Details_model> deContent = JsonConvert.DeserializeObject<Response<Bill_Details_model>>(content);
             
                return View(deContent.Item);
            }

        }

            // ajaxs 

         public ActionResult GetBillDetailsByBillNumber(int Id)
        {
            using (HttpClient c = new HttpClient())
            {
                var response = c.GetAsync(Setting.Host + "/api/Suppliers/GetBillDetailsByBillNumber?Id=" + Id).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Response <BillsDetailsVM> deContent = JsonConvert.DeserializeObject<Response<BillsDetailsVM>>(content);

                if(deContent.data.BillDate != null)
                {
                    deContent.data.BillDateString = deContent.data.BillDate.ToString("yyyy-MM-dd hh:mm:ss");
                }
                return Json(deContent, JsonRequestBehavior.AllowGet);
            }


        }
    }
}