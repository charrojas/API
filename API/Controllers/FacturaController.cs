using LD.Domain.Interfaces.Factura;
using LD.Domain.Modelos.Factura;
using LD.Domain.Modelos.Respuesta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    /// <author>Charlotte Rojas Padilla</author>
    /// <date>11/12/2025</date>
    /// <summary>
    /// Controlador encargado de gestionar las facturas del sistema.
    /// Aquí se manejan funciones como agregar y listar facturas en su encabezado.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IServicioFacturaEncabezado _servicioFacturaEncabezado;
        public FacturaController(IServicioFacturaEncabezado servicioacturaEncabezado)
        {
            _servicioFacturaEncabezado = servicioacturaEncabezado;

        }


        /// <summary>
        /// Agrega una nueva factura en su encabezado.
        /// Recibe los datos necesarios y devuelve una respuesta indicando si el proceso fue exitoso.
        /// </summary>
        /// <param name="solicitud">Información de la factura encabezadi que se desea registrar.</param>
        /// <returns>200 si se registró correctamente, 400 si hubo un problema.</returns>
        [HttpPost]
        [Route("AgregarFacturaEncabezado")]
        public async Task<IActionResult> AgregarFacturaEncabezado([FromBody] SAgregarFacturaEncabezado solicitud)
        {
            var response = await _servicioFacturaEncabezado.AgregarFacturaEncabezado(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return BadRequest("Hubo un problema al procesar la factura.");
        }


        /// <summary>
        /// Obtiene la lista de facturas registradas (encabezados).
        /// </summary>
        /// <returns>200 si se obtienen correctamente, 400 si ocurre un error.</returns>

        [HttpGet]
        [Route("ListarFacturaEncabezado")]
        public async Task<IActionResult> ListarFacturaEncabezado()
        {

            var response = await _servicioFacturaEncabezado.ListarFacturaEncabezado();

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return BadRequest();
        }

    }
}
