using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.DatabaseSql.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegrationAdapters
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Env = environment;
        }

        public static IConfiguration Configuration { get; private set; }
        public IWebHostEnvironment Env { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

        }
        private Server server;
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

        private string CreateConnectionStringFromEnvironment()
        {
            // Change these values for local connection
            var serverDefault = "localhost";
            var portDefault = 5432;
            var userDefault = "postgres";
            var passwordDefault = "super";
            var schema = "healthcare-system-db";

            // Do not change this
            var herokuPostgresURL = Configuration.GetValue<string>("DATABASE_URL") ?? $"{serverDefault}://{userDefault}:{passwordDefault}@{serverDefault}:{portDefault}/{schema}";

            var databaseUri = new Uri(herokuPostgresURL);
            var userInfo = databaseUri.UserInfo.Split(':');
            var server = databaseUri.Host;
            var port = databaseUri.Port.ToString();
            var user = userInfo[0];
            var password = userInfo[1];
            var database = databaseUri.LocalPath.TrimStart('/');

            return $"userid={user};server={server};port={port};database={database};password={password};";
        }

        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }
        }
    }
}
