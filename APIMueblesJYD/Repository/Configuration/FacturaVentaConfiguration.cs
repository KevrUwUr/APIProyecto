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
                    IdFacturaVenta = new Guid("c5f7d82a-b380-49df-9c2a-61ef92acabc1"),
                    FechaGeneracion = new DateOnly(2023, 8, 28),
                    FechaExpedicion = new DateOnly(2023, 8, 28),
                    FechaVencimiento = new DateOnly(2023, 9, 15),
                    TotalBruto = 85000,
                    TotalIVA = 16150,
                    TotalRefuete = 12000,
                    TotalPago = 113150
                },

                new FacturaVenta
                {
                    IdFacturaVenta = new Guid("d7e0f4c9-5b0c-4ccf-8ae0-b7220e5c693e"),
                    FechaGeneracion = new DateOnly(2023, 7, 15),
                    FechaExpedicion = new DateOnly(2023, 7, 15),
                    FechaVencimiento = new DateOnly(2023, 7, 30),
                    TotalBruto = 120000,
                    TotalIVA = 22800,
                    TotalRefuete = 15000,
                    TotalPago = 157800
                }
            );
        }
    }
}
