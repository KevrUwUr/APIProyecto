using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.HasData
            (
            new Proveedor
            {
                IdProveedor = 1,
                RazonSocial = "La Guitarra, S.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 2,
                RazonSocial = "Sol Dorado",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 3,
                RazonSocial = "Marena",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 4,
                RazonSocial = "Juguetes Vikingos",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 5,
                RazonSocial = "Lima & Álvarez",
                Estado = 2,
            },
            new Proveedor
            {
                IdProveedor = 6,
                RazonSocial = "Arcos Dorados, C.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 7,
                RazonSocial = "Carlos Fernández, E.I.R",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 8,
                RazonSocial = "Chascomús, S.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = 9,
                RazonSocial = "Grupo Fernández S.A",
                Estado = 2,
            }
            );
        }
    }
}
