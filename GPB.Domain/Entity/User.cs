using System;
using System.Collections.Generic;

namespace GPB.Domain.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } // Eklenen özellik
        public string Role { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<Guest> Guests { get; set; } // Güncellenmiş
        public List<Admin> Admins { get; set; } // Güncellenmiş
    }
}
