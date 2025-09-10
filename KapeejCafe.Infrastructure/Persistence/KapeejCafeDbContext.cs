using KapeejCafe.Domain.Entities;
using KapeejCafe.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.Persistence
{
    public class KapeejCafeDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public KapeejCafeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public DbSet<ProductoIngrediente> ProductoIngredientes { get; set; } = null!;
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoDetalle> PedidoDetalles => Set<PedidoDetalle>();
        public DbSet<Promocion> Promociones => Set<Promocion>();
        public DbSet<HistorialPuntos> HistorialPuntos => Set<HistorialPuntos>();

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(b =>
            {
                // 1–1 opcional con Cliente usando FK en Cliente.AppUserId
                b.HasOne(u => u.Cliente)
                 .WithOne() // Cliente no conoce AppUser (para no romper Domain)
                 .HasForeignKey<Cliente>(c => c.AppUserId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<RefreshToken>(b =>
            {
                b.HasKey(rt => rt.Id);
                b.HasOne(rt => rt.AppUser)
                 .WithMany(u => u.RefreshTokens)
                 .HasForeignKey(rt => rt.AppUserId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasIndex(rt => new { rt.AppUserId, rt.Token }).IsUnique();
            });



            builder.Entity<Cliente>(b =>
            {
                b.HasKey(c => c.Id);
                b.HasIndex(c => c.AppUserId).IsUnique(); // 1–1 con usuario (si requiere estrictamente 1–1)
                b.Property(c => c.Nombre).HasMaxLength(100).IsRequired();
                b.Property(c => c.Apellido).HasMaxLength(100);
                b.Property(c => c.Telefono).HasMaxLength(30);
            });

            // Cliente
            builder.Entity<Cliente>(b =>
            {
                b.HasKey(c => c.Id);
                b.HasIndex(c => c.AppUserId).IsUnique(); // 1–1 con usuario (si requiere estrictamente 1–1)
                b.Property(c => c.Nombre).HasMaxLength(100).IsRequired();
                b.Property(c => c.Apellido).HasMaxLength(100);
                b.Property(c => c.Telefono).HasMaxLength(30);
            });

            // Producto
            builder.Entity<Producto>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Nombre).HasMaxLength(150).IsRequired();
                b.Property(p => p.PrecioBase).HasColumnType("decimal(18,2)");
            });

            // Ingrediente
            builder.Entity<Ingrediente>(b =>
            {
                b.HasKey(i => i.Id);
                b.Property(i => i.Nombre).HasMaxLength(150).IsRequired();
            });

            // ProductoIngrediente (N–N)
            builder.Entity<ProductoIngrediente>(b =>
            {
                b.HasKey(pi => new { pi.ProductoId, pi.IngredienteId });
                b.HasOne(pi => pi.Producto)
                 .WithMany(p => p.Ingredientes)
                 .HasForeignKey(pi => pi.ProductoId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(pi => pi.Ingrediente)
                 .WithMany(i => i.Productos)
                 .HasForeignKey(pi => pi.IngredienteId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // Pedido
            builder.Entity<Pedido>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Total).HasColumnType("decimal(18,2)");
                b.HasOne(p => p.Cliente)
                 .WithMany(c => c.Pedidos)
                 .HasForeignKey(p => p.ClienteId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // PedidoDetalle
            builder.Entity<PedidoDetalle>(b =>
            {
                b.HasKey(d => d.Id);
                b.Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");
                b.Ignore(d => d.Subtotal); // Derivado
                b.HasOne(d => d.Pedido)
                 .WithMany(p => p.Detalles)
                 .HasForeignKey(d => d.PedidoId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(d => d.Producto)
                 .WithMany()
                 .HasForeignKey(d => d.ProductoId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // HistorialPuntos
            builder.Entity<HistorialPuntos>(b =>
            {
                b.HasKey(h => h.Id);
                b.HasOne(h => h.Cliente)
                 .WithMany(c => c.HistorialPuntos)
                 .HasForeignKey(h => h.ClienteId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(h => h.Pedido)
                 .WithMany()
                 .HasForeignKey(h => h.PedidoId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            // Promocion
            builder.Entity<Promocion>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Nombre).HasMaxLength(150).IsRequired();
            });

        }
    }
}
