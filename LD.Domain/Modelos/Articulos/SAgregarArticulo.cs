/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Modelo de solicitud utilizado para agregar un nuevo artículo al sistema,
/// registrando su nombre, descripción, precio y si aplica IVA.
/// </summary>
namespace LD.Domain.Modelos.Articulo
{
    public class SAgregarArticulo
    {
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public bool IVA { get; set; }

    }
}
