using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.WebUI.Models
{
    public class AdminLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} Required!")]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Password"), Required(ErrorMessage = "{0} Required!")]
        public string Password { get; set; }
    }
}
