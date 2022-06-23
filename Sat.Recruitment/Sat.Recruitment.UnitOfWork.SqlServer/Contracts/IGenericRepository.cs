
namespace Sat.Recruitment.UnitOfWork.SqlServer.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(T entity);
        Task<T> AddAsync(T entity);
    }
}
