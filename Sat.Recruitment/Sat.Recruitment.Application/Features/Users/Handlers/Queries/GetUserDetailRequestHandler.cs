
using AutoMapper;
using MediatR;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Features.Users.Requests.Queries;
using Sat.Recruitment.UnitOfWork.SqlServer;

namespace Sat.Recruitment.Application.Features.Users.Handlers.Queries
{
    public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserDetailRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            var userRequest = _mapper.Map<UserDto>(await _userRepository.GetUser(request.Id));
            return userRequest;
        }
    }
}
