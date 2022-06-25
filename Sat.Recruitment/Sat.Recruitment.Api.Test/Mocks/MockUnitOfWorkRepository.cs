
using Moq;
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.Api.Test.Mocks
{
    public static class MockUnitOfWorkRepository
    {
        public static Mock<IUnitOfWorkRepository> GetUnitOfWorkRepository()
        {
            var mockUow = new Mock<IUnitOfWorkRepository>();
            var mockUserRepo = MockUserRepository.GetUserRepository();

            mockUow.Setup(r => r.UserRepository).Returns(mockUserRepo.Object);
            return mockUow;
        }
    }
}
