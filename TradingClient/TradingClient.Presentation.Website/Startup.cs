using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Implementations;
using TradingClient.Business.Logic.Interfaces;

namespace TradingClient.Presentation.Website
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
            services.AddControllersWithViews();

            AddDependencies(services);

            AddHttpClients(services);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserBl, UserBl>();

            services.AddScoped<IStockBl, StockBl>();

            services.AddScoped<IWalletBl, WalletBl>();
        }

        public void AddHttpClients(IServiceCollection services)
        {
            services.AddHttpClient<IUserBl, UserBl>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetConnectionString("TradingApiURL"));
            });

            services.AddHttpClient<IStockBl, StockBl>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetConnectionString("TradingApiURL"));
            });

            services.AddHttpClient<IWalletBl, WalletBl>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetConnectionString("TradingApiURL"));
            });
        }
    }
}
