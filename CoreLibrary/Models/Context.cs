using Microsoft.EntityFrameworkCore;

namespace CoreLibrary.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=CKLibraryCore;trusted_connection=true;");
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Admin> Admins{ get; set; }
    }
}
