
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Test.Mocks;
using Sat.Recruitment.Application.Configurations;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Features.Users.Handlers.Commands;
using Sat.Recruitment.Application.Features.Users.Requests.Commands;
using Sat.Recruitment.Application.Profiles;
using Sat.Recruitment.Application.Responses;
using Sat.Recruitment.UnitOfWork.Interface;
using Shouldly;

namespace Sat.Recruitment.Api.Test.User.Command
{
    public class CreateUserCommandHandlerTest
    {
        private readonly Mock<IUnitOfWorkRepository> _mockUow;
        private readonly CreateUserCommandHandler _handler;
        public CreateUserCommandHandlerTest()
        {
            _mockUow = MockUnitOfWorkRepository.GetUnitOfWorkRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            var mapper = mapperConfig.CreateMapper();

            var mock = new Mock<ILogger<CreateUserCommandHandler>>();
            var logger = mock.Object;

            _handler = new CreateUserCommandHandler(_mockUow.Object, mapper, logger);
        }

        [Fact]
        public async Task CreateUserSuccessfully()
        {
            //Arrange
            var newUserDto = new CreateUserDto
            {
                Id = 2,
                Name = "Test",
                Email = "test@gmail.com",
                Address = "Av. Juan Test",
                Phone = "+349 35244215",
                UserType = "Normal",
                Money = "1245"
            };

            // Act
            var result = await _handler.Handle(new CreateUserCommand {CreateUserDto = newUserDto}, CancellationToken.None);

            var users = await _mockUow.Object.UserRepository.GetAllUsers();

            //Assert
            result.ShouldBeOfType<BaseCommandResponse>();

            users.Count.ShouldBe(2);

        }

        [Fact]
        public async Task CreateUserFailedUserDuplicate()
        {
            //Arrange
            var newUserDto = new CreateUserDto
            {
                Id = 1,
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            // Act
            var result = await _handler.Handle(new CreateUserCommand { CreateUserDto = newUserDto }, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            if (result.Errors != null) Assert.Contains(Constants.UserDuplicated, result.Errors);
        }

        [Fact]
        public async Task CreateUserFailedMissingProperty()
        {
            //Arrange
            var newUserDto = new CreateUserDto
            {
                Id = 1,
                Name = "",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            // Act
            var result = await _handler.Handle(new CreateUserCommand { CreateUserDto = newUserDto }, CancellationToken.None);

            //Assert
            Assert.False(result.Success);

            if (result.Errors != null) Assert.Contains("'Name' must not be empty.", result.Errors);
        }

    }
}
