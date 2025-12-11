/// <summary>
/// Autor: Charlotte Rojas  
/// Fecha: 11/12/2025  
/// Descripción: Modelo que define los atributos de un usuario dentro del sistema,
/// incluyendo datos personales y credenciales de acceso.
/// </summary>

namespace LD.Domain.Modelos.Usuario
{
    public class MUsuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;


    }
}
