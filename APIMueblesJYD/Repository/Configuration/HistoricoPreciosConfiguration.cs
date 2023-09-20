using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class HistoricoPreciosConfiguration : IEntityTypeConfiguration<HistoricoPrecios>
    {
        public void Configure(EntityTypeBuilder<HistoricoPrecios> builder)
        {
            builder.HasData
            (
                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("2CDC7499-0D1E-4413-9565-9D337D612B45"),
                    PrecioVenta = 42500,
                    FechaPrecioInicial = new DateTime(2023, 8, 28),
                    FechaPrecioFinal = new DateTime(2023, 10, 28),
                    Estado = 1,
                    ProductoId = new Guid("EDF59C51-6384-422F-B941-CE879C82DCDC")
                },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = new Guid("74604BCD-34F7-4BBC-90DA-CD955C2A5117"),
                     PrecioVenta = 60000,
                     FechaPrecioInicial = new DateTime(2023, 9, 1),
                     FechaPrecioFinal = new DateTime(2023, 11, 29),
                     Estado = 1,
                     ProductoId = new Guid("DD6B62DC-F917-4379-9955-1C244EE78C4B")
                 },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = new Guid("0DB01178-1EE0-4B73-9E6C-FB51972517EC"),
                     PrecioVenta = 38500,
                     FechaPrecioInicial = new DateTime(2023, 8, 15),
                     FechaPrecioFinal = new DateTime(2023, 9, 15),
                     Estado = 1,
                     ProductoId = new Guid("5650A477-C720-4438-8DD4-44BC58E5CDDA")
                 },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("5D3D5DC3-FBE5-43EA-875B-3447E32C9E52"),
                    PrecioVenta = 50000,
                    FechaPrecioInicial = new DateTime(2023, 7, 25),
                    FechaPrecioFinal = new DateTime(2023, 9, 5),
                    Estado = 1,
                    ProductoId = new Guid("CE7DC2EA-5931-49A1-8946-9782A5843612")
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("6549AC0E-D34B-43B3-9FED-9847A2B17149"),
                    PrecioVenta = 70000,
                    FechaPrecioInicial = new DateTime(2023, 6, 10),
                    FechaPrecioFinal = new DateTime(2023, 7, 30),
                    Estado = 1,
                    ProductoId = new Guid("3FA14058-D693-4BA9-8B10-F242599F40EA")
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("1C230E78-C12C-4BD8-A4B1-CA7FBC2D0549"),
                    PrecioVenta = 55000,
                    FechaPrecioInicial = new DateTime(2023, 5, 20),
                    FechaPrecioFinal = new DateTime(2023, 6, 20),
                    Estado = 1,
                    ProductoId = new Guid("8B538521-A513-4F5A-B4E6-AE3C57912499")
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("A8CB8414-2308-4F71-A09A-6976DD23F396"),
                    PrecioVenta = 42000,
                    FechaPrecioInicial = new DateTime(2023, 4, 5),
                    FechaPrecioFinal = new DateTime(2023, 5, 5),
                    Estado = 1,
                    ProductoId = new Guid("30D27E06-251C-4911-819A-59A9A3966F78")
                }
            );
        }
    }
}
