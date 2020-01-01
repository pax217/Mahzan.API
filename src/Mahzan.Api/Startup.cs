using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Context;
using Mahzan.Api.Extensions;
using Mahzan.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Mahzan.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Agrega Swagger
            services.AddSwagger();

            //Agrega Versionador de API
            services.AddMvc();
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            //Agrega Autenticación por Jwt
            services.AddJwt(_configuration);

            //IdentityDbContext
            services.AddMahzanIdentityDbContext(_configuration);

            //MahzanDbContext
            services.AddMahzanDbContext(_configuration);

            //Identity Provider
            services.AddIdentityProvider();

            //Inyección de dependencias
            services.ConfigureBlServices();

            //Email Sender
            services.AddEmailSender(_configuration);

            //Requiere confimración de email
            services.AddRequireEmailConfirmation();

            //Add MappingProfile
            services.AddMappingConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                //MahzanIdentityDbContext
                var mahzanIdentityDbContext = serviceScope.ServiceProvider.GetRequiredService<MahzanIdentityDbContext>();

                if (mahzanIdentityDbContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    mahzanIdentityDbContext.Database.Migrate();
                }

                //MahzanDbContext
                var mahzanDbContext = serviceScope.ServiceProvider.GetRequiredService<MahzanDbContext>();

                if (mahzanDbContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    mahzanDbContext.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mahzan API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
