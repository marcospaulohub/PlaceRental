
using Microsoft.EntityFrameworkCore;
using PlaceRentalApp.API.Middlewares;
using PlaceRentalApp.Infrastructure.Persistence;

namespace PlaceRentalApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona ApiExceptionHandler
            builder.Services.AddExceptionHandler<ApiExceptionHandler>();
            builder.Services.AddProblemDetails();

            // Add services to the container.

            //builder.Services.AddSingleton<PlaceRentalDbContext>();
            var connectionString = builder.Configuration
                .GetConnectionString("PlaceRentalCs");

            // DataBase In Memory
            //builder.Services.AddDbContext<PlaceRentalDbContext>(
            //    o => o.UseInMemoryDatabase("PlaceRentaDb"));

            builder.Services.AddDbContext<PlaceRentalDbContext>(
                o => o.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Adiciona ApiExceptionHandler
            app.UseExceptionHandler();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
