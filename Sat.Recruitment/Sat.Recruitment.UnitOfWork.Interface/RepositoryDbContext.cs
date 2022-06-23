
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain;

namespace Sat.Recruitment.UnitOfWork.Interface
{
    public class RepositoryDbContext : AuditableDbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
    }
}
