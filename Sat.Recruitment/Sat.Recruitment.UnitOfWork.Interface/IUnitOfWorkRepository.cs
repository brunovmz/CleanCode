
namespace Sat.Recruitment.UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
