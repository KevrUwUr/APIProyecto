using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class MetodoPagoConfiguration : IEntityTypeConfiguration<MetodoPago>
    {
        public void Configure(EntityTypeBuilder<MetodoPago> builder)
        {
            builder.HasData
                (
                new MetodoPago
                {
                    IdMetodoPago = new Guid("5EF90D94-CA4A-49FE-BA78-E42E1C527606"),
                    FacturaVentaId = new Guid("CEDA0177-4B48-4379-8907-B75C4F0AA10F"),
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma=("Nequi")
                },
                new MetodoPago
                {
                    IdMetodoPago = new Guid("37292A3A-0A69-41A5-A038-1795FA541CF9"),
                    FacturaVentaId = new Guid("A6CF357E-205E-45F4-BE76-25C8E08AAC16"),
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma = ("Daviplata")
                }
                );
        }
    }
}
