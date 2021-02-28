using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.HttpStrategies.Factories;

namespace SmartMedication.Installers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration config)
        {
            //services.AddDbContext<SmartMedicationDbContext>(options =>
            //    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddDbContextFactory<SmartMedicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>());
            services.AddSingleton<IFactory<TService>, Factory<TService>>();
        }
    }
}
