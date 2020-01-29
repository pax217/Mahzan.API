using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AutoMapper;
using Mahzan.Api.Context;
using Mahzan.Api.Services;
using Mahzan.Business.Implementations.Business.BarCodes;
using Mahzan.Business.Implementations.Business.Clients;
using Mahzan.Business.Implementations.Business.Companies;
using Mahzan.Business.Implementations.Business.Employees;
using Mahzan.Business.Implementations.Business.EmployeesStores;
using Mahzan.Business.Implementations.Business.Groups;
using Mahzan.Business.Implementations.Business.Members;
using Mahzan.Business.Implementations.Business.Menu;
using Mahzan.Business.Implementations.Business.PaymentTypes;
using Mahzan.Business.Implementations.Business.PointOfSales;
using Mahzan.Business.Implementations.Business.ProductCategories;
using Mahzan.Business.Implementations.Business.Products;
using Mahzan.Business.Implementations.Business.ProductsPhotos;
using Mahzan.Business.Implementations.Business.ProductUnits;
using Mahzan.Business.Implementations.Business.Stores;
using Mahzan.Business.Implementations.Business.Taxes;
using Mahzan.Business.Implementations.Business.Tickets;
using Mahzan.Business.Implementations.Validations.AspNetUsers;
using Mahzan.Business.Implementations.Validations.Clients;
using Mahzan.Business.Implementations.Validations.Companies;
using Mahzan.Business.Implementations.Validations.Groups;
using Mahzan.Business.Implementations.Validations.Members;
using Mahzan.Business.Implementations.Validations.PointsOfSales;
using Mahzan.Business.Implementations.Validations.Products;
using Mahzan.Business.Implementations.Validations.Stores;
using Mahzan.Business.Implementations.Validations.Taxes;
using Mahzan.Business.Interfaces.Business.BarCodes;
using Mahzan.Business.Interfaces.Business.Clients;
using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.Business.Interfaces.Business.Employees;
using Mahzan.Business.Interfaces.Business.EmployeesStores;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Menu;
using Mahzan.Business.Interfaces.Business.PaymentTypes;
using Mahzan.Business.Interfaces.Business.PointOfSales;
using Mahzan.Business.Interfaces.Business.ProductCategories;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Interfaces.Business.ProductsPhotos;
using Mahzan.Business.Interfaces.Business.ProductUnits;
using Mahzan.Business.Interfaces.Business.Stores;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Interfaces.Validations.AspNetUsers;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Business.Interfaces.Validations.Companies;
using Mahzan.Business.Interfaces.Validations.Groups;
using Mahzan.Business.Interfaces.Validations.Miembros;
using Mahzan.Business.Interfaces.Validations.PointsOfSales;
using Mahzan.Business.Interfaces.Validations.Products;
using Mahzan.Business.Interfaces.Validations.Stores;
using Mahzan.Business.Interfaces.Validations.Taxes;
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
            services.AddTransient<IEmployeesStoresRepository, EmployeesStoresRepository>();
            services.AddTransient<IPointsOfSalesRepository, PointsOfSalesRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IProductsTaxesRepository, ProductsTaxesRepository>();
            services.AddTransient<IProductsStoreRepository, ProductsStoreRepository>();
            services.AddTransient<IProductUnitsRepository, ProductUnitsRepository>();
            services.AddTransient<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddTransient<IProductsPhotosRepository, ProductsPhotosRepository>();
            services.AddTransient<ITicketsRepository, TicketsRepository>();
            services.AddTransient<ITicketDetailRepository, TicketDetailRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IMenuItemsRepository, MenuItemsRepository>();
            services.AddTransient<IMenuSubItemsRepository, MenuSubItemsRepository>();
            services.AddTransient<IPaymentTypesRepository, PaymentTypesRepository>();
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<ITaxesRepository, TaxesRepository>();
            services.AddTransient<ITaxesStoresRepository, TaxesStoresRepository>();


            //Validaciones
            services.AddTransient<ILogInValidations, LogInValidations>();
            services.AddTransient<ISignUpValidations, SignUpValidations>();
            services.AddTransient<IAddMembersValidations, AddMembersValidations>();

            services.AddTransient<IAddGroupsValidations, AddGroupsValidations>();
            services.AddTransient<IDeleteGroupsValidations, DeleteGroupsValidations>();

            services.AddTransient<IAddCompaniesValidations, AddCompaniesValidations>();

            services.AddTransient<IAddStoresValidations, AddStoresValidations>();

            services.AddTransient<IPointsOfSalesValidations, PointsOfSalesValidations>();

            services.AddTransient<IAddProductsValidations, AddProductsValidations>();

            services.AddTransient<IAddClientsValidations, AddClientsValidations>();

            services.AddTransient<IAddTaxesValidations, AddTaxesValidations>();


            //Negocio
            services.AddTransient<IMembersBusiness, MembersBusiness>();
            services.AddTransient<IGroupsBusiness, GroupsBusiness>();
            services.AddTransient<ICompaniesBusiness, CompaniesBusiness>();
            services.AddTransient<IStoresBusiness, StoresBusiness>();
            services.AddTransient<IEmployeesBusiness, EmployeesBusiness>();
            services.AddTransient<IEmployeesStoresBusiness, EmployeesStoresBusiniess>();
            services.AddTransient<IPointsOfSalesBusiness, PointsOfSalesBusiness>();
            services.AddTransient<IProductCategoriesBusiness, ProductCategoriesBusiness>();
            services.AddTransient<IProductUnitsBusiness, ProductUnitsBusiness>();
            services.AddTransient<IProductsPhotosBusiness, ProductsPhotosBusiness>();
            services.AddTransient<IProductsBusiness, ProductsBusiness>();
            services.AddTransient<ITicketsBusiness, TicketsBusiness>();
            services.AddTransient<IMenuBusiness, MenuBusiness>();
            services.AddTransient<IPaymentTypesBusiness, PaymentTypesBusiness>();
            services.AddTransient<IClientsBusiness, ClientsBusiness>();
            services.AddTransient<IBarCodesBusiness, BarCodesBusiness>();
            services.AddTransient<ITaxesBusiness, TaxesBusiness>();


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
