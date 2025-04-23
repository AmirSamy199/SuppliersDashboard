using Newtonsoft.Json;
using SuppliersDashboard.Constants;
using SixLabors.ImageSharp;
using SuppliersDashboard.Constants;
using SuppliersDashboard.Helper;
using SuppliersDashboard.Models;
using SuppliersDashboard.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SuppliersDashboard.Filters;
using static System.Net.WebRequestMethods;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using System.Data;
using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using Antlr.Runtime.Tree;
using RestSharp;
using Microsoft.Extensions.Logging;

namespace SuppliersDashboard.Controllers
{
    public class AdminController : Controller
    {
        private HttpClientHelper httphelp = new HttpClientHelper();
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }
        [FunctionFilter(key = "صفحة ادارة وتعديل المستخدمين")]

        public ActionResult UsersManagement()
        {
            var types = httphelp.Get<Response<List<Select>>>($"/api/GetAgentWithLevel?Level=3");
            ViewBag.CompanyTypes = types.Data;
            return View();
        }
        #region addrequestforadmin
        public ActionResult OnlineRequest()
        {
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            String respone = HTTP.Get("/api/Company/AvailableWareHouseItems");

            ViewBag.pro = JsonConvert.DeserializeObject<Response<List<main_warehouse_items_availablilty_V>>>(respone).Data.Select(x => new Select() { Id = x.ItemID, Value = x.ItemName }).ToList();
            String respone2 = HTTP.Get("/Test");
            ViewBag.pro1 = JsonConvert.DeserializeObject<Response<List<onlineRequest_Detiles_Tbl>>>(respone2).Data.ToList();

            string response3 = HTTP.Get("/api/Selector/AllGetBranch");
            ViewBag.Diss = JsonConvert.DeserializeObject<Response<List<Select>>>(response3).Data;

            return View();
        }

        public ActionResult getRequestdatlis(int id)
        {


            return View();
        }

        public ActionResult Getallrequestorder1()


        {
            List<RegisterRequestDT> prodect = new List<RegisterRequestDT>();
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            String respone = HTTP.Get("/Test1");
            ViewBag.pro1 = JsonConvert.DeserializeObject<List<RegisterRequestDTVM>>(respone);
            foreach (var item in ViewBag.pro1)
            {

                RegisterRequestDT obj = new RegisterRequestDT();
                obj.UserName = item.UserName;
                obj.status = item.status;
                obj.Serial_No = item.Serial_No;
                obj.Record_ID = item.Record_ID;

                prodect.Add(obj);

            }







            return Json(prodect.ToList(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult updatastut(int id)
        {
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            var respone = HTTP.Get<Response<string>>($"/api/Account/AcceptRegistrationRequest?Reg_Id={id}");



            //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
            if (respone == null)
            {
                return Json(new { status = 0 });
            }
            else
            {
                return Json(new { status = 1 });

            }
        }
        public ActionResult GetRequestdatlis1()
        {


            return View();
        }

        public ActionResult getdatils(int id)
        {


            List<onlineRequest_Detiles_Tbl> prodect = new List<onlineRequest_Detiles_Tbl>();
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            var respone = HTTP.Get<Response<List<onlineRequest_Detiles_Tbl>>>($"/api/Account/getdatils?id={id}");
            ViewBag.pro1 = respone.Data.ToList();
            foreach (var item in ViewBag.pro1)
            {

                onlineRequest_Detiles_Tbl obj = new onlineRequest_Detiles_Tbl();
                obj.Items = item.Items;
                obj.UnitPrice = item.UnitPrice;


                prodect.Add(obj);

            }

            return Json(prodect.ToList(), JsonRequestBehavior.AllowGet);


        }
        public ActionResult Addrequest()
        {
            List<onlineRequest_Tbl> prodect = new List<onlineRequest_Tbl>();
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            String respone = HTTP.Get("/Test");
            ViewBag.pro1 = JsonConvert.DeserializeObject<Response<List<onlineRequest_Tbl>>>(respone).Data.ToList();
            foreach (var item in ViewBag.pro1)
            {

                onlineRequest_Tbl obj = new onlineRequest_Tbl();
                obj.request_No = item.request_No;
                obj.request_ID = item.request_ID;
                obj.Currency = item.Currency;
                obj.cus_phone = item.cus_phone;
                obj.CustomerName = item.CustomerName;
                obj.resquest_stautes = item.resquest_stautes;

                prodect.Add(obj);

            }







            return Json(prodect.ToList(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult get()
        {
            return View();
        }
        public class xxx
        {
            public onlineRequest_Tbl Header { get; set; }
            public List<onlineRequest_Detiles_Tbl> Details { get; set; }

        }


        [HttpPost]

        public ActionResult updatastu(int id, int parm)
        {




            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            var respone = HTTP.Get<Response<string>>($"/api/Admin/Editstutas?id={id}&parm={parm}");



            //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
            if (respone == null)
            {
                return Json(new { status = 0 });
            }
            else
            {
                return Json(new { status = 1 });

            }




        }
        [HttpPost]
        public ActionResult AddNewrwquest(xxx model)
        {



            using (HttpClient http = new HttpClient())
            {

                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + "/api/Admin/AddRequest", body).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { status = 0 });
                }
                else
                {
                    return Json(new { status = 1 });

                }
            }



        }


        public ActionResult OnlineRequestdatlis()
        {


            return View();
        }
        #endregion

        #region addrequestforuser
        public ActionResult OnlineRequest_for_User()
        {
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();

            var User = Cokie.UserGet();

            String respone = HTTP.Get("/api/Company/AvailableWareHouseItems");

            ViewBag.pro = JsonConvert.DeserializeObject<Response<List<main_warehouse_items_availablilty_V>>>(respone).Data.Select(x => new Select() { Id = x.ItemID, Value = x.ItemName }).ToList();
            String respone2 = HTTP.Get("/Test");
            ViewBag.pro1 = JsonConvert.DeserializeObject<Response<List<onlineRequest_Detiles_Tbl>>>(respone2).Data.ToList();

            string response3 = HTTP.Get("/api/Selector/AllGetBranch");
            ViewBag.Diss = JsonConvert.DeserializeObject<Response<List<Select>>>(response3).Data;

            return View();
        }
        [HttpGet]
        public ActionResult sreach(string entity)
        {
            List<onlineRequest_Tbl> prodect = new List<onlineRequest_Tbl>();
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            String respone = HTTP.Get($"/Testsreach?entity={entity}");

            ViewBag.pro1 = JsonConvert.DeserializeObject<Response<List<onlineRequest_Tbl>>>(respone).Data.ToList();
            foreach (var item in ViewBag.pro1)
            {

                onlineRequest_Tbl obj = new onlineRequest_Tbl();
                obj.request_No = item.request_No;
                obj.request_ID = item.request_ID;
                obj.Currency = item.Currency;
                obj.cus_phone = item.cus_phone;
                obj.CustomerName = item.CustomerName;
                obj.resquest_stautes = item.resquest_stautes;

                prodect.Add(obj);

            }
            return Json(prodect.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNewrwquest1(xxx model)
        {



            using (HttpClient http = new HttpClient())
            {

                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + "/api/Admin/AddRequest", body).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { status = 0 });
                }
                else
                {
                    return Json(new { status = 1 });

                }
            }



        }
        #endregion


        #region Online Admin Requests 
        [FunctionFilter(key = "قبول طلبات الفروع")]
        public ActionResult OnlineShopRequests()
        {
            var result = httphelp.Get<Response<List<RegisterOnlineShopRequest_tbl>>>($"/api/OnlineShopRequests");

            ViewBag.Companies = httphelp.Get<Response<List<Select>>>("/api/Company/GetCompaniesToFillSelect").Data;
            return View(result);
        }
        public JsonResult EditOnlineBranchRequest(int reqid, int brid)
        {
            var url = $"/api/EditOnlineBranchRequest?reqid={reqid}&brid={brid}";
            var x = httphelp.Get<Response<string>>(url);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AcceptShopAccountRegistrationRequest(int Id)
        {
            var res = httphelp.Get<Response<string>>($"/api/AcceptShopAccountRegistrationRequest?Id={Id}");
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RejectShopAccountRegistrationRequest(int Id)
        {
            var res = httphelp.Get<Response<string>>($"/api/RejectShopAccountRegistrationRequest?Id={Id}");
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        #endregion











        public ActionResult getAll()
        {
            Helper.HttpClientHelper HTTP = new Helper.HttpClientHelper();
            String respone = HTTP.Get("/api/Company/AvailableWareHouseItems");
            ViewBag.pro = JsonConvert.DeserializeObject<Response<List<Select>>>(respone).Data;

            return Json(respone.ToList());
        }
        [HttpPost]
        public ActionResult GetAllUser()
        {
            string res = httphelp.Get("/api/Admin/GetUsersWithFunctions").ToString();
            Response<List<VUsers>> users = JsonConvert.DeserializeObject<Response<List<VUsers>>>(res);

            return Json(new { data = users });
        }

        [HttpPost]
        public ActionResult GetFunctionsUser(int Group_RecordID)
        {
            var res = httphelp.Get($"/api/Selector/GetFunctionsToGroup?GroupId={Group_RecordID}");

            dynamic FuntionUser = JsonConvert.DeserializeObject<ExpandoObject>(res);


            return Json(new { data = FuntionUser.Data });
        }



        [HttpPost]
        public ActionResult AssignUserToGroup(int userid, int groupid)
        {
            try
            {
                var res = httphelp.Get($"/api/Admin/AssignUserToGroup?GroupId={groupid}&UserId={userid}");

                return Json(new { status = 0 });

            }
            catch
            {
                return Json(new { status = 1 });

            }
        }

        [HttpPost]
        public ActionResult AddNewUser(AddUserVM model)
        {



            using (HttpClient http = new HttpClient())
            {

                StringContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + "/api/Admin/AddNewUser", body).Result;
                //Response<string> res = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { status = 0 });
                }
                else
                {
                    return Json(new { status = 1 });

                }
            }



        }


        #region GroupsManagement
        [HttpPost]
        public JsonResult GetGroups()
        {
            string res = httphelp.Get("/api/Selector/GetWebGroups").ToString();
            Response<List<GroupOrFuncVM>> groups = JsonConvert.DeserializeObject<Response<List<GroupOrFuncVM>>>(res);

            return Json(new { data = groups });
        }

        [HttpPost]
        public JsonResult GetFuncsByGroup(int groupId)
        {
            string res = httphelp.Get($"/api/Selector/GetFunctionsToGroup?GroupId={groupId}").ToString();
            Response<List<GroupOrFuncVM>> funcs = JsonConvert.DeserializeObject<Response<List<GroupOrFuncVM>>>(res);

            return Json(new { data = funcs });
        }

        [HttpPost]
        public JsonResult AddGroup(string groupName)
        {
            string res = httphelp.Get($"/api/Admin/addGroup?GroupName={groupName}").ToString();
            Response<string> Groups = JsonConvert.DeserializeObject<Response<string>>(res);

            return Json(new { data = Groups });
        }
        #endregion




        #region functionsManagements

        [HttpPost]
        public JsonResult GetFunctions()
        {
            string res = httphelp.Get($"/api/Selector/GetFunctions").ToString();
            Response<List<GroupOrFuncVM>> funcs = JsonConvert.DeserializeObject<Response<List<GroupOrFuncVM>>>(res);

            return Json(new { data = funcs });
        }

        [HttpPost]
        public JsonResult SubmitFuncs(int groupId, List<GroupOrFuncVM> FuncVM)
        {

            int[] funcsIdArray = new int[FuncVM.Count];
            Console.WriteLine(FuncVM.Count);
            for (int i = 0; i < FuncVM.Count; i++)
            {
                funcsIdArray[i] = FuncVM[i].Id;
            }

            //pass data to VM to send to API
            EditFunctionsVM editFunctionsVM = new EditFunctionsVM
            {
                GroupId = groupId,
                Functions = funcsIdArray,
            };

            using (HttpClient http = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(editFunctionsVM), Encoding.UTF8, "application/json");
                var response = http.PostAsync(Setting.Host + $"/api/Admin/EditGroupFunctions", body).Result;
                Response<string> Fres = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);

                return Json(new { message = Fres.Message, status = Fres.State });
            }

        }

        //[HttpPost]
        //public JsonResult DeleteFunctionInGroup(int functionId,int groupId)
        //{
        //    //List<GroupOrFuncVM> funcsOfgrp = GetFuncsByGroupAsList(groupId);

        //    string res = httphelp.Get($"/api/Selector/GetFunctionsToGroup?GroupId={groupId}").ToString();
        //    Response<List<GroupOrFuncVM>> funcs = JsonConvert.DeserializeObject<Response<List<GroupOrFuncVM>>>(res);
        //    var funcofgroup = funcs.Data;

        //    //get the function which we want to delete
        //    GroupOrFuncVM func = funcofgroup.FirstOrDefault(x => x.Id == functionId);
        //    funcofgroup.Remove(func);

        //    //convert this to IDs of functions
        //    List<int> funcsIdlist = new List<int>();
        //    foreach (var item in funcofgroup)
        //    {
        //        funcsIdlist.Add(item.Id);
        //    }
        //    int[] funcsIdArray = funcsIdlist.ToArray();

        //    EditFunctionsVM editFunctionsVM = new EditFunctionsVM
        //    {
        //        GroupId = groupId,
        //        Functions = funcsIdArray,
        //    };

        //    //return Json(new {data= funcofgroup });

        //    //// test hereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee we will send the changes
        //    using (HttpClient http = new HttpClient())
        //    {
        //        try
        //        {
        //            StringContent body = new StringContent(JsonConvert.SerializeObject(editFunctionsVM), Encoding.UTF8, "application/json");
        //            var response = http.PostAsync(Setting.Host + $"/api/Admin/EditGroupFunctions", body).Result;
        //            Response<string> Fres = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);
        //            return Json(new { data = funcofgroup , Message = "تم مسح الصفحة بنجاح" , State = 1});
        //        }
        //        catch
        //        {
        //            return Json(new { data = funcofgroup ,Message = "حدث خطأ", State = 0 });
        //        }

        //    }
        //}


        //[HttpPost]
        //public JsonResult AddFunctionInGroup(int AssignedFunctionId, int groupId)
        //{

        //    //get functions of group from api
        //    string res = httphelp.Get($"/api/Selector/GetFunctionsToGroup?GroupId={groupId}").ToString();
        //    Response<List<GroupOrFuncVM>> funcs = JsonConvert.DeserializeObject<Response<List<GroupOrFuncVM>>>(res);
        //    var funcofgroup = funcs.Data;



        //    //create array from the IDs of functions
        //    List<int> funcsIdlist = new List<int>();
        //    foreach (var item in funcofgroup)
        //    {
        //        funcsIdlist.Add(item.Id);
        //    }
        //    if (!funcsIdlist.Contains(AssignedFunctionId))
        //    {
        //        funcsIdlist.Add(AssignedFunctionId);
        //    }
        //    else
        //    {
        //        return Json(new { message = "هذة الوظيفة موجوده بالفعل", status = 0 });
        //    }
        //    int[] funcsIdArray = funcsIdlist.ToArray();


        //    ////disunderstand
        //    ////add in list 
        //    ////first,generate a id for function through get the max id and sum on it +1
        //    //int newId = AssignedFunctionId;
        //    ////second,create a object from function with the name in parameter and newId
        //    //GroupOrFuncVM newFunc = new GroupOrFuncVM { Id = newId, Value = functionName };
        //    ////third, add it in list
        //    //funcofgroup.Add(newFunc);




        //    //pass data to VM to send to API
        //    EditFunctionsVM editFunctionsVM = new EditFunctionsVM
        //    {
        //        GroupId = groupId,
        //        Functions = funcsIdArray,
        //    };



        //    //in AddFunctionInGroup and  DeleteFunctionInGroup Actions
        //    //test hereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee we will send the changes
        //    using (HttpClient http = new HttpClient())
        //    {
        //        StringContent body = new StringContent(JsonConvert.SerializeObject(editFunctionsVM), Encoding.UTF8, "application/json");
        //        var response = http.PostAsync(Setting.Host + $"/api/Admin/EditGroupFunctions", body).Result;
        //        Response<string> Fres = JsonConvert.DeserializeObject<Response<string>>(response.Content.ReadAsStringAsync().Result);

        //        //string resAfterAdd = httphelp.Get($"/api/Selector/GetFunctionsToGroup?GroupId={groupId}").ToString();
        //        //Response<List<GroupOrFuncVM>> funcsAfterAdd = JsonConvert.DeserializeObject<Response<List<GroupOrFuncVM>>>(res);
        //        //var funcofgroupAfterAdd = funcs.Data;
        //        return Json(new { message=Fres.Message,status = Fres.State});
        //    }


        //}



        #endregion

        #region GPS Map

        public ActionResult ShowBranchesMap()
        {
            var res = httphelp.Get<Response<List<Branch_Info_V>>>($"/api/AllBranches");

            return View(res);
        }
        public ActionResult ShowMap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowMapPost(ShowMap_VM show)
        {

            //    var model = new List<MapViewModel>
            //{                      latitude                    longitude
            //    new MapViewModel { Latitude = 29.934868840000000, Longitude = 31.193543710000000, Description = "San Francisco" },
            //    new MapViewModel { Latitude = 29.937057495117184, Longitude = 31.197052001953125, Description = "Los Angeles" },
            //    new MapViewModel { Latitude = 29.934966390000000, Longitude = 31.193666350000000, Description = "New York" },
            //    new MapViewModel { Latitude = 29.934984470000000, Longitude = 31.193659790000000, Description = "Abkr" }
            //};

            try
            {
                string res = httphelp.Get($"/Tracking/GetSalesWalkingLineToday?UserID={show.UserID}&Date={show.Date}").ToString();
                TrackingResponse model = JsonConvert.DeserializeObject<TrackingResponse>(res);
                var userres = httphelp.Get($"/api/Account/getUserNameByUserId?UserID={show.UserID}").ToString();
                GetUser user = JsonConvert.DeserializeObject<GetUser>(userres);
                if (user == null)
                {
                    ViewBag.Name = null;
                }
                else
                {
                    ViewBag.Name = user?.Item;
                }
                ViewBag.Date = show.Date;
                return View(model);
            }
            catch (Exception)
            {

                return View(new TrackingResponse());
            }           
        }

        #endregion



        [HttpPost]
        public JsonResult editUserAgent(int userId, int agentId) => Json(httphelp.Get<Response<string>>($"/api/Admin/editUserAgent?userId={userId}&agentId={agentId}"));



        [HttpPost]
        public JsonResult editUserstatus(int userId) => Json(httphelp.Get<Response<string>>($"/api/Admin/editUserstatus?userId={userId}"));


        [HttpPost]
        public JsonResult changeUserPassword(int userId, string newPassword , string email , string username)
        {
            var url = $"/api/ChangeUserPassword?NewPassword={newPassword}&UserId={userId}&email={email}&username={username}";
            var res = httphelp.Get<Response<string>>(url);
            return Json(res);
        }

        [HttpPost]
        public JsonResult getUserDate(int userId)
        {
            var url = $"/api/getUsernameandPasswordData?UserId={userId}";
            var res = httphelp.Get<Response<userdata>>(url);
            return Json(res);
        }
    }
}

public class userdata
{
    public int RecordId { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}