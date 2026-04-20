using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonofiaQ3WebApp26.Models;

namespace MonofiaQ3WebApp26.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> deptList =context.Department.ToList();
            return View("Index",deptList);
            //View :Views/Department/Index.cshtml ,Model =>List<department>
        }
    }
}
