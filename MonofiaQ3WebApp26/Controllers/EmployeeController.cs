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
    }
}
