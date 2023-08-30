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
    public class FacturaCompraConfiguration : IEntityTypeConfiguration<FacturaCompra>
    {
        public void Configure(EntityTypeBuilder<FacturaCompra> builder)
        {
            builder.HasData
            (
                new FacturaCompra
                {
                    IdFacturaCompra = new Guid("a1a26fe5-39b3-4e71-bc0a-725e7c5b8a99"),
                    FechaGeneracion = new DateOnly(1995, 5, 15),
                    FechaExpedicion = new DateOnly(1995, 5, 15),
                    FechaVencimiento = new DateOnly(1995, 5, 15),
                    TotalBruto = 100000,
                    TotalIVA = 19000,
                    TotalRefuete = 20000,
                    TotalPago = 139000
                },
                new FacturaCompra
                {
                    IdFacturaCompra = new Guid("b3d8ca9e-968f-4c5a-9b9e-8247123df605"),
                    FechaGeneracion = new DateOnly(2000, 10, 03),
                    FechaExpedicion = new DateOnly(2000, 10, 03),
                    FechaVencimiento = new DateOnly(2000, 10, 17),
                    TotalBruto = 150000,
                    TotalIVA = 2850, 
                    TotalRefuete = 30000,
                    TotalPago = 182850 
                }

            );
        }
    }
}
