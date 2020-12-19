using HealthClinicBackend.Backend.Repository;
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
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication.Backend.Controllers;
using WebApplication.Backend.Model;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Services;
using IAppointmentRepository = HealthClinicBackend.Backend.Repository.Generic.IAppointmentRepository;
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

            IConfiguration conf = Configuration.GetSection("DataBaseConnectionSettings");
            DataBaseConnectionSettings dataBaseConnectionSettings = conf.Get<DataBaseConnectionSettings>();

            Console.WriteLine($"Connection string: {dataBaseConnectionSettings.ConnectionString}");

            services.AddDbContext<HealthCareSystemDbContext>(options =>
            {
                // options.UseNpgsql(
                //     dataBaseConnectionSettings.ConnectionString);
                options.UseNpgsql(
                    dataBaseConnectionSettings.ConnectionString,
                    x => x.MigrationsAssembly("Backend").EnableRetryOnFailure(dataBaseConnectionSettings.RetryCount,
                        new TimeSpan(0, 0, 0, dataBaseConnectionSettings.RetryWaitInSeconds), new List<string>())
                );
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddScoped<IPhysicianRepository, PhysicianDatabaseSql>();
            services.AddScoped<IPatientRepository, PatientDatabaseSql>();
            services.AddScoped<IAppointmentRepository, AppointmentDatabaseSql>();
            services.AddScoped<IFeedbackRepository, FeedbackDatabaseSql>();
            services.AddScoped<IPatientRepository, PatientDatabaseSql>();
            services.AddScoped<IPrescriptionRepository, PrescriptionDatabaseSql>();
            services.AddScoped<IReportRepository, ReportDatabaseSql>();
            services.AddScoped<ISurveyRepository, SurveyDatabaseSql>();

            services.AddScoped<IRegistrationRepository, RegistrationRepository>();

            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<AppointmentsService, AppointmentsService>();
            services.AddScoped<FeedbackService, FeedbackService>();
            services.AddScoped<PatientService, PatientService>();
            services.AddScoped<PrescriptionService, PrescriptionService>();
            services.AddScoped<RegistrationService, RegistrationService>();
            services.AddScoped<ReportService, ReportService>();
            services.AddScoped<SurveyService, SurveyService>();

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
                Console.WriteLine("Patients");
                foreach (var patient in context.Patient)
                {
                    Console.WriteLine($"{patient.Name} {patient.Id}");
                }

                // try
                // {
                //     Console.WriteLine("Data seeding started.");
                //     DataSeeder seeder = new DataSeeder(true);
                //     seeder.SeedAll(context);
                //     Console.WriteLine("Data seeding finished.");
                // } catch(Exception e)
                // {
                //     Console.WriteLine("Data seeding failed.");
                //     Console.WriteLine(e.Message);
                //     Console.WriteLine(e.StackTrace);
                // }
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}