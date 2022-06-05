using System.ComponentModel.DataAnnotations;

namespace Conduit.Domain.Resources.Requests
{
    public class LoginResource
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
