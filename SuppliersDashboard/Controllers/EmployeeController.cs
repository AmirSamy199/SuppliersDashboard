using SuppliersDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuppliersDashboard.ViewModels;
using System.Web.Mvc;
using SuppliersDashboard.Repository;
using System.Data;
using Connibrary;
using SuppliersDashboard.Helper;
using System.Web.Configuration;
using SuppliersDashboard.Models.Employee;
using SuppliersDashboard.Filters;




namespace SuppliersDashboard.Controllers
{
    public class EmployeeController : Controller
    {
        
         MyFunctions fun = new MyFunctions();
        Getter get = new Getter();
        // GET: Employee




        // GET: Employees
        [FunctionFilter(key= "صقحات الHR")]
        
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult LoadGrid()
        {
            var SelectQ = "Select * From HR_Emp_Details_V";
            
            DataTable dt = fun.fireDataTable(SelectQ);
            List<Employees> EmployeesList = Helper.Converter.ConvertDataTable<Employees>(dt);
            EmployeesList.Select(c => { c._Date_of_hiring = c.DateOfHiring?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c._End_of_hiring = c.EndOfHiring?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c._Date_of_Birth = c.DateOfBirth?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c.IDStartDate = c.ID_StartDate?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c.IDExpDate = c.ID_ExpDate?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c.GraduationDate = c.Graduation_Date?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c.Probation_Date = c.ProbationDate?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c.SocialSecurityDate = c.SocialSecurityStartDate?.ToString("yyyy-MM-dd"); return c; }).ToList();
            EmployeesList.Select(c => { c.Military_Date = c.MilitaryDate?.ToString("yyyy-MM-dd"); return c; }).ToList();
            return Json(new { data = EmployeesList });
        }
        [HttpGet]
        public ActionResult AddEmployees()
        {
            Models.Model1 OBJ = new Models.Model1();
            var data = OBJ.AgentsLevels_tbl.Where(x => x.IsRoot == 1 && x.IsActive == 1).ToList();
            List<SelectListItem> DepartmentList = new List<SelectListItem>();

           
            foreach (var row in data)
            {
                DepartmentList.Add(new SelectListItem { Text = row.Name, Value = row.RecordId.ToString() });
            }
            ViewBag.DepartmentList = DepartmentList;

            List<SelectListItem> CompanyList = new List<SelectListItem>();
            var SelectC = "Select * From Com_Tbl";
            DataTable Companydt = fun.fireDataTable(SelectC);
            foreach (var row in Helper.Converter.ConvertDataTable<Models.Com_Tbl>(Companydt).ToList())
            {
                CompanyList.Add(new SelectListItem { Text = row.Name, Value = row.ComID.ToString() });
            }
            ViewBag.CompanyList = CompanyList;
            List<SelectListItem> DegreeList = new List<SelectListItem>();
            var SelectDegree = "Select * From HR_Degree_Tbl";
            DataTable Degreedt = fun.fireDataTable(SelectDegree);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Degree_Tbl>(Degreedt).ToList())
            {
                DegreeList.Add(new SelectListItem { Text = row.degree_edescription, Value = row.degree_code.ToString() });

            }
            ViewBag.Degrees = DegreeList;


            List<SelectListItem> PostionList = new List<SelectListItem>();
            var SelectQ = "Select * From PositionType_Tbl";
            DataTable positiondt = fun.fireDataTable(SelectQ);
            foreach (var row in Helper.Converter.ConvertDataTable<PositionType_Tbl>(positiondt).ToList())
            {
                PostionList.Add(new SelectListItem { Text = row.TypeName, Value = row.RecordID.ToString() });
            }
            ViewBag.PostionList = PostionList;
            List<SelectListItem> CountryList = new List<SelectListItem>();
            var CountryQuery = "SELECT * FROM Country_TBL";
            DataTable Countrydt = fun.fireDataTable(CountryQuery);
            foreach (var row in Helper.Converter.ConvertDataTable<Country>(Countrydt)
                                         .ToList())
            {
                if (string.IsNullOrEmpty(row.CODE))
                    continue;

                CountryList.Add(new SelectListItem { Text = row.EN + " - " + row.AR, Value = row.CODE });
            }
            ViewBag.CountryList = CountryList;



            List<SelectListItem> ManagerList = new List<SelectListItem>();
            var SelectManager = "Select * From HR_Employee_TBL";
            DataTable Managerdt = fun.fireDataTable(SelectManager);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Employee_TBL>(Managerdt).ToList())
            {
                ManagerList.Add(new SelectListItem { Text = row.EnglishName, Value = row.RecordID.ToString() });

            }
            ViewBag.Manager = ManagerList;

            List<SelectListItem> UniversityList = new List<SelectListItem>();
            var SelectUniversity = "Select * From HR_University_Tbl";
            DataTable Universitydt = fun.fireDataTable(SelectUniversity);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_University_Tbl>(Universitydt).ToList())
            {
                UniversityList.Add(new SelectListItem { Text = row.UniversityName, Value = row.RecordID.ToString() });

            }
            ViewBag.University = UniversityList;

            List<SelectListItem> EducationGradeList = new List<SelectListItem>();
            var SelectEducationGrade = "Select * From HR_Education_Grade_Tbl";
            DataTable EducationGradedt = fun.fireDataTable(SelectEducationGrade);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Education_Grade_Tbl>(EducationGradedt).ToList())
            {
                EducationGradeList.Add(new SelectListItem { Text = row.GradeENName, Value = row.RecordID.ToString() });

            }
            ViewBag.EducationGrade = EducationGradeList;

            List<SelectListItem> Military_StatusList = new List<SelectListItem>();
            var SelectMilitary_Status = "Select * From HR_Military_Status_Tbl";
            DataTable Military_Statusdt = fun.fireDataTable(SelectMilitary_Status);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Military_Status_Tbl>(Military_Statusdt).ToList())
            {
                Military_StatusList.Add(new SelectListItem { Text = row.MilitaryENName, Value = row.RecordID.ToString() });

            }
            ViewBag.Military_Status = Military_StatusList;

            List<SelectListItem> ReligionList = new List<SelectListItem>();
            var SelectReligion = "Select * From HR_Religion_Tbl";
            DataTable Religiondt = fun.fireDataTable(SelectReligion);
            foreach (var row in Helper.Converter.ConvertDataTable<Models.HR_Religion_Tbl>(Religiondt).ToList())
            {
                ReligionList.Add(new SelectListItem { Text = row.ReligionENName, Value = row.RecordID.ToString() });

            }
            ViewBag.Religion = ReligionList;




            return PartialView("_Employees");
        }
        public ActionResult manager1(int DegreeCode)
        {
            Models.Model1 OBJ = new Models.Model1();
            var data = OBJ.AgentsLevels_tbl.Where(x => x.Level == 2 &&x.ParentId== DegreeCode && x.IsActive == 1).ToList();
            List<SelectListItem> DepartmentList = new List<SelectListItem>();


            foreach (var row in data)

            {
                DepartmentList.Add(new SelectListItem { Text = row.Name, Value = row.Name.ToString() });
            }
        

        



            return Json(new { data = DepartmentList });
        }

        public ActionResult DegreeJobs(string DegreeCode)
        {
            List<SelectListItem> JobList = new List<SelectListItem>();
            var Selectjob = "Select * From HR_Jobs_Tbl Where job_degree = " + DegreeCode + "";
            DataTable jobdt = fun.fireDataTable(Selectjob);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Jobs_Tbl>(jobdt).ToList())
            {
                JobList.Add(new SelectListItem { Text = row.job_edescipation, Value = row.JobID.ToString() });

            }
            List<SelectListItem> CategoriesList = new List<SelectListItem>();
            var SelectCategories = "Select * From HR_Jobs_Levels Where degree_ID = " + DegreeCode + "";
            DataTable Categoriesdt = fun.fireDataTable(SelectCategories);
            foreach (var row in Helper.Converter.ConvertDataTable<Joblevels>(Categoriesdt).ToList())
            {
                CategoriesList.Add(new SelectListItem { Text = row.Categories, Value = row.Categories });

            }
            Models.Model1 OBJ = new Models.Model1();
            var data = OBJ.AgentsLevels_tbl.Where(x => x.Level == 2 && x.ParentId.ToString() == DegreeCode && x.IsActive == 1).ToList();
            List<SelectListItem> DepartmentList = new List<SelectListItem>();


            foreach (var row in data)
            {
                DepartmentList.Add(new SelectListItem { Text = row.Name, Value = row.RecordId.ToString() });
            }




            var data1= DepartmentList;

            return Json(new { data1,data = JobList, Grade = CategoriesList });
        }
        
        public ActionResult Joblevel(string Grade)
        {
            List<SelectListItem> JoblevelList = new List<SelectListItem>();
            var SelectJoblevel = "Select * From HR_Jobs_Levels Where Categories = '" + Grade + "' ";
            DataTable Jobleveldt = fun.fireDataTable(SelectJoblevel);
            foreach (var row in Helper.Converter.ConvertDataTable<Joblevels>(Jobleveldt).ToList())
            {
                JoblevelList.Add(new SelectListItem { Text = row.En_Name, Value = row.degree_ID });

            }


            return Json(new { data = JoblevelList });
        }
        
        public ActionResult Shifts(string ComID)
        {
            List<SelectListItem> ShiftsList = new List<SelectListItem>();
            var SelectShifts = "Select * From ShiftsAssigned_V  Where Com_ID = '" + ComID + "' ";
            DataTable Shiftsdt = fun.fireDataTable(SelectShifts);
            foreach (var row in Helper.Converter.ConvertDataTable<AssignShifts>(Shiftsdt).ToList())
            {
                ShiftsList.Add(new SelectListItem { Text = row.ShiftName, Value = row.shift_id.ToString() });

            }

            return Json(new { data = ShiftsList });
        }
        public ActionResult UploadFile()
        {
            HttpPostedFileBase file = Request.Files[0];

            List<UploadFiles> list = (List<UploadFiles>)Session["FileName"];

            list.Add(new UploadFiles { FileName = file.FileName });


            return Json(new { data = list });
        }

        [HttpPost]
        public ActionResult AddEmployee(NewEmloyee Emp)
        {
            if (Emp.Military_Status == "" || Emp.Military_Status == null)
            {
                Emp.Military_Status = "1";
            }
            var CompanyinsuranceDate_ = "";
            if (Emp.SocialSecurityStartDate == null)
            {
                CompanyinsuranceDate_ = DateTime.Parse(Emp.CompanyinsuranceDate).ToString("yyyy-MM-dd");

            }
            if (Emp.CompanyinsuranceDate == null)
            {
                CompanyinsuranceDate_ = DateTime.Parse(Emp.SocialSecurityStartDate).ToString("yyyy-MM-dd");

            }
            var JobName = int.Parse(Emp.Job);
            var ManagerName = int.Parse(Emp.Manager);
            var DegreeName = int.Parse(Emp.Degree);
            var DepartmentName = int.Parse(Emp.Department);
            var CompanyName = int.Parse(Emp.Company);
            var TypeName = int.Parse(Emp.PositionType);
            var Edu_GradeName = int.Parse(Emp.Edu_Grade);
            var UniversityName = int.Parse(Emp.University);
            var Military_StatusName = int.Parse(Emp.Military_Status);
            var ReligionName = int.Parse(Emp.Religion);
            var Salary = decimal.Parse(Emp.EmployeeSalary);
            var DateOfHiring_ = DateTime.Parse(Emp.DateOfHiring);
            var EndOfHiring = DateOfHiring_.AddYears(1);
            var ProbationDate = DateOfHiring_.AddMonths(3);
            var ShiftName = int.Parse(Emp.Shift);
            var Insurance_Status = int.Parse(Emp.InsuranceStatus);

            //List<string> Files = new List<string>();
            //if (Emp.Files.Count() > 0)
            //{
            //    foreach (var file in Emp.Files)
            //    {
            //        string fileName = file.FileName;
            //        if (file != null && file.ContentLength > 0)
            //        {
            //            fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            //            var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
            //            file.SaveAs(path);
            //            Files.Add(fileName);
            //        }
            //    }
            //}
            if (Emp.Graduation_Date == null)
                Emp.Graduation_Date = "1900-01-01"; 
            if (Emp.ID_StartDate == null)
                Emp.ID_StartDate = "1900-01-01";
            var InsertQuery = "INSERT INTO dbo.HR_Employee_TBL (EnglishName,ArabicName,NationalID,EmployeeInsrance,Email," +
            "Address,Phone,DateOfHiring," +
            "EndOfHiring,DateOfBirth,Gender,PositionType, NationalityCode,EmployeeDepartment,Employee_degree,Emp_Job," +
            "Emp_Manager,EmployeeCompany,EmployeeSalary,jobLevel,jobCategories,ID_StartDate,ID_ExpDate,Graduation_Date," +
            "Edu_Grade,Military_Status,Place_Of_Birth,MotherName,University,Martial_Status,ProbationDate,Religion," +
            "SocialSecurityStartDate,ShiftID,InsuranceStatus,MilitaryDate) VALUES" +
            " (N'" + Emp.EmployeeName + "' , N'" + Emp.EmployeeARName + "','" + Emp.NationalID + "','" + Emp.InsuranceNumber + "',N'" + Emp.Email + "'," +
            "N'" + Emp.Location + "','" + Emp.Phone + "','" + DateTime.Parse(Emp.DateOfHiring).ToString("yyyy-MM-dd") + "'," +
            "'" + EndOfHiring + "'," +
            "'" + DateTime.Parse(Emp.DateOfBirth).ToString("yyyy-MM-dd") + "',N'" + Emp.Gender + "'," +
            "" + TypeName + ",'" + Emp.Country + "','" + DepartmentName + "','" + DegreeName + "'," +
            "'" + JobName + "','" + ManagerName + "','" + CompanyName + "','" + Salary + "'," +
            "'" + Emp.jobLevel + "','" + Emp.jobCategories + "','" + DateTime.Parse(Emp.ID_StartDate).ToString("yyyy-MM-dd") + "'," +
            "'" + DateTime.Parse(Emp.ID_ExpDate).ToString("yyyy-MM-dd") + "','" + DateTime.Parse(Emp.Graduation_Date).ToString("yyyy-MM-dd") + "'," +
            "'" + Edu_GradeName + "','" + Military_StatusName + "','" + Emp.Place_Of_Birth + "','" + Emp.MotherName + "','" + UniversityName + "'," +
            "'" + Emp.Martial_Status + "','" + ProbationDate + "','" + ReligionName + "'," +
            "'" + CompanyinsuranceDate_ + "','" + ShiftName + "','" + Insurance_Status + "','" + DateTime.Parse(Emp.MilitaryDate).ToString("yyyy-MM-dd") + "');" +
            $"select RecordID from HR_Employee_TBL where NationalID='{Emp.NationalID}'and Email='{Emp.Email}' and Phone='{Emp.Phone}'";




            DataTable dt = fun.fireDataTable(InsertQuery);
            //if (dt.Rows.Count > 0)
            //{
            //    var EmployeeID = Helper.Converter.ConvertDataTable<HR_Employee_TBL>(dt).FirstOrDefault().RecordID;
            //    foreach (var fileName in Files)
            //    {
            //        var InsertAttachment = $"Insert Into HR_EmloyeeAttachments_Tbl(FileName,EmployeeID)Values('{fileName}',{EmployeeID})";
            //        fun.fireSQL(InsertAttachment);
            //    }
            //}
            return Json(new { data = true });
        }
        
        public ActionResult EditEmployee(string RecordID)
        {
            int ID = int.Parse(RecordID);
            var SelectEmployeeQuery = "Select * From HR_Emp_Details_V where RecordID = " + ID + ";";
            DataTable dt3 = fun.fireDataTable(SelectEmployeeQuery);
            var Employe = Helper.Converter.ConvertDataTable<Employees>(dt3).FirstOrDefault();
            Employe._Date_of_hiring = Employe.DateOfHiring?.ToString("yyyy-MM-dd");
            Employe._End_of_hiring = Employe.EndOfHiring?.ToString("yyyy-MM-dd");
            Employe._Date_of_Birth = Employe.DateOfBirth?.ToString("yyyy-MM-dd");
            Employe.IDStartDate = Employe.ID_StartDate?.ToString("yyyy-MM-dd");
            Employe.IDExpDate = Employe.ID_ExpDate?.ToString("yyyy-MM-dd");
            Employe.GraduationDate = Employe.Graduation_Date?.ToString("yyyy-MM-dd");
            Employe.Probation_Date = Employe.ProbationDate?.ToString("yyyy-MM-dd");
            Employe.SocialSecurityDate = Employe.SocialSecurityStartDate?.ToString("yyyy-MM-dd");
            Employe.Military_Date = Employe.MilitaryDate?.ToString("yyyy-MM-dd");
            List<SelectListItem> CountryList = new List<SelectListItem>();
            var CountryQuery = "SELECT * FROM Country_TBL";
            DataTable Countrydt = fun.fireDataTable(CountryQuery);
            foreach (var row in Helper.Converter.ConvertDataTable<Country>(Countrydt).ToList())
            {
                if (string.IsNullOrEmpty(row.CODE))
                    continue;
                if (row.CODE == Employe.Nationality)
                {
                    CountryList.Add(new SelectListItem { Text = row.EN + " - " + row.AR, Value = row.CODE, Selected = true });
                }
                else
                {
                    CountryList.Add(new SelectListItem { Text = row.EN + " - " + row.AR, Value = row.CODE, });

                }
            }
            ViewBag.Country = CountryList;

            List<SelectListItem> PostionList = new List<SelectListItem>();
            var SelectQ = "Select * From PositionType_Tbl";
            DataTable positiondt = fun.fireDataTable(SelectQ);
            foreach (var row in Helper.Converter.ConvertDataTable<PositionType_Tbl>(positiondt).ToList())
            {
                if (row.RecordID == Employe.PositionType)
                {
                    PostionList.Add(new SelectListItem { Text = row.TypeName, Value = row.RecordID.ToString(), Selected = true });
                }
                else
                {
                    PostionList.Add(new SelectListItem { Text = row.TypeName, Value = row.RecordID.ToString() });
                }
            }
            ViewBag.Postion = PostionList;

            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            Models.Model1 OBJ = new Models.Model1();
            var data = OBJ.AgentsLevels_tbl.Where(x => x.IsRoot == 1 && x.IsActive == 1).ToList();
       


            
           
            foreach (var row in data)
            {
                if (row.RecordId.ToString() == Employe.EmployeeDepartment)
                {
                    DepartmentList.Add(new SelectListItem { Text = row.Name, Value = row.RecordId.ToString(), Selected = true });
                }
                else
                {
                    DepartmentList.Add(new SelectListItem { Text = row.Name, Value = row.RecordId.ToString() });
                }
            }
            ViewBag.Department = DepartmentList;

            List<SelectListItem> CompanyList = new List<SelectListItem>();
            var SelectC = "Select * From Com_Tbl";
            DataTable Companydt = fun.fireDataTable(SelectC);
            foreach (var row in Helper.Converter.ConvertDataTable<Models.Com_Tbl>(Companydt).ToList())
            {
                if (row.ComID == Employe.EmployeeCompany)
                {
                    CompanyList.Add(new SelectListItem { Text = row.Name, Value = row.ComID.ToString(), Selected = true });
                }
                else
                {
                    CompanyList.Add(new SelectListItem { Text = row.Name, Value = row.ComID.ToString() });
                }
            }
            ViewBag.Companys = CompanyList;

            List<SelectListItem> DegreeList = new List<SelectListItem>();
            var SelectDegree = "Select * From HR_Degree_Tbl";
            DataTable Degreedt = fun.fireDataTable(SelectDegree);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Degree_Tbl>(Degreedt).ToList())
            {
                if (row.degree_code == Employe.Employee_degree.ToString())
                {
                    DegreeList.Add(new SelectListItem { Text = row.degree_edescription, Value = row.degree_code.ToString(), Selected = true });
                }
                else
                {
                    DegreeList.Add(new SelectListItem { Text = row.degree_edescription, Value = row.degree_code.ToString() });
                }

            }
            ViewBag.Degrees = DegreeList;



            List<SelectListItem> ManagerList = new List<SelectListItem>();
            var SelectManager = "Select * From HR_Employee_TBL";
            DataTable Managerdt = fun.fireDataTable(SelectManager);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Employee_TBL>(Managerdt).ToList())
            {
                if (row.RecordID == Employe.Emp_Manager)
                {
                    ManagerList.Add(new SelectListItem { Text = row.EnglishName, Value = row.RecordID.ToString(), Selected = true });
                }
                else
                {
                    ManagerList.Add(new SelectListItem { Text = row.EnglishName, Value = row.RecordID.ToString() });
                }
            }
            ViewBag.Managers = ManagerList;

            List<SelectListItem> UniversityList = new List<SelectListItem>();
            var SelectUniversity = "Select * From HR_University_Tbl";
            DataTable Universitydt = fun.fireDataTable(SelectUniversity);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_University_Tbl>(Universitydt).ToList())
            {
                if (row.RecordID == Employe.University)
                {
                    UniversityList.Add(new SelectListItem { Text = row.UniversityName, Value = row.RecordID.ToString(), Selected = true });
                }
                else
                {
                    UniversityList.Add(new SelectListItem { Text = row.UniversityName, Value = row.RecordID.ToString() });
                }
            }
            ViewBag.University = UniversityList;

            List<SelectListItem> EducationGradeList = new List<SelectListItem>();
            var SelectEducationGrade = "Select * From HR_Education_Grade_Tbl";
            DataTable EducationGradedt = fun.fireDataTable(SelectEducationGrade);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Education_Grade_Tbl>(EducationGradedt).ToList())
            {
                if (row.RecordID == Employe.Edu_Grade)
                {
                    EducationGradeList.Add(new SelectListItem { Text = row.GradeENName, Value = row.RecordID.ToString(), Selected = true });
                }
                else
                {
                    EducationGradeList.Add(new SelectListItem { Text = row.GradeENName, Value = row.RecordID.ToString() });
                }

            }
            ViewBag.EducationGrade = EducationGradeList;

            List<SelectListItem> Military_StatusList = new List<SelectListItem>();
            var SelectMilitary_Status = "Select * From HR_Military_Status_Tbl";
            DataTable Military_Statusdt = fun.fireDataTable(SelectMilitary_Status);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Military_Status_Tbl>(Military_Statusdt).ToList())
            {
                if (row.RecordID == Employe.Military_Status)
                {
                    Military_StatusList.Add(new SelectListItem { Text = row.MilitaryENName, Value = row.RecordID.ToString(), Selected = true });
                }
                else
                {
                    Military_StatusList.Add(new SelectListItem { Text = row.MilitaryENName, Value = row.RecordID.ToString() });
                }

            }
            ViewBag.Military_Status = Military_StatusList;

            List<SelectListItem> JobList = new List<SelectListItem>();
            var Selectjob = "Select * From HR_Jobs_Tbl Where job_degree = " + Employe.Employee_degree + "";
            DataTable jobdt = fun.fireDataTable(Selectjob);
            foreach (var row in Helper.Converter.ConvertDataTable<HR_Jobs_Tbl>(jobdt).ToList())
            {
                if (row.JobID == Employe.Emp_Job)
                {
                    JobList.Add(new SelectListItem { Text = row.job_edescipation, Value = row.JobID.ToString(), Selected = true });
                }
                else
                {
                    JobList.Add(new SelectListItem { Text = row.job_edescipation, Value = row.JobID.ToString() });
                }

            }
            ViewBag.Jobs = JobList;

            List<SelectListItem> CategoriesList = new List<SelectListItem>();
            var SelectCategories = "Select * From HR_Jobs_Levels ";
            DataTable Categoriesdt = fun.fireDataTable(SelectCategories);
            foreach (var row in Helper.Converter.ConvertDataTable<Joblevels>(Categoriesdt).ToList())
            {
                if (row.Categories == Employe.jobCategories)
                {
                    CategoriesList.Add(new SelectListItem { Text = row.Categories, Value = row.Categories, Selected = true });
                }
                else
                {
                    CategoriesList.Add(new SelectListItem { Text = row.Categories, Value = row.Categories });

                }
            }
            ViewBag.Categories = CategoriesList;

            List<SelectListItem> JoblevelList = new List<SelectListItem>();
            var SelectJoblevel = "Select * From HR_Jobs_Levels Where Categories = '" + Employe.jobCategories + "'";
            DataTable Jobleveldt = fun.fireDataTable(SelectJoblevel);
            foreach (var row in Helper.Converter.ConvertDataTable<Joblevels>(Jobleveldt).ToList())
            {
                if (row.En_Name == Employe.jobLevel)
                {
                    JoblevelList.Add(new SelectListItem { Text = row.En_Name, Value = row.degree_ID, Selected = true });
                }
                else
                {
                    JoblevelList.Add(new SelectListItem { Text = row.En_Name, Value = row.degree_ID });

                }
            }
            ViewBag.Joblevel = JoblevelList;

            List<SelectListItem> ReligionList = new List<SelectListItem>();
            var SelectReligion = "Select * From HR_Religion_Tbl";
            DataTable Religiondt = fun.fireDataTable(SelectReligion);
            foreach (var row in Helper.Converter.ConvertDataTable<Models.HR_Religion_Tbl>(Religiondt).ToList())
            {
                if (row.RecordID == Employe.Religion)
                {
                    ReligionList.Add(new SelectListItem { Text = row.ReligionENName, Value = row.RecordID.ToString(), Selected = true });
                }
                else
                {
                    ReligionList.Add(new SelectListItem { Text = row.ReligionENName, Value = row.RecordID.ToString() });

                }
            }
            ViewBag.Religion = ReligionList;

            List<SelectListItem> ShiftsList = new List<SelectListItem>();
            var SelectShifts = "Select * From ShiftsAssigned_V Where Com_ID = '" + Employe.EmployeeCompany + "' ";
            DataTable Shiftsdt = fun.fireDataTable(SelectShifts);
            foreach (var row in Helper.Converter.ConvertDataTable<AssignShifts>(Shiftsdt).ToList())
            {
                if (row.shift_id == Employe.ShiftID)
                {
                    ShiftsList.Add(new SelectListItem { Text = row.ShiftName, Value = row.shift_id.ToString(), Selected = true });

                }
                else
                {
                    ShiftsList.Add(new SelectListItem { Text = row.ShiftName, Value = row.shift_id.ToString() });

                }

            }
            ViewBag.Shift = ShiftsList;




            return PartialView("_EditEmployees", Employe);
        }

        public ActionResult SubmitEditEmployee(NewEmloyee Emp)
        {

            if (Emp.Military_Status == "" || Emp.Military_Status == null)
            {
                Emp.Military_Status = "1";
            }
            int id = int.Parse(Emp.RecordID);
            var JobName = int.Parse(Emp.Job);
            var ManagerName = Emp.Manager;
           
            var DegreeName = int.Parse(Emp.Degree);
            var DepartmentName = int.Parse(Emp.Department);
            var CompanyName = int.Parse(Emp.Company);
            var TypeName = int.Parse(Emp.PositionType);
            var Salary = decimal.Parse(Emp.EmployeeSalary);
            var Edu_GradeName = int.Parse(Emp.Edu_Grade);
            var UniversityName = int.Parse(Emp.University);
            var Military_StatusName = int.Parse(Emp.Military_Status);
            var ReligionName = int.Parse(Emp.Religion);
            var DateOfHiring_ = DateTime.Parse(Emp.DateOfHiring);
            var EndOfHiring = DateOfHiring_.AddYears(1);
            var ProbationDate = DateOfHiring_.AddMonths(3);
            var ShiftName = int.Parse(Emp.Shift);
            var Insurance_Status = int.Parse(Emp.InsuranceStatus);

            var UpdateEmployee = "UPDATE HR_Employee_TBL Set EnglishName = '" + Emp.EmployeeName + "'," +
                " ArabicName = N'" + Emp.EmployeeARName + "' , NationalID = '" + Emp.NationalID + "'," +
                " EmployeeInsrance = '" + Emp.InsuranceNumber + "', Email = '" + Emp.Email + "'," +
                " Address = '" + Emp.Location + "', Phone = '" + Emp.Phone + "'," +
                " DateOfHiring = '" + Emp.DateOfHiring + "', DateOfBirth = '" + Emp.DateOfBirth + "'," +
                " EndOfHiring = '" + EndOfHiring + "'," +
                " NationalityCode = '" + Emp.Country + "', Gender = '" + Emp.Gender + "'," +
                " EmployeeDepartment = '" + DepartmentName + "', EmployeeCompany = '" + CompanyName + "'," +
                " jobLevel = '" + Emp.jobLevel + "', jobCategories = '" + Emp.jobCategories + "'," +
                " Emp_Job = '" + JobName + "', Emp_Manager = '" + ManagerName + "',Employee_degree = '" + DegreeName + "',EmployeeSalary = '" + Salary + "'," +
                " ID_StartDate = '" + Emp.ID_StartDate + "', ID_ExpDate = '" + Emp.ID_ExpDate + "'," +
                " Graduation_Date = '" + Emp.Graduation_Date + "', Edu_Grade = '" + Edu_GradeName + "'," +
                " Military_Status = '" + Military_StatusName + "', Place_Of_Birth = '" + Emp.Place_Of_Birth + "'," +
                "MotherName = '" + Emp.MotherName + "',University = '" + UniversityName + "',Martial_Status = '" + Emp.Martial_Status + "'," +
                "ProbationDate = '" + ProbationDate + "'," +
                " PositionType = " + TypeName + ",Religion = " + ReligionName + "," +
                "SocialSecurityStartDate = '" + Emp.SocialSecurityStartDate + "',ShiftID = '" + ShiftName + "'" +
                ",InsuranceStatus = '" + Insurance_Status + "',MilitaryDate = '" + Emp.MilitaryDate + "' WHERE RecordID = " + id + "";

            fun.fireSQL(UpdateEmployee);


            return Json(new { data = true });
        }
        public ActionResult Details(string RecordID)
        {
            int ID = int.Parse(RecordID);
            var SelectQ = "Select * From HR_Emp_Details_V WHERE HR_Emp_Details_V.Employee_ID = " + ID + "";
            DataTable dt = fun.fireDataTable(SelectQ);
            var Details = Helper.Converter.ConvertDataTable<Employees>(dt).FirstOrDefault();
            Details._Date_of_hiring = Details.DateOfHiring?.ToString("yyyy-MM-dd");
            Details._End_of_hiring = Details.EndOfHiring?.ToString("yyyy-MM-dd");
            Details._Date_of_Birth = Details.DateOfBirth?.ToString("yyyy-MM-dd");
            Details.IDStartDate = Details.ID_StartDate?.ToString("yyyy-MM-dd");
            Details.IDExpDate = Details.ID_ExpDate?.ToString("yyyy-MM-dd");
            Details.GraduationDate = Details.Graduation_Date?.ToString("yyyy-MM-dd");
            Details.Probation_Date = Details.ProbationDate?.ToString("yyyy-MM-dd");
            Details.SocialSecurityDate = Details.SocialSecurityStartDate?.ToString("yyyy-MM-dd");
            Details.Military_Date = Details.MilitaryDate?.ToString("yyyy-MM-dd");

            return PartialView("_EmployeeDetails", Details);


        }

        public ActionResult Download(string id)
        {
            int ID = int.Parse(id);
            var Query = "Select * from HR_Emp_Details_V WHERE HR_Emp_Details_V.Employee_ID = " + ID + " ";
            DataTable dt3 = fun.fireDataTable(Query);
            var FileName = Helper.Converter.ConvertDataTable<Employees>(dt3).FirstOrDefault().FileName;
            return File(Server.MapPath("~/Models/UploadFiles.cs") + FileName, "application/octet-stream", FileName);

        }



    }
}
