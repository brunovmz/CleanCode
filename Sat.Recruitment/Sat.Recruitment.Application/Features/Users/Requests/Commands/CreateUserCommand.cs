
using MediatR;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Responses;

namespace Sat.Recruitment.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
