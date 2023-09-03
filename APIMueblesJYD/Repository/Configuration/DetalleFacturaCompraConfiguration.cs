using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class DetalleFacturaCompraConfiguration : IEntityTypeConfiguration<DetalleFacturaCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleFacturaCompra> builder)
        {
            builder.HasData
            (
            new DetalleFacturaCompra
            {
                IdDetalleacturaCompra = 1,
                ValorUnitario = 250000,
                Cantidad = 2,
                IVA = 0.30f,
                ValorDescuento = 0.05f,
                IdFacturaCompra = 1,
                IdProducto = 1,
            },
            new DetalleFacturaCompra
            {
                IdDetalleacturaCompra = 2,
                ValorUnitario = 500000,
                Cantidad = 4,
                IVA = 0.30f,
                ValorDescuento = 0.05f,
                IdFacturaCompra = 2,
                IdProducto = 2,
            }
            );
        }
    }
}
