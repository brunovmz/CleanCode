
namespace Sat.Recruitment.Application.DTOs.User
{
    public interface IUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adrress { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

    }
}
