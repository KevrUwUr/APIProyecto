using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class HistoricoPreciosConfiguration
    {
        public void Configure(EntityTypeBuilder<HistoricoPrecios> builder)
        {
            builder.HasData
            (
                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("98765432-10fe-dcba-hgji-klmnopqrstuv"),
                    PresioVenta = 42500,
                    FechaPrecioInicial = new DateOnly(2023, 8, 28),
                    FechaPrecioFinal = new DateOnly(2023, 10, 28),
                    Estado = 1
                },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = new Guid("efghijkl-mnop-qrst-uvwxyz012345-6789abcd"),
                     PresioVenta = 60000,
                     FechaPrecioInicial = new DateOnly(2023, 9, 1),
                     FechaPrecioFinal = new DateOnly(2023, 11, 29),
                     Estado = 1
                 },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = new Guid("d7e0f4c9-5b0c-4ccf-8ae0-b7220e5c693e"),
                     PresioVenta = 38500,
                     FechaPrecioInicial = new DateOnly(2023, 8, 15),
                     FechaPrecioFinal = new DateOnly(2023, 9, 15),
                     Estado = 1
                 },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("e9a5d2b8-cc54-4a4f-8d57-8e7ff34816b7"),
                    PresioVenta = 50000,
                    FechaPrecioInicial = new DateOnly(2023, 7, 25),
                    FechaPrecioFinal = new DateOnly(2023, 9, 5),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("fba3de98-8e9c-4f94-a25f-21b794334b19"),
                    PresioVenta = 70000,
                    FechaPrecioInicial = new DateOnly(2023, 6, 10),
                    FechaPrecioFinal = new DateOnly(2023, 7, 30),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("abcd1234-5678-efgh-ijkl-mnopqrstuvwx"),
                    PresioVenta = 55000,
                    FechaPrecioInicial = new DateOnly(2023, 5, 20),
                    FechaPrecioFinal = new DateOnly(2023, 6, 20),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("12345678-90ab-cdef-ghij-klmnopqrstuv"),
                    PresioVenta = 42000,
                    FechaPrecioInicial = new DateOnly(2023, 4, 5),
                    FechaPrecioFinal = new DateOnly(2023, 5, 5),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new Guid("uvwxyz01-2345-6789-abcd-efghijklmnop"),
                    PresioVenta = 59000,
                    FechaPrecioInicial = new DateOnly(2023, 3, 15),
                    FechaPrecioFinal = new DateOnly(2023, 4, 15),
                    Estado = 1
                }
            );
        }
    }
}
