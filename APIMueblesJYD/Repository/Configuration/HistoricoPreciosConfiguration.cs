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
                    IdHistoricoPrecios = new int("98765432-10fe-dcba-hgji-klmnopqrstuv"),
                    PrecioVenta = 42500,
                    FechaPrecioInicial = new DateTime(2023, 8, 28),
                    FechaPrecioFinal = new DateTime(2023, 10, 28),
                    Estado = 1
                },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = new int("efghijkl-mnop-qrst-uvwxyz012345-6789abcd"),
                     PrecioVenta = 60000,
                     FechaPrecioInicial = new DateTime(2023, 9, 1),
                     FechaPrecioFinal = new DateTime(2023, 11, 29),
                     Estado = 1
                 },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = new int("d7e0f4c9-5b0c-4ccf-8ae0-b7220e5c693e"),
                     PrecioVenta = 38500,
                     FechaPrecioInicial = new DateTime(2023, 8, 15),
                     FechaPrecioFinal = new DateTime(2023, 9, 15),
                     Estado = 1
                 },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new int("e9a5d2b8-cc54-4a4f-8d57-8e7ff34816b7"),
                    PrecioVenta = 50000,
                    FechaPrecioInicial = new DateTime(2023, 7, 25),
                    FechaPrecioFinal = new DateTime(2023, 9, 5),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new int("fba3de98-8e9c-4f94-a25f-21b794334b19"),
                    PrecioVenta = 70000,
                    FechaPrecioInicial = new DateTime(2023, 6, 10),
                    FechaPrecioFinal = new DateTime(2023, 7, 30),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new int("abcd1234-5678-efgh-ijkl-mnopqrstuvwx"),
                    PrecioVenta = 55000,
                    FechaPrecioInicial = new DateTime(2023, 5, 20),
                    FechaPrecioFinal = new DateTime(2023, 6, 20),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new int("12345678-90ab-cdef-ghij-klmnopqrstuv"),
                    PrecioVenta = 42000,
                    FechaPrecioInicial = new DateTime(2023, 4, 5),
                    FechaPrecioFinal = new DateTime(2023, 5, 5),
                    Estado = 1
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = new int("uvwxyz01-2345-6789-abcd-efghijklmnop"),
                    PrecioVenta = 59000,
                    FechaPrecioInicial = new DateTime(2023, 3, 15),
                    FechaPrecioFinal = new DateTime(2023, 4, 15),
                    Estado = 1
                }
            );
        }
    }
}
