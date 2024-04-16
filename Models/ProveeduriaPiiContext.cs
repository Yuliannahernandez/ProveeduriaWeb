using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace ProveeduriaWeb;

public partial class ProveeduriaPiiContext : DbContext
{
    public ProveeduriaPiiContext()
    {
    }

    public ProveeduriaPiiContext(DbContextOptions<ProveeduriaPiiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesFacturasCompra> DetallesFacturasCompras { get; set; }

    public virtual DbSet<DetallesFacturasVentum> DetallesFacturasVenta { get; set; }

    public virtual DbSet<FacturasCompra> FacturasCompras { get; set; }

    public virtual DbSet<FacturasVentum> FacturasVenta { get; set; }

    public virtual DbSet<ImpuestosMensuale> ImpuestosMensuales { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        // => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ProveeduriaWeb");

        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-P4I5O0J\\MIMSP;Initial Catalog=Proveeduria_PII;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__E005FBFF8AA74E0B");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("ID_Cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Cliente");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Direccion_Cliente");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Telefono_Cliente");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetallesFacturasCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__Detalles__BCDCDC9BD1AF214E");

            entity.ToTable("Detalles_Facturas_Compra");

            entity.Property(e => e.IdDetalleCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_Detalle_Compra");
            entity.Property(e => e.IdFacturaCompra).HasColumnName("ID_Factura_Compra");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Unitario");

            entity.HasOne(d => d.IdFacturaCompraNavigation).WithMany(p => p.DetallesFacturasCompras)
                .HasForeignKey(d => d.IdFacturaCompra)
                .HasConstraintName("FK__Detalles___ID_Fa__4CA06362");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesFacturasCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalles___ID_Pr__4D94879B");
        });

        modelBuilder.Entity<DetallesFacturasVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__Detalles__DF908C888EF0CF97");

            entity.ToTable("Detalles_Facturas_Venta");

            entity.Property(e => e.IdDetalleVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Detalle_Venta");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_Factura_Venta");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Unitario");

            entity.HasOne(d => d.IdFacturaVentaNavigation).WithMany(p => p.DetallesFacturasVenta)
                .HasForeignKey(d => d.IdFacturaVenta)
                .HasConstraintName("FK__Detalles___ID_Fa__534D60F1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesFacturasVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalles___ID_Pr__5441852A");
        });

        modelBuilder.Entity<FacturasCompra>(entity =>
        {
            entity.HasKey(e => e.IdFacturaCompra).HasName("PK__Facturas__F3E65D8D38990BF4");

            entity.ToTable("Facturas_Compra");

            entity.Property(e => e.IdFacturaCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_Factura_Compra");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("date")
                .HasColumnName("Fecha_Factura");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Monto_Total");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Factura");
            entity.Property(e => e.TotalImpuestosPagados)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Impuestos_Pagados");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.FacturasCompras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Facturas___ID_Pr__49C3F6B7");
        });

        modelBuilder.Entity<FacturasVentum>(entity =>
        {
            entity.HasKey(e => e.IdFacturaVenta).HasName("PK__Facturas__5FF041B10D9BFE1B");

            entity.ToTable("Facturas_Venta");

            entity.Property(e => e.IdFacturaVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Factura_Venta");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("date")
                .HasColumnName("Fecha_Factura");
            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Monto_Total");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Factura");
            entity.Property(e => e.TotalImpuestosCobrados)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Impuestos_Cobrados");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.FacturasVenta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Facturas___ID_Cl__5070F446");
        });

        modelBuilder.Entity<ImpuestosMensuale>(entity =>
        {
            entity.HasKey(e => e.IdImpuestoMensual).HasName("PK__Impuesto__FF87A52CFCB17B51");

            entity.ToTable("Impuestos_Mensuales");

            entity.Property(e => e.IdImpuestoMensual)
                .ValueGeneratedNever()
                .HasColumnName("ID_Impuesto_Mensual");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__9B4120E2BD47DA28");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("ID_Producto");
            entity.Property(e => e.CantidadDisponible).HasColumnName("Cantidad_Disponible");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Venta");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__7D65272F26966BD5");

            entity.Property(e => e.IdProveedor)
                .ValueGeneratedNever()
                .HasColumnName("ID_Proveedor");
            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Proveedor");
            entity.Property(e => e.DireccionProveedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Direccion_Proveedor");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Proveedor");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Telefono_Proveedor");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__202AD22059C19775");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("ID_Rol");
            entity.Property(e => e.EstadoRol).HasColumnName("Estado_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DE4431C5AF7B799A");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Funcionario");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Funcionario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__ID_Rol__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
