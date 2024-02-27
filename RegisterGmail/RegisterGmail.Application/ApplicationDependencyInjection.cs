using Microsoft.Extensions.DependencyInjection;
using RegisterGmail.Application.Services.Login;
using RegisterGmail.Application.Services.Register;

namespace RegisterGmail.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();

            return services;
        }
    }
}
