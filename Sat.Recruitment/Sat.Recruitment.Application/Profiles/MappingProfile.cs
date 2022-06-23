
using AutoMapper;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Domain;

namespace Sat.Recruitment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mappins

            CreateMap<User, CreateUserDto>().ReverseMap();

            #endregion
        }
    }
}
