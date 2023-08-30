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
    public class FacturaVentaConfiguration : IEntityTypeConfiguration<FacturaVenta>
    {
        public void Configure(EntityTypeBuilder<FacturaVenta> builder)
        {
            builder.HasData
            (
                new FacturaVenta
                {
                    IdFacturaVenta = 1,
                    NFactura = 1,
                    FechaGeneracion = new DateTime(2023, 8, 28),
                    FechaExpedicion = new DateTime(2023, 8, 28),
                    FechaVencimiento = new DateTime(2023, 9, 15),
                    TotalBruto = 85000,
                    TotalIVA = 16150,
                    TotalRefuete = 12000,
                    TotalPago = 113150,
                    IdUsuario = 1
                },

                new FacturaVenta
                {
                    IdFacturaVenta = 2,
                    NFactura = 2,
                    FechaGeneracion = new DateTime(2023, 7, 15),
                    FechaExpedicion = new DateTime(2023, 7, 15),
                    FechaVencimiento = new DateTime(2023, 7, 30),
                    TotalBruto = 120000,
                    TotalIVA = 22800,
                    TotalRefuete = 15000,
                    TotalPago = 157800,
                    IdUsuario = 2
                }
            );
        }
    }
}
