using Microsoft.AspNetCore.Mvc;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.Services;
using Todo_with_good_practice.ViewModels;

// auth is almost done just need to  handle it from db
namespace Todo_with_good_practice.Controllers
{
    public class AuthController : Controller
    {
        // To get login view
        // note : Filters should not perform the core business logic like validating credentials, registering a user, or storing a user in session
        // it should just check if the user is authenticated or not
        // logic of saving user to session should be in service or controller
        private IsessionService IsessionService;
        public AuthController(IsessionService service)
        {
            IsessionService = service;
        }
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
                SessionUser user = Mappers.UserMapper.MapLoginToUserSession(vm);
                IsessionService.AddUserToSession(HttpContext.Session, user, "CurrentUser");
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
            SessionUser user = Mappers.UserMapper.MapRegisterToUserSession(vm);
            IsessionService.AddUserToSession(HttpContext.Session, user, "CurrentUser");
            // handle register logic here
            return RedirectToAction("Create", "Todo");
        }
        public IActionResult LogOut()
        {
            IsessionService.RemoveSession(HttpContext.Session, "CurrentUser");
            IsessionService.RemoveSession(HttpContext.Session, "todos");
            return View(nameof(Login));
        }
    }
}
