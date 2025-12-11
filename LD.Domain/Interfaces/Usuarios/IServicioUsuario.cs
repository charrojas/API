using LD.Domain.Modelos.Respuesta;
using LD.Domain.Modelos.Usuario;

/// <author>Charlotte Rojas Padilla</author>
/// <date>11/12/2025</date>
/// <summary>
/// Interfaz del servicio de usuario.
/// </summary>
namespace LD.Domain.Interfaces.Usuario
{
    public interface IServicioUsuario
    {

        /// <summary>
        /// Registra un nuevo usuario en el sistema con la información enviada.
        /// </summary>
        /// <param name="solicitud">Datos necesarios para agregar el usuario.</param>
        /// <returns>Una respuesta con la información del usuario registrado.</returns>
        public Task<MRespuesta<MUsuario>> AgregarUsuario(SAgregarUsuario solicitud);



        /// <summary>
        /// Autentica a un usuario validando sus credenciales.
        /// </summary>
        /// <param name="solicitud">Credenciales del usuario que desea iniciar sesión.</param>
        /// <returns>Una respuesta con los datos de autenticación generados.</returns>
        public Task<MRespuesta<MAutenticacion>> AutenticarUsuario(SUsuario solicitud);

    
}
}
