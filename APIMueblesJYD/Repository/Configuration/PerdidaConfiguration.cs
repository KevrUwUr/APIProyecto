﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PerdidaConfiguration : IEntityTypeConfiguration<Perdida>
    {
        public void Configure(EntityTypeBuilder<Perdida> builder)
        {
            builder.HasData
                (
                new Perdida
                {
                    IdPerdida = 1,
                    IdEmpleado = 1,
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 1,
                    Total=300000
                },
                new Perdida
                {
                    IdPerdida = 2,
                    IdEmpleado = 2,
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 2,
                    Total = 200000
                },
                new Perdida
                {
                    IdPerdida = 3,
                    IdEmpleado = 3,
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 2,
                    Total = 350000
                },
                new Perdida
                {
                    IdPerdida = 4,
                    IdEmpleado = 4,
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 1,
                    Total = 500000
                },
                new Perdida
                {
                    IdPerdida = 5,
                    IdEmpleado = 5,
                    FechaPerdida = new DateTime(2023, 06, 21),
                    Estado = 1,
                    Total = 100000
                }
                );
        }
    }
}