using System.ComponentModel.DataAnnotations;

namespace Todo_with_good_practice.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="usernmae is  required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string? UserName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "password must be between 3 and 50 characters")]
        [Required(ErrorMessage = "password is  required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
