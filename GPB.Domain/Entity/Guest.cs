using System.ComponentModel.DataAnnotations;

namespace GPB.Domain.Entity
{
    public class Guest
    {
        public int GuestId { get; set; }
        public int TcNumber { get; set; } // TcNumber
        public string Username { get; set; } // Username
        public string Password { get; set; } // Password
        public string Email { get; set; } // Email
    }
}