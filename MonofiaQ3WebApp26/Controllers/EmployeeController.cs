using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonofiaQ3WebApp26.Models;
using MonofiaQ3WebApp26.Repository;
//using MonofiaQ3WebApp26.ViewModels;

namespace MonofiaQ3WebApp26.Controllers
{
    public class EmployeeController : Controller
    {
        
        IEmployeeRepository EmpRepository=null;
        IDepartmentRepository DeptRepository;
        public EmployeeController(IEmployeeRepository empRepo,IDepartmentRepository deptRepo)//lossly couple
        {
            EmpRepository = empRepo;//di ,dip,ioc
            DeptRepository = deptRepo;
        }//Employee/Index
        [Authorize]
        public IActionResult Index()
        {
            //pagination
            return View("Index",EmpRepository.GetAll());
        }

        public IActionResult CheckSalary(int Salary,string DepartmentId)
        {
            if (Salary > 8000)
            {
                return Json(true);
            }
            return Json("Salary Must be Greater than 8000");//conside false "message rror"
        }
        #region New
        //Employee/NEw
        public IActionResult New()
        {
            ViewBag.DeptList = DeptRepository.GetAll();
            return View("New");
        }
        [HttpPost] //restrict hanel post request only
        [ValidateAntiForgeryToken]//REQUEST["__requestVer"]
        public IActionResult SaveNEw(Employee empFromReq) {
            if(ModelState.IsValid==true)
            {
                try
                {
                    EmpRepository.Add(empFromReq);
                    EmpRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    //ModelState.AddModelError("DepartmentId", "Please Select Department");
                    ModelState.AddModelError("ex",ex.InnerException.Message);
                }
            }
           // IEnumerable<SelectListItem> items = context.Department.ToList();
            ViewBag.DeptList = DeptRepository.GetAll();
            return View("New", empFromReq);
        }
        #endregion

        #region Edit
        //open view "handel link
        public IActionResult Edit(int id)
        {
            //collect
            Employee empFromDb= EmpRepository.GetById(id);
            List<Department> departmentList= DeptRepository.GetAll();
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
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(EmpWithDEptListViewModel EmpFromReq)//1)Create obj ,take porty ==>bind
        {
            if(EmpFromReq.EmpName != null &&EmpFromReq.NetSalary>8000) {
                //mapping from vm to model
                Employee empFromDb = new Employee();
                empFromDb.Id= EmpFromReq.Id;
                
                empFromDb.Name= EmpFromReq.EmpName;
                empFromDb.Salary= EmpFromReq.NetSalary;
                empFromDb.ImageUrl= EmpFromReq.ImageUrl;
                empFromDb.DepartmentId= EmpFromReq.DepartmentId;

                EmpRepository.Update(empFromDb);

                //save
                EmpRepository.Save();
                //index
                return RedirectToAction("Index", "Employee");
            }
            EmpFromReq.DeptList = DeptRepository.GetAll();
            return View("Edit",EmpFromReq);
        }
        #endregion

        #region Deatils
        //Employee/Details/1
        //Employee/Details?id=1
        public IActionResult Details(int id ,string name)
        {
            //logic
            string msg = "Hello";
            int temp = 30;
            List<string> DeptList = DeptRepository.GetAll().Select(d => d.Name).ToList() ;// context.Department.Select(x => x.Name).ToList();
            //fill or set data ViewData C#
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["DeptList"] = DeptList;
            ViewBag.Color = "Blue";//override 
            ViewData["Color"] = "red";


            ViewBag.Val = 10;


            Employee EmpModel = EmpRepository.GetById(id);
            return View("Details",EmpModel);
        }
        public IActionResult DetailsVM(int id)
        {
            //1) collect data
            string msg = "Hello";
            int temp = 30;
            Employee EmpModel = EmpRepository.GetById(id);
            List<string> DeptList = DeptRepository.GetAll().Select(x => x.Name).ToList();
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
