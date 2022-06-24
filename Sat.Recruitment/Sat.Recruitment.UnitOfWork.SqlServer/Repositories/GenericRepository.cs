
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.UnitOfWork.Interface.Contracts;

namespace Sat.Recruitment.UnitOfWork.SqlServer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RepositoryDbContext _dbContext;

        public GenericRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(T entity)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }
    }
}
