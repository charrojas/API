/// <summary>
/// Autor: Charlotte Rojas Padilla
/// Fecha: 11/12/2025
/// Descripción: Modelo que define los atributos un artículo dentro del sistema, incluyendo
/// información básica como código, nombre, descripción, precio e impuesto.
/// </summary>

namespace LD.Domain.Modelos.Articulo
{

    public class MArticulo
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public double Precio { get; set; }

        public bool IVA { get; set; }


    }
}
