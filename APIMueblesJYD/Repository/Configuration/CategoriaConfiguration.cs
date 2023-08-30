using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData
                (
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120001"),
                    Nombre = "Muebles",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120002"),
                    Nombre = "Camas",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120003"),
                    Nombre = "Mesas de Noche",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120004"),
                    Nombre = "Comedores",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120005"),
                    Nombre = "Escritorios",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120006"),
                    Nombre = "Sillas",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120007"),
                    Nombre = "Armarios",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new int("ebed2050-45d0-11ee-be56-0242ac120008"),
                    Nombre = "Camarotes",
                    Estado = 1
                }
                );
        }
    }
}
