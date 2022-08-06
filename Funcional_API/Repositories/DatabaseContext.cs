using Funcional_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Funcional_API.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.Property(e => e.data_criacao).HasDefaultValueSql("(now())");

            });

        }
    }
}
