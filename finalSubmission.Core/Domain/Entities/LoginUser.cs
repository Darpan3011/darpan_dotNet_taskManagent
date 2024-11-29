using System.ComponentModel.DataAnnotations;

namespace finalSubmission.Core.Domain.Entities
{
    public class LoginUser
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

}
