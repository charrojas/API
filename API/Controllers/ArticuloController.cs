using LD.Domain.Interfaces.Articulo;
using LD.Domain.Modelos.Articulo;
using LD.Domain.Modelos.Respuesta;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    /// Author:Charlotte Rojas Padilla
    /// Fecha: 11/12/2025
    /// <summary>
    /// Controlador encargado de gestionar los artículos del sistema.
    /// Aquí se realizan acciones como agregar, listar, actualizar y borrar artículos,
    /// utilizando un servicio que procesa la información y devuelve el resultado.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IServicioArticulo _servicioArticulo;
        public ArticuloController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }


        /// <summary>
        /// Agrega un nuevo artículo al sistema enviando sus datos.
        /// </summary>
        /// <param name="solicitud">Datos del artículo a registrar.</param>
        /// <returns>200 si se agregó, 400 si hubo algún problema.</returns>
        [HttpPost]
        [Route("AgregarArticulo")]
        public async Task<IActionResult> AgregarArticulo([FromBody] SAgregarArticulo solicitud)
        {
            var response = await _servicioArticulo.AgregarArticulo(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// Obtiene la lista completa de artículos registrados.
        /// </summary>
        /// <returns>200 si se listan correctamente, 400 si ocurre un error.</returns>
        [HttpGet]
        [Route("ListarArticulos")]
        public async Task<IActionResult> ListarArticulo()
        {
            var response = await _servicioArticulo.ListarArticulos();

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// Actualiza la información de un artículo existente.
        /// </summary>
        /// <param name="solicitud">Datos actualizados del artículo.</param>
        /// <returns>200 si se actualizó, 404 si no se encontró el artículo.</returns>
        [HttpPut]
        [Route("ActualizarArticulo")]
        public async Task<IActionResult> ActualizarArticulo([FromBody] SActualizarArticulo solicitud)
        {
            var response = await _servicioArticulo.ActualizarArticulo(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        /// <summary>
        /// Borra un artículo usando su ID.
        /// </summary>
        /// <param name="id">ID del artículo a eliminar.</param>
        /// <returns>200 si se eliminó, 404 si no se encontró.</returns>
        [HttpDelete]
        [Route("BorrarArticulo")]
        public async Task<IActionResult> BorrarArticulo([FromQuery] int id)
        {
            var response = await _servicioArticulo.BorrarArticulo(id);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return NotFound(response);
        }
    }
}