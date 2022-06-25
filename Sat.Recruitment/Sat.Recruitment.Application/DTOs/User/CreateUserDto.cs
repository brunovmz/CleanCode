
using Sat.Recruitment.Application.DTOs.Common;

namespace Sat.Recruitment.Application.DTOs.User
{
    public class CreateUserDto : BaseDto, IUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string Money { get; set; } = string.Empty;
    }
}
