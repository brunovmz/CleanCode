
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Configurations;
using Sat.Recruitment.Application.DTOs.User.Validators;
using Sat.Recruitment.Application.Features.Users.Requests.Commands;
using Sat.Recruitment.Application.Responses;
using Sat.Recruitment.Domain;
using Sat.Recruitment.UnitOfWork.Interface;

namespace Sat.Recruitment.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create Request Permission", request.CreateUserDto);

            var response = new BaseCommandResponse();
            var validator = new CreateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateUserDto, cancellationToken);

            var newUser = _mapper.Map<User>(request.CreateUserDto);

            if (await _unitOfWorkRepository.UserRepository.Exist(newUser))
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.CreateUserDto), Constants.UserDuplicated));
            }

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = Constants.RequestFailed;
                response.Errors = validationResult.Errors.Select(q =>q.ErrorMessage).ToList();
                _logger.LogInformation(Constants.RequestFailed, request.CreateUserDto);
            }
            else
            {
                newUser = await _unitOfWorkRepository.UserRepository.AddAsync(newUser);
                await _unitOfWorkRepository.SaveAsync();

                response.Success = true;
                response.Message = Constants.RequestCreatedSuccess;
                response.Id = newUser.Id;

                _logger.LogInformation(Constants.RequestCreatedSuccess, request.CreateUserDto);
            }

            return response;
        }
    }
}
