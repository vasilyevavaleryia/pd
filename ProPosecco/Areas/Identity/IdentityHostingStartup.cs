using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProPosecco.Areas.Identity.Data;
using ProProsecco.Helpers;

[assembly: HostingStartup(typeof(ProPosecco.Areas.Identity.IdentityHostingStartup))]
namespace ProPosecco.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProProseccoDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Dev")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ProProseccoDbContext>()
                    .AddErrorDescriber<IdentityErrorPolishDescriber>();
            });
        }
    }
}