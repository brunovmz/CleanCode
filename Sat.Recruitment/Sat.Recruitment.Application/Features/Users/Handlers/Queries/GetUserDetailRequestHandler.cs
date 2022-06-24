
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Features.Users.Requests.Queries;
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.Application.Features.Users.Handlers.Queries
{
    public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public GetUserDetailRequestHandler(IMapper mapper, IUserRepository userRepository, ILogger logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get User Detail Requested");
            var userRequest = _mapper.Map<UserDto>(await _userRepository.GetUser(request.Id));
            return userRequest;
        }
    }
}
