using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocietyManagement.Infrastructure.Data.DatabaseContext;
using SocietyManagement.Infrastructure.Data.Repository;
using SocietyManagement.Interface.Repository;
using SocietyManagement.Interface.Service;
using SocietyManagement.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace SocietyManagement
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
           

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddEntityFrameworkSqlServer()
                    .AddDbContext<SocietyManagementDBContext>(
                        options => options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));
           
            services.AddOptions();

            services.AddMemoryCache();

            services.AddMvc();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));



            
            services.AddTransient<ISocietyMangementService, SocietyMangementService>();
            services.AddTransient<ISocietyMangementRepository, SocietyMangementRepository>();

            services.AddTransient<IVisitorRepository, VisitorRepository>();
            services.AddTransient<IVisitorService, VisitorService>();

            // Add framework services.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Probation API", Version = "v1" });
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Probation API V1");
            });

            app.UseMvc();
        }
    }
}
