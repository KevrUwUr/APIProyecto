﻿using Entities.Models;
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
                IdCargo = 1,
                NombreCargo = "Carpintero",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = 2,
                NombreCargo = "Diseñador de Muebles",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = 3,
                NombreCargo = "Vendedor de Muebles",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = 4,
                NombreCargo = "Técnico de Acabados",
                Estado = 1,
            },
            new Cargo
            {
                IdCargo = 5,
                NombreCargo = "Asistente de carpinteria",
                Estado = 1
            }
            );
        }
    }
}
