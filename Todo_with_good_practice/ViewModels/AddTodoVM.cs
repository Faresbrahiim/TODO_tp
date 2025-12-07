using System.ComponentModel.DataAnnotations;
using Todo_with_good_practice.Enums;
namespace Todo_with_good_practice.ViewModels
{
    public class AddTodoVM
    {
        [Required(ErrorMessage =" liblle is required")]
        public string Libelle { get; set; }

        public string? Description { get; set; }
        [Required(ErrorMessage = " date limite is required")]
        [DataType(DataType.Date)]
        public DateTime Datelimite { get; set; }
        [Required(ErrorMessage =" status is required")]

        public State State { get; set; }
    }
}
