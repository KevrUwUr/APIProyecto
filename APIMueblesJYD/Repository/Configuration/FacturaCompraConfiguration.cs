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
                    FacturaCompraId = new Guid("5C5B2ABF-5DE1-49CB-98B8-6C13FDDC7A6E"),
                    NFactura = 1,
                    FechaGeneracion = new DateTime(1995, 5, 15),
                    FechaExpedicion = new DateTime(1995, 5, 15),
                    FechaVencimiento = new DateTime(1995, 5, 15),
                    TotalBruto = 100000,
                    TotalIVA = 19000,
                    TotalRefuete = 20000,
                    TotalPago = 139000,
                    IdProveedor = new Guid("9ABC8D3B-3BD1-49C3-84E2-35C59447B0F3")
                },
                new FacturaCompra
                {
                    FacturaCompraId = new Guid("6E922BA7-F823-4A3B-81EF-65A55A981C60"),
                    NFactura = 2,
                    FechaGeneracion = new DateTime(2000, 10, 03),
                    FechaExpedicion = new DateTime(2000, 10, 03),
                    FechaVencimiento = new DateTime(2000, 10, 17),
                    TotalBruto = 150000,
                    TotalIVA = 2850, 
                    TotalRefuete = 30000,
                    TotalPago = 182850,
                    IdProveedor = new Guid("6E6D4C81-9958-44FF-BF39-838A4940C822")
                }

            );
        }
    }
}
