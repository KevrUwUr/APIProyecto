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
                    FacturaVentaId = new Guid("CEDA0177-4B48-4379-8907-B75C4F0AA10F"),
                    NFactura = 1,
                    FechaGeneracion = new DateTime(2023, 8, 28),
                    FechaExpedicion = new DateTime(2023, 8, 28),
                    FechaVencimiento = new DateTime(2023, 9, 15),
                    TotalBruto = 85000,
                    TotalIVA = 16150,
                    TotalRefuete = 12000,
                    TotalPago = 113150,
                    IdUsuario = new Guid("E0AAC839-D3E4-4B5C-9B6E-DBF0303DB2B2")
                },

                new FacturaVenta
                {
                    FacturaVentaId = new Guid("A6CF357E-205E-45F4-BE76-25C8E08AAC16"),
                    NFactura = 2,
                    FechaGeneracion = new DateTime(2023, 7, 15),
                    FechaExpedicion = new DateTime(2023, 7, 15),
                    FechaVencimiento = new DateTime(2023, 7, 30),
                    TotalBruto = 120000,
                    TotalIVA = 22800,
                    TotalRefuete = 15000,
                    TotalPago = 157800,
                    IdUsuario = new Guid("1449F86E-3988-43C6-9210-252136156E7E")
                }
            );
        }
    }
}
