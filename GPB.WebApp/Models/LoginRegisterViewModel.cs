using System.ComponentModel.DataAnnotations;

namespace GPB.WebApp.Models
{
    public class LoginRegisterViewModel
    {
        // Login ile ilgili özellikler 
        public LoginViewModel Login { get; set; } = new LoginViewModel();

        // Register ile ilgili özellikler 
        public RegisterViewModel Register { get; set; } = new RegisterViewModel();
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public int? TcNumber { get; set; } // Nullable, çünkü sadece guestlerde var

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; } // Rol seçimini ekledik
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
