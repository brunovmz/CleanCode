
using Moq;
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.Api.Test.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<Domain.User>
            {
                new()
                {
                    Id = 1,
                    Name = "Mike",
                    Email = "mike@gmail.com",
                    Address = "Av. Juan G",
                    Phone = "+349 1122354215",
                    UserType = "Normal",
                    Money = 124
                }
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAllUsers()).ReturnsAsync(users);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Domain.User>())).ReturnsAsync((Domain.User user) =>
            {
                users.Add(user);
                return user;
            });

            mockRepo.Setup(r => r.Exist(It.IsAny<Domain.User>())).ReturnsAsync((Domain.User user) =>
            {
                return users.Any(q => (q.Email == user.Email || q.Phone == user.Phone) ||
                               (q.Name == user.Name && q.Address == user.Address));
            });

            return mockRepo;
        }
    }
}
