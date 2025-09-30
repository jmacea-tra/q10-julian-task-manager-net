using Microsoft.Extensions.Configuration;
using Q10.TaskManager.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infraestructure.Repositories
{
    public class SettingsRepository : IConfig
    {
        //Inversión de dependencias
        private IConfiguration Configuraction { get; set; }  
        public SettingsRepository(IConfiguration configuraction)
        {
            Configuraction = configuraction;
        }

        public string GetValue(string key)
        {
            return Configuraction[key] ?? string.Empty;
        }
    }
}
