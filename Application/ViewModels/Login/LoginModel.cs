using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.ViewModels.Login
{
    public class LoginModel
    {

        [Display(Name = "user name")]
        [Required(ErrorMessage = "user name is required")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
