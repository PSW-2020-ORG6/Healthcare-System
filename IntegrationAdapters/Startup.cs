using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.DatabaseSql.Util;
using IntegrationAdapters.gRPCProtocol;
using IntegrationAdapters.gRPCProtocol.Protos;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            IConfiguration conf = Configuration.GetSection("DataBaseConnectionSettings");
            DataBaseConnectionSettings dataBaseConnectionSettings = new DataBaseConnectionSettings();

            services.AddControllers();

            services.AddDbContext<IAHealthCareSystemDbContext>(options =>
            {
                options.UseNpgsql(
                    dataBaseConnectionSettings.ConnectionString,
                    x => x.MigrationsAssembly("Backend").EnableRetryOnFailure(
                        dataBaseConnectionSettings.RetryCount, new TimeSpan(0, 0, 0, dataBaseConnectionSettings.RetryWaitInSeconds), new List<string>())
                    ).UseLazyLoadingProxies();
            });
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

            server = new Server
            {
                Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
                Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
            };
            server.Start();

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "healthcare-system-db";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"User ID =postgres;server={server};port={port};database={database};user={user};password={password};Integrated Security=true;Pooling=true;";
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
