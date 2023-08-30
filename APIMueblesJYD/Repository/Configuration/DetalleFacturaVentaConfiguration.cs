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
                    DetalleFacturaVentaID = 1,
                    ValorUnitario = 42500,
                    Cantidad = 2,
                    IVA = 8075,
                    ValorDescuento = 0,
                    IdFacturaVenta = 1,
                    IdProducto = 1
                },
                new DetalleFacturaVenta
                {
                    DetalleFacturaVentaID = 2,
                    ValorUnitario = 60000,
                    Cantidad = 2,
                    IVA = 1534,
                    ValorDescuento = 0,
                    IdFacturaVenta = 2,
                    IdProducto = 2
                }
            );
        }
    }
}
