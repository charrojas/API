using LD.Domain.Interfaces.Usuario;
using LD.Domain.Modelos.Respuesta;
using LD.Domain.Modelos.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <author>Charlotte Rojas Padilla</author>
    /// <date>11/12/2025</date>
    /// <summary>
    /// Controlador encargado de manejar las acciones relacionadas con los usuarios.
    /// Aquí se gestionan funciones como autenticación y registro de nuevos usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicioUsuario _servicioUsuario;

        private readonly IConfiguration _configuration;

        /// <param name="servicioUsuario">Servicio de usuarios</param>
        public UsuarioController(IServicioUsuario servicioUsuario, IConfiguration configuration)
        {
            _servicioUsuario = servicioUsuario;
            _configuration = configuration;
        }

        /// <summary>
        /// Autentica a un usuario utilizando sus credenciales.
        /// Si las credenciales son correctas, devuelve la información correspondiente.
        /// </summary>
        /// <param name="solicitud">Datos del usuario para iniciar sesión.</param>
        /// <returns>200 si se autentica, 401 si las credenciales no son válidas.</returns>
        [HttpPost]
        [Route("AutenticarUsuario")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] SUsuario solicitud)
        {

            var response = await _servicioUsuario.AutenticarUsuario(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return Unauthorized(response);
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// Recibe los datos necesarios y devuelve la respuesta del proceso.
        /// </summary>
        /// <param name="solicitud">Información del usuario que se desea agregar.</param>
        /// <returns>200 si el usuario se registra correctamente, 400 si ocurre un error.</returns>
        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<IActionResult> AgregarUsuario([FromBody] SAgregarUsuario solicitud)
        {
            var response = await _servicioUsuario.AgregarUsuario(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
