namespace GPB.Application.Dtos.GuestDto
{
    public class UpdateGuestDto
    {
        public int GuestId { get; set; }
        public int TcNumber { get; set; } // TcNumber
        public string Username { get; set; } // Username
        public string Password { get; set; } // Password
        public string Email { get; set; } // Email
    }
}
