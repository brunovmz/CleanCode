
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.UnitOfWork.SqlServer.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly RepositoryDbContext _context;
        private IUserRepository _userRepository;

        public UnitOfWorkRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
