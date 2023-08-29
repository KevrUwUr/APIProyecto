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
        }

        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<MetodoPago>? MetodoPagos { get; set; }
        public DbSet<Perdida>? Perdidas { get; set; }
        public DbSet<Perdida_Producto>? Perdida_Productos { get; set; }
        public DbSet<Proveedor>? Proveedors { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
    }
}
