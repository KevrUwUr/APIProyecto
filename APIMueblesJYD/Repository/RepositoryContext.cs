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
            modelBuilder.ApplyConfiguration(new DetalleFacturaVentaConfiguration());
            modelBuilder.ApplyConfiguration(new Empleado_CargoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new FacturaCompraConfiguration());
            modelBuilder.ApplyConfiguration(new FacturaVentaConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoPreciosConfiguration());
        }



        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Empleado>? Empleados { get; set; }
        public DbSet<Empleado_Cargo>? Empleados_Cargos { get; set; }
        public DbSet<FacturaCompra>? FacturasCompras { get; set; }
        public DbSet<FacturaVenta>? FacturasVentas { get; set; }
        public DbSet<DetalleFacturaVenta>? DetallesFacturaVentas { get; set; }
        public DbSet<HistoricoPrecios>? HistoricosPrecios { get; set; }

    }
}
