
namespace Sat.Recruitment.UnitOfWork.SqlServer
{
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
    }
}
