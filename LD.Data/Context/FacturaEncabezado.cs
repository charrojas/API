using System;
using System.Collections.Generic;

namespace LD.Data.Context;

/// <summary>
/// Almacena las facturas de encabezado del sistema
/// </summary>
public partial class FacturaEncabezado
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public int CantidadArticulos { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();

    public virtual Usuario Usuario { get; set; } = null!;
}
