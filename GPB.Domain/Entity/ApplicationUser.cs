using Microsoft.AspNetCore.Identity;
namespace GPB.Domain.Entity
{
    public class ApplicationUser : IdentityUser

    {
        // Kullanıcının T.C. kimlik numarası 
        public int? TcNumber { get; set; } // Nullable olmalı, çünkü adminlerde bu alan boş olabilir 
        // Kullanıcının tam adı 
        public string UserType { get; set; }
    }

}