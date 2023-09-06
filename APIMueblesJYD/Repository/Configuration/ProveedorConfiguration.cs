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
                IdProveedor = new Guid("D0A22AF1-85B2-4EA6-9DAA-D0E321C07964"),
                RazonSocial = "La Guitarra, S.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("6E6D4C81-9958-44FF-BF39-838A4940C822"),
                RazonSocial = "Sol Dorado",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("303504FF-9312-4D2B-9D52-8D16EF08EB69"),
                RazonSocial = "Marena",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("0DD8F80D-4DF6-4FE9-BB72-28C7F5561E7C"),
                RazonSocial = "Juguetes Vikingos",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("BE2C0877-D46B-46E3-B793-CB5711F214C7"),
                RazonSocial = "Lima & Álvarez",
                Estado = 2,
            },
            new Proveedor
            {
                IdProveedor = new Guid("9ABC8D3B-3BD1-49C3-84E2-35C59447B0F3"),
                RazonSocial = "Arcos Dorados, C.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("7A1429E1-C547-4F00-A33A-D27D402BCA3F"),
                RazonSocial = "Carlos Fernández, E.I.R",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("E630FB8F-A34D-4B4D-9DE1-6808FE6A6EDF"),
                RazonSocial = "Chascomús, S.A",
                Estado = 1,
            },
            new Proveedor
            {
                IdProveedor = new Guid("7F740088-B8C7-4094-90B3-9C6385E58597"),
                RazonSocial = "Grupo Fernández S.A",
                Estado = 2,
            }
            );
        }
    }
}
