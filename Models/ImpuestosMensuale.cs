using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class ImpuestosMensuale
{
    public int IdImpuestoMensual { get; set; }

    public int? Mes { get; set; }

    public int? Año { get; set; }

    public decimal? Monto { get; set; }

    public string? Tipo { get; set; }
}
