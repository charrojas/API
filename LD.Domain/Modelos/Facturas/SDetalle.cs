/// <summary>
/// Autor: Charlotte Rojas  
/// Fecha: 11/12/2025  
/// Descripción: Representa el detalle de un artículo dentro de una factura,
/// incluyendo cantidad, precio, impuestos y total calculado.
/// </summary>
namespace LD.Domain.Modelos.Factura
{
    public class SDetalle
    {
        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

    }
}
