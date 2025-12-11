/// <summary>
/// Autor: Charlotte Rojas  
/// Fecha: 11/12/2025  
/// Descripción: Modelo que define los atributos de la autenticación
/// de un usuario, incluyendo el token y los datos del usuario autenticado.
/// </summary>

namespace LD.Domain.Modelos.Usuario
{
    public class MAutenticacion
    {
        public string Token { get; set; } = string.Empty;

        public MUsuario? Usuario { get; set; }


    }
}
