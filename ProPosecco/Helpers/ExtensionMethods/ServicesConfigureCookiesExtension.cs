using Microsoft.Extensions.DependencyInjection;

namespace ProProsecco.Helpers.ExtensionMethods
{
    public static class ServicesConfigureCookiesExtension
    {
        public static void ConfigureCookies(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });
            services.AddAuthentication().AddCookie();
        }
    }
}
