using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Filters;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.Repository;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SuppliersDashboard.Controllers
{
    public class SalesOFclient1Controller : Controller
    {
        // GET: SalesOFclient
        [FunctionFilter(key= "AddSale")]
        public ActionResult addsale()
        {
            int Parent = 0;
            List<AgentSelect> s = (new SelectService()).GetAgentsSelect(Parent);
            ViewBag.data = s.ToList();
            var Userr = Cokie.UserGet();
            ViewBag.Id = Userr.Id.ToString();
            return View();
        }
        public ActionResult Index()
        {
            int Parent = 0;
            List<AgentSelect> s = (new SelectService()).GetAgentsSelect(Parent);
            ViewBag.data = s.ToList();
            var Userr = Cokie.UserGet();
            ViewBag.Id = Userr.Id.ToString();
            return View();
        }
        public class warehouse_Requst
        {
            public warehouse_Requst_Tbl Header { get; set; }
            public List<warehouse_Requst_Tbl> Details { get; set; }

        }
        public class bill
        {
            public Bill_Tbl Header { get; set; }
            public List<Bill_Detiles_Tbl> Details { get; set; }

        }
        [HttpPost]
        public ActionResult AddBill(bill model)
        {

            try
            {
                var CUser = Cokie.UserGet();

                using (HttpClient http = new HttpClient())
                {
                    foreach (var item in model.Details)
                    {
                        Bill_Detiles_Tbl model1 = new Bill_Detiles_Tbl();
                        model1.Suppier_id = CUser.Id;

                        model1.Items = item.Items;
                        model1.NumberOfUnits = item.NumberOfUnits;
                        model1.TotalPrice = item.TotalPrice;
                        StringContent body = new StringContent(JsonConvert.SerializeObject(model1), Encoding.UTF8, "application/json");
                        var response = http.PostAsync(Setting.Host + "/api/Admin/AddBill", body).Result;
                        string content = response.Content.ReadAsStringAsync().Result;
                    }
                    Bill_Detiles_Tbl model11 = new Bill_Detiles_Tbl();
                    model11.Suppier_id = CUser.Id;
                    
                    
                    model11.Items = model.Header.Payment;
                    StringContent body1 = new StringContent(JsonConvert.SerializeObject(model11), Encoding.UTF8, "application/json");
                    var response1 = http.PostAsync(Setting.Host + "/api/Admin/AddBill", body1).Result;
                    string content1 = response1.Content.ReadAsStringAsync().Result;


                    //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                    return Json(new { status = 1 });

                }
            }
            catch (Exception)
            {

                return Json(new { status = 0 });

            }

        }
        [HttpPost]
        public ActionResult AddNewrwquest(warehouse_Requst model)
        {



            try


            {
                var CUser = Cokie.UserGet();
                using (HttpClient http = new HttpClient())
                {
                    foreach (var item in model.Details)
                    {
                        DateTime dt = DateTime.Now;
                        warehouse_Requst_Tbl model1 = new warehouse_Requst_Tbl();
                        model1.User_ID = CUser.Id;
                        model1.type = 1; model1.Supplier_ID = 7;
                        model1.Edit_date = dt;
                        model1.sales_id = model.Header.sales_id;

                        model1.Item_ID = item.Item_ID;
                        model1.Item_Count = item.Item_Count;
                        StringContent body = new StringContent(JsonConvert.SerializeObject(model1), Encoding.UTF8, "application/json");
                        var response = http.PostAsync(Setting.Host + "/api/Warehousing/AddWareHouseRequest", body).Result;
                        string content = response.Content.ReadAsStringAsync().Result;
                    }



                    return Json(new { status = 1 });

                }
            }
            catch (Exception)
            {

                return Json(new { status = 0 });

            }

        }


        [HttpPost]
        public ActionResult AddNewrwquest1(List<string> details)
        {

            try


            {
                var CUser = Cokie.UserGet();
                using (HttpClient http = new HttpClient())
                {
                    //foreach (var item in model1.Details)
                    //{
                    //    warehouse_Requst_Tbl model = new warehouse_Requst_Tbl();
                    //    model.User_ID = CUser.Id;
                    //    model.type = 1;
                    //    model.Item_ID = item.Item_ID;
                    //    model.Item_Count = item.Item_Count;
                    //    StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    //    var response = http.PostAsync(Setting.Host + "/api/Warehousing/AddWareHouseRequest", body).Result;
                    //    string content = response.Content.ReadAsStringAsync().Result;
                    //}


                    //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                    return Json(new { status = 1 });

                }
            }
            catch (Exception)
            {

                return Json(new { status = 0 });

            }




        }
    }
}