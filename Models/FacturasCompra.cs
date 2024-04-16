using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class FacturasCompra
{
    public int IdFacturaCompra { get; set; }

    public int? IdProveedor { get; set; }

    public DateTime? FechaFactura { get; set; }

    public string? NumeroFactura { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? TotalImpuestosPagados { get; set; }

    public virtual ICollection<DetallesFacturasCompra> DetallesFacturasCompras { get; set; } = new List<DetallesFacturasCompra>();

    public virtual Proveedore? IdProveedorNavigation { get; set; }
}
