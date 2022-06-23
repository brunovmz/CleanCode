
using MediatR;
using Sat.Recruitment.Application.DTOs.User;

namespace Sat.Recruitment.Application.Features.Users.Requests.Queries
{
    public class GetUserListRequest : IRequest<List<UserListDto>>
    {
    }
}
