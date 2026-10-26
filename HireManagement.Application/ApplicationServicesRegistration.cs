using Microsoft.Extensions.DependencyInjection;

namespace HireManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));
            return services;
        }
    }
}
