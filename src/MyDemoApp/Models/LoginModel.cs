using System.ComponentModel.DataAnnotations;

namespace MyDemoApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Required!")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Password { get; set; }
    }
}
