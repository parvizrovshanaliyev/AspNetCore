using System;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Context
{
    public class ProductAppDbContext: DbContext
    {
        public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options):base(options)
        {
            
        }
        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "pen",Quantity=1, Price=10 },
                new Product { Id = Guid.NewGuid(), Name = "paper a4",Quantity=1, Price=11 },
                new Product { Id = Guid.NewGuid(), Name = "book",Quantity=1, Price=12 }
                );
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        public DbSet<Product> Products { get; set; }
    }
}
