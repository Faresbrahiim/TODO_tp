using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Todo_with_good_practice.Mappers;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.ViewModels;
using Todo_with_good_practice.Services;
namespace Todo_with_good_practice.Controllers
{
    public class TodoController : Controller
    {
        // depend on abstraction not concret class
        // globaly since we will use it in more than one method
        private IsessionService IsessionService;
        // dependency injection via constructor
        public TodoController(IsessionService TodoService)
        {
            this.IsessionService = TodoService;
        }
        // To get create todo 
        public IActionResult Create()
        {
            return View();
        }
        // to post create todo 
        [HttpPost]
        public IActionResult Create(AddTodoVM  vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm); 
            }
            // we didn't make interface here because it's okk if we have fort coupling ()
            // -> it's not always bad ... depend on context ... , do code x need always code y ?
            Todo todo = TodoMapper.mapTodoFromVM(vm);
            // fort coupling  new sessionTodoService here  .... + sessionTodoService
            //  the solution is dependency inversion principle ... 
            // interface will solve the problem of sessionTodoService instantiation here
            // dependency inversion principle  (DIP)   will solve the instantiation problem here

            //SessionTodoService sessionTodoService = new SessionTodoService();
            // know it depent on abstraction not on concret class
            IsessionService.AddSession(HttpContext.Session, todo);

            return RedirectToAction(nameof(Create));
        }
        // to show todos
        public IActionResult Show()
        {
            //SessionTodoService sessionTodoService = new SessionTodoService();
            var todos = IsessionService.GetSession<List<Todo>>("todos", HttpContext.Session);
            ViewBag.Todos = todos;
            return View(todos);
        }
        // improvement : need to delete based on id not tittle 
        public IActionResult Delete(int id)
        {
            IsessionService.DeleteSessionById(HttpContext.Session, id , "todos");
            return RedirectToAction(nameof(Show));
        }

        [HttpGet]
        
        public IActionResult Edit(int id)
        {
            var todo = IsessionService.GetTodoById<Todo>(HttpContext.Session, id, "todos");
            if (todo == null) return NotFound(); // case of editing in url an id not exist

            // map from todo to EditTodoVM ... to fill the form by existing data
            EditTodoVM vm = TodoMapper.MapTodoToVM(todo);
            return View(vm); // now passing EditTodoVM to the view
        }
      
        // the new todo edited will be passed via EditTodoVM but it will have an id to identify which todo to edit

        [HttpPost]
        public IActionResult Edit(EditTodoVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var updatedTodo = TodoMapper.MapVMToTodo(vm);
            IsessionService.EditSessionById(HttpContext.Session, updatedTodo, "todos");

            return RedirectToAction("Show");
        }
    }
}
