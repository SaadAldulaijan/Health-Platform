using System.ComponentModel.DataAnnotations;

namespace Health.Api.Forms
{
    public class LoginForm
    {
        [Required(ErrorMessage = "username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "password cannot be empty")]
        public string Password { get; set; }
    }
}
