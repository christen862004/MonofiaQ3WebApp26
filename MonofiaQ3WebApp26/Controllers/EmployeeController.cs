using Microsoft.AspNetCore.Mvc;
using MonofiaQ3WebApp26.Models;
//using MonofiaQ3WebApp26.ViewModels;

namespace MonofiaQ3WebApp26.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
        }
        public IActionResult Index()
        {
            //pagination
            return View("Index", context.Employees.ToList());
        }

        #region Edit
        //open view "handel link
        public IActionResult Edit(int id)
        {
            //collect
            Employee empFromDb= context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> departmentList= context.Department.ToList();
            if(empFromDb != null)
            {
                //declare &map
                EmpWithDEptListViewModel empVM = new EmpWithDEptListViewModel()
                {
                    Id=empFromDb.Id,
                    EmpName=empFromDb.Name,
                    NetSalary=empFromDb.Salary,
                    ImageUrl=empFromDb.ImageUrl,
                    DepartmentId=empFromDb.DepartmentId,
                    DeptList=departmentList//////////
                };
                //open view sen view Model
                return View("Edit", empVM);
            }
            return NotFound();
        }
        //handel submit 
        //Employee/SaveEdit/1 ?Name=&Salary=&ImageUrl=&DepartmentId=
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDEptListViewModel EmpFromReq)//1)Create obj ,take porty ==>bind
        {
            if(EmpFromReq.EmpName != null &&EmpFromReq.NetSalary>8000) {
                //get old object
                Employee empFromDb= context.Employees.FirstOrDefault(e => e.Id == EmpFromReq.Id);
                //change value
                empFromDb.Name= EmpFromReq.EmpName;
                empFromDb.Salary= EmpFromReq.NetSalary;
                empFromDb.ImageUrl= EmpFromReq.ImageUrl;
                empFromDb.DepartmentId= EmpFromReq.DepartmentId;
                //save
                context.SaveChanges();
                //index
                return RedirectToAction("Index", "Employee");
            }
            EmpFromReq.DeptList = context.Department.ToList();
            return View("Edit",EmpFromReq);
        }
        #endregion
        #region Deatils

        
        //Employee/Details/1
        //Employee/Details?id=1
        public IActionResult Details(int id)
        {
            //logic
            string msg = "Hello";
            int temp = 30;
            List<string> DeptList=context.Department.Select(x => x.Name).ToList();
            //fill or set data ViewData C#
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["DeptList"] = DeptList;
            ViewBag.Color = "Blue";//override 
            ViewData["Color"] = "red";


            ViewBag.Val = 10;


            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",EmpModel);
        }
        public IActionResult DetailsVM(int id)
        {
            //1) collect data
            string msg = "Hello";
            int temp = 30;
            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);
            List<string> DeptList = context.Department.Select(x => x.Name).ToList();
            //2) declare ViewModel Object //3) Map
            EmpNAmeWithDeptListTempMsgColorViewModel empVM = new() { 
                EmpName=EmpModel.Name,
                EmpId=EmpModel.Id,
                Message=msg,
                Temp=temp,
                Color="red",
                DeptList=DeptList
            };


            //4) return viewModel To View
            return View("DetailsVM", empVM);
            //View ="DetailsVM" ,Model with type EmpNAmeWithDeptListTempMsgColorViewModel
        }
        #endregion
    }
}
