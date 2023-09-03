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
                    IdCategoria = 1,
                    Nombre = "Muebles",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 2,
                    Nombre = "Camas",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 3,
                    Nombre = "Mesas de Noche",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 4,
                    Nombre = "Comedores",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 5,
                    Nombre = "Escritorios",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 6,
                    Nombre = "Sillas",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 7,
                    Nombre = "Armarios",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = 8,
                    Nombre = "Camarotes",
                    Estado = 1
                }
                );
        }
    }
}
