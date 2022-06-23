
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Domain;

namespace Sat.Recruitment.UnitOfWork.Interface.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Juan",
                    Email = "Juan@marmol.com",
                    Phone = "+5491154762312",
                    Address = "Peru 2464",
                    UserType = "Normal",
                    Money = 1234
                },
                new User
                {
                    Id = 2,
                    Name = "Franco",
                    Email = "Franco.Perez@gmail.com",
                    Phone = "+534645213542",
                    Address = "Alvear y Colombres",
                    UserType = "Premium",
                    Money = 112234
                }
                ,
                new User
                {
                    Id = 3,
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Phone = "+534645213542",
                    Address = "Garay y Otra Calle",
                    UserType = "SuperUser",
                    Money = 112234
                });
        }
    }
}
