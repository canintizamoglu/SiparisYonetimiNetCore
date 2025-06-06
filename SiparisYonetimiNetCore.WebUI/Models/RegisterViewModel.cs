using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is Reqiured")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is Reqiured")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is Reqiured")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Reqiured")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password repetition is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }
    }
} 