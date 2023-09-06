using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasData
            (
                new Producto
                {
                    ProductoId = new Guid("EDF59C51-6384-422F-B941-CE879C82DCDC"),
                    Nombre = "Cama doble",
                    Precio = 60000,
                    Stock = 3,
                    Descripcion = "Cama doble de madera",
                    Estado = 1,
                    Color = "Blanco",
                    Tipo = 2,
                    IdCategoria = new Guid("0E371E3E-50C3-48C5-A583-DB1016FB209C")
                },
                new Producto
                {
                    ProductoId = new Guid("DD6B62DC-F917-4379-9955-1C244EE78C4B"),
                    Nombre = "Mesa de noche",
                    Precio = 42500,
                    Stock = 5,
                    Descripcion = "Mesa de noche de estilo moderno",
                    Estado = 1,
                    Color = "Negro",
                    Tipo = 2,
                    IdCategoria = new Guid("8A10A022-BCAC-4D4A-9926-A2B4BA8BC993")
                },
                new Producto
                {
                    ProductoId = new Guid("5650A477-C720-4438-8DD4-44BC58E5CDDA"),
                    Nombre = "Comedor extensible",
                    Precio = 800000.0f,
                    Stock = 2,
                    Descripcion = "Comedor de madera con capacidad para 6 personas",
                    Estado = 1,
                    Color = "Marrón",
                    Tipo = 1,
                    IdCategoria = new Guid("C48F9793-637F-4F19-AC65-0CC5ECEBCFD8")
                },
                new Producto
                {
                    ProductoId = new Guid("CE7DC2EA-5931-49A1-8946-9782A5843612"),
                    Nombre = "Silla ergonómica",
                    Precio = 250000.0f,
                    Stock = 8,
                    Descripcion = "Silla cómoda con soporte lumbar",
                    Estado = 1,
                    Color = "Gris",
                    Tipo = 2,
                    IdCategoria = new Guid("2C9308F6-B13F-4714-B8C0-6B24D9B97389")
                },
                new Producto
                {
                    ProductoId = new Guid("3FA14058-D693-4BA9-8B10-F242599F40EA"),
                    Nombre = "Escritorio moderno",
                    Precio = 350000.0f,
                    Stock = 4,
                    Descripcion = "Escritorio de diseño minimalista",
                    Estado = 1,
                    Color = "Blanco",
                    Tipo = 1,
                    IdCategoria = new Guid("3BE4073A-8614-400E-BDCE-2730059D9E76")
                },
                new Producto
                {
                    ProductoId = new Guid("8B538521-A513-4F5A-B4E6-AE3C57912499"),
                    Nombre = "Armario de 4 puertas",
                    Precio = 700000.0f,
                    Stock = 1,
                    Descripcion = "Armario espacioso con compartimentos",
                    Estado = 1,
                    Color = "Café",
                    Tipo = 1,
                    IdCategoria = new Guid("21C0AB55-CAF3-4636-882B-741D1FA2E352")
                },
                new Producto
                {
                    ProductoId = new Guid("30D27E06-251C-4911-819A-59A9A3966F78"),
                    Nombre = "Camarote infantil",
                    Precio = 450000.0f,
                    Stock = 6,
                    Descripcion = "Camarote con temática de caricaturas",
                    Estado = 1,
                    Color = "Azul",
                    Tipo = 2,
                    IdCategoria = new Guid("1EC8DA08-607C-442C-82BD-2671992C080F")
                }
            );
        }
    }
}
