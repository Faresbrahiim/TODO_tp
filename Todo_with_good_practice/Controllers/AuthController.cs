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
                return View(nameof(Login));
            }
            // TODO : hanlde it from database
            if (vm.UserName == "admin" && vm.Password == "password")
            {
                return RedirectToAction("Create", "Todo");
            }
            return View(vm);

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
                return View(nameof(Login));
            }
            // handle register logic here
            return RedirectToAction("Create", "Todo");
        }
    }
}
