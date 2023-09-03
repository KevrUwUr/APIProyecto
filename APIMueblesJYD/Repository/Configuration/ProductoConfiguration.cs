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
                    IdProducto = 1,
                    Nombre = "Cama doble",
                    Precio = 500000.0f,
                    Stock = 3,
                    Descripcion = "Cama doble de madera",
                    Estado = 1,
                    Color = "Blanco",
                    Tipo = 2,
                    IdCategoria = 1
                },
                new Producto
                {
                    IdProducto = 2,
                    Nombre = "Mesa de noche",
                    Precio = 150000.0f,
                    Stock = 5,
                    Descripcion = "Mesa de noche de estilo moderno",
                    Estado = 1,
                    Color = "Negro",
                    Tipo = 2,
                    IdCategoria = 2
                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "Comedor extensible",
                    Precio = 800000.0f,
                    Stock = 2,
                    Descripcion = "Comedor de madera con capacidad para 6 personas",
                    Estado = 1,
                    Color = "Marrón",
                    Tipo = 1,
                    IdCategoria = 3
                },
                new Producto
                {
                    IdProducto = 4,
                    Nombre = "Silla ergonómica",
                    Precio = 250000.0f,
                    Stock = 8,
                    Descripcion = "Silla cómoda con soporte lumbar",
                    Estado = 1,
                    Color = "Gris",
                    Tipo = 2,
                    IdCategoria = 4
                },
                new Producto
                {
                    IdProducto = 5,
                    Nombre = "Escritorio moderno",
                    Precio = 350000.0f,
                    Stock = 4,
                    Descripcion = "Escritorio de diseño minimalista",
                    Estado = 1,
                    Color = "Blanco",
                    Tipo = 1,
                    IdCategoria = 5
                },
                new Producto
                {
                    IdProducto = 6,
                    Nombre = "Armario de 4 puertas",
                    Precio = 700000.0f,
                    Stock = 1,
                    Descripcion = "Armario espacioso con compartimentos",
                    Estado = 1,
                    Color = "Café",
                    Tipo = 1,
                    IdCategoria = 6
                },
                new Producto
                {
                    IdProducto = 7,
                    Nombre = "Camarote infantil",
                    Precio = 450000.0f,
                    Stock = 6,
                    Descripcion = "Camarote con temática de caricaturas",
                    Estado = 1,
                    Color = "Azul",
                    Tipo = 2,
                    IdCategoria = 7
                }
            );
        }
    }
}
