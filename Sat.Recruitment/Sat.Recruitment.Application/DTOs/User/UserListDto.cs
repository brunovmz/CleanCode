
using Sat.Recruitment.Application.DTOs.Common;

namespace Sat.Recruitment.Application.DTOs.User
{
    public class UserListDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public decimal Money { get; set; }
    }
}
