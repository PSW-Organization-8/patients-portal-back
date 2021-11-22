using HospitalAPI;
using HospitalClassLib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests
{
    public class HospitalTestFactory<TStartup> : WebApplicationFactory<Startup>
    {
        /*protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MyDbContext>));
                services.Remove(descriptor);

                services.AddDbContext<MyDbContext>(opt =>
                    opt.UseNpgsql(CreateConnectionStringForTest()));

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<MyDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<HospitalTestFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    /*try
                    {
                        InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }

        private static void InitializeDbForTests(HospitalTestFactory db)
        {
            var startingDb = File.ReadAllText("../../../Integration/Scripts/data.sql");
            db.Database.ExecuteSqlRaw(startingDb);
        }

        private static string CreateConnectionStringForTest()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "smart-tutor-test";
            var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
            var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

            return
                $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
        }*/
    }
}
