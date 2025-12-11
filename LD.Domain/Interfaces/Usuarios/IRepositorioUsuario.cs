using LD.Domain.Modelos.Usuario;


/// <author>Charlotte Rojas Padilla</author>
/// <date>11/12/2025</date>
/// <summary>
/// Interfaz del repositorio de usuario.
/// </summary>
namespace LD.Domain.Interfaces.Usuario
{
    public interface IRepositorioUsuario
    {

        /// <summary>
        /// Autentica a un usuario utilizando las credenciales enviadas.
        /// </summary>
        /// <param name="solicitud">Datos necesarios para validar al usuario.</param>
        /// <returns>La información del usuario autenticado.</returns>
        public Task<MUsuario> AutenticarUsuario(SUsuario solicitud);


        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="solicitud">Información requerida para crear el usuario.</param>
        /// <returns>El usuario registrado.</returns>
        public Task<MUsuario> AgregarUsuario(SAgregarUsuario solicitud);
    }
}
