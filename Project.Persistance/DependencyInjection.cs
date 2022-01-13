using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projects.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration["DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IToDoListDbContext>(provider => provider.GetService<ApplicationDbContext>());
            return services;
        }
    }
}
