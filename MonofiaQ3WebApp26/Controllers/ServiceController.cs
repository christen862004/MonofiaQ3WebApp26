using Microsoft.AspNetCore.Mvc;
using MonofiaQ3WebApp26.Repository;

namespace MonofiaQ3WebApp26.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService service)//create - reusing
        {
            this.service = service;
        }
        //Service/index
        public IActionResult Index()
        {
            ViewData["Id"] = service.Id;
            return View("Index");
        }
    }
}
