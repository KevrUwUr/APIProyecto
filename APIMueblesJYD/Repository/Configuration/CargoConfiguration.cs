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
                IdCargo = new Guid("81ef2c34-7eb7-4891-8e5b-172e5786e687"),
                NombreCargo = "Carpintero",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = new Guid("2d2df54e-e3ff-45e3-915d-ac2f53d371f2"),
                NombreCargo = "Asistente de carpinteria",
                Estado = 1
            }
            );
        }
    }
}
