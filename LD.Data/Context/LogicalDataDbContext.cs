using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LD.Data.Context;

public partial class LogicalDataDbContext : DbContext
{
    public LogicalDataDbContext()
    {
    }

    public LogicalDataDbContext(DbContextOptions<LogicalDataDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    public virtual DbSet<FacturaEncabezado> FacturaEncabezados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=CHARLOTTE\\SQLEXPRESS; Database=LogicalDataDB; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkArticuloId");

            entity.ToTable("Articulo", "Inventarios", tb => tb.HasComment("Almacena los productos del sistema."));

            entity.HasIndex(e => e.Codigo, "UqArticuloCodigo").IsUnique();

            entity.Property(e => e.Codigo).HasMaxLength(25);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.IVA).HasColumnName("IVA");
            entity.Property(e => e.Nombre).HasMaxLength(25);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkFacturaDetalle");

            entity.ToTable("FacturaDetalle", "Ventas", tb => tb.HasComment("Almacena las factura detalle de las facturas del sistema."));

            entity.Property(e => e.IVA)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("IVA");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Articulo).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ArticuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkFacturaDetalleArticuloId");

            entity.HasOne(d => d.FacturaEncabezado).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.FacturaEncabezadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkFacturaDetalleFacturaEncabezadoId");
        });

        modelBuilder.Entity<FacturaEncabezado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkFacturaEncabezadoId");

            entity.ToTable("FacturaEncabezado", "Ventas", tb => tb.HasComment("Almacena las facturas del encabezado del sistema"));

            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.FacturaEncabezados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkFacturaEncabezadoUsuarioId");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkUsuarioId");

            entity.ToTable("Usuario", "Usuarios", tb => tb.HasComment("Almacena los usuarios del sistema."));

            entity.HasIndex(e => e.Nombre, "UqNombre").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(25);
            entity.Property(e => e.Contrasenia).HasMaxLength(64);
            entity.Property(e => e.Nombre).HasMaxLength(25);
            entity.Property(e => e.Username).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
