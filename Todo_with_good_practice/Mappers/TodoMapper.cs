namespace Todo_with_good_practice.Mappers;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.ViewModels;
{
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
}
}
