using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class DetallesFacturasVentum
{
    public int IdDetalleVenta { get; set; }

    public int? IdFacturaVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual FacturasVentum? IdFacturaVentaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
