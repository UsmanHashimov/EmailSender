using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterGmail.Application.IRepositories;
using RegisterGmail.Infrastructure.Persistence;
using RegisterGmail.Infrastructure.Repositories;

namespace RegisterGmail.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            return services;
        }
    }
}
