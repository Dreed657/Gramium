using System.ComponentModel.DataAnnotations;

namespace Gramium.Server.Features.Identity.Models
{
    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
