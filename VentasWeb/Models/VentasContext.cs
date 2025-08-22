using Microsoft.EntityFrameworkCore;

namespace VentasWeb.Models
{
    public class VentasContext : DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CodigoCategoria);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);

                entity.HasOne(p => p.Categoria)
                      .WithMany(c => c.Productos)
                      .HasForeignKey(p => p.CodigoCategoria)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.CodigoVenta);
                entity.Property(e => e.Fecha).IsRequired();

                entity.HasOne(v => v.Producto)
                      .WithMany(p => p.Ventas)
                      .HasForeignKey(v => v.CodigoProducto)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}