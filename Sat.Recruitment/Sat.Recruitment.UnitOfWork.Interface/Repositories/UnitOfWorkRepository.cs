
using Sat.Recruitment.UnitOfWork.SqlServer;

namespace Sat.Recruitment.UnitOfWork.Interface.Repositories
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
    }
}
