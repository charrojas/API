using System;
using System.Collections.Generic;

namespace LD.Data.Context;

/// <summary>
/// Almacena los usuarios del sistema.
/// </summary>
public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public virtual ICollection<FacturaEncabezado> FacturaEncabezados { get; set; } = new List<FacturaEncabezado>();
}
