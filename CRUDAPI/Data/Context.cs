using CRUDAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
