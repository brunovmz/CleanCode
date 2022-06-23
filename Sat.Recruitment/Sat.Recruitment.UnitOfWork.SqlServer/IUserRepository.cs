using Sat.Recruitment.Domain;
using Sat.Recruitment.UnitOfWork.SqlServer.Contracts;

namespace Sat.Recruitment.UnitOfWork.SqlServer
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUser(int userId);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
    }
}
