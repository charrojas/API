using LD.Domain.Interfaces.Factura;
using LD.Domain.Modelos.Factura;
using LD.Domain.Modelos.Respuesta;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Servicio encargado de manejar la lógica relacionada con las facturas.  
/// Permite agregar nuevas facturas y listar las existentes, controlando respuestas y manejo de errores.
/// </summary>
namespace LD.Infraestructure.Servicios.Factura
{
    public class ServicioFacturaEncabezado : IServicioFacturaEncabezado
    {
        private readonly ILogger<ServicioFacturaEncabezado> _logger;

        private readonly IRepositorioFacturaEncabezado _repositorioFacturaEncabezado;


        /// <summary>
        /// Constructor del servicio.  
        /// Inicializa el logger y el repositorio de facturas para realizar operaciones.
        /// </summary>
        public ServicioFacturaEncabezado(ILogger<ServicioFacturaEncabezado> logger, IRepositorioFacturaEncabezado repositorioFacturaEncabezado)
        {
            _logger = logger;
            _repositorioFacturaEncabezado = repositorioFacturaEncabezado;
        }

        /// <summary>
        /// Agrega una nueva factura al sistema, incluyendo su encabezado y detalles.
        /// </summary>
        /// <param name="solicitud">Datos enviados con la información de la factura a registrar.</param>
        /// <returns>Respuesta con la factura creada y un mensaje de estado.</returns>
        public async Task<MRespuesta<MFacturaEncabezado>> AgregarFacturaEncabezado(SAgregarFacturaEncabezado solicitud)
        {
            var respuesta = new MRespuesta<MFacturaEncabezado>();

            try
            {
                var factura = await _repositorioFacturaEncabezado.AgregarFacturaEncabezado(solicitud);

                if (factura == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = "Error al agregar la factura";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = factura;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar la factura");

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al agregar la factura";
            }

            return respuesta;
        }

        /// <summary>
        /// Obtiene la lista completa de facturas registradas en el sistema.
        /// </summary>
        /// <returns>Respuesta con la lista de facturas y un mensaje de estado.</returns>
        public async Task<MRespuesta<IEnumerable<MFacturaEncabezado>>> ListarFacturaEncabezado()
        {
            var respuesta = new MRespuesta<IEnumerable<MFacturaEncabezado>>();

            try
            {
                var facturas = await _repositorioFacturaEncabezado.ListarFacturaEncabezado();

                if (facturas == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = "Error al listar la factura";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = facturas;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar la factura");

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al listar la factura";
            }

            return respuesta;
        }
    }
}
