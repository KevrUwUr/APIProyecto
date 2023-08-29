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
                    IdContactoProveedor = new Guid("c6d84c8a-5a75-4c97-b095-5429214a5acf"),
                    NombreProv = "Sam Raiden",
                    Telefono = 314526948,
                    Email = "ContactP1@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2020, 3, 13),
                    FechaBaja = new DateOnly(2023, 5, 3),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120004")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("b048792f-384d-46bb-b2f1-2aeb775ebf75"),
                    NombreProv = "Laura Montoya",
                    Telefono = 310987654,
                    Email = "ContactP2@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2022, 8, 20),
                    FechaBaja = new DateOnly(2023, 6, 15),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120001")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("d3d11e89-1d0c-4e92-9f6b-07d17b020cf7"),
                    NombreProv = "Carlos Rivera",
                    Telefono = 317895623,
                    Email = "ContactP3@gmail.com",
                    Estado = 2,
                    FechaAlta = new DateOnly(2021, 5, 10),
                    FechaBaja = new DateOnly(2023, 4, 25),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120003")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("f7a5b2a3-4a1e-4291-8f57-b6a740a4f56b"),
                    NombreProv = "Elena Gómez",
                    Telefono = 312589764,
                    Email = "ContactP4@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2023, 2, 18),
                    FechaBaja = new DateOnly(2023, 7, 10),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120002")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("12f9d33b-5d79-42b9-b1f2-693d98ef5bf9"),
                    NombreProv = "Ana Martínez",
                    Telefono = 319875634,
                    Email = "ContactP5@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2022, 6, 5),
                    FechaBaja = new DateOnly(2023, 6, 30),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120006")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("ec99599e-cf72-412a-b8c9-9d02fe5f1977"),
                    NombreProv = "Juan Soto",
                    Telefono = 316547896,
                    Email = "ContactP6@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2021, 9, 12),
                    FechaBaja = new DateOnly(2023, 7, 20),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120008")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("8cd4870a-5e20-4bc1-96fe-456c5c6962ed"),
                    NombreProv = "María Salas",
                    Telefono = 318564237,
                    Email = "ContactP7@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2020, 12, 8),
                    FechaBaja = new DateOnly(2023, 6, 5),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120007")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("61093b5b-1e9e-4dbf-b0b1-0b5989183e9a"),
                    NombreProv = "Luis Gutiérrez",
                    Telefono = 313258741,
                    Email = "ContactP8@gmail.com",
                    Estado = 2,
                    FechaAlta = new DateOnly(2021, 3, 25),
                    FechaBaja = new DateOnly(2023, 6, 20),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120009")
                },
                new ContactoProveedor
                {
                    IdContactoProveedor = new Guid("92d541d9-8570-4c72-b92c-6f3e7d918c48"),
                    NombreProv = "Fernando López",
                    Telefono = 317896542,
                    Email = "ContactP9@gmail.com",
                    Estado = 1,
                    FechaAlta = new DateOnly(2022, 4, 17),
                    FechaBaja = new DateOnly(2023, 7, 15),
                    IdProveedor = new Guid("02d69c24-45fe-11ee-be56-0242ac120005")
                }
            );
        }
    }
}
