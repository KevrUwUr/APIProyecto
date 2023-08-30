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
                    IdProducto = new int("3e32e739-f4e0-4b3a-8748-118fc4de366b"),
                    Nombre = "Cama doble",
                    Precio = 500000.0f,
                    Stock = 3,
                    Descripcion = "Cama doble de madera",
                    Estado = 1,
                    Color = "Blanco",
                    Tipo = 2,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120002")
                },
                new Producto
                {
                    IdProducto = new int("6fc03e94-7f4b-47cc-9df4-73ecaa6ce244"),
                    Nombre = "Mesa de noche",
                    Precio = 150000.0f,
                    Stock = 5,
                    Descripcion = "Mesa de noche de estilo moderno",
                    Estado = 1,
                    Color = "Negro",
                    Tipo = 2,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120003")
                },
                new Producto
                {
                    IdProducto = new int("3e242bb6-8959-4b53-933b-c9397d11d0d0"),
                    Nombre = "Comedor extensible",
                    Precio = 800000.0f,
                    Stock = 2,
                    Descripcion = "Comedor de madera con capacidad para 6 personas",
                    Estado = 1,
                    Color = "Marrón",
                    Tipo = 1,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120004")
                },
                new Producto
                {
                    IdProducto = new int("7ef6aa54-153a-4d94-af65-139d11f5f0f3"),
                    Nombre = "Silla ergonómica",
                    Precio = 250000.0f,
                    Stock = 8,
                    Descripcion = "Silla cómoda con soporte lumbar",
                    Estado = 1,
                    Color = "Gris",
                    Tipo = 2,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120006")
                },
                new Producto
                {
                    IdProducto = new int("d994f932-cb57-4ff7-8b01-81c12d3ed16b"),
                    Nombre = "Escritorio moderno",
                    Precio = 350000.0f,
                    Stock = 4,
                    Descripcion = "Escritorio de diseño minimalista",
                    Estado = 1,
                    Color = "Blanco",
                    Tipo = 1,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120005")
                },
                new Producto
                {
                    IdProducto = new int("a96c86ce-8916-45c2-a988-ea5e12b8792a"),
                    Nombre = "Armario de 4 puertas",
                    Precio = 700000.0f,
                    Stock = 1,
                    Descripcion = "Armario espacioso con compartimentos",
                    Estado = 1,
                    Color = "Café",
                    Tipo = 1,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120007")
                },
                new Producto
                {
                    IdProducto = new int("9d4d828d-7a48-44a9-b02b-4e1f22abf389"),
                    Nombre = "Camarote infantil",
                    Precio = 450000.0f,
                    Stock = 6,
                    Descripcion = "Camarote con temática de caricaturas",
                    Estado = 1,
                    Color = "Azul",
                    Tipo = 2,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120008")
                },
                new Producto
                {
                    IdProducto = new int("b70f72de-7e2c-45ad-a62a-52df8f67c2d2"),
                    Nombre = "Silla ejecutiva",
                    Precio = 300000.0f,
                    Stock = 10,
                    Descripcion = "Silla de oficina con respaldo alto",
                    Estado = 1,
                    Color = "Negro",
                    Tipo = 1,
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120006")
                }
            );
        }
    }
}
