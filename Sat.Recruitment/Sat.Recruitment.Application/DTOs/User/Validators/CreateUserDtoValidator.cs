
using AutoMapper;
using FluentValidation;
using Sat.Recruitment.Application.Configurations;

namespace Sat.Recruitment.Application.DTOs.User.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(Constants.PropertyNameRequired);

            RuleFor(p => p.Adrress)
                .NotEmpty()
                .NotNull()
                .WithMessage(Constants.PropertyNameRequired);

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(Constants.PropertyNameRequired);

            RuleFor(p => p.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage(Constants.PropertyNameRequired);
        }
    }
}
