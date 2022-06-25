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

        /// <summary>
        /// This endpoint creates a new User by validating specific criteria
        /// </summary>
        /// <param name="userDto">Request contains all data necesary to create a new User</param>
        /// <returns>If the operation is successfull return the new Id created else return a list of errors </returns>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> CreateUser([FromBody] CreateUserDto userDto)
        {
            _logger.LogInformation("Method invoked {request}", Constants.UserPost);
            var command = new CreateUserCommand {CreateUserDto = userDto};
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// This endpoint return a list of Users without filters
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        public async Task<ActionResult<List<UserListDto>>> GetAllUsers()
        {
            _logger.LogInformation("Method invoked {request}", Constants.UserGet);
            var userList = await _mediator.Send(new GetUserListRequest());
            return Ok(userList);
        }
    }
}
