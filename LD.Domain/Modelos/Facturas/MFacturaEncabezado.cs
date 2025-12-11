/// <summary>
/// Autor: Charlotte Rojas Padilla
/// Fecha: 11/12/2025
/// Descripción: Modelo que define los atributos del encabezado de una factura, incluyendo información
/// del usuario que la genera, fecha, total general, cantidad de artículos y su listado de detalles.
/// </summary>

namespace LD.Domain.Modelos.Factura
{
    public class MFacturaEncabezado
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public int CantidadArticulos { get; set; }

        public ICollection<MFacturaDetalle> Detalle { get; set; } = new List<MFacturaDetalle>();


    }
}
