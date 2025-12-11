using System;
using System.Collections.Generic;

namespace LD.Data.Context;

/// <summary>
/// Almacena las factura detalle de las facturas del sistema.
/// </summary>
public partial class FacturaDetalle
{
    public int Id { get; set; }

    public int FacturaEncabezadoId { get; set; }

    public int ArticuloId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal IVA { get; set; }

    public decimal Total { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;

    public virtual FacturaEncabezado FacturaEncabezado { get; set; } = null!;
}
