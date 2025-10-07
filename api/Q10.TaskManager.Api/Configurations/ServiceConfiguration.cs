using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;

namespace Q10.TaskManager.Api.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Repositories
            services.AddSingleton<ICacheRepository, CacheRepository>();
            services.AddScoped<IConfig, SettingsRepository>();
            #endregion Repositories

            return services;
        }

    }
}
