using System.ComponentModel.DataAnnotations;

/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Modelo solicitud utilizado para autenticar un usuario en el sistema,
/// solicitando únicamente las credenciales necesarias para iniciar sesión.
/// </summary>
/// 

namespace LD.Domain.Modelos.Usuario
{
    public class SUsuario
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Contrasenia { get; set; } = string.Empty;

    }
}
