using Jarbas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jarbas.Domain.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("jarbinhas");
        }

        public DbSet<Emission> Emission { get; set; }
    }
}
