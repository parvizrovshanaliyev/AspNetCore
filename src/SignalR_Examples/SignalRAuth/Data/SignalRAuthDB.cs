using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRAuth.Models;

namespace SignalRAuth.Data
{
    public class SignalRAuthDB : DbContext
    {
        public SignalRAuthDB(DbContextOptions<SignalRAuthDB> options) : base(options)
        {
        }

        #region Overrides of DbContext

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AspNetCoreExamplesDb;Trusted_Connection=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }

        #endregion

        #region DbSet

        public DbSet<User> Users { get; private set; }

        #endregion
    }
}
