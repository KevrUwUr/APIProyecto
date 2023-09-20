using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Configuration
{
    public class ContactoProveedorConfiguration : IEntityTypeConfiguration<ContactoProveedor>
    {
        public void Configure(EntityTypeBuilder<ContactoProveedor> builder)
        {
            builder.HasData
            (
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("11B72F91-F5A9-4E6A-8C48-624A0729941D"),
                    NombreProv = "Sam Raiden",
                    Telefono = 314526948,
                    Email = "ContactP1@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2020, 3, 13),
                    FechaBaja = new DateTime(2023, 5, 3),
                    IdProveedor = new Guid("D0A22AF1-85B2-4EA6-9DAA-D0E321C07964")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("42DC025F-3E80-4768-930D-6EF208FAAC3E"),
                    NombreProv = "Laura Montoya",
                    Telefono = 310987654,
                    Email = "ContactP2@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2022, 8, 20),
                    FechaBaja = new DateTime(2023, 6, 15),
                    IdProveedor = new Guid("6E6D4C81-9958-44FF-BF39-838A4940C822")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("6299AE61-9578-4898-A9D6-8697A84B9C84"),
                    NombreProv = "Carlos Rivera",
                    Telefono = 317895623,
                    Email = "ContactP3@gmail.com",
                    Estado = 2,
                    FechaAlta = new DateTime(2021, 5, 10),
                    FechaBaja = new DateTime(2023, 4, 25),
                    IdProveedor = new Guid("303504FF-9312-4D2B-9D52-8D16EF08EB69")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("D6E22B76-D99F-4376-9DEE-B542EE7AA729"),
                    NombreProv = "Elena Gómez",
                    Telefono = 312589764,
                    Email = "ContactP4@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2023, 2, 18),
                    FechaBaja = new DateTime(2023, 7, 10),
                    IdProveedor = new Guid("0DD8F80D-4DF6-4FE9-BB72-28C7F5561E7C")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("AAEC0A58-444B-48BC-9291-6AAA50F27008"),
                    NombreProv = "Ana Martínez",
                    Telefono = 319875634,
                    Email = "ContactP5@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2022, 6, 5),
                    FechaBaja = new DateTime(2023, 6, 30),
                    IdProveedor = new Guid("BE2C0877-D46B-46E3-B793-CB5711F214C7")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("136AD92B-614D-41FA-90D7-1F0F4A6C6D6E"),
                    NombreProv = "Juan Soto",
                    Telefono = 316547896,
                    Email = "ContactP6@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2021, 9, 12),
                    FechaBaja = new DateTime(2023, 7, 20),
                    IdProveedor = new Guid("9ABC8D3B-3BD1-49C3-84E2-35C59447B0F3")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("8A91EBD3-D855-4BE0-AF6D-5DD91D3A4811"),
                    NombreProv = "María Salas",
                    Telefono = 318564237,
                    Email = "ContactP7@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2020, 12, 8),
                    FechaBaja = new DateTime(2023, 6, 5),
                    IdProveedor = new Guid("7A1429E1-C547-4F00-A33A-D27D402BCA3F")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("35CE9EA9-6AED-459E-9FDE-C02B768DDBEC"),
                    NombreProv = "Luis Gutiérrez",
                    Telefono = 313258741,
                    Email = "ContactP8@gmail.com",
                    Estado = 2,
                    FechaAlta = new DateTime(2021, 3, 25),
                    FechaBaja = new DateTime(2023, 6, 20),
                    IdProveedor = new Guid("E630FB8F-A34D-4B4D-9DE1-6808FE6A6EDF")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("6F562B34-CEE6-4684-BE79-4A3638DE30F0"),
                    NombreProv = "Fernando López",
                    Telefono = 317896542,
                    Email = "ContactP9@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2022, 4, 17),
                    FechaBaja = new DateTime(2023, 7, 15),
                    IdProveedor = new Guid("7F740088-B8C7-4094-90B3-9C6385E58597")
                }
            );
        }
    }
}
