using LD.Domain.Interfaces.Articulo;
using LD.Domain.Modelos.Articulo;
using LD.Domain.Modelos.Respuesta;
using Microsoft.Extensions.Logging;


/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Servicio encargado de manejar la lógica relacionada con los artículos.  
/// Permite agregar, actualizar, eliminar y listar artículos, controlando respuestas y manejo de errores.
/// </summary>
namespace LD.Infraestructure.Servicios.Articulo
{
    public class ServicioArticulo : IServicioArticulo
    {
        private readonly ILogger<ServicioArticulo> _logger;

        private readonly IRepositorioArticulo _repositorioArticulo;

        /// <summary>
        /// Constructor del servicio.  
        /// Inicializa el logger y el repositorio de artículos para realizar operaciones.
        /// </summary>
        public ServicioArticulo(ILogger<ServicioArticulo> logger, IRepositorioArticulo repositorioArticulo)
        {
            _logger = logger;
            _repositorioArticulo = repositorioArticulo;
        }

        /// <summary>
        /// Actualiza un artículo existente en el sistema.
        /// </summary>
        /// <param name="solicitud">Datos enviados con la información del artículo a actualizar.</param>
        /// <returns>Respuesta indicando si la actualización fue exitosa o no, con un mensaje descriptivo.</returns>

        public async Task<MRespuesta<bool>> ActualizarArticulo(SActualizarArticulo solicitud)
        {
            var respuesta = new MRespuesta<bool>();

            try
            {
                var articuloActualizado = await _repositorioArticulo.ActualizarArticulo(solicitud);

                if (!articuloActualizado)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = "Error al actualizar el articulo";
                    respuesta.Dato = false;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el articulo");

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al actualizar el articulo";
            }

            return respuesta;
        }

        /// <summary>
        /// Agrega un nuevo artículo al sistema.
        /// </summary>
        /// <param name="solicitud">Datos enviados con la información del artículo a registrar.</param>
        /// <returns>Respuesta con el artículo agregado y un mensaje de estado.</returns>
        public async Task<MRespuesta<MArticulo>> AgregarArticulo(SAgregarArticulo solicitud)
        {
            var respuesta = new MRespuesta<MArticulo>();

            try
            {
                var articulo = await _repositorioArticulo.AgregarArticulo(solicitud);

                if (articulo.Codigo == "")
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = "Error al agregar el articulo";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = articulo;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el articulo");

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al agregar el articulo";
            }

            return respuesta;
        }


        /// <summary>
        /// Elimina un artículo del sistema por su identificador.
        /// </summary>
        /// <param name="id">Identificador del artículo a eliminar.</param>
        /// <returns>Respuesta con el artículo eliminado y un mensaje de estado.</returns>
        public async Task<MRespuesta<MArticulo>> BorrarArticulo(int id)
        {
            var respuesta = new MRespuesta<MArticulo>();

            try
            {
                var producto = await _repositorioArticulo.BorrarArticulo(id);

                if (producto == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = "Error al borrar el articulo";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = producto;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al borrar el articulo");

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }


        /// <summary>
        /// Obtiene la lista completa de artículos registrados en el sistema.
        /// </summary>
        /// <returns>Respuesta con la lista de artículos y un mensaje de estado.</returns>
        public async Task<MRespuesta<IEnumerable<MArticulo>>> ListarArticulos()
        {
            var respuesta = new MRespuesta<IEnumerable<MArticulo>>();

            try
            {
                var articulos = await _repositorioArticulo.ListarArticulos();

                if (articulos == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = "Error al obtener las listas de articulos";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = articulos;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las listas de articulos");

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al obtener las listas de articulos";
            }

            return respuesta;
        }
    }
}
