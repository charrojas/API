using AutoMapper;
using LD.Data.Context;
using LD.Domain.Interfaces.Articulo;
using LD.Domain.Modelos.Articulo;  
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Repositorio encargado de gestionar las operaciones de acceso a datos 
/// relacionadas con los artículos, incluyendo creación, actualización, eliminación y consulta.
/// </summary>

namespace LD.Infraestructure.Repositorios.Articulos
{
    public class RArticulo : IRepositorioArticulo
    {
        private readonly LogicalDataDbContext _context; 
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del repositorio de artículos.  
        /// Inicializa el contexto de base de datos y el mapeador.
        /// </summary>
        public RArticulo(LogicalDataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Actualiza los datos de un artículo existente según el código proporcionado.
        /// </summary>
        public async Task<bool> ActualizarArticulo(SActualizarArticulo solicitud)
        {
            var articulo = await _context.Articulos.FirstOrDefaultAsync(p => p.Codigo == solicitud.Codigo);

            if (articulo != null)
            {
                articulo.Descripcion = solicitud.Descripcion;
                articulo.Nombre = solicitud.Nombre;
                articulo.Precio = solicitud.Precio;
                articulo.IVA = solicitud.IVA;

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Agrega un nuevo artículo a la base de datos, generando un código único.
        /// </summary>
        public async Task<MArticulo> AgregarArticulo(SAgregarArticulo solicitud)
        {
            var ArticuloNuevo = _mapper.Map<Articulo>(solicitud);
            var codigoCreado = "Art-" + Guid.NewGuid().ToString().Substring(0, 10);
            var Articulo = _mapper.Map<MArticulo>(solicitud);

            if (await _context.Articulos.AnyAsync(p => p.Codigo == ArticuloNuevo.Codigo || p.Nombre.ToLower() == solicitud.Nombre.ToLower()))
            {
                ArticuloNuevo.Codigo = "";
            }
            else
            {
                ArticuloNuevo.Codigo = codigoCreado;

                await _context.Articulos.AddAsync(ArticuloNuevo);
                await _context.SaveChangesAsync();

                Articulo.Id = ArticuloNuevo.Id;
                Articulo.Codigo = ArticuloNuevo.Codigo;
            }

            return Articulo;
        }


        /// <summary>
        /// Elimina un artículo por su ID y retorna el artículo eliminado.
        /// </summary>
        public async Task<MArticulo> BorrarArticulo(int id)
        {
            var producto = await _context.Articulos.FirstOrDefaultAsync(p => p.Id == id);

            if (producto != null)
            {
                _context.Articulos.Remove(producto);
                await _context.SaveChangesAsync();

                return _mapper.Map<MArticulo>(producto);
            }

            return null;
        }

        /// <summary>
        /// Obtiene la lista completa de artículos registrados en el sistema.
        /// </summary>
        public async Task<IEnumerable<MArticulo>> ListarArticulos()
        {
            var productos = await _context.Articulos.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<MArticulo>>(productos);
        }
    }
}
