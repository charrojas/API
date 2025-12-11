/// <summary>
/// Autor: Charlotte Rojas Padilla
/// Fecha: 11/12/2025  
/// Descripción: Solicitud para agregar un encabezado de factura junto con su lista de detalles.
/// Contiene la información principal de la factura y los artículos asociados.
/// </summary>
namespace LD.Domain.Modelos.Factura
{
    public class SAgregarFacturaEncabezado
    {
        public SFacturaEncabezado FacturaEncabezado { get; set; }

        public ICollection<SDetalle>? Detalles { get; set; }


    }
}
