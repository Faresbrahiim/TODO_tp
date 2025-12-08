namespace Todo_with_good_practice.Mappers;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.ViewModels;
public class TodoMapper
{
        public static Todo mapTodoFromVM(AddTodoVM vm)
        {
            return new Todo
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                Datelimite = vm.Datelimite,
                State = vm.State
            };
        }
   
        public static void MapTodo(Todo source, Todo target)
        {
            target.Libelle = source.Libelle;
            target.Description = source.Description;
            target.Datelimite = source.Datelimite;
            target.State = source.State;
        }
        
        public static EditTodoVM MapTodoToVM(Todo todo)
        {
            return new EditTodoVM
            {
                Id = todo.Id,
                Libelle = todo.Libelle,
                Description = todo.Description,
                Datelimite = todo.Datelimite,
                State = todo.State
            };
        }
    public static Todo MapVMToTodo(EditTodoVM vm)
    {
        return new Todo
        {
            Id = vm.Id,
            Libelle = vm.Libelle,
            Description = vm.Description,
            Datelimite = vm.Datelimite,
            State = vm.State
        };
    }
    public static void MapTodoToExisting(Todo source, Todo target)
    {
        target.Libelle = source.Libelle;
        target.Description = source.Description;
        target.Datelimite = source.Datelimite;
        target.State = source.State;
    }
}

