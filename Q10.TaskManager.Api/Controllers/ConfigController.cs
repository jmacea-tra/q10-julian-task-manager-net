using Microsoft.AspNetCore.Mvc;
using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;
using System.Linq;

namespace Q10.TaskManager.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar las configuraciones del sistema
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        public IConfig Config { get; set; }

        /// <summary>
        /// Constructor del controlador de configuraciones
        /// </summary>
        /// <param name="configs">Colección de configuraciones disponibles</param>
        public ConfigController(IEnumerable<IConfig> configs)
        {
            Config = configs.OfType<EnvironmentRepository>().FirstOrDefault();
        }

        /// <summary>
        /// Obtiene el valor de la variable de entorno ASPNETCORE_ENVIRONMENT
        /// </summary>
        /// <returns>Valor de la variable de entorno actual</returns>
        /// <response code="200">Retorna el valor de la variable de entorno</response>
        /// <response code="404">Si no se encuentra la variable de entorno</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var value = Config.GetValue("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(value))
                return NotFound();

            return Ok(value);
        }
    }
}