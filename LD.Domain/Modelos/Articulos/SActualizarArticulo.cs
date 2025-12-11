
/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Modelo utilizado para actualizar la información de un artículo,
/// permitiendo modificar su código, nombre, descripción, precio y si aplica IVA.
/// </summary>
namespace LD.Domain.Modelos.Articulo
{
    public class SActualizarArticulo
    {
        public string Codigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public bool IVA { get; set; }

    }
}
