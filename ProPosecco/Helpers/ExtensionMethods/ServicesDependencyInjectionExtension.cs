using Microsoft.Extensions.DependencyInjection;
using ProProsecco.Repositories.Implementations;
using ProProsecco.Repositories.Interfaces;
using ProProsecco.Repositories.Wrappers.Implementations;
using ProProsecco.Repositories.Wrappers.Interfaces;

namespace ProProsecco.Helpers.ExtensionMethods
{
    public static class ServicesDependencyInjectionExtension
    {
        public static void AddDependencyInjectionRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWine, RepositoryWine>();
            services.AddScoped<IRepositoryCart, RepositoryCart>();
            services.AddScoped<IRepositoryOrder, RepositoryOrder>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
        }

        public static void AddDependencyInjectionWrappers(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryAdministratorWrapper, RepositoryAdministratorWrapper>();
            services.AddScoped<IRepositoryCartWrapper, RepositoryCartWrapper>();
            services.AddScoped<IRepositoryShopWrapper, RepositoryShopWrapper>();
        }
    }
}
