
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Test.Mocks;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Features.Users.Handlers.Queries;
using Sat.Recruitment.Application.Features.Users.Requests.Queries;
using Sat.Recruitment.Application.Profiles;
using Sat.Recruitment.UnitOfWork.Interface;
using Shouldly;

namespace Sat.Recruitment.Api.Test.User.Queries
{
    public class GetUserListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly ILogger<GetUserListRequestHandler> _logger;
        public GetUserListRequestHandlerTest()
        {
            _mockUserRepository = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            var mock = new Mock<ILogger<GetUserListRequestHandler>>();
            _logger = mock.Object;
        }

        [Fact]
        public async Task GetUserRequestListTest()
        {
            var handler = new GetUserListRequestHandler(_mockUserRepository.Object, _mapper, _logger);

            var result = await handler.Handle(new GetUserListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<UserListDto>>();

            result.Count.ShouldBe(1);
        }
    }
}
