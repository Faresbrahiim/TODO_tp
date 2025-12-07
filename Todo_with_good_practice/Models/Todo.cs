using System.ComponentModel.DataAnnotations;
using Todo_with_good_practice.Enums;
namespace Todo_with_good_practice.Models
{
    // the only data src -> so will be mapped from viewmodel to this model
    public class Todo
    {
        public string Libelle { get; set; }
        public string? Description { get; set; }
        public DateTime Datelimite { get; set; }
        public State State { get; set; }
    }
}
