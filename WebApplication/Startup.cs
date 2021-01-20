using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApplication.util;

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
            services.AddSingleton(GetMicroServiceUrisFromEnvironment());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        private MicroServiceUris GetMicroServiceUrisFromEnvironment()
        {
            // Change values for local connection
            var accountServiceUri = "http://localhost:57053";
            var appointmentServiceUri = "http://localhost:57056";
            var feedbackServiceUri = "http://localhost:57057";
            var searchServiceUri = "http://localhost:57060";

            // Do not change this
            var microServiceUris = new MicroServiceUris
            {
                AccountServiceUrl = Configuration.GetValue<string>("WEB_APP_ACCOUNT_URL") ?? accountServiceUri,
                AppointmentServiceUrl =
                    Configuration.GetValue<string>("WEB_APP_APPOINTMENT_URL") ?? appointmentServiceUri,
                FeedbackServiceUrl = Configuration.GetValue<string>("WEB_APP_FEEDBACK_URL") ?? feedbackServiceUri,
                SearchServiceUrl = Configuration.GetValue<string>("WEB_APP_SEARCH_URL") ?? searchServiceUri
            };

            // Used to check if correct values are being used
            Console.WriteLine($"WEB_APP_ACCOUNT_URL: {microServiceUris.AccountServiceUrl}");
            Console.WriteLine($"WEB_APP_APPOINTMENT_URL: {microServiceUris.AppointmentServiceUrl}");
            Console.WriteLine($"WEB_APP_FEEDBACK_URL: {microServiceUris.FeedbackServiceUrl}");
            Console.WriteLine($"WEB_APP_SEARCH_URL: {microServiceUris.SearchServiceUrl}");

            return microServiceUris;
        }
    }
}