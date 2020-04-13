
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Project.DAL.Context;
using Project.Repository.Common.Interfaces.API;
using Project.Repository.Repository.API;
using Project.Service.Common.Interfaces.API;
using Project.Service.Services.API;
using System;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace Mono_Project_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().
                AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3001", "https://localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var connectionString = Configuration["PostgreSql:ConnectionString"];
            var dbPassword = Configuration["PostgreSql:DbPassword"];

            var builder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Password = dbPassword
            };

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.ConnectionString));

            // Add UnitOfWork Test
            // services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            // Vehicle Service
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeServiceAPI>();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelServiceAPI>();

            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Repository Test
            // builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
            // builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
