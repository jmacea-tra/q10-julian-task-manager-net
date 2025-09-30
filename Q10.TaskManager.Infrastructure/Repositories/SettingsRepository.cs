using Microsoft.Extensions.Configuration;
using Q10.TaskManager.Infrastructure.Interfaces;

namespace Q10.TaskManager.Infrastructure.Repositories
{
    public class SettingsRepository : IConfig
    {
        private IConfiguration Configuration { get; set; }
        public SettingsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string GetValue(string key)
        {
            return Configuration[key];
        }
    }
}