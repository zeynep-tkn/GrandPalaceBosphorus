using Microsoft.EntityFrameworkCore;
using GPB.Domain.Entity;

//sql bağlantısı burada yapılacak

namespace GPB.Persistence.Context // Namespace'in doğru olduğundan emin ol
{
    public class GPBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<EntryExit> EntryExit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DNMTRN080\\SQLEXPRESS;Database=GrandPalaceBosphorus;Integrated Security=True; TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Server=10.157.30.108;initial catalog=TEST;User Id=webTest; Password=!Webtst1234;Integrated Security=True; TrustServerCertificate=True;");
        }
    }
}