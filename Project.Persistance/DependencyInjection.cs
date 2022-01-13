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
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connection, b => b.MigrationsAssembly("ToDoList.Api"));
            });
            services.AddScoped<IToDoListDbContext>(provider => provider.GetService<ApplicationDbContext>());
            return services;
        }
    }
}
