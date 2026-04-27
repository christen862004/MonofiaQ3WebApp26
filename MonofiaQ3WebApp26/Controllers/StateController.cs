using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MonofiaQ3WebApp26.Controllers
{
    public class StateController : Controller
    {
        int counter = 0;
        public StateController()
        {
            
        }//state/index
        //set
        public IActionResult SetSession(string name ,int age)
        {
            //logic................
            HttpContext.Session.SetString("UserName", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Success Save");
        }
        //get
        public ActionResult GetSession()
        {
            //logic
            string n = HttpContext.Session.GetString("UserName");
            int? a = HttpContext.Session.GetInt32("Age");
            //logic
            return Content($"name={n}\t age={a}");
        }


        public IActionResult SetCookie(string name,int age)
        {
            //logic
            //sesion Cookie
            HttpContext.Response.Cookies.Append("UserName", name);
            //Presisiten cookie "expiration hours ,days"
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);
            return Content("Cooikie Save");
        }

        public ActionResult GetCookie()
        {
            string n = HttpContext.Request.Cookies["UserName"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"name={n}\t age={a}");

        }
    }
}
