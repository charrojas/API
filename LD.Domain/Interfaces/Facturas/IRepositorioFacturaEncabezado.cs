using LD.Domain.Modelos.Factura;

/// <author>Charlotte Rojas Padilla</author>
/// <date>11/12/2025</date>
/// <summary>
/// Interfaz del repositorio de factura encabezado.
/// </summary>
namespace LD.Domain.Interfaces.Factura
{
    public interface IRepositorioFacturaEncabezado
    {

        /// <summary>
        /// Agrega un nuevo encabezado de factura utilizando la información recibida.
        /// </summary>
        /// <param name="solicitud">Datos necesarios para registrar la factura.</param>
        /// <returns>El encabezado de la factura registrada.</returns>
        public Task<MFacturaEncabezado> AgregarFacturaEncabezado(SAgregarFacturaEncabezado solicitud);


        /// <summary>
        /// Obtiene la lista de facturas registradas en su encabezado.
        /// </summary>
        /// <returns>Una colección con todas las facturas almacenadas.</returns>
        public Task<IEnumerable<MFacturaEncabezado>> ListarFacturaEncabezado();
    }

}