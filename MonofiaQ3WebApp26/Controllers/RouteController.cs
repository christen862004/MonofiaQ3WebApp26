using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MonofiaQ3WebApp26.Filtters;

namespace MonofiaQ3WebApp26.Controllers
{
  //  [HandelError]
    //[Route("route")]
    public class RouteController : Controller
    {
        [HandelError]
        public IActionResult M1()
        {
            throw new Exception("some Exception");
        }
     //   [HandelError]
        public IActionResult M2()
        {
            throw new Exception("some Exception");
        }
        //Route/MEthod1?name=ahmed&age=12 (using default route)
        //r1?name=ahmed&age=12
        //r1/12/ahmed
        //r1/13/esraa
        //r1/144
        //  [HttpGet("rr/{age:int}/{name?}",Name ="Reout3")]//ignore all ather routs
        public IActionResult Method1(int age,string name,int id)
        {
            //ExceptionFilterAttribute
            return Content ("M1");
        }
        //r2
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
