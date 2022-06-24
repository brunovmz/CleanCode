
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Features.Users.Requests.Queries;
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.Application.Features.Users.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserListDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserListRequestHandler> _logger;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserListRequestHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<UserListDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get list user requested");
            var users = await _userRepository.GetAllUsers();
            var requests = _mapper.Map<List<UserListDto>>(users);

            return requests;
        }
    }
}
