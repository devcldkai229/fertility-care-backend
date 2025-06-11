using FertilityCare.Infrastructure.Identity;
using FertilityCare.Infrastructure.Repositories;
using FertilityCare.UseCase.Implements;
using FertilityCare.UseCase.Interfaces.Repositories;
using FertilityCare.UseCase.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace FertilityCare.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<FertilityCareDBContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                           .UseLazyLoadingProxies());

            builder.Services.AddScoped<ITreatmentServiceRepository, TreatmentServiceRepository>();

            builder.Services.AddScoped<ITreatmentStepRepository, TreatmentStepRepository>();

            builder.Services.AddScoped<IPublicTreatmentService, PublicTreatmentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
