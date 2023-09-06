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
                DetalleacturaCompraId = new Guid("AB7DCDDF-F549-4AE2-9C0D-E2237B831F76"),
                ValorUnitario = 250000,
                Cantidad = 2,
                IVA = 0.30f,
                ValorDescuento = 0.05f,
                FacturaCompraId = new Guid("5C5B2ABF-5DE1-49CB-98B8-6C13FDDC7A6E"),
                ProductoId = new Guid("CE7DC2EA-5931-49A1-8946-9782A5843612"),
            },
            new DetalleFacturaCompra
            {
                DetalleacturaCompraId = new Guid("5AEC0ACF-8B05-40BB-A874-C244487B56AF"),
                ValorUnitario = 500000,
                Cantidad = 4,
                IVA = 0.30f,
                ValorDescuento = 0.05f,
                FacturaCompraId = new Guid("6E922BA7-F823-4A3B-81EF-65A55A981C60"),
                ProductoId = new Guid("30D27E06-251C-4911-819A-59A9A3966F78"),
            }
            );
        }
    }
}
