using System.ComponentModel.DataAnnotations;

namespace MVCAuthApp.Models.Views
{
    public class LoginViewModel
    {
        [Required]
        public string Username { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}