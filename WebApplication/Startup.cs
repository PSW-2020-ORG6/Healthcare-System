using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication.Backend.Controllers;
using WebApplication.Backend.Model;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using IPatientRepository = HealthClinicBackend.Backend.Repository.Generic.IPatientRepository;
using IPrescriptionRepository = HealthClinicBackend.Backend.Repository.Generic.IPrescriptionRepository;
using IReportRepository = HealthClinicBackend.Backend.Repository.Generic.IReportRepository;
using ISurveyRepository = HealthClinicBackend.Backend.Repository.Generic.ISurveyRepository;

namespace WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<HealthCareSystemDbContext>(options =>
            {
                options.UseNpgsql(
                    CreateConnectionStringFromEnvironment(),
                    x => x.MigrationsAssembly("Backend").EnableRetryOnFailure(5,
                        new TimeSpan(0, 0, 0, 30), new List<string>())
                );
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            // Repository dependency injection
            services.AddScoped<IPhysicianRepository, PhysicianDatabaseSql>();
            services.AddScoped<IPatientRepository, PatientDatabaseSql>();
            services.AddScoped<IAppointmentRepository, AppointmentDatabaseSql>();
            services.AddScoped<IFeedbackRepository, FeedbackDatabaseSql>();
            services.AddScoped<IPatientRepository, PatientDatabaseSql>();
            services.AddScoped<IPrescriptionRepository, PrescriptionDatabaseSql>();
            services.AddScoped<IReportRepository, ReportDatabaseSql>();
            services.AddScoped<ISurveyRepository, SurveyDatabaseSql>();

            // Repository-service hybrids dependency injection
            // TODO: refactor to a normal service
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();

            // Service dependency injection
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<AppointmentsService, AppointmentsService>();
            services.AddScoped<FeedbackService, FeedbackService>();
            services.AddScoped<PatientService, PatientService>();
            services.AddScoped<PrescriptionService, PrescriptionService>();
            services.AddScoped<RegistrationService, RegistrationService>();
            services.AddScoped<ReportService, ReportService>();
            services.AddScoped<SurveyService, SurveyService>();

            // Controller dependency injection
            services.AddScoped<RegistrationController, RegistrationController>();
            services.AddScoped<AppointmentController, AppointmentController>();
            services.AddScoped<FeedbackController, FeedbackController>();
            services.AddScoped<SurveyController, SurveyController>();
            services.AddScoped<UserController, UserController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<HealthCareSystemDbContext>())
            {
                Console.WriteLine("Connecting to db");
                foreach (var medicineManufacturer in context.MedicineManufacturer)
                {
                    Console.WriteLine(medicineManufacturer.Name);
                }

                Console.WriteLine("Loading physicians");
                foreach (var physician in context.Physician)
                {
                    Console.WriteLine($"{physician.Name} {physician.Surname}");
                }
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "healthcare-system-db";

            // Change this if user and password are different
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "super";
            string str =
                "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

            return $"userid={user};server={server};port={port};database={database};password={password};";
        }
    }
}