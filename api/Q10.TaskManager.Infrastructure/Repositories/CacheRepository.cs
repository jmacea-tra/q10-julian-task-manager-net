using Q10.TaskManager.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Q10.TaskManager.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación de un repositorio de caché en memoria usando IMemoryCache.
    /// </summary>
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _defaultOptions;

        /// <summary>
        /// Constructor que inicializa el repositorio de caché.
        /// </summary>
        /// <param name="cache">Instancia de IMemoryCache inyectada.</param>
        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
            _defaultOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };
        }

        /// <summary>
        /// Obtiene un valor de la caché por su clave.
        /// Si la clave no existe, retorna el valor por defecto del tipo.
        /// </summary>
        /// <typeparam name="T">Tipo del valor a obtener.</typeparam>
        /// <param name="key">Clave a buscar.</param>
        /// <returns>Valor almacenado o valor por defecto si no existe.</returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("La clave de caché no puede ser nula o estar vacía.", nameof(key));

            if (_cache.TryGetValue(key, out T value))
                return value;

            return default;
        }

        /// <summary>
        /// Establece un valor en la caché con expiración automática de 30 minutos.
        /// </summary>
        /// <typeparam name="T">Tipo del valor a almacenar.</typeparam>
        /// <param name="key">Clave para almacenar el valor.</param>
        /// <param name="value">Valor a almacenar.</param>
        public void Set<T>(string key, T value)
        {
            _cache.Set(key, value, _defaultOptions);
        }

        /// <summary>
        /// Elimina un valor de la caché por su clave.
        /// </summary>
        /// <param name="key">Clave del valor a eliminar.</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Verifica si existe una clave en la caché.
        /// </summary>
        /// <param name="key">Clave a verificar.</param>
        /// <returns>True si existe, false en caso contrario.</returns>
        public bool Exists(string key)
        {
            return _cache.TryGetValue(key, out _);
        }
    }
}
