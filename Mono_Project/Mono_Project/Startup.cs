using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Project.Service.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Project.Service.Interfaces;
using Project.Service.Services;
using AutoMapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Mono_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var connectionString = Configuration["PostgreSql:ConnectionString"];
            var dbPassword = Configuration["PostgreSql:DbPassword"];

            var builder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Password = dbPassword
            };

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.ConnectionString));

            // .net Core, new dependency injection, replaced with AutoFac
            //services.AddTransient<IVehicleMakeService, VehicleMakeService>();
            //services.AddTransient<IVehicleModelService, VehicleModelService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
