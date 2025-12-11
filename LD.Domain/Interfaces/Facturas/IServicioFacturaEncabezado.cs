using LD.Domain.Modelos.Factura;
using LD.Domain.Modelos.Respuesta;


/// <author>Charlotte Rojas Padilla</author>
/// <date>11/12/2025</date>
/// <summary>
/// Interfaz del servicio de factura encabezado.
/// </summary>
namespace LD.Domain.Interfaces.Factura
{
    public interface IServicioFacturaEncabezado
    {

        /// <summary>
        /// Agrega un nuevo encabezado de factura utilizando la información enviada.
        /// </summary>
        /// <param name="solicitud">Datos necesarios para registrar la factura.</param>
        /// <returns>Una respuesta indicando el resultado del proceso.</returns>
        public Task<MRespuesta<MFacturaEncabezado>> AgregarFacturaEncabezado(SAgregarFacturaEncabezado solicitud);

        /// <summary>
        /// Obtiene la lista de encabezados de factura registrados.
        /// </summary>
        /// <returns>Una respuesta con todas las facturas disponibles.</returns>
        public Task<MRespuesta<IEnumerable<MFacturaEncabezado>>> ListarFacturaEncabezado();
    
    }
}
