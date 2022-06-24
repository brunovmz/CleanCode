
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain;
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.UnitOfWork.SqlServer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private  readonly RepositoryDbContext _dbContext;
        public UserRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(q => q.Id == userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _dbContext.AddAsync(user);
        }

        public async Task<bool> Exist(User user)
        {
            return await _dbContext.Users.AnyAsync(q => (q.Email == user.Email || q.Phone == user.Phone) || 
                                                        (q.Name == user.Name && q.Address == user.Address));
        }
    }
}
