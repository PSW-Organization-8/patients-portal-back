using HospitalClassLib;
using HospitalClassLib.MedicalRecords.Repository.MedicationRepo;
using HospitalClassLib.MedicalRecords.Repository.ReceiptRepo;
using HospitalClassLib.MedicalRecords.Service;
using HospitalClassLib.MedicalRecords.Service.Interface;
using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.FeedbackRepository;
using HospitalClassLib.Schedule.Repository.ManagerRepo;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Repository.SurveyRepository;
using HospitalClassLib.Schedule.Service;
using IntegrationClassLib.Pharmacy.Repository.MedicationRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI
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
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(x => x.MigrationsAssembly("HospitalAPI")));

            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddScoped<TokenService>();

            services.AddTransient<IAllergenRepository, AllergenRepository>();
            services.AddScoped<AllergenService>();
            services.AddScoped<AllergenRepository>();

            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddScoped<DoctorService>();
            services.AddScoped<DoctorRepository>();
          
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddScoped<PatientService>();
            services.AddScoped<PatientRepository>();

            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<FeedbackService>();
            services.AddScoped<FeedbackRepository>();

            services.AddTransient<ISurveyRepository, SurveyRepository>();
            services.AddScoped<SurveyService>();
            services.AddScoped<SurveyRepository>();

            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddScoped<QuestionService>();
            services.AddScoped<QuestionRepository>();

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<AppointmentService>();
            services.AddScoped<AppointmentRepository>();

            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddScoped<IMedicationService, MedicationService>();

            services.AddTransient<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IReceiptService, ReceiptService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new
                    SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes
                    (Configuration["Jwt:Key"]))
                };
            });


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSession();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MyDbContext>();
                try
                {
                    Console.WriteLine("###############################################################################");
                    Console.WriteLine("Migriram bazu podataka");
                    context.Database.Migrate();
                    Console.WriteLine("###############################################################################");
                }
                catch (Exception e)
                {
                    Console.WriteLine("###############################################################################");
                    Console.WriteLine("Greska prilikom kreiranja baze podataka");
                    Console.WriteLine(e.Data);
                    Console.WriteLine("###############################################################################");
                }

            }

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthorization();



            app.UseSession();
                        app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });
           /* app.UseStaticFiles();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Login}/{action=Index}/{id?}");
            });*/
        }

    }
}
