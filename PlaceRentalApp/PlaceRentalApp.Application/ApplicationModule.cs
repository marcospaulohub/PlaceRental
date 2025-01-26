using Microsoft.Extensions.DependencyInjection;
using PlaceRentalApp.Application.Services;
using PlaceRentalApp.Application.Services.Interfaces;

namespace PlaceRentalApp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
