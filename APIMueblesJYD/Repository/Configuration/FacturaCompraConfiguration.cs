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
                    IdFacturaCompra = 1,
                    NFactura = 1,
                    FechaGeneracion = new DateTime(1995, 5, 15),
                    FechaExpedicion = new DateTime(1995, 5, 15),
                    FechaVencimiento = new DateTime(1995, 5, 15),
                    TotalBruto = 100000,
                    TotalIVA = 19000,
                    TotalRefuete = 20000,
                    TotalPago = 139000,
                    IdProveedor = 1
                },
                new FacturaCompra
                {
                    IdFacturaCompra = 2,
                    NFactura = 2,
                    FechaGeneracion = new DateTime(2000, 10, 03),
                    FechaExpedicion = new DateTime(2000, 10, 03),
                    FechaVencimiento = new DateTime(2000, 10, 17),
                    TotalBruto = 150000,
                    TotalIVA = 2850, 
                    TotalRefuete = 30000,
                    TotalPago = 182850,
                    IdProveedor = 2
                }

            );
        }
    }
}
