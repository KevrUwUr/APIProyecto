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
                    IdHistoricoPrecios = 1,
                    PrecioVenta = 42500,
                    FechaPrecioInicial = new DateTime(2023, 8, 28),
                    FechaPrecioFinal = new DateTime(2023, 10, 28),
                    Estado = 1,
                    IdProducto = 1
                },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = 2,
                     PrecioVenta = 60000,
                     FechaPrecioInicial = new DateTime(2023, 9, 1),
                     FechaPrecioFinal = new DateTime(2023, 11, 29),
                     Estado = 1,
                     IdProducto = 2
                 },
                 new HistoricoPrecios
                 {
                     IdHistoricoPrecios = 3,
                     PrecioVenta = 38500,
                     FechaPrecioInicial = new DateTime(2023, 8, 15),
                     FechaPrecioFinal = new DateTime(2023, 9, 15),
                     Estado = 1,
                     IdProducto = 3
                 },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = 4,
                    PrecioVenta = 50000,
                    FechaPrecioInicial = new DateTime(2023, 7, 25),
                    FechaPrecioFinal = new DateTime(2023, 9, 5),
                    Estado = 1,
                    IdProducto = 4
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = 5,
                    PrecioVenta = 70000,
                    FechaPrecioInicial = new DateTime(2023, 6, 10),
                    FechaPrecioFinal = new DateTime(2023, 7, 30),
                    Estado = 1,
                    IdProducto = 5
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = 6,
                    PrecioVenta = 55000,
                    FechaPrecioInicial = new DateTime(2023, 5, 20),
                    FechaPrecioFinal = new DateTime(2023, 6, 20),
                    Estado = 1,
                    IdProducto = 7
                },

                new HistoricoPrecios
                {
                    IdHistoricoPrecios = 7,
                    PrecioVenta = 42000,
                    FechaPrecioInicial = new DateTime(2023, 4, 5),
                    FechaPrecioFinal = new DateTime(2023, 5, 5),
                    Estado = 1,
                    IdProducto = 7
                }
            );
        }
    }
}
