using System;
using System.Collections.Generic;

namespace ProveeduriaWeb;

public partial class Role
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public bool? EstadoRol { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
