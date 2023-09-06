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
                    IdCategoria = new Guid("DD412B15-5220-43CD-90A8-228827CD4988"),
                    Nombre = "Muebles",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("0E371E3E-50C3-48C5-A583-DB1016FB209C"),
                    Nombre = "Camas",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("8A10A022-BCAC-4D4A-9926-A2B4BA8BC993"),
                    Nombre = "Mesas de Noche",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("C48F9793-637F-4F19-AC65-0CC5ECEBCFD8"),
                    Nombre = "Comedores",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("3BE4073A-8614-400E-BDCE-2730059D9E76"),
                    Nombre = "Escritorios",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("2C9308F6-B13F-4714-B8C0-6B24D9B97389"),
                    Nombre = "Sillas",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("21C0AB55-CAF3-4636-882B-741D1FA2E352"),
                    Nombre = "Armarios",
                    Estado = 1
                },
                new Categoria
                {
                    IdCategoria = new Guid("1EC8DA08-607C-442C-82BD-2671992C080F"),
                    Nombre = "Camarotes",
                    Estado = 1
                }
                );
        }
    }
}
