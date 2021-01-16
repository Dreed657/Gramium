namespace Gramium.Web.ViewModels.Auth
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
