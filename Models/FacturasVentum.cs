using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class FacturasVentum
{
    public int IdFacturaVenta { get; set; }

    public int? IdCliente { get; set; }

    public DateTime? FechaFactura { get; set; }

    public string? NumeroFactura { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? TotalImpuestosCobrados { get; set; }

    public virtual ICollection<DetallesFacturasVentum> DetallesFacturasVenta { get; set; } = new List<DetallesFacturasVentum>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
