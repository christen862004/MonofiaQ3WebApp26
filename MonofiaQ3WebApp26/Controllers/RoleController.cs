using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MonofiaQ3WebApp26.Controllers
{
    [Authorize(Roles ="Admin")]//check cookie ==>claim Role="Admin"
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel RoleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { 
                    Name=RoleFromReq.RoleName
                };
                IdentityResult result= await roleManager.CreateAsync(role);//duplicate
                if (result.Succeeded)
                {
                    //view
                    return RedirectToAction("Index","department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
