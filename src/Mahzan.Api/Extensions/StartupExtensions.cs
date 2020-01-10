using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AutoMapper;
using Mahzan.Api.Context;
using Mahzan.Api.Services;
using Mahzan.Business.Implementations.Business.Companies;
using Mahzan.Business.Implementations.Business.Employees;
using Mahzan.Business.Implementations.Business.Groups;
using Mahzan.Business.Implementations.Business.Members;
using Mahzan.Business.Implementations.Business.Stores;
using Mahzan.Business.Implementations.Validations.AspNetUsers;
using Mahzan.Business.Implementations.Validations.Members;
using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.Business.Interfaces.Business.Employees;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Stores;
using Mahzan.Business.Interfaces.Validations.AspNetUsers;
using Mahzan.Business.Interfaces.Validations.Miembros;
using Mahzan.Business.Mapping;
using Mahzan.DataAccess.Implementations;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Mahzan.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class StartupExtensions
    {
        public static void ConfigureBlServices(this IServiceCollection services)
        {

            //Data Access
            services.AddTransient<IMembersRepository, MembersRepository>();
            services.AddTransient<IGroupsRepository, GroupsRepository>();
            services.AddTransient<ICompaniesRepository, CompaniesRepository>();
            services.AddTransient<IStoresRepository, StoresRepository>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();

            //Validaciones
            services.AddTransient<ILogInValidations, LogInValidations>();
            services.AddTransient<ISignUpValidations, SignUpValidations>();
            services.AddTransient<IAddMembersValidations, AddMembersValidations>();


            //Negocio
            services.AddTransient<IMembersBusiness, MembersBusiness>();
            services.AddTransient<IGroupsBusiness, GroupsBusiness>();
            services.AddTransient<ICompaniesBusiness, CompaniesBusiness>();
            services.AddTransient<IStoresBusiness, StoresBusiness>();
            services.AddTransient<IEmployeesBusiness, EmployeesBusiness>();
        }

        /// <summary>
        /// Agrega Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mahzan API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
               {
                 new OpenApiSecurityScheme
                 {
                   Reference = new OpenApiReference
                   {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                   }
                  },
                  new string[] { }
                }
              });
            });
        }

        /// <summary>
        /// Agrega Autenticación por Jwt
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwt(this IServiceCollection services,
                                  IConfiguration Configuration)
        {
            string secretKey = Configuration["Jwt:Key"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://oec.com",
                    ValidIssuer = "http://oec.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });

        }

        public static void AddMahzanIdentityDbContext(this IServiceCollection services,
                                                      IConfiguration Configuration)
        {
            services.AddDbContext<MahzanIdentityDbContext>(options =>
                                                           options.UseSqlServer(Configuration.GetConnectionString("Mahzan")
                                                           ));
        }

        public static void AddMahzanDbContext(this IServiceCollection services,
                                              IConfiguration Configuration)
        {
            services.AddDbContext<MahzanDbContext>(options =>
                                                   options.UseSqlServer(Configuration.GetConnectionString("Mahzan")
                                                   ));
        }

        public static void AddIdentityProvider(this IServiceCollection services)
        {
            services.AddIdentity<AspNetUsers, IdentityRole>()
                    .AddEntityFrameworkStores<MahzanIdentityDbContext>()
                    .AddDefaultTokenProviders();
        }


        public static void AddEmailSender(this IServiceCollection services,
                                          IConfiguration Configuration)
        {
            //Envio de Email
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        public static void AddRequireEmailConfirmation(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(o => {
                o.SignIn.RequireConfirmedEmail = true;
            });
        }

        public static void AddMappingConfig(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddCorsPolicy(this IServiceCollection services)
        {
            /*ADD CORS*/
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                    // Apply CORS policy for any type of origin  
                    .AllowAnyMethod()
                    // Apply CORS policy for any type of http methods  
                    .AllowAnyHeader()
                    // Apply CORS policy for any headers  
                    .AllowCredentials()
                    // Apply CORS policy for all users  
                    .AllowAnyOrigin());
            });
        }

    }
}
