using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;
using static System.Net.WebRequestMethods;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //MySqlConnection con = new MySqlConnection("server=localhost;port=3306;database=newmydb11;user=root;password=root");
            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("select * from newmydb11");
            //MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //Debug.WriteLine("jsdqnidvjnwirvwrvwrvwrvwbrv");
            //Console.ReadLine();




        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
