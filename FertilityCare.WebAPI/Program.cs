using Fertilitycare.Share.Models;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.Infrastructure.Repositories;
using FertilityCare.Infrastructure.Services;
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

            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

            builder.Services.AddScoped<IDoctorService, DoctorService>();

            builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();

            builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();

            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

            builder.Services.AddScoped<ISlotRepository, SlotRepository>();

            builder.Services.AddScoped<ITreatmentServiceRepository, TreatmentServiceRepository>();

            builder.Services.AddScoped<ITreatmentStepRepository, TreatmentStepRepository>();

            builder.Services.AddScoped<IPublicTreatmentService, PublicTreatmentService>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddScoped<IPatientRepository, PatientRepository>();

            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            builder.Services.AddScoped<IAppointmentReminderRepository, AppointmentReminderRepository>();

            builder.Services.AddScoped<IOrderStepRepository, OrderStepRepository>();

            builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<IOrderStepService, OrderStepService>();

            builder.Services.AddScoped<IEmailService, EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
