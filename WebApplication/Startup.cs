using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using HealthClinicBackend.Backend.Repository;
//using HealthClinicBackend.Backend.Repository.DatabaseSql;
//using HealthClinicBackend.Backend.Repository.Generic;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using WebApplication.Backend.Controllers;
//using WebApplication.Backend.Model;
//using WebApplication.Backend.Repositorys.Interfaces;
//using WebApplication.Backend.Services;

namespace WebApplication
{
    //public class Startup
    //{
    //    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    //    {
    //        Configuration = configuration;
    //        Env = environment;
    //    }

    //    public IConfiguration Configuration { get; }
    //    public IWebHostEnvironment Env { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddCors(options => {
    //            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
    //        });
    //        services.AddControllers();
    //        services.AddOcelot(Configuration);
    //        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //           .AddJwtBearer(options =>
    //           {
    //               options.TokenValidationParameters = new TokenValidationParameters
    //               {
    //                   ValidateIssuer = true,
    //                   ValidateAudience = true,
    //                   ValidateLifetime = true,
    //                   ValidateIssuerSigningKey = true,
    //                   ValidIssuer = Configuration["Jwt:Issuer"],
    //                   ValidAudience = Configuration["Jwt:Issuer"],
    //                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
    //               };
    //           });
    //        services.AddDbContext<HealthCareSystemDbContext>(options =>
    //        {
    //            var connectionString = CreateConnectionStringFromEnvironment();
    //            Console.WriteLine(connectionString);

    //            options.UseNpgsql(
    //                connectionString,
    //                x => x.MigrationsAssembly("WebApplication").EnableRetryOnFailure(5,
    //                    new TimeSpan(0, 0, 0, 30), new List<string>())
    //            );
    //        });
    //        services.AddMvc();


    //        // Inject repositories
    //        services.AddScoped<IActionAndBenefitMessageRepository, ActionAndBenefitMessageDatabaseSql>();
    //        services.AddScoped<IAppointmentRepository, AppointmentDatabaseSql>();
    //        services.AddScoped<IFeedbackRepository, FeedbackDatabaseSql>();
    //        services.AddScoped<IPatientRepository, PatientDatabaseSql>();
    //        services.AddScoped<IPhysicianRepository, PhysicianDatabaseSql>();
    //        services.AddScoped<IPrescriptionRepository, PrescriptionDatabaseSql>();
    //        services.AddScoped<IReportRepository, ReportDatabaseSql>();
    //        services.AddScoped<ISpecializationRepository, SpecializationDatabaseSql>();
    //        services.AddScoped<ISurveyRepository, SurveyDatabaseSql>();
    //        services.AddScoped<IAdminRepository, AdminDatabaseSql>();
    //        services.AddScoped<IAddressRepository, AddressDatabaseSql>();



    //        // Inject services
    //        services.AddScoped<AppointmentService, AppointmentService>();
    //        services.AddScoped<FeedbackService, FeedbackService>();
    //        services.AddScoped<PatientService, PatientService>();
    //        services.AddScoped<RegistrationService, RegistrationService>();
    //        services.AddScoped<SurveyService, SurveyService>();
    //        services.AddScoped<PrescriptionService, PrescriptionService>();
    //        services.AddScoped<ReportService, ReportService>();
    //        services.AddScoped<UserService, UserService>();

    //        // Configure Mail Service
    //        services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
    //        services.AddTransient<IMailService, MailService>();

    //        // Inject Controllers
    //        services.AddScoped<RegistrationController, RegistrationController>();
    //        services.AddScoped<AppointmentController, AppointmentController>();
    //        services.AddScoped<FeedbackController, FeedbackController>();
    //        services.AddScoped<SurveyController, SurveyController>();
    //        services.AddScoped<UserController, UserController>();
    //        //services.AddScoped<LoginController, LoginController>();




    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        using (var scope = app.ApplicationServices.CreateScope())
    //        using (var context = scope.ServiceProvider.GetService<HealthCareSystemDbContext>())
    //        {
    //            context.Database.EnsureCreated();
    //        }

    //        app.UseRouting();
    //        app.UseAuthentication();
    //        app.UseAuthorization();
    //        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    //        app.UseDefaultFiles();
    //        app.UseStaticFiles();
    //        app.UseOcelot();
    //    }

    //    private string CreateConnectionStringFromEnvironment()
    //    {
    //        // Change these values for local connection
    //        var serverDefault = "localhost";
    //        var portDefault = 5432;

    //        var userDefault = "postgres";
    //        var passwordDefault = "super";
    //        var schema = "healthcare-system-db";

    //        // Do not change this
    //        var herokuPostgresURL = Configuration.GetValue<string>("DATABASE_URL") ?? $"{serverDefault}://{userDefault}:{passwordDefault}@{serverDefault}:{portDefault}/{schema}";

    //        var databaseUri = new Uri(herokuPostgresURL);
    //        var userInfo = databaseUri.UserInfo.Split(':');
    //        var server = databaseUri.Host;
    //        var port = databaseUri.Port.ToString();
    //        var user = userInfo[0];
    //        var password = userInfo[1];
    //        var database = databaseUri.LocalPath.TrimStart('/');

    //        return $"userid={user};server={server};port={port};database={database};password={password};Pooling=true;sslmode=Prefer;TrustServerCertificate=True;";
    //    }

    //}

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
            //var authenticationProviderKey = "TestKey";
            services.AddControllers();
            //services.AddOcelot(Configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(/*authenticationProviderKey,*/options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());
            //});

            //services.AddMvc();
            //services.AddOcelot(Configuration);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //await app.UseOcelot();
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.IdentityModel.Tokens;
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;

//namespace WebApplication
//{
//    public class Startup
//    {
//        public IConfiguration Configuration { get; }
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services)
//        {
//            //services.AddControllers();
//            services.AddOcelot(Configuration);
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseRouting();

//            app.UseAuthorization();

//            //app.UseEndpoints(endpoints =>
//            //{
//            //    endpoints.MapControllers();
//            //});
//            app.UseOcelot().Wait();
            var databaseUri = new Uri(herokuPostgresURL);
            var userInfo = databaseUri.UserInfo.Split(':');
            var server = databaseUri.Host;
            var port = databaseUri.Port.ToString();
            var user = userInfo[0];
            var password = userInfo[1];
            var database = databaseUri.LocalPath.TrimStart('/');
            
            return $"userid={user};server={server};port={port};database={database};password={password};";
        }

//            //app.Run(async (context) =>
//            //{
//            //    await context.Response.WriteAsync("Hello World!");
//            //});
//        }
//    }
//}
