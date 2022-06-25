using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Configurations;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Features.Users.Requests.Commands;
using Sat.Recruitment.Application.Features.Users.Requests.Queries;
using Sat.Recruitment.Application.Responses;

namespace Sat.Recruitment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<ActionResult<BaseCommandResponse>> CreateUser([FromBody] CreateUserDto userDto)
        {
            _logger.LogInformation("Method invoked {request}", Constants.UserPost);
            var command = new CreateUserCommand {CreateUserDto = userDto};
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Route("/get-all-user")]
        public async Task<ActionResult<List<UserListDto>>> GetAllUsers()
        {
            _logger.LogInformation("Method invoked {request}", Constants.UserGet);
            var userList = await _mediator.Send(new GetUserListRequest());
            return Ok(userList);
        }
    }
}
