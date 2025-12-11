using LD.Domain.Modelos.Articulo;
using LD.Domain.Modelos.Respuesta;


/// <author>Charlotte Rojas Padilla</author>
/// <date>11/12/2025</date>
/// <summary>
/// Interfaz que define las funciones principales del servicio de artículos.
/// Aquí se manejan acciones como agregar, listar, actualizar y borrar artículos.
/// </summary>
namespace LD.Domain.Interfaces.Articulo
{
    public interface IServicioArticulo
    {

        /// <summary>
        /// Agrega un nuevo artículo.
        /// </summary>
        /// <param name="solicitud">Datos del artículo que se desea registrar.</param>
        /// <returns>Una respuesta indicando el resultado del proceso.</returns>

        public Task<MRespuesta<MArticulo>> AgregarArticulo(SAgregarArticulo solicitud);

        /// <summary>
        /// Obtiene la lista completa de artículos registrados.
        /// </summary>
        /// <returns>Una respuesta con todos los artículos disponibles.</returns>
        public Task<MRespuesta<IEnumerable<MArticulo>>> ListarArticulos();


        /// <summary>
        /// Actualiza los datos de un artículo existente.
        /// </summary>
        /// <param name="solicitud">Información del artículo para actualizarlo.</param>
        /// <returns>Una respuesta indicando si la actualización fue exitosa.</returns>
        public Task<MRespuesta<bool>> ActualizarArticulo(SActualizarArticulo solicitud);


        /// <summary>
        /// Elimina un artículo por su identificación.
        /// </summary>
        /// <param name="id">ID del artículo que se desea borrar.</param>
        /// <returns>Una respuesta con la información del artículo eliminado.</returns>
        public Task<MRespuesta<MArticulo>> BorrarArticulo(int id);
    }
}
