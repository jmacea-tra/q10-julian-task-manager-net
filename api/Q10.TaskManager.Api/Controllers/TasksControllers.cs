using Microsoft.AspNetCore.Mvc;
using Q10.TaskManager.Infrastructure.Interfaces;

namespace Q10.TaskManager.Api.Controllers
{
    /// <summary>
    /// Controlador para operaciones de caché de tareas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksControllers : ControllerBase
    {
        public IConfiguration Configuration;
        public ICacheRepository CacheRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de caché por inyección de dependencias.
        /// </summary>
        /// <param name="cacheRepository">Repositorio de caché</param>
        public TasksControllers(IConfiguration configuration, ICacheRepository cacheRepository)
        {
            CacheRepository = cacheRepository;
            Configuration = configuration;
        }

        /// <summary>
        /// Obtiene un valor de la caché por su clave.
        /// </summary>
        /// <param name="key">Clave a buscar</param>
        /// <returns>Valor almacenado o valor por defecto si no existe</returns>
        [HttpGet("get/{key}")]
        public ActionResult<string?> Get(string key)
        {
            var value = CacheRepository.Get<string>(key);
            if (value == null)
                return NotFound();
            return Ok(value);
        }

        /// <summary>
        /// Establece un valor en la caché.
        /// </summary>
        /// <param name="key">Clave para almacenar el valor</param>
        /// <param name="value">Valor a almacenar</param>
        [HttpPost("set")]
        public IActionResult Set([FromQuery] string key, [FromBody] string value)
        {
            CacheRepository.Set(key, value);
            return Ok();
        }

        /// <summary>
        /// Elimina un valor de la caché por su clave.
        /// </summary>
        /// <param name="key">Clave del valor a eliminar</param>
        [HttpDelete("remove/{key}")]
        public IActionResult Remove(string key)
        {
            CacheRepository.Remove(key);
            return NoContent();
        }

        /// <summary>
        /// Verifica si existe una clave en la caché.
        /// </summary>
        /// <param name="key">Clave a verificar</param>
        /// <returns>True si existe, false en caso contrario</returns>
        [HttpGet("exists/{key}")]
        public ActionResult<bool> Exists(string key)
        {
            var exists = CacheRepository.Exists(key);
            return Ok(exists);
        }
    }
}
