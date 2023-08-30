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
    public class DetalleFacturaVentaConfiguration : IEntityTypeConfiguration<DetalleFacturaVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleFacturaVenta> builder)
        {
            builder.HasData
            (
                new DetalleFacturaVenta
                {
                    DetalleFacturaVentaID = new int("c5f7d82a-b380-49df-9c2a-61ef92acabc1"),
                    ValorUnitario = 42500,
                    Cantidad = 2,
                    IVA = 8075,
                    ValorDescuento = 0
                },
                new DetalleFacturaVenta
                {
                    DetalleFacturaVentaID = new int("d7e0f4c9-5b0c-4ccf-8ae0-b7220e5c693e"),
                    ValorUnitario = 60000,
                    Cantidad = 2,
                    IVA = 1534,
                    ValorDescuento = 0
                }
            );
        }
    }
}
