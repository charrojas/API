
/// <summary>
/// Autor: Charlotte Rojas Padilla
/// Fecha: 11/12/2025
/// Descripción: Modelo que define los atributos de una factura, incluyendo el artículo,
/// cantidad, precio, impuestos y total correspondiente al cálculo línea por línea.
/// </summary>

namespace LD.Domain.Modelos.Factura
{
    public class MFacturaDetalle
    {
        public int Id { get; set; }

        public int FacturaEncabezadoId { get; set; }

        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }


    }
}
