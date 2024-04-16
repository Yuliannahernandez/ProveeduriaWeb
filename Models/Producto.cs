using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? CantidadDisponible { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual ICollection<DetallesFacturasCompra> DetallesFacturasCompras { get; set; } = new List<DetallesFacturasCompra>();

    public virtual ICollection<DetallesFacturasVentum> DetallesFacturasVenta { get; set; } = new List<DetallesFacturasVentum>();
}
