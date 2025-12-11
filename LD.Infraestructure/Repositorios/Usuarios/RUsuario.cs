using AutoMapper;
using LD.Data.Context;
using LD.Domain.Interfaces.Usuario;
using LD.Domain.Modelos.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Repositorio encargado de manejar las operaciones de acceso a datos 
/// relacionadas con los usuarios.  
/// Permite agregar nuevos usuarios y autenticar a los existentes.
/// </summary>
namespace LD.Infraestructure.Repositorios.Usuarios
    {
        public class RUsuario : IRepositorioUsuario
        {
            private readonly LogicalDataDbContext _context;

            private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del repositorio.  
        /// Inicializa el contexto de base de datos y el mapeador utilizado para transformar entidades.
        /// </summary>
        public RUsuario(LogicalDataDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


        /// <summary>
        /// Agrega un nuevo usuario al sistema si no existe otro con el mismo nombre de usuario.
        /// </summary>
        /// <param name="solicitud">Información enviada con los datos del usuario a registrar.</param>
        /// <returns>El usuario creado, o null si ya existía un usuario con el mismo nombre.</returns>

        public async Task<MUsuario> AgregarUsuario(SAgregarUsuario solicitud)
            {
                var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == solicitud.Username);

                if (usuarioExistente == null)
                {
                    var usuarioNuevo = _mapper.Map<Usuario>(solicitud);

                    var usuarioRespuesta = _mapper.Map<MUsuario>(solicitud);

                    await _context.Usuarios.AddAsync(usuarioNuevo);
                    await _context.SaveChangesAsync();

                    usuarioRespuesta.Id = usuarioNuevo.Id;

                    return usuarioRespuesta;
                }

                return null;
            }

        /// <summary>
        /// Autentica a un usuario verificando que el nombre de usuario y la contraseña sean correctos.
        /// </summary>
        /// <param name="solicitud">Información enviada con el nombre de usuario y la contraseña.</param>
        /// <returns>El usuario autenticado, o null si las credenciales no son correctas.</returns>
        public async Task<MUsuario> AutenticarUsuario(SUsuario solicitud)
            {
                var contraseniaBytes = Encoding.UTF8.GetBytes(solicitud.Contrasenia);

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Username == solicitud.Username && u.Contrasenia == solicitud.Contrasenia);

                return _mapper.Map<MUsuario>(usuario);
            }
        }
    }
