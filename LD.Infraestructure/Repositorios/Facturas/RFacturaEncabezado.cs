using AutoMapper;
using LD.Data.Context;
using LD.Domain.Interfaces.Factura;
using LD.Domain.Modelos.Factura;
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
/// relacionadas con el encabezado y los detalles de las facturas.  
/// Permite registrar nuevas facturas con sus ítems y consultar las facturas existentes.
/// </summary>s
namespace LD.Infraestructure.Repositorios.Factura
{
    public class RFacturaEncabezado : IRepositorioFacturaEncabezado
    {
        private readonly LogicalDataDbContext _context;

        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del repositorio.  
        /// Inicializa el contexto de base de datos y el mapeador utilizado para transformar entidades.
        /// </summary>
        public RFacturaEncabezado(LogicalDataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Agrega una nueva factura al sistema, incluyendo su encabezado y todos sus detalles.
        /// </summary>
        /// <param name="solicitud">Información enviada con el encabezado y los ítems de la factura.</param>
        /// <returns>El encabezado de factura creado, o null si la información no fue válida.</returns>
        public async Task<MFacturaEncabezado> AgregarFacturaEncabezado(SAgregarFacturaEncabezado solicitud)
        {
            if (!(solicitud.FacturaEncabezado is null || solicitud.Detalles is null))
            {
                var nuevaOrden = _mapper.Map<FacturaEncabezado>(solicitud.FacturaEncabezado);
                nuevaOrden.Total = solicitud.FacturaEncabezado.Total;
                nuevaOrden.CantidadArticulos = solicitud.FacturaEncabezado.CantidadArticulos;

                await _context.FacturaEncabezados.AddAsync(nuevaOrden);
                await _context.SaveChangesAsync();

                var ordenItems = _mapper.Map<FacturaDetalle[]>(solicitud.Detalles);
                ordenItems.Select(item =>
                {
                    item.FacturaEncabezadoId = nuevaOrden.Id;
                    item.Total = item.Precio * item.Cantidad;
                    return item;
                }).ToList();

                await _context.FacturaDetalles.AddRangeAsync(ordenItems);

                await _context.SaveChangesAsync();

                return _mapper.Map<MFacturaEncabezado>(nuevaOrden);
            }

            return null;
        }


        /// <summary>
        /// Obtiene la lista completa de facturas registradas, incluyendo sus detalles.
        /// </summary>
        public async Task<IEnumerable<MFacturaEncabezado>> ListarFacturaEncabezado()
        {
            var facturas = await _context.FacturaEncabezados.AsNoTracking().Include(o => o.FacturaDetalles).ToListAsync();

            return _mapper.Map<MFacturaEncabezado[]>(facturas);
        }
    }
}
