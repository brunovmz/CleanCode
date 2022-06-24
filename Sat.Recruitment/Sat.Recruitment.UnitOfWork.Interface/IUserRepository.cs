using Sat.Recruitment.Domain;
using Sat.Recruitment.UnitOfWork.Interface.Contracts;

namespace Sat.Recruitment.UnitOfWork.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUser(int userId);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task<bool> Exist(User user);
    }
}
