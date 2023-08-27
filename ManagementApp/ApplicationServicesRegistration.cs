using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Management.Application
{
    static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); //https://stackoverflow.com/questions/75635995/adding-mediatr-service

            return services;
        }
    }
}
