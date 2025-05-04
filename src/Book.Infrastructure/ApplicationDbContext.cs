using Book.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext , IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) 
            : base(dbContext) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
