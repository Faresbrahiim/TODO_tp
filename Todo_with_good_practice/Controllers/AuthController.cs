using Microsoft.AspNetCore.Mvc;
using Todo_with_good_practice.ViewModels;

// auth is almost done just need to  handle it from db
namespace Todo_with_good_practice.Controllers
{
    public class AuthController : Controller
    {
        // To get login view
        public IActionResult Login()
        {
        return View();
        }
        // To post login view
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
        // To get register view
        public IActionResult Register()
        {
            return View();
        }
        // To post register view
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
