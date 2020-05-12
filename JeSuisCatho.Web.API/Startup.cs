using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using JeSuisCatho.Web.API.Persistence;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Controllers;
 using JeSuisCatho.Shared;

using NSwag.AspNetCore;
using NJsonSchema;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JeSuisCatho.Web.API.Core.Models.Shop;
using Microsoft.AspNetCore.Http;
using JeSuisCatho.Web.API.Persistence.DataAccess;

namespace JeSuisCatho.Web.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.Configure<DocumentSettings>(Configuration.GetSection("DocumentSettings"));
            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));
            services.AddScoped<IChurchRepository, ChurchRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddTransient<IPhotoService, PhotoService>();
     
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IPhotoStorage, FileSystemPhotoStorage>();
            services.AddTransient<ICartService, CartDataAccessLayer>();
            services.AddTransient<IOrderService, OrderDataAccessLayer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpClient();
            // Register the Swagger services
            services.AddSwaggerDocument();
            services.AddAutoMapper();
            services.AddRouting(Options => Options.LowercaseUrls = true);
            services.AddDbContext<JeSuisCathoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
        


            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<JeSuisCathoDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AuthSettings:Audience"],
                    ValidIssuer = Configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{Configuration["AuthSettings:Key"]}")),
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization(option =>
            {
               // option.AddPolicy
            });

            services.AddScoped<IUserService, UserRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //  app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // app.UseCookiePolicy();

            //  app.UseRouting();
            // app.UseRequestLocalization();
             app.UseCors();

            app.UseAuthentication();
            //  app.UseAuthorization();
            // app.UseSession();



            // Register the Swagger generator and the Swagger UI middlewares

            app.UseOpenApi();

            app.UseSwaggerUi3();
         
            app.UseSpaStaticFiles();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
