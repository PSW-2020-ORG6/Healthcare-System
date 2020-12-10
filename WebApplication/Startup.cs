using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            //TODO: use postgresql
            
            services.AddDbContext<UtilDbContext>(options =>
            options.UseNpgsql(ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString")));
            
            // services.AddDbContext<UtilDbContext>(options =>
            // options.UseMySql(ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString")).UseLazyLoadingProxies());
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
