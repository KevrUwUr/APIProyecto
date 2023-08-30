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
                IdDetalleacturaCompra = new int("93cf50f8-d098-4d3e-8412-edc49a219e7e"),
                ValorUnitario = 250000,
                Cantidad = 2,
                IVA = 0.30f,
                ValorDescuento = 0.05f,
                IdFacturaCompra = new int("a1a26fe5-39b3-4e71-bc0a-725e7c5b8a99"),
                IdProducto = new int("3e32e739-f4e0-4b3a-8748-118fc4de366b"),
            },
            new DetalleFacturaCompra
            {
                IdDetalleacturaCompra = new int("d3e5c3c8-66c7-4e3d-b606-ab3a33626904"),
                ValorUnitario = 500000,
                Cantidad = 4,
                IVA = 0.30f,
                ValorDescuento = 0.05f,
                IdFacturaCompra = new int("b3d8ca9e-968f-4c5a-9b9e-8247123df605"),
                IdProducto = new int("578a8bad-c734-4d31-bba7-8099af8ed974"),
            }
            );
        }
    }
}
