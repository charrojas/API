using LD.Domain.Modelos.Articulo;


/// <author>Charlotte Rojas Padilla</author>
/// <date>11/12/2025</date>
/// <summary>
/// Interfaz del repositorio articulo.
/// Aquí se especifican las acciones de agregar, listar, actualizar y borrar artículos.
/// </summary>
namespace LD.Domain.Interfaces.Articulo
{
    public interface IRepositorioArticulo
    {

        /// <summary>
        /// Agrega un nuevo artículo utilizando la información recibida.
        /// </summary>
        /// <param name="solicitud">Datos necesarios para registrar el artículo.</param>
        /// <returns>El artículo registrado.</returns>
        public Task<MArticulo> AgregarArticulo(SAgregarArticulo solicitud);


        /// <summary>
        /// Obtiene la lista completa de artículos registrados.
        /// </summary>
        /// <returns>Una colección con todos los artículos.</returns>
        public Task<IEnumerable<MArticulo>> ListarArticulos();


        /// <summary>
        /// Actualiza la información de un artículo existente.
        /// </summary>
        /// <param name="solicitud">Datos del artículo que se desea actualizar.</param>
        /// <returns>true si la actualización se realizó correctamente.</returns>
        public Task<bool> ActualizarArticulo(SActualizarArticulo solicitud);


        /// <summary>
        /// Elimina un artículo según su ID.
        /// </summary>
        /// <param name="id">Identificador del artículo a borrar.</param>
        /// <returns>El artículo que fue eliminado.</returns>
        public Task<MArticulo> BorrarArticulo(int id);


    }
}
