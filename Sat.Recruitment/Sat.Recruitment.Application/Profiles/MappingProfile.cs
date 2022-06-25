
using AutoMapper;
using Sat.Recruitment.Application.DTOs.User;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Domain;

namespace Sat.Recruitment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mappins

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Money, opt => opt.MapFrom(src => Functions.CalculateMoney(src)))
                .ReverseMap();

            CreateMap<User, UserListDto>()
                .ReverseMap();

            #endregion
        }
    }
}
