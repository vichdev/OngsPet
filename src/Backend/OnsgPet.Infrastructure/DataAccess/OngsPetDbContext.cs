using Microsoft.EntityFrameworkCore;
using OngsPet.Domain.Entities;

namespace OngsPet.Infrastructure.DataAccess
{
    public class OngsPetDbContext : DbContext
    {
        public OngsPetDbContext(DbContextOptions<OngsPetDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OngsPetDbContext).Assembly);
        }
    }
}
