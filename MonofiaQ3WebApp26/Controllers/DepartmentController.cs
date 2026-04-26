using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonofiaQ3WebApp26.Models;
using MonofiaQ3WebApp26.Repository;

namespace MonofiaQ3WebApp26.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext context = new ITIContext();
        IDepartmentRepository deptRepository;
        public DepartmentController()
        {
            deptRepository = new DepartmentRepository();
        }
        public IActionResult Index()
        {
            List<Department> deptList =deptRepository.GetAll();
            return View("Index",deptList);
            //View :Views/Department/Index.cshtml ,Model =>List<department>
        }
        #region New
        public IActionResult New()
        {
            return View("New");//New Model=null
        }
        //Req Get - url:/Department/SaveNew?Name=&ManagerName=

        //Action can handel any req get or post
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)//string name,string ManagerName)
        {
           // if(Request.Method=="POST")
            if (deptFromReq.Name != null) { 
                deptRepository.Add(deptFromReq);
                deptRepository.Save();
                
                //create objkrect controll call action
                //return RedirectToAction("Index");
                return RedirectToAction(actionName:"Index",controllerName:"Department");
            }
            return View("New",deptFromReq);//new Miodel =Department
        }
        #endregion
    }
}
