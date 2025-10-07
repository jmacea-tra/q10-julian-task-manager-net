using System;

namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface ICacheRepository
    {
        /// <summary>
        /// Obtiene un valor de la caché por su clave.
        /// </summary>
        /// <typeparam name="T">Tipo del valor a obtener.</typeparam>
        /// <param name="key">Clave a buscar.</param>
        /// <returns>Valor almacenado o valor por defecto si no existe.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Establece un valor en la caché.
        /// </summary>
        /// <typeparam name="T">Tipo del valor a almacenar.</typeparam>
        /// <param name="key">Clave para almacenar el valor.</param>
        /// <param name="value">Valor a almacenar.</param>
        void Set<T>(string key, T value);

        /// <summary>
        /// Elimina un valor de la caché.
        /// </summary>
        /// <param name="key">Clave del valor a eliminar.</param>
        void Remove(string key);

        /// <summary>
        /// Verifica si existe una clave en la caché.
        /// </summary>
        /// <param name="key">Clave a verificar.</param>
        /// <returns>True si existe, false en caso contrario.</returns>
        bool Exists(string key);
    }
}
