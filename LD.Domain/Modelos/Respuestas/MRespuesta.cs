/// <summary>
/// Autor: Charlotte Rojas Padilla
/// Fecha: 11/12/2025
/// Descripción: Modelo genérico utilizado para estandarizar las respuestas de los servicios,
/// incluyendo estado, mensaje y un dato opcional de tipo genérico.
/// </summary>
namespace LD.Domain.Modelos.Respuesta
{
    public class MRespuesta<T>
    {
        public EEstadoRespuesta EstadoRespuesta { get; set; }

        public string Mensaje { get; set; } = string.Empty;

        public T? Dato { get; set; }

    }
    public enum EEstadoRespuesta
    {
        Success = 200,
        NotFound = 404,
        Incorrect = 500,
        Error = 4,
        Unauthorized = 401,
    }

}
