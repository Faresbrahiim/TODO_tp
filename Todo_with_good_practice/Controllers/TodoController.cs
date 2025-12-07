using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Todo_with_good_practice.Mappers;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.ViewModels;

namespace Todo_with_good_practice.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddTodoVM  vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm); 
            }
            // mappage
            List<Todo> todos = new List<Todo>();
            Todo todo = TodoMapper.mapTodoFromVM(vm);
            todos.Add(todo);
            return RedirectToAction(nameof(Create));
        }
    }
}
