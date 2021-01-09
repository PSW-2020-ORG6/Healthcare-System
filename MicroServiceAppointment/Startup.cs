//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HealthClinicBackend.Backend.Repository;
//using HealthClinicBackend.Backend.Repository.DatabaseSql;
//using HealthClinicBackend.Backend.Repository.Generic;
//using MicroServiceAccount.Backend.Controllers;
//using MicroServiceAppointment.Backend.Controllers;
//using MicroServiceAppointment.Backend.Service;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens;

//namespace MicroServiceAppointment
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
//        {
//            Configuration = configuration;
//            Env = environment;
//        }

//        public IConfiguration Configuration { get; }
//        public IWebHostEnvironment Env { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddCors(options => {
//                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
//            });
//            services.AddControllers();
//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//               .AddJwtBearer(options =>
//               {
//                   options.TokenValidationParameters = new TokenValidationParameters
//                   {
//                       ValidateIssuer = true,
//                       ValidateAudience = true,
//                       ValidateLifetime = true,
//                       ValidateIssuerSigningKey = true,
//                       ValidIssuer = Configuration["Jwt:Issuer"],
//                       ValidAudience = Configuration["Jwt:Issuer"],
//                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
//                   };
//               });
//            services.AddDbContext<HealthCareSystemDbContext>(options =>
//            {
//                var connectionString = CreateConnectionStringFromEnvironment();
//                Console.WriteLine(connectionString);

//                options.UseNpgsql(
//                    connectionString,
//                    x => x.MigrationsAssembly("WebApplication").EnableRetryOnFailure(5,
//                        new TimeSpan(0, 0, 0, 30), new List<string>())
//                );
//            });
//            services.AddMvc();


//            // Inject repositories
//            services.AddScoped<IActionAndBenefitMessageRepository, ActionAndBenefitMessageDatabaseSql>();
//            services.AddScoped<IAppointmentRepository, AppointmentDatabaseSql>();        
//            services.AddScoped<IPrescriptionRepository, PrescriptionDatabaseSql>();
//            services.AddScoped<IReportRepository, ReportDatabaseSql>();
//            services.AddScoped<ISpecializationRepository, SpecializationDatabaseSql>();
//            services.AddScoped<ISurveyRepository, SurveyDatabaseSql>();
//            services.AddScoped<IAdminRepository, AdminDatabaseSql>();
//            services.AddScoped<IAddressRepository, AddressDatabaseSql>();



//            // Inject services
//            services.AddScoped<AppointmentService, AppointmentService>();
//            services.AddScoped<SurveyService, SurveyService>();
//            //services.AddScoped<PrescriptionService, PrescriptionService>();
//            //services.AddScoped<ReportService, ReportService>();


//            // Inject Controllers
//            services.AddScoped<AppointmentController, AppointmentController>();
//            services.AddScoped<SurveyController, SurveyController>();
//            services.AddScoped<LoginController, LoginController>();




//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            using (var scope = app.ApplicationServices.CreateScope())
//            using (var context = scope.ServiceProvider.GetService<HealthCareSystemDbContext>())
//            {
//                context.Database.EnsureCreated();
//            }

//            app.UseRouting();
//            app.UseAuthentication();
//            app.UseAuthorization();
//            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
//            app.UseDefaultFiles();
//            app.UseStaticFiles();
//        }

//        private string CreateConnectionStringFromEnvironment()
//        {
//            // Change these values for local connection
//            var serverDefault = "localhost";
//            var portDefault = 5432;

//            var userDefault = "postgres";
//            var passwordDefault = "root";
//            var schema = "healthcare-system-db";

//            // Do not change this
//            var herokuPostgresURL = Configuration.GetValue<string>("DATABASE_URL") ?? $"{serverDefault}://{userDefault}:{passwordDefault}@{serverDefault}:{portDefault}/{schema}";

//            var databaseUri = new Uri(herokuPostgresURL);
//            var userInfo = databaseUri.UserInfo.Split(':');
//            var server = databaseUri.Host;
//            var port = databaseUri.Port.ToString();
//            var user = userInfo[0];
//            var password = userInfo[1];
//            var database = databaseUri.LocalPath.TrimStart('/');

//            return $"userid={user};server={server};port={port};database={database};password={password};Pooling=true;sslmode=Prefer;TrustServerCertificate=True;";
//        }
//    }
//}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroServiceAppointment
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
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}

