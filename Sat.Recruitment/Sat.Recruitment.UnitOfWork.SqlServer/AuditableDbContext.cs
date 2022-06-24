
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Common;

namespace Sat.Recruitment.UnitOfWork.SqlServer
{
    public abstract class AuditableDbContext : DbContext
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual async Task<int> SaveChangesAsync()
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainUserEntity>()
                         .Where(q => q.State is EntityState.Added or EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
            }

            var result = await base.SaveChangesAsync();
            return result;
        }
    }
}
