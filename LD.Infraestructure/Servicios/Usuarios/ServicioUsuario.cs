using LD.Domain.Interfaces.Usuario;
using LD.Domain.Modelos.Respuesta;
using LD.Domain.Modelos.Usuario;
using Microsoft.Extensions.Logging;

/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Servicio encargado de manejar la lógica relacionada con los usuarios.  
/// Permite agregar nuevos usuarios y autenticar a los existentes, controlando respuestas y manejo de errores.
/// </summary>
namespace LD.Infraestructure.Servicios.Usuario
{
    public class ServicioUsuario : IServicioUsuario
    {

        private readonly ILogger<ServicioUsuario> _logger;

        private readonly IRepositorioUsuario _repositorioUsuario;

        /// <summary>
        /// Constructor del servicio.  
        /// Inicializa el logger y el repositorio de usuarios para realizar operaciones.
        /// </summary>
        public ServicioUsuario(ILogger<ServicioUsuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        /// <summary>
        /// Agrega un nuevo usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Datos enviados con la información del usuario a registrar.</param>
        /// <returns>Respuesta con el usuario agregado y un mensaje de estado.</returns>
        public async Task<MRespuesta<MUsuario>> AgregarUsuario(SAgregarUsuario solicitud)
        {
            var respuesta = new MRespuesta<MUsuario>();

            try
            {
                var usuario = await _repositorioUsuario.AgregarUsuario(solicitud);

                if (usuario != null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                    respuesta.Dato = usuario;
                }
                else
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = "Error al agregar el usuario";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _logger.LogError(ex, "Error al agregar el usuario");
                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al agregar el usuario";
            }

            return respuesta;
        }


        /// <summary>
        /// Autentica un usuario verificando sus credenciales.
        /// </summary>
        /// <param name="solicitud">Datos enviados con el nombre de usuario y la contraseña.</param>
        /// <returns>Respuesta con los datos de autenticación, incluyendo un token simulado y el usuario autenticado.</returns>
        public async Task<MRespuesta<MAutenticacion>> AutenticarUsuario(SUsuario solicitud)
        {
            var respuesta = new MRespuesta<MAutenticacion>();

            try
            {
                var usuarioAutenticado = await _repositorioUsuario.AutenticarUsuario(solicitud);

                if (usuarioAutenticado != null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                    respuesta.Dato = new MAutenticacion { Token = "TOKEN123", Usuario = usuarioAutenticado };
                }
                else
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = "Error al AUTENTICAR el usuario";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al AUTENTICAR el usuario");
                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = "Error al AUTENTICAR el usuario";
            }

            return respuesta;
        }
    }
}
