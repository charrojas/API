/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Modelo solicitud utilizado para registrar el encabezado de una factura,
/// incluyendo información general como usuario, fecha, total y cantidad de artículos.
/// </summary>
namespace LD.Domain.Modelos.Factura
{
    public class SFacturaEncabezado
    {
        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
        public int CantidadArticulos { get; set; }
    }
}
