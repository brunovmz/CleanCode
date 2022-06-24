
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.UnitOfWork.Interface;
using Sat.Recruitment.UnitOfWork.Interface.Contracts;
using Sat.Recruitment.UnitOfWork.SqlServer.Repositories;

namespace Sat.Recruitment.UnitOfWork.SqlServer
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("SatRecruitmentConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
