using JWTDemo3.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo3.Data
{
    public class ApplicationDbContext :DbContext
    {
        //Veritabanına hazırladığım modeli tablo olarak eklemesini söylüyorum.
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Veritabanı olarak SQLite kullanacağımı söylüyorum.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=jwtSample.db");

        //Veritabanı oluşturulurken dummy data ile oluşturulmasını istiyorum.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 1,
                FirstName = "test",
                Username = "testUser",
                Password = "testPassword"
            });
        }
    }
}
