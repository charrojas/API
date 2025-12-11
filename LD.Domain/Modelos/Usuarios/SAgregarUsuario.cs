/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Modelo solicitud utilizado para registrar un nuevo usuario,
/// incluyendo información personal y credenciales de acceso.
/// </summary>
namespace LD.Domain.Modelos.Usuario
{
    public class SAgregarUsuario
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;

    }
}
