using AcademyG.Week6Test.Core.BusinessLayer;
using AcademyG.Week6Test.Core.EF;
using AcademyG.Week6Test.Core.EF.Repository;
using AcademyG.Week6Test.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AcademyG.Week6Test.WebAPI
{
    public class Startup
    {
        //sfruttiamo la reflection che permettono di manipolare il codice a runtime
        public readonly string ApplicationName = Assembly.GetEntryAssembly().GetName().Name;

        public readonly string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //DI
            services.AddTransient<IManagementBL, ManagementBL>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            //configurazione EFCore
            services.AddDbContext<ManagementContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AcademyGTest"));
            });

            //confiurazione swagger 
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });

                //string file = $"{ApplicationName}.xml";
                //options.IncludeXmlComments(
                //    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file)
                //    );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //swagger middleware
            app.UseSwagger();

            //ci permette di andare sulla documentazione di swagger e di non usare postman
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json", $"{ApplicationVersion} {ApplicationName}");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
