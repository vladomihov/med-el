using System;
using System.Collections.Generic;
using MedEl.Domain.Configuration;
using MedEl.Domain.Services;
using MedEl.Infrastructure.Database;
using MedEl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MedEl.Infrastructure.DependencyInjection
{
    public static class MedElServicesExtensions
    {
        public static IServiceCollection AddMedElServices(this IServiceCollection services, IConfiguration configuration, Action<MedElServicesOptions> setupAction)
        {
            services.AddPersistenceContext<MedElContext>(configuration);
            services.AddScoped<ITireSetRepository, TireSetRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddOptions<TireConfiguration>().Bind(configuration.GetSection("Tires"));

            var options = new MedElServicesOptions();
            setupAction(options);

            AddVehicleFactoryResolver<ICarFactory>(services, options.CarFactories);
            AddVehicleFactoryResolver<IMotorcycleFactory>(services, options.MotorcycleFactories);

            return services;
        }

        private static void AddVehicleFactoryResolver<TFactory>(IServiceCollection services, IDictionary<string, Type> factories)
        {
            foreach (var factoryType in factories.Values)
            {
                services.AddScoped(factoryType, factoryType);
            }

            services.AddSingleton(new NamedFactoryResolverConfiguration<TFactory>(factories));
            services.AddScoped<INamedFactoryResolver<TFactory>, NamedFactoryResolver<TFactory>>();
        }

        private static void AddPersistenceContext<TDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
        {
            var connectionStringName = typeof(TDbContext).Name;
            var connectionString = configuration.GetConnectionString(connectionStringName);

            var migrationsAssembly = typeof(TDbContext).Assembly.GetName().Name;

            services.AddDbContext<TDbContext>(builder =>
                //builder.UseInMemoryDatabase(connectionString), ServiceLifetime.Transient);
                builder.UseNpgsql(connectionString, options => options.MigrationsAssembly(migrationsAssembly)), ServiceLifetime.Scoped);
        }

        public static IHost MigrateDatabase(this IHost app)
        {
            return app.MigrateDatabase<MedElContext>();
        }

        private static IHost MigrateDatabase<TDbContext>(this IHost app)
            where TDbContext : DbContext
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<TDbContext>();

                dbContext.Database.Migrate();
            }

            return app;
        }
    }
}