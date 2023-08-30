using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasData
            (
            new Cargo
            {
                IdCargo = new int("81ef2c34-7eb7-4891-8e5b-172e5786e687"),
                NombreCargo = "Carpintero",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = new int("ef3f0aae-804f-4e7c-9633-212a439d0960"),
                NombreCargo = "Diseñador de Muebles",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = new int("2954f19b-36e5-4a69-996b-dc3911df74b2"),
                NombreCargo = "Vendedor de Muebles",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = new int("8d8330ee-16ed-41ba-89d3-599651cddb34"),
                NombreCargo = "Técnico de Acabados",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = new int("2d2df54e-e3ff-45e3-915d-ac2f53d371f2"),
                NombreCargo = "Asistente de carpinteria",
                Estado = 1
            }
            );
        }
    }
}
