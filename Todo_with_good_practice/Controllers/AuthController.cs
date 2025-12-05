using Microsoft.AspNetCore.Mvc;
using Todo_with_good_practice.ViewModels;

namespace Todo_with_good_practice.Controllers
{
    public class AuthController : Controller
    {
      public IActionResult Login()
      {
        return View();
      }
       [HttpPost]
      public IActionResult Login(LoginVM vm)
      {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            // handle login logic here
            return View();
      }
      public IActionResult Register()
      {
        return View();
      }

       [HttpPost]
      public IActionResult Register(RegisterVM vm)
       {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            // handle register logic here
            return View();
        }
    }
}
