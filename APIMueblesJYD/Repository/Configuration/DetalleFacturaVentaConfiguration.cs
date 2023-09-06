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
                    DetalleFacturaVentaID = new Guid("636E9434-F3AA-44D1-9EF0-8470D72A5BEE"),
                    ValorUnitario = 42500,
                    Cantidad = 2,
                    IVA = 8075,
                    ValorDescuento = 0,
                    FacturaVentaId = new Guid("CEDA0177-4B48-4379-8907-B75C4F0AA10F"),
                    ProductoId = new Guid("DD6B62DC-F917-4379-9955-1C244EE78C4B")
                },
                new DetalleFacturaVenta
                {
                    DetalleFacturaVentaID = new Guid("21980B54-0DD3-46B0-B77A-29EB80CAA3C8"),
                    ValorUnitario = 60000,
                    Cantidad = 2,
                    IVA = 1534,
                    ValorDescuento = 0,
                    FacturaVentaId = new Guid("A6CF357E-205E-45F4-BE76-25C8E08AAC16"),
                    ProductoId = new Guid("EDF59C51-6384-422F-B941-CE879C82DCDC")
                }
            );
        }
    }
}
