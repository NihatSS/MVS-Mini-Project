using System.ComponentModel.DataAnnotations;

namespace MVS_Mini_Mini_Project.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
