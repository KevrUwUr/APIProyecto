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
                    IdMetodoPago = new int("41e399b6-45d2-11ee-be56-0242ac120001"),
                    IdFacturaVenta = new int("c5f7d82a-b380-49df-9c2a-61ef92acabc1"),
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma=("Nequi")
                },
                new MetodoPago
                {
                    IdMetodoPago = new int("41e399b6-45d2-11ee-be56-0242ac120002"),
                    IdFacturaVenta = new int("d7e0f4c9-5b0c-4ccf-8ae0-b7220e5c693e"),
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma = ("Daviplata")
                },
                new MetodoPago
                {
                    IdMetodoPago = new int("41e399b6-45d2-11ee-be56-0242ac120003"),
                    IdFacturaVenta = new int("f6733487-0563-461d-b6f0-78b9de803063"),
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 2,
                    NombrePlataforma = ("Nequi")
                },
                new MetodoPago
                {
                    IdMetodoPago = new int("41e399b6-45d2-11ee-be56-0242ac120004"),
                    IdFacturaVenta = new int("f6733487-0563-461d-b6f0-78b9de803064"),
                    FechaTransaccion = new DateTime(2023, 06, 21),
                    Tipo = 1,
                    NombrePlataforma = ("Bancolombia")
                }
                );
        }
    }
}
