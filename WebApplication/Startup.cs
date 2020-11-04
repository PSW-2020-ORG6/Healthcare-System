
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication.Backend.Model;
using VueCliMiddleware;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          //  MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=newmydb11;user=root;password=root");

          ////metoda za dodavanje u tabelu-bazu
          //  string sql1 = "REPLACE  into feedbacks(Id,Name,Text,Approved)Values('" + "a"+"','"+"PERA"+"','"+"TEXT"+"','"+0+"')";
          //  MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
          //  conn.Open();
          //  cmd1.ExecuteNonQuery();


          // //metoda za iscitavanje(upisujemo u fajl samo radi provjere)
          //  string sql = "SELECT * from feedbacks";
          //  MySqlCommand cmd = new MySqlCommand(sql, conn);
          //  MySqlDataReader rdr = cmd.ExecuteReader();
          //  using (System.IO.StreamWriter file =
          //        new System.IO.StreamWriter(@"D:\text.txt"))
          //      while (rdr.Read())
          //      {
          //          file.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3]);
          //      }
          //  rdr.Close();
          //  conn.Close();
          //  Console.WriteLine("Done.");
            }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MyDbContext>(options=>
            options.UseMySql(ConfigurationExtensions.GetConnectionString(Configuration,"MyDbContextConnectionString")).UseLazyLoadingProxies());
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
