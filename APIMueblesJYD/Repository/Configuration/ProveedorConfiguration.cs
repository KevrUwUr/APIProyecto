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
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120001"),
                RazonSocial = "La Guitarra, S.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120002"),
                RazonSocial = "Sol Dorado",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120003"),
                RazonSocial = "Marena",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120004"),
                RazonSocial = "Juguetes Vikingos",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120005"),
                RazonSocial = "Lima & Álvarez",
                Estado = 2,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120006"),
                RazonSocial = "Arcos Dorados, C.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120007"),
                RazonSocial = "Carlos Fernández, E.I.R",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120008"),
                RazonSocial = "Chascomús, S.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new int("02d69c24-45fe-11ee-be56-0242ac120009"),
                RazonSocial = "Grupo Fernández S.A",
                Estado = 2,
            }
            );
        }
    }
}
