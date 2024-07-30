using GPB.Domain.Entity;
using System.Collections.ObjectModel;

namespace GPB.Application.Dtos.UserDto
{
    public class GetByIdUserDto
    {
        public int UserId { get; set; } // UserId
        public string UserName { get; set; } // UserName
        public string Role { get; set; } // Role
        public DateTime CreationDate { get; set; } // CreationDate
        public DateTime UpdateDate { get; set; } // UpdateDate
        public List<Guest> Guests { get; set; } // Güncellenmiş
        public List<Admin> Admins { get; set; } // Güncellenmiş
    }
}
