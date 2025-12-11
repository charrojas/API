using LD.Data.Context;
using LD.Domain.Interfaces.Usuario;
using LD.Domain.Interfaces.Factura;
using LD.Domain.Interfaces.Articulo;
using LD.Infraestructure.Servicios.Usuario;
using LD.Infraestructure.Servicios.Factura;
using LD.Infraestructure.Servicios.Articulo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LD.Infraestructure.Mapper;
using LD.Infraestructure.Repositorios.Usuarios;
using LD.Infraestructure.Repositorios.Articulos;
using LD.Infraestructure.Repositorios.Factura;

namespace LD.Infraestructure
{

    /// <summary>
    /// Autor: Charlotte Rojas Padilla  
    /// Fecha: 11/12/2025  
    /// Descripción: Clase de configuración de dependencias del proyecto.  
    /// Registra los servicios, repositorios, el contexto de base de datos y AutoMapper 
    /// en el contenedor de inyección de dependencias.
    /// </summary>
    public static class ConfiguracionDependencias
    {

        /// <summary>
        /// Configura los servicios de la API, incluyendo contexto, mapeos y dependencias.
        /// </summary>
        /// <param name="services">Colección de servicios donde se registran las dependencias.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <returns>La colección de servicios actualizada con las dependencias registradas.</returns>
        public static IServiceCollection ConfigurarAPI(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<LogicalDataDbContext>(optionsLifetime: ServiceLifetime.Transient);
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());

            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IRepositorioUsuario, RUsuario>();
            services.AddScoped<IServicioArticulo, ServicioArticulo>();
            services.AddScoped<IRepositorioArticulo, RArticulo>();
            services.AddScoped<IServicioFacturaEncabezado, ServicioFacturaEncabezado>();
            services.AddScoped<IRepositorioFacturaEncabezado, RFacturaEncabezado>();


            return services;
        }

    }
}
