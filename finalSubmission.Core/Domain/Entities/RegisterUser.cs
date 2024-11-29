using System.ComponentModel.DataAnnotations;

namespace finalSubmission.Core.Domain.Entities
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }

}
