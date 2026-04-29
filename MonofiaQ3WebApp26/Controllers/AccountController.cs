using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace MonofiaQ3WebApp26.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppliactionUser> userManager;
        private readonly SignInManager<AppliactionUser> signInManager;

        public AccountController(UserManager<AppliactionUser> userManager,SignInManager<AppliactionUser> signInManager)//ask dont create
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //mapp from vm to model
                AppliactionUser user = new AppliactionUser() { 
                    UserName=userFromReq.UserName,
                    PasswordHash=userFromReq.Password,
                    Address=userFromReq.Address
                };
                //create user on db
                IdentityResult result=await userManager.CreateAsync(user,userFromReq.Password);
                if(result.Succeeded)
                {
                    //create cookie
                    //create cookie - user id ,username,email? ,role?
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);//display div
                }
            }
            //return toi register view
            return View("Register",userFromReq);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//
        public async Task<IActionResult> Login(LoginUserViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //check valid
                AppliactionUser appUser=await userManager.FindByNameAsync(userFromReq.UserName);
                if (appUser != null)
                {
                    //check password
                    bool found=await userManager.CheckPasswordAsync(appUser, userFromReq.Password);
                    if (found)
                    {
                        //create cookie
                        List<Claim> extraClaims = new List<Claim>();
                        extraClaims.Add(new Claim("Address", appUser.Address));
                        await signInManager.SignInWithClaimsAsync(appUser, userFromReq.RmemeberMe,extraClaims);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "Invaliad Account");
                //create cookie
            }
            return View("Login", userFromReq);

        }
        #endregion

        #region LogOut
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
    }
}
