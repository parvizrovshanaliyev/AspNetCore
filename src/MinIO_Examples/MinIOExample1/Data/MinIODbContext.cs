using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinIOExample1.Models;

namespace MinIOExample1.Data
{
    public class MinIODbContext : DbContext
    {
        public MinIODbContext(DbContextOptions<MinIODbContext> options) : base(options)
        {
        }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().ToTable("FileMinIOExample1");
        }

        #endregion

        #region DbSet

        public DbSet<File> Files { get; private set; }

        #endregion
    }
}
