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
    public class EmpleadoCargoConfiguration : IEntityTypeConfiguration<EmpleadoCargo>
    {
        public void Configure(EntityTypeBuilder<EmpleadoCargo> builder)
        {
            builder.HasData
            (
            new EmpleadoCargo
            {
                FechaInicio = new DateTime(1995, 5, 15),
                FechaFin = new DateTime(2015, 5, 15),
                NumeroContrato = 1,
                CargoId = 1,
                EmpleadoId = 1
            },
            new EmpleadoCargo
            {
                FechaInicio = new DateTime(2000, 10, 03),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 2,
                CargoId = 2,
                EmpleadoId = 2
            },

            new EmpleadoCargo
            {
                FechaInicio = new DateTime(2005, 3, 20),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 3,
                CargoId = 3,
                EmpleadoId = 3
            },

            new EmpleadoCargo
            {
                FechaInicio = new DateTime(2012, 8, 10),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 4,
                CargoId = 4,
                EmpleadoId = 4
            },

            new EmpleadoCargo
            {
                FechaInicio = new DateTime(2010, 6, 15),
                FechaFin = new DateTime(2018, 9, 30),
                NumeroContrato = 5,
                CargoId = 5,
                EmpleadoId = 5
            });

        }
    }
}
