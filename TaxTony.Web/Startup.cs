using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxTony.AutoMapper.Builders;
using TaxTony.Core.Contracts.Factories;
using TaxTony.Core.Contracts.Repositories;
using TaxTony.Core.Contracts.Services;
using TaxTony.DataAccess.Contexts;
using TaxTony.DataAccess.Repositories;
using TaxTony.Services.Factories;
using TaxTony.Services.Services;

namespace TaxTony.Web
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
            //entity framework
            services.AddDbContext<TaxTonyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TaxTonyContext"))
            );

            //register automapper
            services.AddSingleton(sp => MapperBuilder.Mapper);
            services.AddSingleton(sp => MapperBuilder.ConfigurationProvider);

            //register services
            services.AddTransient<ITaxService, TaxService>();
            services.AddSingleton<ITaxStrategyFactory, TaxStrategyFactory>();

            //register repositories
            services.AddScoped<ITaxCalculationRepository, TaxCalculationRepository>();

            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
