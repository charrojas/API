using AutoMapper;
using LD.Data.Context;
using LD.Domain.Modelos.Articulo;
using LD.Domain.Modelos.Factura;
using LD.Domain.Modelos.Usuario;


/// <summary>
/// Autor: Charlotte Rojas Padilla  
/// Fecha: 11/12/2025  
/// Descripción: Perfil de AutoMapper encargado de definir las conversiones entre
/// los modelos de dominio, las entidades de base de datos y los modelos de solicitud.
/// </summary>

namespace LD.Infraestructure.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<Usuario, MUsuario>().ReverseMap();
            CreateMap<SAgregarUsuario, MUsuario>().ReverseMap();
            CreateMap<Usuario, SAgregarUsuario>().ReverseMap();

            CreateMap<SFacturaEncabezado, FacturaEncabezado>().ReverseMap();
            CreateMap<MFacturaEncabezado, FacturaEncabezado>().ReverseMap();

            CreateMap<SDetalle, FacturaDetalle>().ReverseMap();
            CreateMap<MFacturaDetalle, FacturaDetalle>().ReverseMap();

            CreateMap<MArticulo, Articulo>().ReverseMap();
            CreateMap<SAgregarArticulo, Articulo>().ReverseMap();
            CreateMap<Articulo, SAgregarArticulo>().ReverseMap();
            CreateMap<SAgregarArticulo, MArticulo>().ReverseMap();

        }
    }
}
