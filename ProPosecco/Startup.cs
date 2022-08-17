using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProPosecco.Areas.Identity.Data;
using ProPosecco.Helpers;
using ProProsecco.Helpers;
using ProProsecco.Helpers.ExtensionMethods;
using System.Globalization;
using System.Linq;

namespace ProPosecco
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // extension methods
            services.ConfigureCookies();
            services.AddDependencyInjectionRepositories();
            services.AddDependencyInjectionWrappers();

            // automapper
            services.AddAutoMapper(profile => profile.AddProfile(new Mapper()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProProseccoDbContext context)
        {
            // migrations
            var migrations = context.Database.GetPendingMigrations();

            if (migrations.Any())
            {
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shop/Error");
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            // seeder
            Seeder.Seed(context);
        }
    }
}
