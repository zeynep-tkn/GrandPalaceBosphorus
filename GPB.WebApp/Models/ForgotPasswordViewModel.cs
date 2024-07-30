using System.ComponentModel.DataAnnotations;
namespace GPB.WebApp.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}