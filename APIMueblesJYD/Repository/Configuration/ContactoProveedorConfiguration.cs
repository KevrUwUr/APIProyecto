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
                    IdContactoProveedor = 1,
                    NombreProv = "Sam Raiden",
                    Telefono = 314526948,
                    Email = "ContactP1@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2020, 3, 13),
                    FechaBaja = new DateTime(2023, 5, 3),
                    IdProveedor = 1
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 2,
                    NombreProv = "Laura Montoya",
                    Telefono = 310987654,
                    Email = "ContactP2@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2022, 8, 20),
                    FechaBaja = new DateTime(2023, 6, 15),
                    IdProveedor = 2
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 3,
                    NombreProv = "Carlos Rivera",
                    Telefono = 317895623,
                    Email = "ContactP3@gmail.com",
                    Estado = 2,
                    FechaAlta = new DateTime(2021, 5, 10),
                    FechaBaja = new DateTime(2023, 4, 25),
                    IdProveedor = 3
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 4,
                    NombreProv = "Elena Gómez",
                    Telefono = 312589764,
                    Email = "ContactP4@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2023, 2, 18),
                    FechaBaja = new DateTime(2023, 7, 10),
                    IdProveedor = 4
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 5,
                    NombreProv = "Ana Martínez",
                    Telefono = 319875634,
                    Email = "ContactP5@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2022, 6, 5),
                    FechaBaja = new DateTime(2023, 6, 30),
                    IdProveedor = 5
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 6,
                    NombreProv = "Juan Soto",
                    Telefono = 316547896,
                    Email = "ContactP6@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2021, 9, 12),
                    FechaBaja = new DateTime(2023, 7, 20),
                    IdProveedor = 6
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 7,
                    NombreProv = "María Salas",
                    Telefono = 318564237,
                    Email = "ContactP7@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2020, 12, 8),
                    FechaBaja = new DateTime(2023, 6, 5),
                    IdProveedor = 7
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 8,
                    NombreProv = "Luis Gutiérrez",
                    Telefono = 313258741,
                    Email = "ContactP8@gmail.com",
                    Estado = 2,
                    FechaAlta = new DateTime(2021, 3, 25),
                    FechaBaja = new DateTime(2023, 6, 20),
                    IdProveedor = 8
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = 8,
                    NombreProv = "Fernando López",
                    Telefono = 317896542,
                    Email = "ContactP9@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateTime(2022, 4, 17),
                    FechaBaja = new DateTime(2023, 7, 15),
                    IdProveedor = 8
                }
            );
        }
    }
}
