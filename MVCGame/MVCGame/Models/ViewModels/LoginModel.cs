using System.ComponentModel.DataAnnotations;

namespace MVCGame.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
