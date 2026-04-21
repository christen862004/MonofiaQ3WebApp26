using Microsoft.AspNetCore.Mvc;

namespace MonofiaQ3WebApp26.Controllers
{
    public class BindController : Controller
    {
        //Bind/m1
        //[HttpGet]
        //public IActionResult M1()
        //{
        //    return Content("M1_!");
        //}
        ////Bind/m1
        ////Bind/m1?name=ahmed
        //[HttpPost]
        //public IActionResult M1(string name)
        //{
        //    return Content("M1_!");
        //}

        /*
         <form action="http://localhost:12950/Bind/TestPrimitive/11" method="post">
            <input type="text" name="UserName">
            <input type="number" name="Age">
            <input type="text" name="color[1]">
            <input type="text" name="color[0]">
            <input type="text" name="PhoneBook[Ahmed]">
            <!--<input type="text" name="id">send querstting || FromData-->
            <input type="submit" value="Submit">

         </form>
         */
        //Bind/TestPrimitive?UserName=Ahmed&age=33&id=22
        //Bind/TestPrimitive/11?UserName=Ahmed&age=33&color=red&color=blue
        public IActionResult TestPrimitive(string UserName,int age,string[] color,int id)//Bind from Request
        {
            return Content("ok");
        }


        //test collection list dic
        //Bind/TestDic?PhoneBook[ahmed]=123&PhoneBook[Moh]=456&name=Christe
        public IActionResult TestDic(Dictionary<string, string> PhoneBook,string name) {
            return Content("ok");
        }

        //Test Cutom Class
        //Bind/TestObj?id=11&name=newDept&ManagerName=ahmed&Employees[0].name=ahmed
        public IActionResult TestObj(Department dept,string name)
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees, string name)
        {
          
            return Content("ok");

        }
    }
}
