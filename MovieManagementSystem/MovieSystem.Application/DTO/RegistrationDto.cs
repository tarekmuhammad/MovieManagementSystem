using System.ComponentModel.DataAnnotations;

namespace MovieSystem.Application.DTO
{
    public class RegistrationDto 
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [
            Required(ErrorMessage = "Password is required."),
            MinLength(6, ErrorMessage = "Password must be at least 6 characters.")
        ]
        public string Password { get; set; }

        [
            Required(ErrorMessage = "Please confirm your password."), 
            Compare("Password", ErrorMessage = "Password not match")
        ]
        public string ConfirmPassword { get; set; }
 
    

    }
}
