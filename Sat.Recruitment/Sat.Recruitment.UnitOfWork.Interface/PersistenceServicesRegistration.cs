
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.UnitOfWork.Interface.Repositories;
using Sat.Recruitment.UnitOfWork.SqlServer;
using Sat.Recruitment.UnitOfWork.SqlServer.Contracts;

namespace Sat.Recruitment.UnitOfWork.Interface
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
