using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceRentalApp.Core.IRepositories;
using PlaceRentalApp.Infrastructure.Persistence;
using PlaceRentalApp.Infrastructure.Persistence.Repositories;

namespace PlaceRentalApp.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddData(configuration)
                .AddRepository();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            // DataBase In Memory
            //builder.Services.AddDbContext<PlaceRentalDbContext>(
            //    o => o.UseInMemoryDatabase("PlaceRentaDb"));

            var connectionString = configuration.GetConnectionString("PlaceRentalCs");

            services.AddDbContext<PlaceRentalDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPlaceRepository, PlaceRepository>();

            return services;
        }
    }
}
