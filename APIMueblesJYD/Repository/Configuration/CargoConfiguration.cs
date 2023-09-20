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
                CargoId = new Guid("5E74A02D-A99F-40E3-8C4C-A4C58A78AD04"),
                NombreCargo = "Carpintero",
                Estado = 1,
            },
            new Cargo
            {
                CargoId = new Guid("24254AC3-4379-41BA-AB1D-D4C31FFC4855"),
                NombreCargo = "Diseñador de Muebles",
                Estado = 1,
            },
            new Cargo
            {
                CargoId = new Guid("1CB1DE39-40FE-472B-BDB7-D37DB36387FB"),
                NombreCargo = "Vendedor de Muebles",
                Estado = 1,
            },
            new Cargo
            {
                CargoId = new Guid("201B4CC5-5647-44B8-8664-08F49C8EBCF6"),
                NombreCargo = "Técnico de Acabados",
                Estado = 1,
            },
            new Cargo
            {
                CargoId = new Guid("8D9B73EC-049B-483A-8D48-36E29C25021E"),
                NombreCargo = "Asistente de carpinteria",
                Estado = 1
            }
            );
        }
    }
}
