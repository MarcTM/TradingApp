using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Trading.Application.Services;
using Trading.Application.Services.Implementations;
using Trading.Application.Services.Interfaces;
using Trading.Application.Services.Jwt;
using Trading.Infrastructure.Persistent;

namespace Trading.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddJWTTokenServices(Configuration);

            ConfigureApiServices(services);

            ConfigureApiVersioning(services);

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                                Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });

                // Swagger documentation
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Trading Api",
                    Version = "v1"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStockService stockService, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            // Logger
            loggerFactory.AddFile("../Logs/mylog-{Date}.txt");

            // Swagger
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trading.Web.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var context = (TradingDbContext) serviceProvider.GetService(typeof(TradingDbContext));

            // Database migrations
            context.Database.MigrateAsync().Wait();

            // Stocks seeder
            stockService.SeedStocks(Configuration["ApiStocksUrl"], Configuration["StockAPIKey"]).Wait();
        }

        //Api services injections
        public void ConfigureApiServices(IServiceCollection services)
        {
            DIConfiguration dIConfiguration = new();
            dIConfiguration.ConfigureSrevices(services);

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IWalletService, WalletService>();
        }

        // Api versioning
        public void ConfigureApiVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(config => {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
