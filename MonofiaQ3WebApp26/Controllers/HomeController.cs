using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonofiaQ3WebApp26.Models;
using System.Diagnostics;

namespace MonofiaQ3WebApp26.Controllers
{
    //Class to be controller an call in url
    //1) class en with Controller
    //2) Classs inherit built in class Contoller
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //metho can be write url "Call Action":
        //1) Must be Public 
        //2) Cant be Static
        //3) Cant be overload (only in one case)
        //endpoint:/Home/ShowMsg
        
        public ContentResult ShowMsg()
        {
          
            //logic
            //dEcalre
            ContentResult result = new ContentResult();
            //set 
            result.Content = "Hello";
            //retunr 
            return result;
        }

        //enpoint:/Home/showView
        public ViewResult showView()
        {
            //logic
            //ecalre
            ViewResult result = new ViewResult();
            //set
            result.ViewName = "View1";
            //return
            return result;
        }
        //Home/ShowMix?no=1&name=omar&id=10
        //Home/ShowMix/10?no=1&name=omar
        public IActionResult ShowMix(int no,string name,int id)
        {
            if (no == 13)
            {
                //retunr 
                return Content("Hello");
            }
            else
            {       
                return View("View1");
            }
        }
        //public ViewResult View(string viewname)
        //{
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = viewname;
        //    //return
        //    return result;

        //}




        /*
         1) Action return type
        1)Content==>ContentResult  ==>Content(""msg)
        2)View   ==>ViewREsult     ==>View("ViewNAme"
        3)Json   ==>JsonREsult     ==>Json(obj)
        4)NotFound=>NotFountREsult ==>NotFoun()
         .......
         */
















        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
    