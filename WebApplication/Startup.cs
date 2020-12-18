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
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication.Backend.Model;
using WebApplication.Backend.Services;

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

            services.AddDbContext<HealthCareSystemDbContext>(options =>
            {
                options.UseNpgsql(
                    dataBaseConnectionSettings.ConnectionString);
                // options.UseNpgsql(
                //     dataBaseConnectionSettings.ConnectionString,
                //     x => x.MigrationsAssembly("Backend").EnableRetryOnFailure(dataBaseConnectionSettings.RetryCount,
                //         new TimeSpan(0, 0, 0, dataBaseConnectionSettings.RetryWaitInSeconds), new List<string>())
                // );
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}