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
            modelBuilder.ApplyConfiguration(new ContactoEmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new ContactoProveedorConfiguration());
        }

        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<ContactoEmpleado> ContactoEmpleados {get; set;}
        public DbSet<ContactoProveedor> ContactoProveedores { get; set; }
        public DbSet<ContactoUsuario> contactoUsuarios { get; set; }
        public DbSet<DetalleFacturaCompra> DetalleFacturaCompras { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }

    }
}
