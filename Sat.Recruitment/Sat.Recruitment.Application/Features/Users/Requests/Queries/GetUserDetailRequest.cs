
using MediatR;
using Sat.Recruitment.Application.DTOs.User;

namespace Sat.Recruitment.Application.Features.Users.Requests.Queries
{
    public class GetUserDetailRequest : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
