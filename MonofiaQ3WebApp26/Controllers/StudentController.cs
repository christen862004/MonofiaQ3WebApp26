using Microsoft.AspNetCore.Mvc;
using MonofiaQ3WebApp26.Models;

namespace MonofiaQ3WebApp26.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        //Student/index
        public IActionResult Index()
        {
            List<Student> students = studentBL.GetAll();//get list form model
            return View("Index", students);
            //shear for view "Views/Stuent/Inex   sen Moel List<stuent>
         }
    }
}
