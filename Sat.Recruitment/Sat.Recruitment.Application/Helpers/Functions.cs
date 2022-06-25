
using Sat.Recruitment.Application.Configurations;
using Sat.Recruitment.Application.DTOs.User;

namespace Sat.Recruitment.Application.Helpers
{
    internal static class Functions
    {
        public static decimal CalculateMoney(CreateUserDto userDto)
        {
            var money = Convert.ToDecimal(userDto.Money);
            var result = money;
            switch (userDto.UserType)
            {
                case Constants.Normal when money > 100:
                {
                    var gif = money * Constants.GifNormal12;
                    money += gif;
                    result = money;
                    break;
                }
                case Constants.Normal:
                {
                    if (money > 10)
                    {
                        var gif = money * Constants.GifNormal8;
                        money += gif;
                        result = money;
                    }

                    break;
                }
                case Constants.SuperUser:
                {
                    if (money > 100)
                    {
                        var gif = money * Constants.GifSuperUser20;
                        money += gif;
                        result = money;
                    }

                    break;
                }
                case Constants.Premium:
                {
                    if (money > 100)
                    {
                        var gif = money * 2;
                        money += gif;
                        result = money;
                    }

                    break;
                }
            }
            return result;
        }
    }
}
