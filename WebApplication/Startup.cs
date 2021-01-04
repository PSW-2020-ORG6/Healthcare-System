using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.DatabaseSql.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Backend.Controllers;
using WebApplication.Backend.Model;
using WebApplication.Backend.Services;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            IConfiguration conf = Configuration.GetSection("DataBaseConnectionSettings");
            DataBaseConnectionSettings dataBaseConnectionSettings = conf.Get<DataBaseConnectionSettings>();

            // Check if connection string is valid
            Console.WriteLine($"Connection string: {dataBaseConnectionSettings.ConnectionString}");

            services.AddDbContext<HealthCareSystemDbContext>(options =>
            {
                options.UseNpgsql(dataBaseConnectionSettings.ConnectionString,
                    x => x.MigrationsAssembly("Backend")
                        .EnableRetryOnFailure(dataBaseConnectionSettings.RetryCount,
                            new TimeSpan(0, 0, 0, dataBaseConnectionSettings.RetryWaitInSeconds),
                            new List<string>()));
            });

            // Inject repositories
            services.AddScoped<IActionAndBenefitMessageRepository, ActionAndBenefitMessageDatabaseSql>();
            services.AddScoped<IAppointmentRepository, AppointmentDatabaseSql>();
            services.AddScoped<IFeedbackRepository, FeedbackDatabaseSql>();
            services.AddScoped<IPatientRepository, PatientDatabaseSql>();
            services.AddScoped<IPhysicianRepository, PhysicianDatabaseSql>();
            services.AddScoped<IPrescriptionRepository, PrescriptionDatabaseSql>();
            services.AddScoped<IReportRepository, ReportDatabaseSql>();
            services.AddScoped<ISpecializationRepository, SpecializationDatabaseSql>();
            services.AddScoped<ISurveyRepository, SurveyDatabaseSql>();

            // Inject services
            services.AddScoped<AppointmentService, AppointmentService>();
            services.AddScoped<FeedbackService, FeedbackService>();
            services.AddScoped<PatientService, PatientService>();
            services.AddScoped<RegistrationService, RegistrationService>();
            services.AddScoped<SurveyService, SurveyService>();
            services.AddScoped<PrescriptionService, PrescriptionService>();
            services.AddScoped<ReportService, ReportService>();

            // Configure Mail Service
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            // Inject Controllers
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
                context.Database.EnsureCreated();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}