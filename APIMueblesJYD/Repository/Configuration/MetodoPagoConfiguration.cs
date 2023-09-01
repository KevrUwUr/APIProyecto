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
                    IdMetodoPago = 1,
                    IdFacturaVenta = 1,
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma=("Nequi")
                },
                new MetodoPago
                {
                    IdMetodoPago = 2,
                    IdFacturaVenta = 2,
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma = ("Daviplata")
                }
                );
        }
    }
}
