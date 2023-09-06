using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ContactoEmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new ContactoProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new ContactoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleFacturaCompraConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleFacturaVentaConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoCargoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new FacturaCompraConfiguration());
            modelBuilder.ApplyConfiguration(new FacturaVentaConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoPreciosConfiguration());
            modelBuilder.ApplyConfiguration(new MetodoPagoConfiguration());
            modelBuilder.ApplyConfiguration(new PerdidaConfiguration());
            modelBuilder.ApplyConfiguration(new PerdidaProductoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new ProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            //modelBuilder
            //.Entity<Perdida_Producto>(
            //    eb =>
            //    {
            //        eb.HasNoKey();
            //    });

            //modelBuilder
            //.Entity<EmpleadoCargo>(
            //    eb =>
            //    {
            //        eb.HasNoKey();
            //    });

            modelBuilder.Entity<EmpleadoCargo>()
                .HasKey(t => new { t.EmpleadoId, t.CargoId });
            modelBuilder.Entity<PerdidaProducto>()
                .HasKey(t => new { t.IdPerdida, t.ProductoId });

        }



        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<ContactoEmpleado>? ContactoEmpleados { get; set; }
        public DbSet<ContactoProveedor>? ContactoProveedorConfigurations { get; set; }
        public DbSet<ContactoUsuario>? ContactoUsuarioConfigurations { get; set; }
        public DbSet<Empleado>? Empleados { get; set; }
        public DbSet<EmpleadoCargo>? EmpleadoCargos { get; set; }
        public DbSet<FacturaCompra>? FacturasCompras { get; set; }
        public DbSet<FacturaVenta>? FacturasVentas { get; set; }
        public DbSet<DetalleFacturaVenta>? DetallesFacturaVentas { get; set; }
        public DbSet<HistoricoPrecios>? HistoricosPrecios { get; set; }
        public DbSet<MetodoPago>? MetodoPagos { get; set; }
        public DbSet<Perdida>? Perdida { get; set; }
        public DbSet<PerdidaProducto>? Perdida_Productos { get; set; }
        public DbSet<Producto>? Productos { get; set; }
        public DbSet<Proveedor>? Proveedores { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
    }
}