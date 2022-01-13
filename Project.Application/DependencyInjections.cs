using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Projects.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
