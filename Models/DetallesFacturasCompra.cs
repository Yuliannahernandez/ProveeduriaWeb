using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class DetallesFacturasCompra
{
    public int IdDetalleCompra { get; set; }

    public int? IdFacturaCompra { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual FacturasCompra? IdFacturaCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
